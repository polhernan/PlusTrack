package com.example.plustrack_android

import android.graphics.Color
import android.os.Bundle
import android.text.SpannableString
import android.text.Spanned
import android.text.style.ForegroundColorSpan
import android.text.style.UnderlineSpan
import android.widget.TextView
import android.widget.Toast
import androidx.activity.enableEdgeToEdge
import androidx.appcompat.app.AppCompatActivity
import androidx.core.view.ViewCompat
import androidx.core.view.WindowInsetsCompat

class ActivityCrearCompte : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        enableEdgeToEdge()
        setContentView(R.layout.activity_crear_compte)
        ViewCompat.setOnApplyWindowInsetsListener(findViewById(R.id.main)) { v, insets ->
            val systemBars = insets.getInsets(WindowInsetsCompat.Type.systemBars())
            v.setPadding(systemBars.left, systemBars.top, systemBars.right, systemBars.bottom)
            insets
        }

        val txtFerLogin: TextView = findViewById(R.id.txtFerLogin)

        // Crear un SpannableString para modificar el color y comportamiento del texto
        val text = "o fer login"
        val spannableString = SpannableString(text)

        // Hacer "crear compte" azul y con estilo de enlace
        val start = text.indexOf("fer login")
        val end = start + "fer login".length

        spannableString.setSpan(ForegroundColorSpan(Color.BLUE), start, end, Spanned.SPAN_EXCLUSIVE_EXCLUSIVE)
        spannableString.setSpan(UnderlineSpan(), start, end, Spanned.SPAN_EXCLUSIVE_EXCLUSIVE) // Subrayado para simular un enlace

        // Establecer el texto en el TextView
        txtFerLogin.text = spannableString

        // Hacer clic en "crear compte"
        txtFerLogin.setOnClickListener {
            Toast.makeText(this, "Redirigir a la creación de cuenta", Toast.LENGTH_SHORT).show()
        }

    }
}