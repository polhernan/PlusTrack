package com.example.plustrack_android

import com.google.gson.annotations.SerializedName
import java.io.Serializable
import java.time.LocalDateTime

data class User(
    @SerializedName("id") val Id: String,
    @SerializedName("name")val Name: String?,
    @SerializedName("surnames")val Surnames: String?,
    @SerializedName("deviceId")val DeviceId: String?,
    @SerializedName("email")val Email: String?,
    @SerializedName("password")val Password: String?,
) : Serializable