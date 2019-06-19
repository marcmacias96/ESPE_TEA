using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    private Vector3 mMovementDirection = Vector3.zero;
    private Coroutine mCurrentChanger = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += mMovementDirection * Time.deltaTime * 0.5f;

    }

    public void MakeBigger(){
        transform.localScale += new Vector3(1F, 0, 0);
    }

}
