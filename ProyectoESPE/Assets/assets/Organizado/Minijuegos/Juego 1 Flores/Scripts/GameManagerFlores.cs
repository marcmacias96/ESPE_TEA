using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerFlores : MonoBehaviour
{

    public GameObject canvTutorial;
    public GameObject canvPistal;
    public GameObject canvCorrecto;
    public GameObject gesturePointer;
    public float time;

    private static float waitTime;
    private bool doTutorial;
    private bool isPlaying;
    IEnumerator co;
    IEnumerator IsInactive;
    private List<string> colorsList = new List<string>();
    public Sprite[] images;
    private int counter = 5;
    public GameObject showImage;

    void Start()
    {
        colorsList.Add("yellow");
        colorsList.Add("green");
        colorsList.Add("blue");
        colorsList.Add("red");
        //gesturePointer.SetActive(false);
        doTutorial = false;
        isPlaying = false;
        setWaitTime(time);
        //co = showAndDisable(canvTutorial);
        StartCoroutine(tutorialTime(canvTutorial));
       
    }

    void ChangeImage(int value)
    {
        Sprite im = images[value];
        showImage.GetComponent<Image>().sprite = im;

    }

    IEnumerator waitToSelect()
    {
        yield return new WaitForSeconds(1);
        counter--;
        if (counter == 0)
        {
            //gesturePointer.SetActive(false);
            StartCoroutine(showAndDisable(canvPistal));
        }
        else
        {
            Choose();
        }

    }

    IEnumerator showAndDisable(GameObject canvas)
    {
        Debug.Log("reboot");
        int selected = Random.Range(0, 4);
        AnimalSelected.setColor(colorsList[selected]);
        ChangeImage(selected);
        Debug.Log(AnimalSelected.getColor());
        canvas.SetActive(true);
        yield return new WaitForSeconds(time);
        canvas.SetActive(false);
    
        counter = 5;
        Choose();

    }

    public void Choose()
    {
        //gesturePointer.SetActive(true);
        Debug.Log(AnimalSelected.getisColorSelected());
        if (AnimalSelected.getisColorSelected())
        {
            //gesturePointer.SetActive(false);
            AnimalSelected.setisColorSelected(false);
            Debug.Log("Dentro del if: "+AnimalSelected.getisColorSelected());
            StartCoroutine(tutorialTime(canvCorrecto));
        }
        else
        {
            StartCoroutine(waitToSelect());
        }
    }

    IEnumerator tutorialTime(GameObject canvas)
    {
        canvas.SetActive(true);
        yield return new WaitForSeconds(time);
        canvas.SetActive(false);
        StartCoroutine(showAndDisable(canvPistal));
    }

   

    public  static void setWaitTime(float timeWait)
    {
        waitTime = timeWait;
    }
}
    