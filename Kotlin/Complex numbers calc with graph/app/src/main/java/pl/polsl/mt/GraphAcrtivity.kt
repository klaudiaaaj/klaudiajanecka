package pl.polsl.mt

import android.graphics.Color
import android.os.Bundle
import android.view.View
import android.widget.Toast
import androidx.appcompat.app.AppCompatActivity
import com.jjoe64.graphview.GraphView
import com.jjoe64.graphview.GridLabelRenderer
import com.jjoe64.graphview.series.DataPoint
import com.jjoe64.graphview.series.DataPointInterface
import com.jjoe64.graphview.series.PointsGraphSeries
import com.jjoe64.graphview.series.Series
import java.lang.Math.abs
import kotlin.math.roundToInt


class GraphAcrtivity : AppCompatActivity() {

    lateinit var point: Complex
    override fun onCreate(savedInstanceState: Bundle?) {
        val mSize = 12
        super.onCreate(savedInstanceState)
        setContentView(pl.polsl.mt.R.layout.activity_graph)

        supportActionBar?.setDisplayHomeAsUpEnabled(true)
        point = takeAPoint()

        val maxY = kotlin.math.abs(setGrid(point.imag))
        val maxX = kotlin.math.abs(setGrid(point.real))
        val minX = -maxX
        val minY = -maxY

        val graph = findViewById<View>(pl.polsl.mt.R.id.graph) as GraphView
        val series = PointsGraphSeries(
                arrayOf<DataPoint>(
                        DataPoint(point.real, point.imag)
                )
        )
        graph.addSeries(series)
        series.color = Color.RED
        series.size = mSize.toFloat()
        series.shape = PointsGraphSeries.Shape.POINT
        series.setOnDataPointTapListener { series: Series<DataPointInterface>, dataPointInterface: DataPointInterface ->
            Toast.makeText(applicationContext, " Z = " + dataPointInterface.x + dataPointInterface.y + " i", Toast.LENGTH_SHORT).show()
        }

        graph.viewport.isYAxisBoundsManual = true
        graph.viewport.setMinY(minY)
        graph.viewport.setMaxY(maxY)

        graph.viewport.isXAxisBoundsManual = true
        graph.viewport.setMinX(minX)
        graph.viewport.setMaxX(maxX)

        graph.viewport.isScalable = true
        graph.viewport.setScalableY(true)
         graph.setPadding(0, 32, 64, 32)

        val gridLabel: GridLabelRenderer = graph.gridLabelRenderer
        gridLabel.horizontalAxisTitle = "Re"
        gridLabel.verticalAxisTitle = "Im"
        gridLabel.setHumanRounding(false)
        gridLabel.padding = 64

        graph.title = "Complex point graph";
    }

    private fun takeAPoint(): Complex {

        val temp = Complex(0.0, 0.0)
        temp.real = intent.getDoubleExtra("Real_EXTRA", 0.0)
        temp.imag = intent.getDoubleExtra("Imagine_EXTRA", 0.0)

        return temp
    }

    fun setGrid(size: Double): Double {

        if (size == 0.0 || abs(size) < 1)
            return 10.0

        val temp = size.roundToInt()
        val long = temp.toString().length

        return Math.pow(10.0, long.toDouble())
    }


}