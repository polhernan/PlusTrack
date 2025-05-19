package com.example.plustrack_android

import android.content.Intent
import android.graphics.Color
import android.os.Bundle
import android.os.Looper
import android.text.SpannableString
import android.text.Spanned
import android.text.method.LinkMovementMethod
import android.text.style.ForegroundColorSpan
import android.text.style.UnderlineSpan
import android.util.Log
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Button
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
import java.util.Locale

class CrearCompteFragment : Fragment(R.layout.crear_compte_fragment) {
    private val userApi = RetrofitUsuari.apiService

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
    }

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?, savedInstanceState: Bundle?
    ): View? {
        return inflater.inflate(R.layout.crear_compte_fragment, container, false)
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)

        val loginNom: EditText = view.findViewById(R.id.loginNom)
        val loginCognoms: EditText = view.findViewById(R.id.loginCognoms)
        val loginEmail: EditText = view.findViewById(R.id.loginEmail)
        val loginContrasenya: EditText = view.findViewById(R.id.loginPassword)
        val loginRepetirContrasenya: EditText = view.findViewById(R.id.loginRepetirContrasenya)

        val btnRegistrar: TextView = view.findViewById(R.id.btnRegistrar)
        val txtFerLogin: TextView = view.findViewById(R.id.txtFerLogin)

        val text = getString(R.string.text_fer_login)
        val spannableString = SpannableString(text)

        val keyword = when (Locale.getDefault().language) {
            "ca" -> "fer login"
            "es" -> "hacer login "
            "en" -> "log in"
            else -> "fer login"
        }

        val start = text.indexOf(keyword)
        val end = start + keyword.length

        if (start != -1) {
            spannableString.setSpan(ForegroundColorSpan(Color.CYAN), start, end, Spanned.SPAN_EXCLUSIVE_EXCLUSIVE)
            spannableString.setSpan(UnderlineSpan(), start, end, Spanned.SPAN_EXCLUSIVE_EXCLUSIVE)
        }

        txtFerLogin.text = spannableString
        txtFerLogin.movementMethod = LinkMovementMethod.getInstance()

        btnRegistrar.setOnClickListener{
            if (loginContrasenya.text.toString() == loginRepetirContrasenya.text.toString() && !loginNom.text.isNullOrBlank() && !loginCognoms.text.isNullOrBlank() && !loginEmail.text.isNullOrBlank() && !loginContrasenya.text.isNullOrBlank()) {
                CoroutineScope(Dispatchers.IO).launch {
                    try {
                        val response = userApi.postUser(loginNom.text.toString(), loginCognoms.text.toString(), loginEmail.text.toString(), loginContrasenya.text.toString())

                        if (response.isSuccessful){
                            Log.d("responsePost", "response is successful")
                            withContext(Dispatchers.Main) {
                                val newUser = response.body()

                                Toast.makeText(requireContext(), "Benvolgut ${newUser!!.Name}!", Toast.LENGTH_LONG).show()

                                val bundle = Bundle()
                                bundle.putSerializable("usuari", newUser)

                                val fragment = IniciFragment()
                                fragment.arguments = bundle

                                parentFragmentManager.beginTransaction()
                                    .replace(R.id.fragmentContainerView, fragment)
                                    .addToBackStack(null)
                                    .commit()
                            }
                        } else if (response.code() == 500) {
                            withContext(Dispatchers.Main) {
                                Toast.makeText(requireContext(), "L'usuari amb email ${loginEmail.text.toString()} ja existeix", Toast.LENGTH_LONG).show()
                            }
                        }
                    } catch (e: Exception) {
                        Log.e("Login", "Petició erronea: ${e.message}", e)
                        withContext(Dispatchers.Main) {
                            Toast.makeText(requireContext(), "Error de connexió", Toast.LENGTH_SHORT).show()
                        }
                    }
                }
            } else {
                Toast.makeText(requireContext(), "Las contrasenyes introduides no coincideixen o falten dades", Toast.LENGTH_LONG).show()
            }
        }

        txtFerLogin.setOnClickListener {
            val fragmentManager = parentFragmentManager
            val transaction = fragmentManager.beginTransaction()
            transaction.replace(R.id.fragmentContainerView, LoginFragment())
            transaction.addToBackStack(null)
            transaction.commit()
        }
    }
}