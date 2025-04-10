package com.example.plustrack_android

import java.io.Serializable

data class LoginRequest (
    val email: String,
    val password: String
) : Serializable