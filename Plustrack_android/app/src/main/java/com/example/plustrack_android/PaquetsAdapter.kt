package com.example.plustrack_android

import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.ImageView
import android.widget.TextView
import androidx.fragment.app.FragmentManager
import androidx.recyclerview.widget.RecyclerView
import com.bumptech.glide.Glide
import java.time.LocalDateTime
import java.time.format.DateTimeFormatter

class PaquetsAdapter(
    private val llistaPaquets: List<Package>,
    private val onItemClick: (Package) -> Unit,
) :  RecyclerView.Adapter<PaquetsAdapter.PaquetViewHolder>() {

    class PaquetViewHolder(view: View) : RecyclerView.ViewHolder(view) {

        var id_paquet : TextView = view.findViewById(R.id.id_paquet)
        var data_hora_estimada_entregar : TextView = view.findViewById(R.id.data_hora_estimada_entregar)

        fun bind(paquet: Package, onItemClick: (Package) -> Unit) {
            id_paquet.text = paquet.Id.toString()
            data_hora_estimada_entregar.text = paquet.DataEntrega.toString()

            itemView.setOnClickListener {
                onItemClick(paquet)
            }
        }
    }

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): PaquetViewHolder {
        val view = LayoutInflater.from(parent.context)
            .inflate(R.layout.cardview_paquets, parent, false)
        return PaquetViewHolder(view)
    }

    override fun getItemCount() = llistaPaquets.size

    override fun onBindViewHolder(holder: PaquetViewHolder, position: Int) {
        holder.bind(llistaPaquets[position], onItemClick)
    }
}