using UnityEngine;
using System.Collections;

public class GameControlScript : MonoBehaviour 
{
	[Tooltip("Prefab used to create the scene fence.")]
	public GameObject cratePrefab;

	[Tooltip("GUI-Window rectangle in screen coordinates (pixels).")]
	public Rect guiWindowRect = new Rect(10, 40, 200, 300);

	[Tooltip("GUI-Window skin (optional).")]
	public GUISkin guiSkin;


	// whether the fence is already created
	private bool isFenceCreated = false;

	
	void Update () 
	{
		if(!isFenceCreated)
		{
			SpeechManager speechManager = SpeechManager.Instance;

			if(speechManager && speechManager.IsSapiInitialized())
			{
				Quaternion quatRot90 = Quaternion.Euler(new Vector3(0, 90, 0));
				GameObject newObj = null;

				for(int i = -50; i <= 50; i++)
				{
					newObj = (GameObject)GameObject.Instantiate(cratePrefab, new Vector3(i, 0.32f, 50), Quaternion.identity);
					newObj.transform.parent = transform;

					newObj = (GameObject)GameObject.Instantiate(cratePrefab, new Vector3(i, 0.32f, -50), Quaternion.identity);
					newObj.transform.parent = transform;

					newObj = (GameObject)GameObject.Instantiate(cratePrefab, new Vector3(50, 0.32f, i), quatRot90);
					newObj.transform.parent = transform;

					newObj = (GameObject)GameObject.Instantiate(cratePrefab, new Vector3(-50, 0.32f, i), quatRot90);
					newObj.transform.parent = transform;
				}

				isFenceCreated = true;
			}
		}
	}

	private void ShowGuiWindow(int windowID) 
	{
		GUILayout.BeginVertical();

	   GUILayout.Label("<i>Hablar Fuerte y Claro</i>");
       GUILayout.Label("<b>* Ir para adelante decir: FORWARD</b>");
		GUILayout.Label("<b>* Ir para atras decir:    BACK </b>");
		GUILayout.Label("<b>* Girar hacia la derecha:  TURN LEFT</b>");
		GUILayout.Label("<b>* Girar hacia la izquierda: TURN RIGHT</b>");
		GUILayout.Label("<b>* Correr decir: RUN</b>");
		GUILayout.Label("<b>* Saltar decir: JUMP</b>");
		GUILayout.Label("<b>* Detenerse decir: STOP</b>");
		GUILayout.Label("<b>* Para saludar decir: HELLO </b>");
	
		
		GUILayout.EndVertical();
		
		// Make the window draggable.
		GUI.DragWindow();
	}
	
	void OnGUI()
	{
		GUI.skin = guiSkin;
		guiWindowRect = GUI.Window(0, guiWindowRect, ShowGuiWindow, "Comandos Personaje");
	}
	
}
