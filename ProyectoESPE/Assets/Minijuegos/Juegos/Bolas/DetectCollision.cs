using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour {

	public TextMesh texto;
	public int balls=0;
	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.name == "BallPrefab2DCustom(Clone)") {
			Destroy (col.gameObject);
			balls++;
			texto.text = "Caidas: "+balls;
		}
	}
}
