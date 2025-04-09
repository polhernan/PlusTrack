package com.example.plustrack_android

import java.util.Date

data class Employee(
    val id: String,
    val name: String,
    val surnames: String,
    val dni: String,
    val birthDate: Date,
    val email: String,
    val password: String,
    val companyId: String? = null,
)