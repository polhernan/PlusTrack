package com.example.plustrack_android

import retrofit2.Call
import retrofit2.http.GET
import retrofit2.http.Path

interface PaquetApi {
    @GET("paquets/{id}")
    suspend fun getPaquet(
        @Path("id") id: Int
    ): Package

    @GET("paquets")
    suspend fun getAllPaquets(): List<Package>
}