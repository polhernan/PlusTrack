package com.example.plustrack_android

import com.google.gson.GsonBuilder
import okhttp3.OkHttpClient
import retrofit2.Retrofit
import retrofit2.converter.gson.GsonConverterFactory
import okhttp3.logging.HttpLoggingInterceptor

object RetrofitPaquet {
    private const val BASE_URL = "http://172.16.24.30/plustrack/"

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
    val apiService: PaquetApi by lazy {
        retrofit.create(PaquetApi::class.java)
    }

    suspend fun getPaquet(id: Int): Package {
        return try {
            apiService.getPaquet(id)
        } catch (e: Exception) {
            throw Exception("Error en la petició: ${e.message}")
        }
    }

    suspend fun getAllPaquets(): List<Package> {
        return try {
            apiService.getAllPaquets()
        } catch (e: Exception) {
            throw Exception("Error en la petició: ${e.message}")
        }
    }
}