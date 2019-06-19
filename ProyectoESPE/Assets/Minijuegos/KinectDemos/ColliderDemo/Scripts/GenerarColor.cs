using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerarColor : MonoBehaviour
{

    //public GameObject sheep, pig, duck, cow, chicken;
    public Text texto;
    //GameObject[] animals;
    string[] nombres = new string[4];
    int color = -1;
    public string nombreactivo = "";
    public AudioSource Amarillo, Azul, Rojo , pig;

    AudioSource[] colors = new AudioSource[4];

    // Use this for initialization
    void Start()
    {
        color = Random.Range(0, 3);
        colors[0] = Amarillo;
        nombres[0] = "Amarillo";
        colors[1] = Azul;
        nombres[1] = "Azul";
        colors[2] = Rojo;
        nombres[2] = "Rojo";
        colors[3] = pig;
        nombres[3] = "Oculto";
        texto.text = nombres[color];
    }

    public void CambiarColor()
    {
        color = Random.Range(0, 3);
        nombreactivo = nombres[color];
        texto.text = nombres[color];
        colors[color].Play();
    }
}