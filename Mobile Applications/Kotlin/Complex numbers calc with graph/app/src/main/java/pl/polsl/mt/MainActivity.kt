package pl.polsl.mt

import android.content.Context
import android.content.Intent
import android.os.Bundle
import android.view.View
import android.view.ViewGroup
import android.view.inputmethod.InputMethodManager
import android.widget.*
import androidx.appcompat.app.AppCompatActivity


class Complex(internal var real: Double = 0.0, internal var imag: Double = 0.0) {

}

class MainActivity : AppCompatActivity(), AdapterView.OnItemSelectedListener {

    lateinit var B: Complex
    lateinit var A: Complex
    var result = Complex(0.0, 0.0)
    private lateinit var reATextView: TextView
    private lateinit var reBTextView: TextView
    private lateinit var imATextView: TextView
    private lateinit var imBTextView: TextView


    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        val addButton: Button = findViewById(R.id.additionButton)
        val subtractionButton: Button = findViewById(R.id.subtitutionButton)
        val grapButton: Button = findViewById(R.id.graphButton)
        val spinner: Spinner = findViewById(R.id.spinner)

        addButton.setOnClickListener {
            result = performAddition()
            Toast.makeText(
                    applicationContext,
                    "Sum is equal to ${result.real} + ${result.imag}i ",
                    Toast.LENGTH_LONG
            )
                    .show();
        }

        subtractionButton.setOnClickListener {
            result = performSubtraction()
            Toast.makeText(
                    applicationContext,
                    "Difference is equal to ${result.real} + ${result.imag}i ",
                    Toast.LENGTH_LONG
            )
                    .show();
        }
        grapButton.setOnClickListener()
        {
            val intent = Intent(this, GraphAcrtivity::class.java)
            intent.putExtra("Real_EXTRA", result.real)
            intent.putExtra("Imagine_EXTRA", result.imag)

            startActivity(intent)
        }
        val list: MutableList<String> = ArrayList()
        list.add("Additon")
        list.add("Substraction")
        list.add("[Select one]")
        val listsize = list.size - 1

        val dataAdapter: ArrayAdapter<String?> = object : ArrayAdapter<String?>(this, android.R.layout.simple_spinner_item, list as List<String?>) {
            override fun getCount(): Int {
                return listsize
            }
        }

        dataAdapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item)
        spinner.setAdapter(dataAdapter)
        spinner.setSelection(listsize) // Hidden item to appear in the spinner
        spinner.onItemSelectedListener = this

    }

    fun performSubtraction(): Complex {
        createComplexObj()
        return subtract()
    }

    fun performAddition(): Complex {
        createComplexObj()
        return add()
    }

    private fun createComplexObj() {

        reATextView = findViewById(R.id.reA)
        reBTextView = findViewById(R.id.reB)
        imATextView = findViewById(R.id.imA)
        imBTextView = findViewById(R.id.imB)

        val reA: Double =
                if (reATextView.text.isBlank()) 0.0 else reATextView.text.toString().toDouble()
        val reB: Double =
                if (reBTextView.text.isBlank()) 0.0 else reBTextView.text.toString().toDouble()
        val imA: Double =
                if (imATextView.text.isBlank()) 0.0 else imATextView.text.toString().toDouble()
        val imB: Double =
                if (imBTextView.text.isBlank()) 0.0 else imBTextView.text.toString().toDouble()

        A = Complex(reA, imA)
        B = Complex(reB, imB)

    }

    private fun add(): Complex {
        val temp = Complex(0.0, 0.0)

        temp.real = A.real + B.real
        temp.imag = A.imag + B.imag
        return temp

    }

    private fun subtract(): Complex {
        val temp = Complex(0.0, 0.0)

        temp.real = A.real - B.real
        temp.imag = A.imag - B.imag

        return temp

    }

    override fun onItemSelected(
            parent: AdapterView<*>?,
            view: View?,
            position: Int,
            id: Long
    ) {

        var selected = parent?.getItemAtPosition(position).toString()
        if (selected.equals("Additon")) {
            result = performAddition()
            Toast.makeText(
                    applicationContext,
                    "Sun is equal to ${result.real} + ${result.imag}i ",
                    Toast.LENGTH_LONG
            )
                    .show();
            selected = ""
        } else if (selected.equals("Substraction")) {
            result = performSubtraction()
            Toast.makeText(
                    applicationContext,
                    "Difference is equal to ${result.real} + ${result.imag}i ",
                    Toast.LENGTH_LONG
            )
                    .show();
        }
    }


    override fun onNothingSelected(parent: AdapterView<*>?) {
        Toast.makeText(
                applicationContext,
                ("Nothing is Selected"), Toast.LENGTH_LONG
        )
                .show();
    }

}

