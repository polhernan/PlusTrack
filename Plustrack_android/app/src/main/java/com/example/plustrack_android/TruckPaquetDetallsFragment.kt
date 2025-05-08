package com.example.plustrack_android

import android.os.Bundle
import android.util.Log
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.EditText
import android.widget.ImageButton
import android.widget.TextView
import android.widget.Toast
import androidx.fragment.app.Fragment
import androidx.fragment.app.activityViewModels
import com.google.android.gms.location.LocationServices
import com.google.android.gms.maps.SupportMapFragment
import com.google.gson.GsonBuilder
import kotlinx.coroutines.CoroutineScope
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.launch
import kotlinx.coroutines.withContext
import retrofit2.Retrofit
import retrofit2.converter.gson.GsonConverterFactory

class TruckPaquetDetallsFragment : Fragment(R.layout.truck_paquet_detalls_fragment) {
    private val paquetApi = RetrofitPaquet.apiService


    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
    }

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?, savedInstanceState: Bundle?
    ): View? {
        return inflater.inflate(R.layout.truck_paquet_detalls_fragment, container, false)
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)

        val paquetId = arguments?.getSerializable("paquetId") as String

        var Id_paquet: TextView = view.findViewById(R.id.Id_paquet)
        Id_paquet.text = paquetId
        val btnEntregat: TextView = view.findViewById(R.id.btnEntregat)
        val btnNoEntregat: TextView = view.findViewById(R.id.btnNoEntregat)
        val btnTornar: TextView = view.findViewById(R.id.btnTornar)

        btnEntregat.setOnClickListener {
            CoroutineScope(Dispatchers.IO).launch {
                try {
                    withContext(Dispatchers.Main) {
                        val responseEntregat = paquetApi.postPackageState(Id_paquet.text.toString(), 1) //1 = Entregat
                        //Log.d("responseEntregat","responseEntregat.body() = " + responseEntregat.body())
                        withContext(Dispatchers.Main) {
                            if (responseEntregat.isSuccessful) {
                                Log.d("responseEntregat Succesful", "responseEntregat: Paquet entregat!") // NO SALE NI ESTE LOG NI EL DEL ELSE DE ABAJO, TRABAJO PARA MAÑANA 30 ABRIL
                                Toast.makeText(requireContext(),"Paquet entregat correctament",Toast.LENGTH_LONG).show()

                                val fragment = TruckMapFragment()
                                parentFragmentManager.beginTransaction()
                                    .replace(R.id.fragmentContainerView, fragment)
                                    .addToBackStack(null)
                                    .commit()
                            } else {
                                Log.d("responseEntregat NOT Succesful", "responseEntregat NOT Succesful") // NO SALE NI ESTE LOG NI EL DEL ELSE DE ABAJO, TRABAJO PARA MAÑANA 30 ABRIL
                            }
                        }
                    }
                } catch (e: Exception) {
                    Log.e("btnEntregat", "Peticio erronea: ${e.message}", e)
                    withContext(Dispatchers.Main) {
                        Toast.makeText(requireContext(), "Error de connexio", Toast.LENGTH_SHORT).show()
                    }
                }
            }
        }

        btnNoEntregat.setOnClickListener {
            CoroutineScope(Dispatchers.IO).launch {
                try {
                    withContext(Dispatchers.Main) {
                        val responseEntregat = paquetApi.postPackageState(Id_paquet.text.toString(), 0) //0 = Entregat
                        withContext(Dispatchers.Main) {
                            if (responseEntregat.isSuccessful) {
                                Log.d("responseNoEntregat Succesful", "responseNoEntregat: Paquet NO entregat!") // NO SALE NI ESTE LOG NI EL DEL ELSE DE ABAJO, TRABAJO PARA MAÑANA 30 ABRIL
                                Toast.makeText(requireContext(),"Paquet NO entregat correctament",Toast.LENGTH_LONG).show()

                                val fragment = TruckMapFragment()
                                parentFragmentManager.beginTransaction()
                                    .replace(R.id.fragmentContainerView, fragment)
                                    .addToBackStack(null)
                                    .commit()
                            } else {
                                Log.d("responseNoEntregat NOT Succesful", "responseNoEntregat NOT Succesful") // NO SALE NI ESTE LOG NI EL DEL ELSE DE ABAJO, TRABAJO PARA MAÑANA 30 ABRIL
                            }
                        }
                    }
                } catch (e: Exception) {
                    Log.e("btnNoEntregat", "Peticio erronea: ${e.message}", e)
                    withContext(Dispatchers.Main) {
                        Toast.makeText(requireContext(), "Error de connexio", Toast.LENGTH_SHORT).show()
                    }
                }
            }
        }

        btnTornar.setOnClickListener {
            val fragment = TruckMapFragment()
            parentFragmentManager.beginTransaction()
                .replace(R.id.fragmentContainerView, fragment)
                .addToBackStack(null)
                .commit()
        }

    }

}