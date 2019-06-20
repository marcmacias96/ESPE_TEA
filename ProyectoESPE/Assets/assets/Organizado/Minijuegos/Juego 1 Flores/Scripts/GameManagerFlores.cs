using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerFlores : MonoBehaviour
{
    //Es el canvas donde se muestra el tutorial de inicio
    public GameObject canvTutorial;
    //Es el canvas donde se muestra la flor que debe ser elegida
    public GameObject canvPistal;
    //Es el canvas donde se muestra si la seleccion fue correcta
    public GameObject canvCorrecto;
    //Es el puntero de seleccion (manito)
    public GameObject gesturePointer;
    //El tiempo de espera entre cada estado asignado desde el editor
    public float time;


    private static float waitTime;
    //private bool doTutorial;
    //private bool isPlaying;
    //Lista de colores a elegir
    private List<string> colorsList = new List<string>();
    //Lista de imagenes de flores
    public List<Sprite> images;

    private int counter = 5;
    //Objeto que muestra la imagen de la flor que se debe seleccionar
    public GameObject showImage;

    //1.-
    void Start()
    {
        //Anadir colores a la lista colorsList
        colorsList.Add("yellow");
        colorsList.Add("green");
        colorsList.Add("blue");
        colorsList.Add("red");
        //gesturePointer.SetActive(false);
        //doTutorial = false;
        //isPlaying = false;
        //Inicializar el tiempo con la variable time
        //setWaitTime(time);
        //co = showAndDisable(canvTutorial);
        //Inicia tutorialtime y le envia el canvas del tutorial
        StartCoroutine(tutorialTime(canvTutorial));
       
    }

    //3.1.-
    void ChangeImage(int value)
    {
        //Se elije el sprite dentro de la lista de imagenes de flores
        Sprite im = images[value];
        Debug.Log("value: " + value);
        //Se asigna el sprite que se debe mostrar en la variable showImage, que es el objeto dentro del canvas pista1
        showImage.GetComponent<Image>().sprite = im;

    }

    //6.-
    IEnumerator waitToSelect(int selected)
    {
        //Espera por 1 segundo
        yield return new WaitForSeconds(1);
        //Le resta uno al contador counter que esta en 5 despues de cada instruccion
        counter--;
        //Chequea si el contador es 0, o sea si han si han pasado 5 segundos
        Debug.Log("Contador: " + counter);
        if (counter == 0)
        {
            //gesturePointer.SetActive(false);
            //Llama a showAndDisable y le manda el canvas pista1 que es donde se muestran las instrucciones
            //StartCoroutine(showAndDisable(canvPistal));
            counter = 5;
            Choose(selected);
        }
        else
        {
            //Si no se han cumplido los 5 segundos llama a Choose nuevamente
            Choose(selected);
        }

    }

    //3.-
    IEnumerator showAndDisable(GameObject canvas)
    {
        gesturePointer.SetActive(false);
        //Selecciona al azar  un numero del 0 al tamano de la lista de colores
        int selected = Random.Range(0, colorsList.Count);
        Debug.Log("count: " + colorsList.Count);
        Debug.Log("selected: " + selected);
        //Setea en el KinecIbjectSelection del objeto KinectController, el color que debe seleccionarse
        KinectObjectSelection.setColor(colorsList[selected]);
        //Se envia a change image el indice del array de colorsList(5)
        ChangeImage(selected);
        //Activa el canvas pista1
        canvas.SetActive(true);
        //Espera el tiempo establecido
        yield return new WaitForSeconds(time);
        //Desactiva el canvas
        canvas.SetActive(false);
        //Igual el contador a 5 para esperar los 5 segundos
        counter = 5;
        //Llama a Choose(5)
        Choose(selected);

    }

    //5.-
    public void Choose(int selected)
    {
        gesturePointer.SetActive(true);
        Debug.Log("Seleccionado? "+KinectObjectSelection.getisColorSelected());
        //Chequea si el color seleccionado por el jugador es el mismo que se asigno en el juego
        if (KinectObjectSelection.getisColorSelected())
        {
            //gesturePointer.SetActive(false);
            //setea la variable isColorSelected a false para que vuelva a iniciar el juego
            KinectObjectSelection.setisColorSelected(false);
            Debug.Log("Dentro del if: "+ KinectObjectSelection.getisColorSelected());
            //Elimina el color elegido correctamente, de la lista de colores
            colorsList.RemoveAt(selected);
            images.RemoveAt(selected);
            //Inicia tutorialTime con el canvas de haber elegido correctamente el color
            StartCoroutine(tutorialTime(canvCorrecto));
        }
        else
        {
            //Se llama a waitToSelecte si el color correcto no ha sido seleccionado
            StartCoroutine(waitToSelect(selected));
        }
    }

    //2.-
    IEnumerator tutorialTime(GameObject canvas)
    {
        //Pone el puntero en desactivado para que no se pueda seleccionar nada
        gesturePointer.SetActive(false);
        //Activa el canvas
        canvas.SetActive(true);
        //Espera el tiempo establecido
        yield return new WaitForSeconds(time);
        //Desactiva el canvas
        canvas.SetActive(false);
        //Chequea si la lista de colores esta vacia para cambiar al estado de TIEMPOS.
        if (colorsList.Count == 0)
        {
            //CAmbiar al estado TIEMPOS

        }
        else
        {
            //Inicia showAndDisable y le envia el canvas pista1 donde estan las imagenes de las flores a seleccionar
            StartCoroutine(showAndDisable(canvPistal));
        }
        
    }
}
    