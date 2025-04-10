package com.example.plustrack_android

import java.io.Serializable
import java.time.LocalDateTime

data class CreateUserRequest (
    val Name: String?,
    val Surnames: String?,
    val DeviceId: String?,
    val Email: String?,
    val Password: String?,
    val BirthDate: LocalDateTime?,
) : Serializable