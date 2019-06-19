using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Selecion2  : MonoBehaviour
{

    public GameObject KinectControl;
    public Text texto;
    string activeobjname = "";
    GrabDropScriptVoc sc;
    GenerarColor2 gen;
    bool ok = false;
    int puntos = -1;



    // Use this for initialization
    void Start()
    {
        sc = KinectControl.GetComponent<GrabDropScriptVoc>();
        gen = KinectControl.GetComponent<GenerarColor2>();

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
            gen.CambiarColor2();
        }
        else if (!activeobjname.Equals(gen.nombreactivo) && !activeobjname.Equals(""))
        {
            gen.CambiarColor2();
            sc.objname = "";
        }
    }
}
