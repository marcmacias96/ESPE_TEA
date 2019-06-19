using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AnimalSelected : MonoBehaviour {

	public GameObject kinectcontrol;
	public Text texto;
	string activeobjname="";
	GrabDropScript sc;
	GenerarAnimal gen;
	bool ok=false;
	int puntos=-1;
    private static string color;
    private static bool isColorSelected = false;
    


	// Use this for initialization
	void Start () {
		sc=kinectcontrol.GetComponent<GrabDropScript>();
		gen=kinectcontrol.GetComponent<GenerarAnimal>();

	}
	
	// Update is called once per frame
	void Update () {	
		activeobjname=sc.objname;
       if(activeobjname.Equals(color))
        {
            isColorSelected = true;
            activeobjname = "";
        }
        else
        {
            isColorSelected = false;
        }
       
       
	}

    public static void  setColor(string setColor)
    {
        color = setColor;
    }

    public static string getColor()
    {
        return color;
    }

    public static bool getisColorSelected()
    {
        return isColorSelected;
    }

    public static void setisColorSelected(bool sel)
    {
        isColorSelected = sel;
    }
}
