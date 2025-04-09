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

        val id: TextView = view.findViewById(R.id.id_paquet)
        val editTextEstimada = view.findViewById<TextView>(R.id.data_hora_estimada_entregar)
        private val formatter = DateTimeFormatter.ofPattern("dd/MM/yyyy HH:mm")

        fun bind(paquet: Package, onItemClick: (Package) -> Unit) {
            id.text = paquet.id.toString()
            editTextEstimada.text = paquet.data_hora_estimada_entregar.format(formatter)

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