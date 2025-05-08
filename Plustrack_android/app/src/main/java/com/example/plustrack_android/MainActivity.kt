package com.example.plustrack_android

import android.content.Intent
import android.graphics.Color
import android.os.Bundle
import android.text.SpannableString
import android.text.Spanned
import android.text.style.ForegroundColorSpan
import android.text.style.UnderlineSpan
import android.util.Log
import android.view.View
import android.widget.EditText
import android.widget.TextView
import android.widget.Toast
import androidx.activity.enableEdgeToEdge
import androidx.appcompat.app.AppCompatActivity
import androidx.core.view.ViewCompat
import androidx.core.view.WindowInsetsCompat
import com.google.android.material.bottomnavigation.BottomNavigationView

class MainActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        enableEdgeToEdge()
        setContentView(R.layout.activity_main)

        val bottomNavigationView = findViewById<BottomNavigationView>(R.id.bottomNavigationView)

        supportFragmentManager.addOnBackStackChangedListener {
            val currentFragment = supportFragmentManager.findFragmentById(R.id.fragmentContainerView)

            val bottomNavigationView = findViewById<BottomNavigationView>(R.id.bottomNavigationView)

            if (currentFragment is TruckMapFragment || currentFragment is TruckPaquetDetallsFragment || currentFragment is CrearCompteFragment || currentFragment is LoginFragment) {
                bottomNavigationView.visibility = View.GONE
            } else {
                bottomNavigationView.visibility = View.VISIBLE
            }
        }


        // Carreguem LoginFragment amagant el bottomNavigationView
        if (savedInstanceState == null) {
            supportFragmentManager.beginTransaction()
                .replace(R.id.fragmentContainerView, LoginFragment())
                .commit()

            bottomNavigationView.visibility = View.GONE
        }

        /*// Si el fragment es el de CrearCompteFragment o el de LoginFragment, tambe amagem el bottomNavigationView
        // Tenim que tornar a posar el LoginFragment ja que si l'usuari tira enrrera amb el boto d'anar enrrera
        // propi del movil, es veure el bottom menu
        supportFragmentManager.addOnBackStackChangedListener {
            val fragment = supportFragmentManager.findFragmentById(R.id.fragmentContainerView)

            if (fragment is CrearCompteFragment || fragment is LoginFragment) {
                bottomNavigationView.visibility = View.GONE
            } else {
                bottomNavigationView.visibility = View.VISIBLE
            }
        }*/

        findViewById<BottomNavigationView>(R.id.bottomNavigationView).setOnItemSelectedListener { item ->

            when (item.itemId) {
                R.id.menu_inici_selector -> {
                    val transaccio = supportFragmentManager.beginTransaction()
                    val menuInici = IniciFragment()
                    transaccio.replace(R.id.fragmentContainerView, menuInici)
                    transaccio.commit()
                    true
                }

                R.id.menu_paquets_selector -> {
                    val transaccio = supportFragmentManager.beginTransaction()
                    val menuPaquets = PaquetsFragment()
                    transaccio.replace(R.id.fragmentContainerView, menuPaquets)
                    transaccio.commit()
                    true
                }

                else -> {
                    val transaccio = supportFragmentManager.beginTransaction()
                    val menuPerfil = PerfilFragment()
                    transaccio.replace(R.id.fragmentContainerView, menuPerfil)
                    transaccio.commit()
                    true
                }

            }
        }

    }
}