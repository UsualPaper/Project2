using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreText : MonoBehaviour {

    Text scoreText;
    

	// Use this for initialization
	void Start () {
		scoreText = gameObject.GetComponent<Text> ();
    }
	
	// Update is called once per frame
	void Update () {
//        if(scoreText.name == "scoreText")
//        {
//            scoreText.text = "score:" + GameMaster.Score;
			scoreText.text = GameMaster.Score.ToString ();
       
//        
	
	}
}
