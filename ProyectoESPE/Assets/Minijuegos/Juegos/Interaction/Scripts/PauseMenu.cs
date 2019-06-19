using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

	public static bool gameIsPaused = false;
	public GameObject pauseMenuUI;
	EggSpawnerCustom spawner;


	void Start(){
		spawner = GameObject.Find ("BallSpawner").GetComponent<EggSpawnerCustom> ();
	}

	// Update is called once per frame
	void Update () {

		if (spawner.manager != null) {
			if (spawner.manager.IsUserDetected (0)) {
				Resume ();
			} else {
				Pause ();
			}
		}


		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (gameIsPaused) {
				Resume ();
			} else {
				Pause ();
			}
		}
	}


	void Resume(){
		pauseMenuUI.SetActive (false);
		Time.timeScale = 1f;
		gameIsPaused = false;
	}

	public void Pause(){
		pauseMenuUI.SetActive (true);
		Time.timeScale = 0f;
		gameIsPaused = true;
	}
}
