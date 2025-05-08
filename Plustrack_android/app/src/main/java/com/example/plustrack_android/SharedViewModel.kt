package com.example.plustrack_android

import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel

class SharedViewModel : ViewModel() {
    var user = MutableLiveData<User>()
    var deliverer = MutableLiveData<Deliverer>()
    var packageData = MutableLiveData<Package>()
}