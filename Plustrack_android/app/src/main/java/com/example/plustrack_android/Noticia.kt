package com.example.plustrack_android

data class Noticia(
    val titol: String,
    val descripcio: String,
    val imatge: String
)

val noticiaInfo = listOf(
    Noticia("Obrim PlusTrack!", "Obertura de la nostre empresa", "https://www.signs.com/blog/wp-content/uploads/2012/05/Grand-Opening.jpg"),
    Noticia("Titol d'exemple", "Descripcio d'exemple", "https://www.signs.com/blog/wp-content/uploads/2012/05/Grand-Opening.jpg"),
)
