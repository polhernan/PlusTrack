package com.example.plustrack_android

import com.example.inadal_projecte_mapes.Entities.Directions
import retrofit2.Call
import retrofit2.Response
import retrofit2.http.Body
import retrofit2.http.GET
import retrofit2.http.POST
import retrofit2.http.PUT
import retrofit2.http.Path
import retrofit2.http.Query

interface PaquetApi {
    @GET("/v1/packages/next-package-employee/{employeeId}")
    suspend fun getPackageToDeliver(
        @Path("employeeId") Id: String
    ): Response<Package> // Package SEGUENT A ENTREGAR

    @GET("/v1/packages/by-user-id/{userId}")
    suspend fun getAllUserPackages(
        @Path("userId") Id: String
    ): Response<List<Package>>

    @GET("/v1/packages/package-amount/{employeeId}")
    suspend fun getTotalPackagesToDeliver(
        @Path("employeeId") Id: String
    ): Response<Int> // TOTAL PAQUETES DE ENTREGAR

    @GET("/v1/packages/{packageId}")
    suspend fun getPackageById(
        @Path("packageId") Id: String
    ): Response<Package>

    @PUT("/v1/packages/package-status/{packageId}/{packageStatus}")
    suspend fun postPackageState(
        @Path("packageId") Id: String,
        @Path("packageStatus") State: Int
    ): Response<Void> // packageStatus = 0: Sin entregar, packageStatus = 1: Entregado

    @GET("ors/v2/directions/driving-car")
    suspend fun getRuta(
        //@Query("api_key") api_key: String,
        @Query("start") start: String,
        @Query("end") end: String
    ): Response<Directions>

    @POST("/v1/employees/add-location/{employeeId}")
    suspend fun postCurrentUbication(
        @Path("employeeId") employeeId: String,
        @Body driverLocation: Location,
    ): Response<Void>
}