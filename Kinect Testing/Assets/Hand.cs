using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    //public  Transform mHandMesh;

    // Start is called before the first frame update

    bool mustHide=false;
    RaycastHit hit;
    void Start()
    {
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

        
        IEnumerator co = SecondsToHide();
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask) && hit.transform.gameObject.tag == "Bubble")
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log("Did Hit");
            mustHide=true;
            StartCoroutine(co);
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            Debug.Log("Did not Hit");
            mustHide=false;
            StopCoroutine(co);
        }
    }

    IEnumerator SecondsToHide()
    {
        print(Time.time);
        yield return new WaitForSeconds(2);
        print(Time.time);

        if(hit.transform!=null && mustHide){
            //hit.transform.gameObject.SetActive(false);
            hit.transform.gameObject.SendMessage("MakeBigger");
        }
    }
}
