package com.example.plustrack_android

import android.os.Bundle
import android.util.Log
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Toast
import androidx.constraintlayout.widget.ConstraintLayout
import androidx.fragment.app.Fragment
import androidx.fragment.app.activityViewModels
import androidx.lifecycle.lifecycleScope
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView
import com.google.android.material.bottomnavigation.BottomNavigationView
import com.google.gson.GsonBuilder
import kotlinx.coroutines.CoroutineScope
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.delay
import kotlinx.coroutines.isActive
import kotlinx.coroutines.launch
import kotlinx.coroutines.withContext
import retrofit2.Retrofit
import retrofit2.converter.gson.GsonConverterFactory
import kotlin.getValue

class PaquetsFragment : Fragment(R.layout.paquets_fragment) {
    private val paquetApi = RetrofitPaquet.apiService
    private val sharedViewModel: SharedViewModel by activityViewModels()

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
    }

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?, savedInstanceState: Bundle?
    ): View? {
        return inflater.inflate(R.layout.paquets_fragment, container, false)
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)

        val recyclerView = view.findViewById<RecyclerView>(R.id.recycler_paquets)

        recyclerView.layoutManager = LinearLayoutManager(requireContext())

        val userId = sharedViewModel.user.value!!.Id

        // Si volem que la corrutina es canceli automaticament quan es destrueixi:
        // CoroutineScope(Dispatchers.IO).launch {
        viewLifecycleOwner.lifecycleScope.launch(Dispatchers.IO) {
            while (isActive) {
            try {
                val response = paquetApi.getAllUserPackages(userId)
                withContext(Dispatchers.Main) {
                    if (response.isSuccessful) {
                        val paquetList = response.body()

                        if (paquetList != null) {
                            recyclerView.adapter = PaquetsAdapter(
                                paquetList,
                                { paquet ->
                                    val fragment = PaquetSeleccionatFragment()
                                    val bundle = Bundle()

                                    bundle.putSerializable("paquet", paquet)
                                    fragment.arguments = bundle

                                    requireActivity().supportFragmentManager.beginTransaction()
                                        .replace(R.id.fragmentContainerView, fragment)
                                        .addToBackStack(null)
                                        .commit()
                                }
                            )
                        } else {
                            Toast.makeText(
                                requireContext(),
                                "No hi han paquets",
                                Toast.LENGTH_SHORT
                            ).show()
                        }
                    } else {
                        Toast.makeText(
                            requireContext(),
                            "Error response not succefsul",
                            Toast.LENGTH_SHORT
                        ).show()
                    }
                }
            } catch (e: Exception) {
                withContext(Dispatchers.Main) {
                    Log.e("PaquetsFragment", "Error en la llamada a la API: ${e.message}")
                    Toast.makeText(requireContext(), "Error en la conexión", Toast.LENGTH_SHORT)
                        .show()
                }
            }
                delay(5_000L)
            }
        }

    }
}