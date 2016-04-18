using UnityEngine;
using System.Collections;

public class switchCharacter : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		switchChar ();
	}

	void switchChar (){
		if(Input.GetKeyDown(KeyCode.Alpha1)){
			StatsManager.character = StatsManager.charForm.human;
			//print (StatsManager.character);
		}
		if(Input.GetKeyDown(KeyCode.Alpha2)){
			StatsManager.character = StatsManager.charForm.animal;
			//print (StatsManager.character);
		}
		if(Input.GetKeyDown(KeyCode.Alpha3)){
			StatsManager.character = StatsManager.charForm.android;
			//print (StatsManager.character);
		}
	}
}
