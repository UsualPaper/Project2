using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RetriesText : MonoBehaviour {

    Text retriesText;

    // Use this for initialization
    void Start () {
        retriesText = gameObject.GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        retriesText.text = GameMaster.Retries.ToString();
    }
}
