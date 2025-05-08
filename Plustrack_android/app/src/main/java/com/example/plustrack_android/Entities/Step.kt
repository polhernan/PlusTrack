package com.example.inadal_projecte_mapes.Entities

data class Step(
    val distance: Double,
    val duration: Double,
    val instruction: String,
    val name: String,
    val type: Int,
    val way_points: List<Int>
)