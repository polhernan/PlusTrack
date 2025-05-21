package com.example.plustrack_android

import android.os.Bundle
import android.util.Log
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.EditText
import android.widget.ImageView
import android.widget.TextView
import android.widget.Toast
import androidx.fragment.app.Fragment
import com.google.gson.GsonBuilder
import retrofit2.Retrofit
import retrofit2.converter.gson.GsonConverterFactory
import java.time.format.DateTimeFormatter

class PaquetSeleccionatFragment : Fragment(R.layout.paquet_seleccionat_fragment) {
    private var paquet: Package? = null

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        paquet = arguments?.getSerializable("paquet") as? Package
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)

        // ATENCIO MAMONS: tindriem que fer crides amb aquest paquet a la DB per saber
        // per on esta i aixi canviar les icones (tick o creu) per saber el seu estat

        Log.d(
            "paquet info",
            "Paquet Id = ${paquet?.Id}, Paquet Recollida = ${paquet?.DataEntrega}, Paquet Receptor = ${paquet?.Receptor}"
        )

        var id_paquet : TextView = view.findViewById(R.id.id_paquet_seleccionat)
        var recollida : TextView = view.findViewById(R.id.recollida)
        val dades_receptor: TextView = view.findViewById(R.id.dades_receptor)
        var imatge_estat_1: ImageView = view.findViewById(R.id.imatge_estat_1)
        var imatge_estat_2: ImageView = view.findViewById(R.id.imatge_estat_2)
        var imatge_estat_3: ImageView = view.findViewById(R.id.imatge_estat_3)
        var imatge_estat_4: ImageView = view.findViewById(R.id.imatge_estat_4)

        val formatDateTime = DateTimeFormatter.ofPattern("dd/MM/yyyy HH:mm")

        paquet?.let {
            id_paquet.text = it.Id.toString()
            recollida.text = it.DataEntrega?.format(formatDateTime)
            dades_receptor.text = it.Receptor
        }

        when (paquet!!.Status) {
            0 -> {
                imatge_estat_1.setImageResource(R.drawable.tick)
                imatge_estat_2.setImageResource(R.drawable.cross)
                imatge_estat_3.setImageResource(R.drawable.cross)
                imatge_estat_4.setImageResource(R.drawable.cross)
            }
            1 -> {
                imatge_estat_1.setImageResource(R.drawable.tick)
                imatge_estat_2.setImageResource(R.drawable.tick)
                imatge_estat_3.setImageResource(R.drawable.cross)
                imatge_estat_4.setImageResource(R.drawable.cross)
            }
            2 -> {
                imatge_estat_1.setImageResource(R.drawable.tick)
                imatge_estat_2.setImageResource(R.drawable.tick)
                imatge_estat_3.setImageResource(R.drawable.tick)
                imatge_estat_4.setImageResource(R.drawable.cross)
            }
            else -> {
                imatge_estat_1.setImageResource(R.drawable.tick)
                imatge_estat_2.setImageResource(R.drawable.tick)
                imatge_estat_3.setImageResource(R.drawable.tick)
                imatge_estat_4.setImageResource(R.drawable.tick)
            }
        }
    }
}