package com.example.inadal_projecte_mapes.Entities

data class Directions(
    val bbox: List<Double>,
    val features: List<Feature>,
    val metadata: Metadata,
    val type: String,
    val routes: List<Route>
)