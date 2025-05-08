package com.example.plustrack_android

import android.Manifest
import android.content.Intent
import android.content.pm.PackageManager
import android.net.Uri
import android.os.Bundle
import android.util.Log
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.TextView
import android.widget.Toast
import androidx.core.app.ActivityCompat
import androidx.fragment.app.Fragment
import com.google.android.gms.location.FusedLocationProviderClient
import com.google.android.gms.location.LocationServices
import com.google.android.gms.maps.GoogleMap
import com.google.android.gms.maps.OnMapReadyCallback
import com.google.android.gms.maps.SupportMapFragment
import com.google.gson.GsonBuilder
import kotlinx.coroutines.CoroutineScope
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.launch
import kotlinx.coroutines.withContext
import retrofit2.Retrofit
import retrofit2.converter.gson.GsonConverterFactory
import androidx.fragment.app.activityViewModels
import androidx.lifecycle.lifecycleScope
import com.google.android.gms.maps.CameraUpdateFactory
import com.google.android.gms.maps.model.LatLng
import com.google.android.gms.maps.model.LatLngBounds
import com.google.android.gms.maps.model.Marker
import com.google.android.gms.maps.model.MarkerOptions
import com.google.android.gms.maps.model.Polyline
import com.google.android.gms.maps.model.PolylineOptions
import kotlinx.coroutines.delay
import kotlinx.coroutines.isActive
import kotlin.coroutines.resume
import kotlin.coroutines.suspendCoroutine

class TruckMapFragment : Fragment(R.layout.truck_map_fragment), OnMapReadyCallback {
    private val sharedViewModel: SharedViewModel by activityViewModels()
    private lateinit var paquetApi: PaquetApi;
    private lateinit var paquetApiGetRuta: PaquetApi;
    private lateinit var fusedLocationClient: FusedLocationProviderClient
    private lateinit var mMap: GoogleMap
    private val LOCATION_PERMISSION_REQUEST_CODE = 1001
    private var polyline: Polyline? = null
    private var coordenadesDestiAux: LatLng? = null
    private var currentMarker: Marker? = null

    override fun onCreate(savedInstanceState: Bundle?) {
        val gson = GsonBuilder().setLenient().create()
        val retrofitServer = Retrofit.Builder()
            .baseUrl("http://172.16.24.23:8085/")
            .addConverterFactory(GsonConverterFactory.create(gson))
            .build()
        paquetApi = retrofitServer.create(PaquetApi::class.java)

        val retrofitOpenRoute = Retrofit.Builder()
            .baseUrl("http://172.16.24.23:8080/")
            .addConverterFactory(GsonConverterFactory.create(gson))
            .build()
        paquetApiGetRuta = retrofitOpenRoute.create(PaquetApi::class.java)

        super.onCreate(savedInstanceState)
    }

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?, savedInstanceState: Bundle?
    ): View? {
        return inflater.inflate(R.layout.truck_map_fragment, container, false)
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)

        val btnDetall: TextView = view.findViewById(R.id.btnDetall)
        val btnGoogleMaps: TextView = view.findViewById(R.id.btnGoogleMaps)
        val seguent_paquet: TextView = view.findViewById(R.id.seguent_paquet)
        val llista_paquets: TextView = view.findViewById(R.id.llista_paquets)

        fusedLocationClient = LocationServices.getFusedLocationProviderClient(requireContext())

        val mapFragment = childFragmentManager.findFragmentById(R.id.map1) as SupportMapFragment
        mapFragment.getMapAsync(this)

        //paquetApi.postCurrentUbication, paquetApi.getPackageToDeliver, paquetApiGetRuta.getRuta, paquetApi.getTotalPackagesToDeliver
        viewLifecycleOwner.lifecycleScope.launch {
            while (isActive) {
                val coordenadesOrigenAux = getCurrentUbiSuspend()
                coordenadesOrigenAux?.let {
                    currentMarker?.remove()
                    currentMarker = mMap.addMarker(MarkerOptions().position(it).title("Mi ubicación actual"))

                    try {
                        val deliverer = sharedViewModel.deliverer.value!!

                        val newLocation = Location(
                            id = null,
                            latitude = it.latitude,
                            longitude = it.longitude
                        )

                        withContext(Dispatchers.IO) {
                            paquetApi.postCurrentUbication(deliverer.Id.toString(), newLocation)
                        }

                        val nextPackage = withContext(Dispatchers.IO) {
                            paquetApi.getPackageToDeliver(deliverer.Id)
                        }

                        if (nextPackage.isSuccessful) {
                            val packageInfo = nextPackage.body()
                            val destLatLng = LatLng(
                                packageInfo!!.Location!!.latitude,
                                packageInfo.Location!!.longitude
                            )
                            this@TruckMapFragment.coordenadesDestiAux = destLatLng

                            withContext(Dispatchers.Main) {
                                seguent_paquet.text = packageInfo.Id
                                mMap.addMarker(MarkerOptions().position(destLatLng).title("Ubicació següent paquet"))

                                val bounds = LatLngBounds.builder()
                                    .include(it)
                                    .include(destLatLng)
                                    .build()

                                mMap.animateCamera(CameraUpdateFactory.newLatLngBounds(bounds, 200))
                            }

                            val rutaResponse = withContext(Dispatchers.IO) {
                                paquetApiGetRuta.getRuta(
                                    start = "${it.longitude},${it.latitude}",
                                    end = "${destLatLng.longitude},${destLatLng.latitude}"
                                )
                            }

                            if (rutaResponse.isSuccessful) {
                                rutaResponse.body()?.let { ruta ->
                                    val coordenades = ruta.features[0].geometry.coordinates
                                    withContext(Dispatchers.Main) {
                                        drawRoute(mMap, coordenades)
                                    }
                                }
                            }
                        }

                        val intTotal = withContext(Dispatchers.IO) {
                            paquetApi.getTotalPackagesToDeliver(deliverer.Id)
                        }

                        if (intTotal.isSuccessful) {
                            withContext(Dispatchers.Main) {
                                llista_paquets.text = intTotal.body().toString()
                                if (intTotal.body() == 0) {
                                    seguent_paquet.text = "Ja no hi han paquets!"
                                }
                            }
                        }
                    } catch (e: Exception) {
                        Log.e("TruckMapFragment", "Error: ${e.message}", e)
                        withContext(Dispatchers.Main) {
                            Toast.makeText(requireContext(), "Error de connexio", Toast.LENGTH_SHORT).show()
                        }
                    }
                }
                delay(5_000L)
            }
        }


        if (ActivityCompat.checkSelfPermission(requireContext(), Manifest.permission.ACCESS_FINE_LOCATION) != PackageManager.PERMISSION_GRANTED
            && ActivityCompat.checkSelfPermission(requireContext(), Manifest.permission.ACCESS_COARSE_LOCATION) != PackageManager.PERMISSION_GRANTED) {

            requestPermissions(
                arrayOf(
                    Manifest.permission.ACCESS_FINE_LOCATION,
                    Manifest.permission.ACCESS_COARSE_LOCATION
                ),
                LOCATION_PERMISSION_REQUEST_CODE
            )
        }

        btnDetall.setOnClickListener {
            val bundle = Bundle()
            bundle.putSerializable("delivererId", seguent_paquet.text.toString())
            bundle.putSerializable("paquetId", seguent_paquet.text.toString())

            val fragment = TruckPaquetDetallsFragment()
            fragment.arguments = bundle

            parentFragmentManager.beginTransaction()
                .replace(R.id.fragmentContainerView, fragment)
                .addToBackStack(null)
                .commit()
        }

        btnGoogleMaps.setOnClickListener {
            coordenadesDestiAux?.let { coords ->
                val latitude = coords.latitude
                val longitude = coords.longitude
                val gmmIntentUri = Uri.parse("geo:$latitude,$longitude?q=$latitude,$longitude")

                val mapIntent = Intent(Intent.ACTION_VIEW, gmmIntentUri)
                mapIntent.setPackage("com.google.android.apps.maps")

                if (mapIntent.resolveActivity(requireContext().packageManager) != null) {
                    startActivity(mapIntent)
                } else {
                    Toast.makeText(requireContext(), "Google Maps no esta instalat", Toast.LENGTH_SHORT).show()
                }
            } ?: run {
                Toast.makeText(requireContext(), "Coordenades no disponibles encara", Toast.LENGTH_SHORT).show()
            }
        }

    }

    override fun onMapReady(googleMap: GoogleMap) {
        mMap = googleMap

        //Si tenim permisos acvtivem la ubi del mapa
        if (ActivityCompat.checkSelfPermission(requireContext(), android.Manifest.permission.ACCESS_FINE_LOCATION) == PackageManager.PERMISSION_GRANTED
            || ActivityCompat.checkSelfPermission(requireContext(), Manifest.permission.ACCESS_COARSE_LOCATION) == PackageManager.PERMISSION_GRANTED) {
            mMap.isMyLocationEnabled = true
        }
    }

    override fun onRequestPermissionsResult(
        requestCode: Int,
        permissions: Array<out String>,
        grantResults: IntArray
    ) {
        super.onRequestPermissionsResult(requestCode, permissions, grantResults)

        if (requestCode == LOCATION_PERMISSION_REQUEST_CODE) {
            if (grantResults.isNotEmpty() && grantResults[0] == PackageManager.PERMISSION_GRANTED) {
                if (::mMap.isInitialized) {
                    if (ActivityCompat.checkSelfPermission(
                            requireContext(), Manifest.permission.ACCESS_FINE_LOCATION
                        ) == PackageManager.PERMISSION_GRANTED
                    ) {
                        mMap.isMyLocationEnabled = true
                    }
                }
            }
        }
    }

    suspend fun getCurrentUbiSuspend(): LatLng? = suspendCoroutine { cont ->
        getCurrentUbi { ubicacio ->
            cont.resume(ubicacio)
        }
    }

    private fun getCurrentUbi(onResult: (LatLng?) -> Unit) {
        if (ActivityCompat.checkSelfPermission(requireContext(), Manifest.permission.ACCESS_FINE_LOCATION) != PackageManager.PERMISSION_GRANTED &&
            ActivityCompat.checkSelfPermission(requireContext(), Manifest.permission.ACCESS_COARSE_LOCATION) != PackageManager.PERMISSION_GRANTED) {
            Toast.makeText(requireContext(), "Permisos de ubicación no concedidos", Toast.LENGTH_SHORT).show()
            onResult(null)
            return
        }

        fusedLocationClient.lastLocation.addOnSuccessListener { location ->
            if (location != null) {
                val latLng = LatLng(location.latitude, location.longitude)
                onResult(latLng)
            } else {
                Log.d("getCurrentUbi","No s'ha pogut obtenir la ubicacio")
                onResult(null)
            }
        }.addOnFailureListener {
            Log.d("getCurrentUbi","Error obtenint l'ubicacio: ${it.message}")
            onResult(null)
        }
    }

    private fun drawRoute(map: GoogleMap, coordenades: List<List<Double>>) {
        Log.d("drawRoute","drawRoute coordenades = ")
        for ((index, coord) in coordenades.withIndex()) {
            if (coord.size >= 2) {
                val lat = coord[0]
                val lng = coord[1]
                Log.d("drawRoute", "[$index] Lat: $lat, Lng: $lng")
            } else {
                Log.w("drawRoute", "[$index] Coordenada inválida: $coord")
            }
        }
        polyline?.remove()

        val polyLineOptions = PolylineOptions()

        coordenades.forEach { coords ->
            polyLineOptions.add(LatLng(coords[1], coords[0]))
        }

        polyLineOptions.color(0xFF528AAE.toInt())

        requireActivity().runOnUiThread {
            polyline = map.addPolyline(polyLineOptions)
        }
    }
}