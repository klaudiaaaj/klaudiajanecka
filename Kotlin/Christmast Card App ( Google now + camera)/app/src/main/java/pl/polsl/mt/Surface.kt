package pl.polsl.mt.klaudiajanecka

import android.content.Context
import android.media.MediaPlayer
import android.opengl.GLSurfaceView


class Surface(context: Context?) : GLSurfaceView(context) {
    private val mediaPlayer: MediaPlayer = MediaPlayer.create(context, R.raw.ball)
    private val renderingProcess: pl.polsl.mt.klaudiajanecka.RenderingProcess = RenderingProcess(mediaPlayer)
    private var start = false

    init
    {
        setRenderer(renderingProcess)
        start = true
    }

    fun moveObject(acceleration: Float)
    {
        renderingProcess.changeMotion(acceleration)
    }

    fun isReady() : Boolean
    {
        return start
    }

}