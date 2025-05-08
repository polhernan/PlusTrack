package com.example.inadal_projecte_mapes.Entities

data class Metadata(
    val attribution: String,
    val engine: Engine,
    val query: Query,
    val service: String,
    val timestamp: Long
)