using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseMenu : MonoBehaviour {

	public static bool gameIsLost = false;
	public GameObject loseMenuUI;
	DetectCollision col;

	void Start(){
		col = GameObject.Find("Cube").GetComponent<DetectCollision>();
	}

	// Update is called once per frame
	void Update () {
		if (col.balls >= 30) {
			Pause ();
		}
	}


	void Resume(){
		loseMenuUI.SetActive (false);
		Time.timeScale = 1f;
		gameIsLost = false;
	}

	void Pause(){
		PauseMenu pau = GameObject.Find ("Canvas").GetComponent<PauseMenu> ();
		pau.Pause ();
		pau.pauseMenuUI.SetActive (false);
		loseMenuUI.SetActive (true);
		Time.timeScale = 0f;
		gameIsLost = true;
	}

	public void OnReintentar(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}
}
