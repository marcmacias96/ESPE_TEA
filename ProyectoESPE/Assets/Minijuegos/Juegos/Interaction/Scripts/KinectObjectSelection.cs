    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class KinectObjectSelection : MonoBehaviour {

    //Es el objeto KinectController
	public GameObject kinectcontrol;
    //public Text texto;
    //El nombre del objeto seleccionado actualmente
    string activeobjname="";
    //El Script del Kinect para Seleccionar Objetos
	GrabDropScript sc;
    //El string que se envia desde otro script para comprobar que sea el seleccionado, puede ser un color o nombre cualquiera, pero debe hacer referencia al nombre del objeto que se desea seleccionar
    private static string color;
    //Es para saber si el nombre del objeto seleccionado es el mismo del que se envio desde otro script. Comparacion hecha con variable color
    private static bool isColorSelected = false;
    


	// Use this for initialization
	void Start () {
		sc=kinectcontrol.GetComponent<GrabDropScript>();
	}
	
	// Update is called once per frame
	void Update () {	
        //Toma el nombre del objeto seleccionado desde GrabDropScript a activeobjname
		activeobjname=sc.objname;
        Debug.Log("objselected: " + activeobjname + "  toselecte: " + color);
        //Compara el nombre del objeto seleccionado con el nombre enviado desde otro script
       if(activeobjname.Equals(color))
        {
            //Se indica que el nommbre del objeto seleccionado coincide con el nombre enviado desde otro script
            isColorSelected = true;
            //Se limpia el nombre del objeto asignado
            activeobjname = "";
        }
        else
        {
            //Se indica que el nommbre del objeto seleccionado no coincide con el nombre enviado desde otro script
            isColorSelected = false;
        }
       
       
	}


    //Setter de color
    public static void  setColor(string setColor)
    {
        color = setColor;
    }

    //Getter de color
    public static string getColor()
    {
        return color;
    }

    //Setter de iscolorselected
    public static bool getisColorSelected()
    {
        return isColorSelected;
    }

    //Getter de iscolorselected
    public static void setisColorSelected(bool sel)
    {
        isColorSelected = sel;
    }
}
