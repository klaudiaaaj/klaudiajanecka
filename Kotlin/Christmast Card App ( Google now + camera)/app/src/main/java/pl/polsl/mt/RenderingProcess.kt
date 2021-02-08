package pl.polsl.mt.klaudiajanecka

import android.content.res.Resources
import android.media.MediaPlayer
import android.opengl.GLSurfaceView
import android.opengl.GLU
import android.os.SystemClock
import java.nio.ByteBuffer
import java.nio.ByteOrder
import java.nio.FloatBuffer
import javax.microedition.khronos.egl.EGLConfig
import javax.microedition.khronos.opengles.GL10
import kotlin.math.abs
import kotlin.math.cos
import kotlin.math.sin

class RenderingProcess(private val mediaPlayer: MediaPlayer) : GLSurfaceView.Renderer{

    private lateinit var vertexBuffer: FloatBuffer
    private val circleAccuracy = 200
    private val smallestAngle = 360 / circleAccuracy * 3 * (Math.PI / 180)

    private val dampening = -0.5f
    private var possition = 0f
    private var speed = 0f
    private var accelerationNow = 0f
    private val height = Resources.getSystem().displayMetrics.heightPixels.toFloat()
    private val width = Resources.getSystem().displayMetrics.widthPixels.toFloat()
    private val possibleDataChange: Float = (height * 0.2f) / width
    private val bounds: Float = 0.8f
    private var timeChange: Long = SystemClock.elapsedRealtime()
    private var speedChange: Long = SystemClock.elapsedRealtime()

    override fun onDrawFrame(gl: GL10?)
    {
        updatePosition()
        gl?.glClear(GL10.GL_COLOR_BUFFER_BIT)
        gl?.glLoadIdentity()
        gl?.glTranslatef(possition, 0f, 0f)
        gl?.glPushMatrix()
        gl?.glColor4f(0f, 0f, 1f, 1f)
        gl?.glScalef(0.2f, possibleDataChange, 0f)
        gl?.glEnableClientState(GL10.GL_VERTEX_ARRAY)
        gl?.glVertexPointer(3, GL10.GL_FLOAT, 0, vertexBuffer)
        gl?.glDrawArrays(GL10.GL_TRIANGLE_FAN, 0, circleAccuracy / 2)
        gl?.glDisableClientState(GL10.GL_VERTEX_ARRAY)
        gl?.glPopMatrix()
    }
    override fun onSurfaceChanged(gl: GL10?, width: Int, height: Int)
    {
        gl?.glViewport(0,0,width,height)
        gl?.glMatrixMode(GL10.GL_PROJECTION)
        gl?.glLoadIdentity()
        GLU.gluPerspective(gl, 45f, 0.5f, -1f, -10f)
        gl?.glClearColor(0f, 0.7f, 0.1f, 1f)
    }
    private fun createBall()
    {
        val vertices = FloatArray((circleAccuracy) * 3 / 2)
        for (i in 0..((circleAccuracy - 1) * 3 / 2) step 3){
            val ithSmallestAngle = i * smallestAngle
            vertices[i] = cos(ithSmallestAngle).toFloat()
            vertices[i + 1] = sin(ithSmallestAngle).toFloat()
            vertices[i + 2] = 0f
        }
        val byteBuffer: ByteBuffer = ByteBuffer.allocateDirect(vertices.size * 4)
        byteBuffer.order(ByteOrder.nativeOrder())
        vertexBuffer = byteBuffer.asFloatBuffer()
        vertexBuffer.put(vertices)
        vertexBuffer.position(0)
    }

    private fun onCollision(current: Float)
    {
        possition = current * bounds
        speed *= dampening
        if(abs(speed) < 0.67f)
            speed = 0f
        else
            mediaPlayer.start()
    }

    private fun updatePosition()
    {
        val timeDifference = (SystemClock.elapsedRealtime() - timeChange) / 1000f
        timeChange = SystemClock.elapsedRealtime()
        possition += (speed * timeDifference + 0.5f * accelerationNow * timeDifference * timeDifference) / 5f
        speed += accelerationNow * ((SystemClock.elapsedRealtime() - speedChange) / 1000f)
        speedChange = SystemClock.elapsedRealtime()

        when
        {
            possition <= -bounds ->
            {
                onCollision(-1f)
            }
            possition >= bounds ->
            {
                onCollision(1f)
            }
        }
    }


    override fun onSurfaceCreated(gl: GL10?, config: EGLConfig?) {
        createBall()
    }

    fun changeMotion(acceleration: Float){

        val timeDifference = (SystemClock.elapsedRealtime() - timeChange) / 1000f
        possition += (speed * timeDifference + 0.5f * accelerationNow * timeDifference * timeDifference) / 5f
        timeChange = SystemClock.elapsedRealtime()

        speed += accelerationNow * ((SystemClock.elapsedRealtime() - speedChange) / 1000f)
        speedChange = SystemClock.elapsedRealtime()
        accelerationNow = acceleration

        if(possition > bounds)
            possition = bounds
        else if (possition <-bounds)
            possition = -bounds
    }

}