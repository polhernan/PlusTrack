package com.example.plustrack_android

import java.io.Serializable
import java.util.UUID

data class RouteStop(
    val id: String,
    val stopOrder: Int,
    val location: Location? = null,
    val locationId: String? = null,
    val pack: Package? = null,
    val packageId: UUID? = null
) : Serializable
