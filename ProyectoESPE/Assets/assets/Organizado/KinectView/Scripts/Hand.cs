using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    //public  Transform mHandMesh;

    // Start is called before the first frame update

    RaycastHit hit;
    IEnumerator co;
    public string selectedFlower;

    List<string> colorsList = new List<string>();

    void Start()
    {
        colorsList.Add("yellow");
        colorsList.Add("green");
        colorsList.Add("blue");
        colorsList.Add("red");
        co = SecondsToHide();
        ChoseColor();
    }

    // Update is called once per frame
    void Update()
    {
        //mHandMesh.position = Vector3.Lerp(mHandMesh.position, transform.position, Time.deltaTime * 15.0f);

        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 8;

        // This would cast rays only against colliders in layer 8.
        // But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;

        
        
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask) && hit.transform.gameObject.tag == "flower")
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log("Did Hit "+ hit.transform.gameObject.name);
            if (hit.transform.gameObject.name == selectedFlower)
            {
                StartCoroutine(co);
            }
            
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            Debug.Log("Did not Hit ");
            StopCoroutine(co);
        }
    }

    IEnumerator SecondsToHide()
    {
        //print(Time.time);
        yield return new WaitForSeconds(1.5f);
        //print(Time.time);

        CorrectSelection();
    }

    void CorrectSelection()
    {
        //Mostrar una felicitacion por haber elegido correctamente
        Debug.Log("Felicitaciones");

        //Cambiar al siguiente color para seleccionar
        ChoseColor();
    }

    void ChoseColor()
    {
        selectedFlower = colorsList[Random.Range(0, 4)];
        Debug.Log(selectedFlower);
    }
}
