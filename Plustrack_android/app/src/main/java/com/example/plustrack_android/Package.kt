package com.example.plustrack_android

import com.google.gson.annotations.SerializedName
import java.time.LocalDateTime
import java.io.Serializable

data class Package(
    @SerializedName("id") val Id: String,
    @SerializedName("status") val Status: Int, //0 = Creado, 1 = En transito, 2 = En reparto, 3 = Entregado
    @SerializedName("timeToDeliver") val DataEntrega: String?,
    @SerializedName("receptor") val Receptor: String,
    @SerializedName("location") val Location: Location?,
    //@SerializedName("timeToDeliver") val TimeToDeliver: String?
) : Serializable
