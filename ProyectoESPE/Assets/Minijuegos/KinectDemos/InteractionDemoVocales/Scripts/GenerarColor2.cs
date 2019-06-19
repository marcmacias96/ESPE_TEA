using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerarColor2 : MonoBehaviour
{

    //public GameObject sheep, pig, duck, cow, chicken;
    public Text texto;
    //GameObject[] animals;
    string[] nombres = new string[6];
    int color = -1;
    public string nombreactivo = "";
    public AudioSource a, e, i,o,u, s;

    AudioSource[] colors = new AudioSource[6];

    // Use this for initialization
    void Start()
    {
        color = Random.Range(0, 5);
        colors[0] = a;
        nombres[0] = "a";
        colors[1] = e;
        nombres[1] = "e";
        colors[2] = i;
        nombres[2] = "i";
        colors[3] = o;
        nombres[3] = "o";
        colors[4] = u;
        nombres[4] = "u";
        colors[5] = s;
        nombres[5] = "s";
        texto.text = nombres[color];
    }

    public void CambiarColor2()
    {
        color = Random.Range(0, 5);
        nombreactivo = nombres[color];
        texto.text = nombres[color];
        colors[color].Play();
    }

}