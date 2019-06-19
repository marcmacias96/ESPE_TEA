using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveActor : MonoBehaviour {

	public GameObject loc1, loc2;
	public GameObject actorCam;

	public void MoveToLocation1(){
		Vector3 location=loc1.transform.position;
		location.x=location.z-50;
		actorCam.transform.Translate(location);
	}

	public void MoveToLocation2(){
		Vector3 location=loc2.transform.position;
		location.x=location.z-50;
		actorCam.transform.Translate(location);
	}
}
