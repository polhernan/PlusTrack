package com.example.inadal_projecte_mapes.Entities

data class Query(
    val coordinates: List<List<Double>>,
    val format: String,
    val profile: String,
    val profileName: String
)