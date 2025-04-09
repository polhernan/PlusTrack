package com.example.plustrack_android

import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.EditText
import android.widget.TextView
import androidx.fragment.app.Fragment
import java.time.format.DateTimeFormatter

class PaquetSeleccionatFragment : Fragment(R.layout.paquet_seleccionat_fragment) {

    private var paquet: Package? = null

    /*override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?, savedInstanceState: Bundle?
    ): View? {
        return inflater.inflate(R.layout.paquet_seleccionat_fragment, container, false)
    }*/

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)

        paquet = arguments?.getSerializable("paquet") as? Package
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)

        // ATENCIO MAMONS: tindriem que fer crides amb aquest paquet a la DB per saber
        // per on esta i aixi canviar les icones (tick o creu) per saber el seu estat

        var id_paquet : TextView = view.findViewById(R.id.id_paquet_seleccionat)
        var recollida : TextView = view.findViewById(R.id.recollida)
        var dades_receptor : TextView = view.findViewById(R.id.dades_receptor)
        val data_hora_demanat: TextView = view.findViewById(R.id.compra)
        val data_hora_estimada: TextView = view.findViewById(R.id.recollida)
        val dimensions: TextView = view.findViewById(R.id.dimensions)
        val fragil: TextView = view.findViewById(R.id.fragil)

        val formatDateTime = DateTimeFormatter.ofPattern("dd/MM/yyyy HH:mm")

        paquet?.let {
            id_paquet.text = it.id.toString()
            recollida.text = it.data_hora_estimada_entregar.format(formatDateTime)
            dades_receptor.text = it.receptor
            data_hora_demanat.text = it.data_hora_demanat.format(formatDateTime)
            data_hora_estimada.text = it.data_hora_estimada_entregar.format(formatDateTime)
            dimensions.text = "${it.dimensions.first} x ${it.dimensions.second} x ${it.dimensions.third}"
            fragil.text = if (it.isFragil) "És fràgil" else "No és fràgil"
        }
    }
}