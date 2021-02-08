package pl.polsl.mt.klaudiajanecka

import android.content.Context
import android.content.pm.ActivityInfo
import android.hardware.Sensor
import android.hardware.SensorEvent
import android.hardware.SensorEventListener
import android.hardware.SensorManager
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle

class MainActivity : AppCompatActivity(), SensorEventListener {

    private lateinit var surface: Surface
    private lateinit var sensor: SensorManager

    override fun onCreate(savedInstanceState: Bundle?) {

        sensor = getSystemService(Context.SENSOR_SERVICE) as SensorManager
        val accelerometer = sensor.getDefaultSensor(Sensor.TYPE_ACCELEROMETER)

        sensor.registerListener(this, accelerometer, SensorManager.SENSOR_DELAY_GAME)

        super.onCreate(savedInstanceState)
        requestedOrientation = ActivityInfo.SCREEN_ORIENTATION_LANDSCAPE
        surface = Surface(applicationContext)

        setContentView(surface)
    }

    override fun onAccuracyChanged(sensor: Sensor?, accuracy: Int) {

    }

    override fun onSensorChanged(event: SensorEvent?) {
        if(surface.isReady()){
            var acceleration = event?.values?.get(1).toString().toFloat()
            if(acceleration < -0.2f || acceleration > 0.2f)
            {
                surface.moveObject(acceleration)
            }
            else if(acceleration < -10f)
            {
                acceleration = -10f
                surface.moveObject(acceleration)
            }
            else if(acceleration > 10f)
            {
                acceleration = 10f
                surface.moveObject(acceleration)
            }

        }
    }
}