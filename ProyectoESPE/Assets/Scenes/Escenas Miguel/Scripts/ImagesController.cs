using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImagesController : MonoBehaviour
{

    public Texture texture1;
    public Texture texture2;
    public Texture texture3;
    public Texture texture4;
    public Texture texture5;
    public RawImage image;

    List<Texture> textures = new List<Texture>();

    // Start is called before the first frame update
    void Start()
    {
        textures.Add(texture1);
        textures.Add(texture2);
        textures.Add(texture3);
        textures.Add(texture4);
        textures.Add(texture5);

        StartCoroutine(ChangeController());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeImage(){
        StartCoroutine(ChangeController());
    }

    IEnumerator ChangeController()
    {
        image.enabled = true;
        image.GetComponent<RawImage>().texture = textures[Random.Range(0,4)];
        yield return new WaitForSeconds(3);
        image.enabled = false;
    }


}
