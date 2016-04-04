using UnityEngine;
using System.Collections;


public class CameraControl : MonoBehaviour {

    public GameObject Display1;
    public GameObject Display2;
    public GameObject Display3;

    public GameObject Character1;
    public GameObject Character2;
    public GameObject Character3;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown("1"))
        {
            Display1.SetActive(true);
            Display2.SetActive(false);
            Display3.SetActive(false);
        }
        if (Input.GetKeyDown("2"))
        {
            Display1.SetActive(false);
            Display2.SetActive(true);
            Display3.SetActive(false);
        }
        if (Input.GetKeyDown("3"))
        {
            Display1.SetActive(false);
            Display2.SetActive(false);
            Display3.SetActive(true);
        }

        if (Input.GetKeyDown("1"))
        {
            Character1.SetActive(true);
            Character2.SetActive(false);
            Character3.SetActive(false);
        }
        if (Input.GetKeyDown("2"))
        {
            Character1.SetActive(false);
            Character2.SetActive(true);
            Character3.SetActive(false);
        }
        if (Input.GetKeyDown("3"))
        {
            Character1.SetActive(false);
            Character2.SetActive(false);
            Character3.SetActive(true);
        }
    }
}
