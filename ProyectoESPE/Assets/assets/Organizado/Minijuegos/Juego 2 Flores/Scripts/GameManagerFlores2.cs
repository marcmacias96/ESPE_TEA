using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerFlores2 : MonoBehaviour
{
    public GameObject FAzul, Froja, Fverde, Famarilla;
    public Transform PositionGenerete;
    private List<string> colorsList = new List<string>();
    private bool correctSelection = true;
    public GameObject kinectController;
    SphereSelected sphereSelected;

    // Start is called before the first frame update
    void Start()
    {
        colorsList.Add("yellow");
        colorsList.Add("green");
        colorsList.Add("blue");
        colorsList.Add("red");
        sphereSelected = kinectController.GetComponent<SphereSelected>();
        
    }

    void Update()
    {

      //  correctSelection = sphereSelected.getIsColorSelected();
        if (correctSelection)
        {
            correctSelection = false;
            string sel = SelectColor();

            switch (sel)
            {
                case "yellow":
                    {
                        GameObject obj = Instantiate(Famarilla, PositionGenerete);
                        break;
                    }

                case "green":
                    {
                        GameObject obj = Instantiate(Fverde, PositionGenerete);
                        break;
                    }

                case "blue":
                    {
                        GameObject obj = Instantiate(FAzul, PositionGenerete);
                        break;
                    }

                case "red":
                    {
                        GameObject obj = Instantiate(Froja, PositionGenerete);
                        break;
                    }
            }
        }
    }


    string SelectColor()
    {
        int selected = UnityEngine.Random.Range(0, 4);
        return colorsList[selected];
    }


    
}
