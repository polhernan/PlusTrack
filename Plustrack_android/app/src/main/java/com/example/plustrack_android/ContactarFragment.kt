package com.example.plustrack_android

import android.os.Bundle
import android.text.Html
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.TextView
import androidx.constraintlayout.widget.ConstraintLayout
import androidx.fragment.app.Fragment
import com.google.android.material.bottomnavigation.BottomNavigationView

class ContactarFragment : Fragment(R.layout.contactar_fragment) {

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?, savedInstanceState: Bundle?
    ): View? {
        return inflater.inflate(R.layout.contactar_fragment, container, false)
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)

        val textContacte = getString(R.string.Info_contactar)

        val formattedText = Html.fromHtml(textContacte, Html.FROM_HTML_MODE_LEGACY)

        val textView = view.findViewById<TextView>(R.id.info)
        textView.text = formattedText
    }
}