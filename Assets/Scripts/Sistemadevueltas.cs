using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sistemadevueltas : MonoBehaviour
{
    public float timer = 0;
    private bool startTimer = false;
    public float bestLapTime = float.MaxValue;
    private int lapCount = 0;

    private bool checkpoint1 = false;
    private bool checkpoint2 = false;

    public Text Tiempo;
    public Text Vueltas;

    void Start()
    {
        // Inicializar los textos al inicio del juego
        UpdateUITexts();
    }

    void Update()
    {
        if (startTimer)
        {
            timer += Time.deltaTime;

            // Actualizar los textos en cada frame
            UpdateUITexts();
        }
    }

void OnTriggerEnter(Collider other)
{
    Debug.Log("Triggered: " + other.gameObject.name);

    if (other.gameObject.name == "Startfine")
    {
        Debug.Log("Passed StartFinish");

        if (checkpoint1 && checkpoint2)
        {
            Debug.Log("Completed a lap");

            startTimer = false;

            if (timer < bestLapTime)
            {
                bestLapTime = timer;
                Debug.Log("New best lap time: " + bestLapTime.ToString("F2"));
            }

            lapCount++;
            startTimer = true;
            timer = 0;
            checkpoint1 = false;
            checkpoint2 = false;
        }
    }

        if (other.gameObject.name == "checkpoint1")
        {
            Debug.Log("Passed checkpoint1");
            checkpoint1 = true;
        }

        if (other.gameObject.name == "checkpoint2")
        {
            Debug.Log("Passed checkpoint2");
            checkpoint2 = true;
        }
    }

    void UpdateUITexts()
    {
        // Actualizar los textos de Tiempo y Vueltas con los valores actuales
        Tiempo.text = timer.ToString("F2"); // Convertir el tiempo a string con 2 decimales
        Vueltas.text = lapCount.ToString(); // Convertir el número de vueltas a string
    }
}
