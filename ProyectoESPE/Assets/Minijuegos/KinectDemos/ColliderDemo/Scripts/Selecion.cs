using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Selecion  : MonoBehaviour
{

    public GameObject KinectControl;
    public Text texto;
    string activeobjname = "";
    GrabDropScript sc;
    GenerarColor gen;
    bool ok = false;
    int puntos = -1;



    // Use this for initialization
    void Start()
    {
        sc = KinectControl.GetComponent<GrabDropScript>();
        gen = KinectControl.GetComponent<GenerarColor>();

    }

    // Update is called once per frame
    void Update()
    {
        activeobjname = sc.objname;
        if (activeobjname.Equals(gen.nombreactivo))
        {
            puntos++;
            texto.text = "Puntos: " + puntos;
            print("nombre activo: " + activeobjname + " puntos: " + puntos);
            sc.objname = "";
            gen.CambiarColor();
        }
        else if (!activeobjname.Equals(gen.nombreactivo) && !activeobjname.Equals(""))
        {
            gen.CambiarColor();
            sc.objname = "";
        }
    }
}
