package pl.polsl.tm

import android.annotation.SuppressLint
import android.content.pm.ActivityInfo
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.webkit.JavascriptInterface
import android.webkit.WebView

@SuppressLint("JavascriptInterface", "AddJavascriptInterface", "SetJavaScriptEnabled",
        "SourceLockedOrientationActivity"
)
class Card : AppCompatActivity() {
    var presentsFromIntent: String? = null
    lateinit var photoUrl: String
    override fun onCreate(savedInstanceState: Bundle?) {
        requestedOrientation = ActivityInfo.SCREEN_ORIENTATION_LANDSCAPE
        super.onCreate(savedInstanceState)

        val page = WebView(this)

        page.settings.javaScriptEnabled = true
        page.addJavascriptInterface(this, "Card")
        page.loadUrl("file:///android_asset/card.html")
        setContentView(page)

        presentsFromIntent = intent.getStringExtra("presents")!!
        photoUrl = intent.getStringExtra("photoPath")!!

    }

    @JavascriptInterface
    fun getPresents(): String? {
        return presentsFromIntent ?: "Nothing to dream about"
    }

    @JavascriptInterface
    fun getPhoto(): String {
        return photoUrl
    }

}