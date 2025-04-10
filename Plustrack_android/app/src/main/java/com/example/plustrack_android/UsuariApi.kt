package com.example.plustrack_android

import retrofit2.Call
import retrofit2.http.Body
import retrofit2.http.GET
import retrofit2.http.POST
import retrofit2.http.Path

interface UsuariApi {
    @POST("/v1/users/login")
    suspend fun getUserFromDB(
        @Body loginRequest: LoginRequest
    ): User

    @POST("/v1/users/register")
    suspend fun postUser(
        @Body createUserRequest : CreateUserRequest
    ): User

    @GET("/v1/users/{id}")
    suspend fun getUser(
        @Path("id") id: Int
    ): User

    @GET("/v1/users")
    suspend fun getAllUsers(): List<User>

    @POST("/v1/employees/login")
    suspend fun GetEmployeeFromDB(
        @Body loginRequest: LoginRequest
    ): Employee
}