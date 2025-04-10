package com.example.plustrack_android

import java.time.LocalDateTime
import java.io.Serializable

data class Package(
    val Id: String,
    val Status: Int,
    val DataEntrega: LocalDateTime,
    val Receptor: String,
) : Serializable

    val paquetInfo = listOf(
        Package(
            Id = "458742",
            Status = 1,
            DataEntrega = LocalDateTime.now(),
            Receptor = "Pol Hernan Camino"
        )
    )
