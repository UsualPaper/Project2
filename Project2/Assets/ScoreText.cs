using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreText : MonoBehaviour {

    public Text scoreText;


	// Use this for initialization
	void Start () {
        scoreText.text = GameMaster.Score.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
        if(scoreText.name == "scoreText")
        {
            scoreText.text = "score:" + GameMaster.Score;
        }
	
	}
}
