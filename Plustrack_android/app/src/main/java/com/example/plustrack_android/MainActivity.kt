package com.example.plustrack_android

import android.content.Intent
import android.graphics.Color
import android.os.Bundle
import android.text.SpannableString
import android.text.Spanned
import android.text.style.ForegroundColorSpan
import android.text.style.UnderlineSpan
import android.util.Log
import android.widget.EditText
import android.widget.TextView
import android.widget.Toast
import androidx.activity.enableEdgeToEdge
import androidx.appcompat.app.AppCompatActivity
import androidx.core.view.ViewCompat
import androidx.core.view.WindowInsetsCompat

class MainActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        enableEdgeToEdge()
        setContentView(R.layout.activity_main)
        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main)) { v, insets ->
            val systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars())
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom)
            insets
        }

        val loginUsuari: EditText = findViewById(R.id.loginUsuari)
        val loginContrasenya: EditText = findViewById(R.id.loginContrasenya)

        val btnEntrar: TextView = findViewById(R.id.btnEntrar)
        val txtCrearCompte: TextView = findViewById(R.id.txtCrearCompte)
        val btnNoUsuari: TextView = findViewById(R.id.btnNoUsuari)

        val text = "o crear compte"
        val spannableString = SpannableString(text)

        val start = text.indexOf("crear compte")
        val end = start + "crear compte".length

        spannableString.setSpan(ForegroundColorSpan(Color.BLUE), start, end, Spanned.SPAN_EXCLUSIVE_EXCLUSIVE)
        spannableString.setSpan(UnderlineSpan(), start, end, Spanned.SPAN_EXCLUSIVE_EXCLUSIVE)

        txtCrearCompte.text = spannableString

        btnEntrar.setOnClickListener {
            // Aixo verifica l'usuari i la seva contrasenya, aixi que aqui es crida a la base de dades
            val fragment = IniciFragment()
            supportFragmentManager.beginTransaction()
                .replace(R.id.fragmentContainerView, fragment)
                .addToBackStack(null)
                .commit()

        }

        txtCrearCompte.setOnClickListener {
            Toast.makeText(this, "Boton Crear Compte pulsado", Toast.LENGTH_SHORT).show()
            val fragment = CrearCompteFragment()
            supportFragmentManager.beginTransaction()
                .replace(R.id.fragmentContainerView, fragment)
                .addToBackStack(null)
                .commit()
        }

        btnNoUsuari.setOnClickListener {
            Toast.makeText(this, "Boton Sense Usuari pulsado", Toast.LENGTH_SHORT).show()
            // Aixo entra a la app com un usuari no registrat
        }

    }
}