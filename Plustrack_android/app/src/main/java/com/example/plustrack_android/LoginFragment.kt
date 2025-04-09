package com.example.plustrack_android

import android.graphics.Color
import android.os.Bundle
import android.text.SpannableString
import android.text.Spanned
import android.text.style.ForegroundColorSpan
import android.text.style.UnderlineSpan
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.EditText
import android.widget.TextView
import android.widget.Toast
import androidx.fragment.app.Fragment

class LoginFragment : Fragment(R.layout.login_fragment) {

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
        // Aixo verifica l'usuari i la seva contrasenya, aixi que aqui es crida a la base de dades
        val fragment = IniciFragment()
        parentFragmentManager.beginTransaction()
            .replace(R.id.fragmentContainerView, fragment)
            .addToBackStack(null)
            .commit()
    }

    txtCrearCompte.setOnClickListener {
        val fragment = CrearCompteFragment()
        parentFragmentManager.beginTransaction()
            .replace(R.id.fragmentContainerView, fragment)
            .addToBackStack(null)
            .commit()
    }

    btnNoUsuari.setOnClickListener {
        Toast.makeText(requireContext(), "Boton Sense Usuari pulsado", Toast.LENGTH_SHORT).show()
        // Aixo entra a la app com un usuari no registrat
    }

}
    }