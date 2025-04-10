package com.example.plustrack_android

import com.google.gson.GsonBuilder
import okhttp3.OkHttpClient
import okhttp3.logging.HttpLoggingInterceptor
import retrofit2.Retrofit
import retrofit2.converter.gson.GsonConverterFactory

object RetrofitUsuari {

    private const val BASE_URL = "http://172.16.24.23:5184/"

    private val loggingInterceptor = HttpLoggingInterceptor().apply {
        level = HttpLoggingInterceptor.Level.BODY
    }

    private val client = OkHttpClient.Builder()
        .addInterceptor(loggingInterceptor)
        .build()

    private val gson = GsonBuilder().setLenient().create()

    private val retrofit: Retrofit by lazy {
        Retrofit.Builder()
            .baseUrl(BASE_URL)
            .client(client)
            .addConverterFactory(GsonConverterFactory.create(gson))
            .build()
    }
    val apiService: UsuariApi by lazy {
        retrofit.create(UsuariApi::class.java)
    }

    /*suspend fun getUserFromDB(email: String, password: String): User {
        return try {
            val loginRequest = LoginRequest(email, password)
            apiService.getUserFromDB(loginRequest)
        } catch (e: Exception) {
            throw Exception("Error en la petición: ${e.message}")
        }
    }*/

}