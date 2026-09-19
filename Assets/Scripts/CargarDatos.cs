using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
using UnityEngine.SceneManagement;

public class CargarDatos : MonoBehaviour
{
    public TMP_InputField campoNombre;
    public TMP_Text topScoreText;

    void Start()
    {
        string ruta = Application.persistentDataPath + "/datosJugador.json";

        if (File.Exists(ruta))
        {
            string json = File.ReadAllText(ruta);

            DatosJugador datos = JsonUtility.FromJson<DatosJugador>(json);

            topScoreText.text = "Top Score: " + datos.nombreTopScore + " : " + datos.puntuacionTopScore;
        }
    }

    public void Cargar()
    {
        string ruta = Application.persistentDataPath + "/datosJugador.json";

        DatosJugador datos;

        if (File.Exists(ruta))
        {
            string jsonCargado = File.ReadAllText(ruta);

            datos = JsonUtility.FromJson<DatosJugador>(jsonCargado);
        }
        else
        {
            datos = new DatosJugador();

            datos.nombreTopScore = "";
            datos.puntuacionTopScore = 0;
        }

        datos.nombreJugador = campoNombre.text;

        string json = JsonUtility.ToJson(datos);

        File.WriteAllText(ruta, json);

        SceneManager.LoadScene(1);
    }
}
