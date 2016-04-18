using UnityEngine;
using System.Collections;

public class Obsticle : MonoBehaviour {

    public GameObject door;

    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Destroy(door);
        }
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
