package com.example.plustrack_android

import retrofit2.Call
import retrofit2.http.GET
import retrofit2.http.Path

interface UsuariApi {
    @GET("user/{id}")
    suspend fun getUser(
        @Path("id") id: Int
    ): User

    @GET("user")
    suspend fun getAllUsers(): List<User>
}