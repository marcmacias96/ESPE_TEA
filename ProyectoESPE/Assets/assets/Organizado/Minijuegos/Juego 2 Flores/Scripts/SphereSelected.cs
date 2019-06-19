 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereSelected : MonoBehaviour
{
    public GameObject kinectcontrol;
    GrabDropScript sc;
    private static string color;
    private static bool isColorSelected = false;
    string activeobjname = "";

    // Start is called before the first frame update
    void Start()
    {
        sc = kinectcontrol.GetComponent<GrabDropScript>();
    }

    // Update is called once per frame
    void Update()
    {
        activeobjname = sc.objname;
        if (activeobjname.Equals(color))
        {
            isColorSelected = true;
            activeobjname = "";
        }
        else
        {
            isColorSelected = false;
        }

    }

    public static void setColor(string setColor)
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
