using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    public GameObject MainCanvas;
    public GameObject CameraFlowers;
    public GameObject CameraMenu;
    public GameObject GameManager;

    public void Play(){
        CameraMenu.SetActive(false);
        MainCanvas.SetActive(true);
        CameraFlowers.SetActive(true);
        GameManager.SetActive(true);
    }

    public void Exit(){
        Application.Quit();
    }

    public void Return(){
        GameManager.SetActive(false);
        MainCanvas.SetActive(false);
        CameraFlowers.SetActive(false);
        CameraMenu.SetActive(true);
    }
}
