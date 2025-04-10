package com.example.plustrack_android

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
import android.widget.EditText
import android.widget.TextView
import android.widget.Toast
import androidx.fragment.app.Fragment
import com.google.gson.GsonBuilder
import kotlinx.coroutines.CoroutineScope
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.launch
import kotlinx.coroutines.withContext
import retrofit2.Retrofit
import retrofit2.converter.gson.GsonConverterFactory

class LoginFragment : Fragment(R.layout.login_fragment) {
    private lateinit var userApi: UsuariApi;

    override fun onCreate(savedInstanceState: Bundle?) {

        val gson = GsonBuilder().setLenient().create()
        val retrofit = Retrofit.Builder()
            .baseUrl("http://172.16.24.23:5184/")
            .addConverterFactory(GsonConverterFactory.create(gson))
            .build()

        userApi = retrofit.create(UsuariApi::class.java)

        super.onCreate(savedInstanceState)

    }

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?, savedInstanceState: Bundle?
    ): View? {
        return inflater.inflate(R.layout.login_fragment, container, false)
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)

        val loginUsuari: EditText = view.findViewById(R.id.loginUsuari)
        val loginContrasenya: EditText = view.findViewById(R.id.loginContrasenya)
        val btnEntrar: TextView = view.findViewById(R.id.btnEntrar)
        val txtCrearCompte: TextView = view.findViewById(R.id.txtCrearCompte)
        val btnNoUsuari: TextView = view.findViewById(R.id.btnNoUsuari)

        val text = "o crear compte"
        val spannableString = SpannableString(text)
        val start = text.indexOf("crear compte")
        val end = start + "crear compte".length
        spannableString.setSpan(ForegroundColorSpan(Color.CYAN), start, end, Spanned.SPAN_EXCLUSIVE_EXCLUSIVE)
        spannableString.setSpan(UnderlineSpan(), start, end, Spanned.SPAN_EXCLUSIVE_EXCLUSIVE)
        txtCrearCompte.text = spannableString

        btnEntrar.setOnClickListener {
            val loginUsuariStr = loginUsuari.text.toString()
            val loginContrasenyaStr = loginContrasenya.text.toString()

            CoroutineScope(Dispatchers.IO).launch {
                try {
                    val loginRequest = LoginRequest(
                        email = loginUsuariStr,
                        password = loginContrasenyaStr
                    )
                    val usuarioEncontrado = userApi.getUserFromDB(loginRequest)

                    withContext(Dispatchers.Main) {
                        if (!usuarioEncontrado.Id.isNullOrEmpty()) {
                            Toast.makeText(requireContext(), "Benvolgut ${usuarioEncontrado.Name}!", Toast.LENGTH_LONG).show()

                            val bundle = Bundle()
                            bundle.putSerializable("usuari", usuarioEncontrado)

                            val fragment = IniciFragment()
                            fragment.arguments = bundle

                            parentFragmentManager.beginTransaction()
                                .replace(R.id.fragmentContainerView, fragment)
                                .addToBackStack(null)
                                .commit()
                        }
                    }
                } catch (e: Exception) {
                    Log.e("getCurrentLocation", "Peticio erronea: ${e.message}", e)
                    withContext(Dispatchers.Main) {
                        Toast.makeText(requireContext(), "Error de connexió", Toast.LENGTH_SHORT).show()
                    }
                }
            }
        }

        txtCrearCompte.setOnClickListener {
            val fragment = CrearCompteFragment()
            parentFragmentManager.beginTransaction()
                .replace(R.id.fragmentContainerView, fragment)
                .addToBackStack(null)
                .commit()
        }

        btnNoUsuari.setOnClickListener {
            Toast.makeText(requireContext(), "Botó Sense Usuari pulsat", Toast.LENGTH_SHORT).show()
        }
    }
}
