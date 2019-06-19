using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePuntoJuego : MonoBehaviour
{
    public float angleToRotate=0;
    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(0, angleToRotate, 0, Space.Self);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
