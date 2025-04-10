package com.example.plustrack_android

import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.EditText
import android.widget.TextView
import androidx.fragment.app.Fragment
import com.google.gson.GsonBuilder
import retrofit2.Retrofit
import retrofit2.converter.gson.GsonConverterFactory
import java.time.format.DateTimeFormatter

class PaquetSeleccionatFragment : Fragment(R.layout.paquet_seleccionat_fragment) {

    private var paquet: Package? = null
    private lateinit var paquetApi: PaquetApi;

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)

        val gson = GsonBuilder()
            .setLenient()
            .create()

        val retrofit = Retrofit.Builder()
            .baseUrl("http://172.16.24.30/municipis//")
            .addConverterFactory(GsonConverterFactory.create(gson))
            .build()

        paquetApi = retrofit.create(PaquetApi::class.java)
        paquet = arguments?.getSerializable("paquet") as? Package
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)

        // ATENCIO MAMONS: tindriem que fer crides amb aquest paquet a la DB per saber
        // per on esta i aixi canviar les icones (tick o creu) per saber el seu estat

        var id_paquet : TextView = view.findViewById(R.id.id_paquet_seleccionat)
        var recollida : TextView = view.findViewById(R.id.recollida)
        val dades_receptor: TextView = view.findViewById(R.id.dades_receptor)

        val formatDateTime = DateTimeFormatter.ofPattern("dd/MM/yyyy HH:mm")

        paquet?.let {
            id_paquet.text = it.Id.toString()
            recollida.text = it.Receptor
            dades_receptor.text = it.DataEntrega.format(formatDateTime)
        }
    }
}