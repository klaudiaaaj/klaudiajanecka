package pl.polsl.tm

import android.Manifest
import android.annotation.SuppressLint
import android.app.Activity
import android.content.Context
import android.content.Intent
import android.content.pm.PackageManager
import android.widget.ImageView
import android.graphics.Bitmap
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.os.Environment
import android.provider.MediaStore
import android.speech.RecognizerIntent
import android.speech.SpeechRecognizer
import android.webkit.JavascriptInterface
import android.widget.Toast
import java.util.*
import android.webkit.WebView
import androidx.core.app.ActivityCompat
import androidx.core.content.FileProvider
import java.io.File
import java.io.IOException

class MainActivity : AppCompatActivity() {

    private val RQ_SPEACH_REC = 102
    private val RQ_CAMERA = 42
    lateinit var page: WebView
    var presentGoogleNow: String? = null
    lateinit var currentPhotoPath: String

    @SuppressLint("SetJavastriptEnabled", "AddJavaScriptInterface")
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        webViewSetup()
        if (!hasPermissions(
                        this,
                        Manifest.permission.CAMERA,
                        Manifest.permission.WRITE_EXTERNAL_STORAGE,
                        Manifest.permission.ACCESS_FINE_LOCATION
                )
        ) {
            ActivityCompat.requestPermissions(
                    this,
                    arrayOf(
                            Manifest.permission.CAMERA,
                            Manifest.permission.WRITE_EXTERNAL_STORAGE,
                            Manifest.permission.ACCESS_FINE_LOCATION
                    ),
                    2)
        }
    }

    private fun webViewSetup() {
        page = WebView(this)
        page.settings.javaScriptEnabled = true
        page.addJavascriptInterface(this, "activity")
        page.loadUrl("file:///android_asset/page.html")

        setContentView(page)
    }

    @JavascriptInterface
    fun generate() {
        takePicture()
    }

    @JavascriptInterface
    fun getPresentsList() {
        speechToText()
    }

    @SuppressLint("QueryPermissionsNeeded")
    private fun takePicture() {
        if (!applicationContext.packageManager.hasSystemFeature(PackageManager.FEATURE_CAMERA)) {
            Toast.makeText(applicationContext, "No camera", Toast.LENGTH_SHORT).show()
            return
        }
        if (!hasPermissions(this, Manifest.permission.CAMERA, Manifest.permission.WRITE_EXTERNAL_STORAGE)) {
            ActivityCompat.requestPermissions(this, arrayOf(Manifest.permission.CAMERA, Manifest.permission.WRITE_EXTERNAL_STORAGE), 4)
            Toast.makeText(applicationContext, "Allow camera and access to the storage", Toast.LENGTH_LONG).show()
            return
        }
        Intent(MediaStore.ACTION_IMAGE_CAPTURE).also { takePictureIntent ->
            takePictureIntent.resolveActivity(packageManager)?.also {
                val photoFile: File? = try {
                    createImage()
                } catch (ex: IOException) {
                    null
                }
                photoFile?.also {
                    val imageURI = FileProvider.getUriForFile(this, "pl.polsl.tm.FileProvider", it)
                    takePictureIntent.putExtra(MediaStore.EXTRA_OUTPUT, imageURI)
                    startActivityForResult(takePictureIntent, RQ_CAMERA)
                }
            }
        }

    }

    @Throws(IOException::class)
    private fun createImage(): File {
        val storDir: File = getExternalFilesDir(Environment.DIRECTORY_PICTURES)!!
        return File.createTempFile(
                "android6",
                ".jpg",
                storDir
        ).apply {
            currentPhotoPath = absolutePath
        }
    }

    private fun hasPermissions(context: Context, vararg permissions: String): Boolean = permissions.all {
        ActivityCompat.checkSelfPermission(context, it) == PackageManager.PERMISSION_GRANTED

    }

    private fun speechToText(): String? {
        if (!SpeechRecognizer.isRecognitionAvailable(this)) {
            Toast.makeText(this, "Speech recognition is not avaible", Toast.LENGTH_SHORT).show()
        } else {
            val i = Intent(RecognizerIntent.ACTION_RECOGNIZE_SPEECH)
            i.putExtra(RecognizerIntent.ACTION_RECOGNIZE_SPEECH, RecognizerIntent.LANGUAGE_MODEL_FREE_FORM)
            i.putExtra(RecognizerIntent.EXTRA_LANGUAGE, Locale.ENGLISH)
            i.putExtra(RecognizerIntent.EXTRA_PROMPT, "Say about your dreams")
            startActivityForResult(i, RQ_SPEACH_REC)
        }
        return presentGoogleNow
    }

    override fun onActivityResult(requestCode: Int, resultCode: Int, data: Intent?) {

        if (resultCode == Activity.RESULT_OK) {
            if (requestCode == RQ_SPEACH_REC) {

                presentGoogleNow = (data?.getStringArrayListExtra(RecognizerIntent.EXTRA_RESULTS)
                        ?: ArrayList<String>())[0]

            }
            if (requestCode == RQ_CAMERA) {
                val intent = Intent(this, Card::class.java)
                intent.putExtra("presents", presentGoogleNow
                        ?: "Everything what I'm have dreaming about I already have")
                intent.putExtra("photoPath", currentPhotoPath)
                startActivity(intent)
            }

        } else {
            super.onActivityResult(requestCode, resultCode, data)

        }
    }

}
