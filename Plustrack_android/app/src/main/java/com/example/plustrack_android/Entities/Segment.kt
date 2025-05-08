package com.example.inadal_projecte_mapes.Entities

data class Segment(
    val distance: Double,
    val duration: Double,
    val steps: List<Step>
)