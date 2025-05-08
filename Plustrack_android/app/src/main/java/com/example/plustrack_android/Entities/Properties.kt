package com.example.inadal_projecte_mapes.Entities

data class Properties(
    val segments: List<Segment>,
    val summary: Summary,
    val way_points: List<Int>
)