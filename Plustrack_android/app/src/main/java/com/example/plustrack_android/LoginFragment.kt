package com.example.plustrack_android

import android.graphics.Color
import android.os.Bundle
import android.text.SpannableString
import android.text.Spanned
import android.text.method.LinkMovementMethod
import android.text.style.ClickableSpan
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
import androidx.fragment.app.activityViewModels
import com.google.android.material.bottomnavigation.BottomNavigationView
import com.google.gson.GsonBuilder
import kotlinx.coroutines.CoroutineScope
import kotlinx.coroutines.Dispatchers
import kotlinx.coroutines.launch
import kotlinx.coroutines.withContext
import retrofit2.Retrofit
import retrofit2.converter.gson.GsonConverterFactory
import java.time.LocalDateTime
import java.util.Locale

class LoginFragment : Fragment(R.layout.login_fragment) {
    private val userApi = RetrofitUsuari.apiService
    private val sharedViewModel: SharedViewModel by activityViewModels()

    override fun onCreate(savedInstanceState: Bundle?) {
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

        loginUsuari.setText("aaa")
        loginContrasenya.setText("aaa")

        val text = getString(R.string.text_crear_compte)
        val spannableString = SpannableString(text)

        val keyword = when (Locale.getDefault().language) {
            "ca" -> "crear compte"
            "es" -> "crear cuenta"
            "en" -> "create account"
            else -> "crear compte"
        }

        val start = text.indexOf(keyword)
        if (start >= 0) {
            val end = start + keyword.length

            spannableString.setSpan(ForegroundColorSpan(Color.CYAN), start, end, Spanned.SPAN_EXCLUSIVE_EXCLUSIVE)
            spannableString.setSpan(UnderlineSpan(), start, end, Spanned.SPAN_EXCLUSIVE_EXCLUSIVE)
        }
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
                    val responseUser = userApi.getUserFromDB(loginRequest)
                    Log.d("response", "response.code() es: " + responseUser.code())

                    withContext(Dispatchers.Main) {
                        if (responseUser.code() == 200 && responseUser.body()?.Id?.isNotEmpty() == true) {
                            val usuariTrobat = responseUser.body()
                            if (usuariTrobat != null && !usuariTrobat.Id.isNullOrEmpty()) {
                                Toast.makeText(requireContext(), "Benvolgut ${usuariTrobat.Name}!", Toast.LENGTH_LONG).show()

                                sharedViewModel.user.value = usuariTrobat

                                val fragment = IniciFragment()
                                //fragment.arguments = bundle

                                parentFragmentManager.beginTransaction()
                                    .replace(R.id.fragmentContainerView, fragment)
                                    .addToBackStack(null)
                                    .commit()
                            } else {
                                Toast.makeText(
                                    requireContext(),
                                    "Error: codi ${responseUser.code()}",
                                    Toast.LENGTH_SHORT
                                ).show()
                            }
                        } else if (responseUser.code() == 404) {
                                try {
                                    val responseDeliverer = userApi.getDelivererFromDB(loginRequest)
                                    val delivererTrobat = responseDeliverer.body()

                                    Toast.makeText(requireContext(),"Benvingut repartidor ${delivererTrobat?.Name}",Toast.LENGTH_LONG).show()

                                        //val bundle = Bundle()
                                        //bundle.putSerializable("usuari", delivererTrobat)

                                        val sharedViewModel: SharedViewModel by activityViewModels()
                                        sharedViewModel.deliverer.value = delivererTrobat

                                        val fragment = TruckMapFragment()
                                        //fragment.arguments = bundle

                                    try {
                                        parentFragmentManager.beginTransaction()
                                            .replace(R.id.fragmentContainerView, fragment)
                                            .addToBackStack(null)
                                            .commit()
                                    } catch (e: Exception) {
                                        Log.e("Fragment", "Error al reemplazar el fragmento: ${e.message}", e)
                                    }
                                } catch (e: Exception) {
                                    Log.e("Login", "Error al buscar repartidor: ${e.message}",e)
                                    Toast.makeText(requireContext(), "No s'ha pogut identificar l'usuari", Toast.LENGTH_SHORT).show()
                                }
                        } else {
                                Toast.makeText(requireContext(), "Error: codi ${responseUser.code()}", Toast.LENGTH_SHORT).show()
                            }
                    }
                } catch (e: Exception) {
                    Log.e("Login", "Peticio erronea: ${e.message}", e)
                    withContext(Dispatchers.Main) {
                        Toast.makeText(requireContext(), "Error de connexió", Toast.LENGTH_SHORT).show()
                    }
                }
            }
        }

        txtCrearCompte.setOnClickListener {
            Log.d("Entrar txtCrearCompte","hem entrat a txtCrearCompte")
            val fragment = CrearCompteFragment()
            parentFragmentManager.beginTransaction()
                .replace(R.id.fragmentContainerView, fragment)
                .addToBackStack(null)
                .commit()
        }
    }
}
