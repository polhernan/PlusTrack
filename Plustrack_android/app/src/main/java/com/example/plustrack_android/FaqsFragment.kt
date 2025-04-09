package com.example.plustrack_android

import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import androidx.constraintlayout.widget.ConstraintLayout
import androidx.fragment.app.Fragment
import com.google.android.material.bottomnavigation.BottomNavigationView

class FaqsFragment : Fragment(R.layout.faqs_fragment) {

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?, savedInstanceState: Bundle?
    ): View? {
        return inflater.inflate(R.layout.faqs_fragment, container, false)
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)

        // Obtener el BottomNavigationView de la actividad principal
        val bottomNav = activity?.findViewById<BottomNavigationView>(R.id.bottomNavigationView)

        // Aquí puedes obtener la altura del BottomNavigationView y configurar tus vistas en consecuencia.
        val bottomNavHeight = bottomNav?.height ?: 0

        // Ajustar la posición de las vistas dependiendo de la altura del BottomNavigationView
        val layoutParams = view.findViewById<View>(R.id.cuadradoBlanco).layoutParams as ConstraintLayout.LayoutParams
        layoutParams.bottomToTop = R.id.bottomNavigationView // Ajustar la vista a la parte superior del BottomNavigationView
        view.findViewById<View>(R.id.cuadradoBlanco).layoutParams = layoutParams

    }

}