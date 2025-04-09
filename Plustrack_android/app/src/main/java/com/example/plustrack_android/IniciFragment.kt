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
import android.widget.ImageButton
import android.widget.TextView
import android.widget.Toast
import androidx.constraintlayout.widget.ConstraintLayout
import androidx.fragment.app.Fragment
import com.google.android.material.bottomnavigation.BottomNavigationView

class IniciFragment : Fragment(R.layout.inici_fragment) {

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?, savedInstanceState: Bundle?
    ): View? {
        return inflater.inflate(R.layout.inici_fragment, container, false)
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)

//        // Obtener el BottomNavigationView de la actividad principal
//        val bottomNav = activity?.findViewById<BottomNavigationView>(R.id.bottomNavigationView)
//
//        // Aquí puedes obtener la altura del BottomNavigationView y configurar tus vistas en consecuencia.
//        val bottomNavHeight = bottomNav?.height ?: 0
//
//        // Ajustar la posición de las vistas dependiendo de la altura del BottomNavigationView
//        val layoutParams = view.findViewById<View>(R.id.cuadradoBlanco).layoutParams as ConstraintLayout.LayoutParams
//        layoutParams.bottomToTop = R.id.bottomNavigationView // Ajustar la vista a la parte superior del BottomNavigationView
//        view.findViewById<View>(R.id.cuadradoBlanco).layoutParams = layoutParams

        val etIdProducte: EditText = view.findViewById(R.id.etIdProducte)

        val btnCercar: ImageButton = view.findViewById(R.id.btnCercar)
        val btnContactar: TextView = view.findViewById(R.id.btnContactar)
        val btnNoticies: TextView = view.findViewById(R.id.btnNoticies)
        val btnFAQs: TextView = view.findViewById(R.id.btnFAQs)

        btnCercar.setOnClickListener {
            // Busca el ID introduit per l'usuari (etIdProducte) a la base de dades y es carrega el fragment de Paquets amb aquest paquet
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