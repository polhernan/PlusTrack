package com.example.plustrack_android

import java.io.Serializable

data class Location(
    val id: String,
    val latitude: Double,
    val longitude: Double,
    val routeStops: List<RouteStop>? = null,
) : Serializable