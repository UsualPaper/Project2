using UnityEngine;
using System.Collections;

public class collectable : MonoBehaviour {

    AudioSource audioSource;
    public AudioClip collectSound;


	// Use this for initialization
	void Start () {
        audioSource = GameObject.Find("CollectableAS").GetComponent<AudioSource> ();

	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D col){
        if (col.CompareTag ("Player")) {
            GameMaster.Score++;
            if (audioSource != null){
                    audioSource.PlayOneShot(collectSound);
                }
            
                Destroy(gameObject);
            }
        }
    }
