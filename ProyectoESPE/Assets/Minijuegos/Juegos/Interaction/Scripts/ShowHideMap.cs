using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHideMap : MonoBehaviour {

	public GameObject cam1, cam2;
	public GameObject b0,b1;
	bool ismap=false;

	public void SetCam(){
		print("Camara");
		if(ismap){
			cam1.SetActive(true);
			cam2.SetActive(false);
			b0.SetActive(false);
			b1.SetActive(false);
			ismap=false;
		}else{
			cam1.SetActive(false);
			cam2.SetActive(true);
			b0.SetActive(true);
			b1.SetActive(true);
			ismap=true;
		}
	}
}
