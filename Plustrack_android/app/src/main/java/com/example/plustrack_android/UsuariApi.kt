package com.example.plustrack_android

import retrofit2.Call
import retrofit2.Response
import retrofit2.http.Body
import retrofit2.http.GET
import retrofit2.http.POST
import retrofit2.http.Path
import retrofit2.http.Query

interface UsuariApi {
    @POST("/v1/users/login")
    suspend fun getUserFromDB(
        @Body loginRequest: LoginRequest
    ): Response<User>

    @POST("/v1/employees/login")
    suspend fun getDelivererFromDB(
        @Body loginRequest: LoginRequest
    ): Response<Deliverer>

    @POST("/v1/users/register")
    suspend fun postUser(
        @Query("name") name: String,
        @Query("surnames") surnames: String,
        @Query("email") email: String,
        @Query("password") password: String
    ): Response<User>
}