package com.example.plustrack_android

import java.io.Serializable
import java.time.LocalDateTime

data class User(
    val Id: String,
    val Name: String?,
    val Surnames: String?,
    val DeviceId: String?,
    val Email: String?,
    val Password: String?,
    val BirthDate: LocalDateTime?, //YYYY-MM-DDTHH:MM:SS
    //import java.time.Istant
    //import java.time.format.DateTimeFormatter
    //DateTimeFormatter.ISO_INSTANT.format(nowUtc)
) : Serializable

val userInfo = listOf(
    User(
        Id = "1",
        Name = "Joan",
        Surnames = "Lopez Gort",
        DeviceId = "1",
        Email = "jlopezgort@gmail.com",
        Password = "123456",
        BirthDate = LocalDateTime.now()
    )
    ,User(
        Id = "2",
        Name = "Abraham",
        Surnames = "Garcia Nuñez",
        DeviceId = "2",
        Email = "agarcianunez@gmail.com",
        Password = "123456",
        BirthDate = LocalDateTime.now()
    )

)