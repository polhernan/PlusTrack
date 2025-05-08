package com.example.plustrack_android

import com.google.gson.annotations.SerializedName
import java.io.Serializable

data class Deliverer(
    @SerializedName("id") val Id: String,
    @SerializedName("dni") val Dni: String?,
    @SerializedName("name")val Name: String?,
    @SerializedName("surnames")val Surnames: String?,
    @SerializedName("deviceId")val DeviceId: String?,
    @SerializedName("email")val Email: String?,
    @SerializedName("password")val Password: String?,
    @SerializedName("birthDate")val BirthDate: String?
) : Serializable