using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BarraCarga : MonoBehaviour {
    public GameObject panel;
    public Slider barra;    
    private AsyncOperation asyncLoad;
	// Use this for initialization
	
   public void ClickCarga()
    {
        panel.SetActive(true);

        Invoke("corrutina", 0.5f);
    }

    void corrutina()
    {
        StartCoroutine(LoadSceneSlider());
    }
    IEnumerator LoadSceneSlider()
    {
        asyncLoad = SceneManager.LoadSceneAsync(1);
        while (!asyncLoad.isDone)
        {
            barra.value = asyncLoad.progress;
            yield return null;
        }
    }
}
