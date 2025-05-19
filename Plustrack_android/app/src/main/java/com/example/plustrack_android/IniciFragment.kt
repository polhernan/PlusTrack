package com.example.plustrack_android

import android.content.Intent
import android.graphics.Color
import android.os.Bundle
import android.text.SpannableString
import android.text.Spanned
import android.text.style.ForegroundColorSpan
import android.text.style.UnderlineSpan
import android.util.Log
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Button
import android.widget.EditText
import android.widget.ImageButton
import android.widget.TextView
import android.widget.Toast
import androidx.constraintlayout.widget.ConstraintLayout
import androidx.fragment.app.Fragment
import androidx.fragment.app.activityViewModels
import com.google.android.material.bottomnavigation.BottomNavigationView
import kotlinx.coroutines.CoroutineScope
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.launch
import kotlinx.coroutines.withContext
import kotlin.getValue

class IniciFragment : Fragment(R.layout.inici_fragment) {
    private val paquetApi = RetrofitPaquet.apiService

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?, savedInstanceState: Bundle?
    ): View? {
        return inflater.inflate(R.layout.inici_fragment, container, false)
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)

        val etIdProducte: EditText = view.findViewById(R.id.etIdProducte)

        etIdProducte.setText("5F87001A-2EE4-4900-9042-55681EE1F215")

        val btnCercar: ImageButton = view.findViewById(R.id.btnCercar)
        val btnContactar: TextView = view.findViewById(R.id.btnContactar)
        val btnNoticies: TextView = view.findViewById(R.id.btnNoticies)
        val btnFAQs: TextView = view.findViewById(R.id.btnFAQs)

        btnCercar.setOnClickListener {
            CoroutineScope(Dispatchers.IO).launch {
                try {
                    val response = paquetApi.getPackageById(etIdProducte.text.toString())

                    if (response.isSuccessful){
                        withContext(Dispatchers.Main) {
                            val packageFound = response.body()

                            val bundle = Bundle()
                            bundle.putSerializable("paquet", packageFound)

                            val fragment = PaquetSeleccionatFragment()
                            fragment.arguments = bundle

                            parentFragmentManager.beginTransaction()
                                .replace(R.id.fragmentContainerView, fragment)
                                .addToBackStack(null)
                                .commit()
                        }
                    } else {
                        withContext(Dispatchers.Main) {
                            Toast.makeText(requireContext(), "Paquet no trobat", Toast.LENGTH_LONG).show()
                        }
                    }
                } catch (e: Exception) {
                    Log.e("Login", "Petició erronea: ${e.message}", e)
                    withContext(Dispatchers.Main) {
                        Toast.makeText(requireContext(), "Error de connexió", Toast.LENGTH_SHORT).show()
                    }
                }
            }
        }

        btnContactar.setOnClickListener {
            val fragmentManager = parentFragmentManager
            val transaction = fragmentManager.beginTransaction()
            transaction.replace(R.id.fragmentContainerView, ContactarFragment())
            transaction.addToBackStack(null)
            transaction.commit()
        }

        btnNoticies.setOnClickListener {
            val fragmentManager = parentFragmentManager
            val transaction = fragmentManager.beginTransaction()
            transaction.replace(R.id.fragmentContainerView, NoticiaFragment())
            transaction.addToBackStack(null)
            transaction.commit()
        }

        btnFAQs.setOnClickListener {
            val fragmentManager = parentFragmentManager
            val transaction = fragmentManager.beginTransaction()
            transaction.replace(R.id.fragmentContainerView, FaqsFragment())
            transaction.addToBackStack(null)
            transaction.commit()
        }
    }
}