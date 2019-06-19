using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscena : MonoBehaviour {
    private AsyncOperation asyncLoad;
    // Ropero de Gordito

    public void RoperoPictograma()
    {
        SceneManager.LoadScene(15);
    }
    public void RoperoEsena()
    {
        SceneManager.LoadScene(2);
    }

    //Emociones con gordito 
    public void PigtogramaEmociones()
    {
        SceneManager.LoadScene(11);
    }

    public void Emociones()
    {
        SceneManager.LoadScene(3);
    }

    //Moviendo Objetos 
     
    public void PictogramaMovimientos()
    {
        SceneManager.LoadScene(14);
    }

    public void Movimientos()
    {
        SceneManager.LoadScene(4);
    }

    //Fotografias

    public void PictogramaFotos()
    {
        SceneManager.LoadScene(12);
    }
    public void Photo()
    {
        SceneManager.LoadScene(6);
    }

    //Ingles Gordito
    public void PictogramaIngles()
    {
        SceneManager.LoadScene(13);
    }
    public void Ingles()
    {
        SceneManager.LoadScene(8);
    }

    //Colores 

    public void PictogramaColores()
    {
        SceneManager.LoadScene(10);
    }

    public void Colores()
    {
        SceneManager.LoadScene(7);
    }

    //Animales 

    public void PictogramaAnimales()
    {
        SceneManager.LoadScene(9);
    }
    public void Animales()
    {
        SceneManager.LoadScene(17);
    }

    // Vocales
    public void PictogramaVocales()
    {
        SceneManager.LoadScene(16);
    }

    public void Vocales()
    {
        SceneManager.LoadScene(18);
    }

    // Regresar 

    public void Regresar()
    {
       StartCoroutine(LoadSceneSlider());
    }

    IEnumerator LoadSceneSlider()
    {
        asyncLoad = SceneManager.LoadSceneAsync(1);
        while (!asyncLoad.isDone)
        {
           
            yield return null;
        }
    }

}
