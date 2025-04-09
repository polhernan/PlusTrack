package com.example.plustrack_android

import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.ImageView
import android.widget.TextView
import androidx.recyclerview.widget.RecyclerView
import com.bumptech.glide.Glide

class NoticiaAdapter(private val llistaNoticies: List<Noticia>) :
    RecyclerView.Adapter<NoticiaAdapter.NoticiaViewHolder>() {

    class NoticiaViewHolder(view: View) : RecyclerView.ViewHolder(view) {
        val imatgeNoticia: ImageView = view.findViewById(R.id.imatge_noticia)
        val titolNoticia: TextView = view.findViewById(R.id.titol_noticia)
        val descripcioNoticia: TextView = view.findViewById(R.id.descripcio_noticia)
    }

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): NoticiaViewHolder {
        val view = LayoutInflater.from(parent.context)
            .inflate(R.layout.cardview_noticia, parent, false)
        return NoticiaViewHolder(view)
    }

    override fun getItemCount() = llistaNoticies.size

    override fun onBindViewHolder(holder: NoticiaViewHolder, position: Int) {
        val noticia = llistaNoticies[position]
        holder.titolNoticia.text = noticia.titol
        holder.descripcioNoticia.text = noticia.descripcio
        Glide.with(holder.itemView.context).load(noticia.imatge).into(holder.imatgeNoticia)
    }
}