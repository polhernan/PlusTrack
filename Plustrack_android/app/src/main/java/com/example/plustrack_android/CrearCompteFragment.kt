package com.example.plustrack_android

import android.content.Intent
import android.graphics.Color
import android.os.Bundle
import android.text.SpannableString
import android.text.Spanned
import android.text.style.ForegroundColorSpan
import android.text.style.UnderlineSpan
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Button
import android.widget.EditText
import android.widget.TextView
import android.widget.Toast
import androidx.fragment.app.Fragment

class CrearCompteFragment : Fragment(R.layout.crear_compte_fragment) {

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?, savedInstanceState: Bundle?
    ): View? {
        return inflater.inflate(R.layout.crear_compte_fragment, container, false)
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)

        val loginUsuari: EditText = view.findViewById(R.id.loginUsuari)
        val loginContrasenya: EditText = view.findViewById(R.id.loginContrasenya)
        val loginRepetirContrasenya: EditText = view.findViewById(R.id.loginRepetirContrasenya)
        val loginEmail: EditText = view.findViewById(R.id.loginEmail)
        val btnRegistrar: TextView = view.findViewById(R.id.btnRegistrar)
        val txtFerLogin: TextView = view.findViewById(R.id.txtFerLogin)

        // Crear un SpannableString para modificar el color y comportamiento del texto
        val text = "o fer login"
        val spannableString = SpannableString(text)

        // Hacer "fer login" azul y con estilo de enlace
        val start = text.indexOf("fer login")
        val end = start + "fer login".length

        spannableString.setSpan(ForegroundColorSpan(Color.BLUE), start, end, Spanned.SPAN_EXCLUSIVE_EXCLUSIVE)
        spannableString.setSpan(UnderlineSpan(), start, end, Spanned.SPAN_EXCLUSIVE_EXCLUSIVE)

        // Establecer el texto en el TextView
        txtFerLogin.text = spannableString

        btnRegistrar.setOnClickListener{
            // Aqui agafem les dades de l'usuari y creem un compte amb elles
        }

        txtFerLogin.setOnClickListener {
            txtFerLogin.setOnClickListener {
                val intent = Intent(requireContext(), MainActivity::class.java)
                startActivity(intent)
            }
        }
    }

}