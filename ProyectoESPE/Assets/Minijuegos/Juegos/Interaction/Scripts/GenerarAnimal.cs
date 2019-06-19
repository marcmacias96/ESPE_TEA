using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerarAnimal : MonoBehaviour {

	//public GameObject sheep, pig, duck, cow, chicken;
	public Text texto;
	//GameObject[] animals;
	string[] nombres=new string[6];
	int animal=-1;
	public string nombreactivo="";
	public AudioSource Oveja, Cerdo, Pato, Vaca, Gallina, pig;

	AudioSource[] animals=new AudioSource[6];

	// Use this for initialization
	void Start () {
		animal=Random.Range(0,5);
		animals[0]=Oveja;
		nombres[0]="Oveja";
		animals[1]=Cerdo;
		nombres[1]="Cerdo";
		animals[2]=Pato;
		nombres[2]="Pato";
		animals[3]=Vaca;
		nombres[3]="Vaca";
		animals[4]=Gallina;
		nombres[4]="Gallina";
        animals[5] = pig;
        nombres[5] = "Oculto";
        texto.text=nombres[animal];
	}
	
	public void CambiarAnimal(){
		animal=Random.Range(0,5);
		nombreactivo=nombres[animal];
		texto.text=nombres[animal];
		animals[animal].Play();
	}
}
