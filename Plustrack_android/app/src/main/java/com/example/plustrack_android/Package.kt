package com.example.plustrack_android

import java.time.LocalDateTime
import java.io.Serializable

data class Package(
    val id: Int,
    val receptor: String,
    val data_hora_estimada_entregar: LocalDateTime
) : Serializable

    val paquetInfo = listOf(
        Package(
            id = 1,
            receptor = "Joan Pérez",            //any, mes, dia, hora, minuts, segons, ni idea
            data_hora_estimada_entregar = LocalDateTime.of(2024, 4, 10, 9, 0, 0, 0),
        )
        ,
        Package(
            id = 2,
            receptor = "Laura Martí",
            data_hora_estimada_entregar = LocalDateTime.now().plusDays(1),
        )
    )
