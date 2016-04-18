using UnityEngine;
using System.Collections;

public class camManager : MonoBehaviour {


	[Header("Characters")]
	public GameObject human;
	public GameObject animal;
	public GameObject android;

	Vector3 humanStart;
	Vector3 animalStart;
	Vector3 androidStart;


	Rigidbody2D charRB;

	[Header("Main Camera Object")]
	public Camera mainCamera;

	StatsManager.charForm _pastChar;

	public float lerpCamSpeed = 10f;
	public bool lerping = false;
	GameObject _newChar;
	Vector3 _target;
	Vector3 _camPosition;
	float startTime;
	float lerpDistance;

	// Use this for initialization
	void Start () {
		humanStart = human.transform.position;
		animalStart = animal.transform.position;
		androidStart = android.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		//setLerp ();
		//lerpCamera ();
		// AND/OR
		snapCamera ();
		//print (lerping);

		if(Input.GetKeyDown(KeyCode.R)){
			human.transform.position = humanStart;
			animal.transform.position = animalStart;
			android.transform.position = androidStart;
            GameMaster.Retries++;

        }
	}
		
	// function checks to see if you've changed the states. no sense if call functions if the state hasn't changed, or does it?
	void setLerp(){
			switch (StatsManager.character) {
		case StatsManager.charForm.human:
			_target = new Vector3 (human.transform.position.x, mainCamera.transform.position.y, -1f);
			human.GetComponent<character> ().enabled = true;
			animal.GetComponent<character> ().enabled = false;
			android.GetComponent<character> ().enabled = false;
					break;
				case StatsManager.charForm.animal:
					_target = new Vector3 (animal.transform.position.x, mainCamera.transform.position.y, -1f);
			human.GetComponent<character> ().enabled = false;
			animal.GetComponent<character> ().enabled = true;
			android.GetComponent<character> ().enabled = false;
					break;
				case StatsManager.charForm.android:
					_target = new Vector3 (android.transform.position.x, mainCamera.transform.position.y, -1f);
			human.GetComponent<character> ().enabled = false;
			animal.GetComponent<character> ().enabled = false;
			android.GetComponent<character> ().enabled = true;
					break;
				default:
					_target = new Vector3 (human.transform.position.x, mainCamera.transform.position.y, -1f);
			human.GetComponent<character> ().enabled = true;
			animal.GetComponent<character> ().enabled = false;
			android.GetComponent<character> ().enabled = false;
					break;
			}

			if (!lerping) {
				// Sets the Lerp values: start point, end point, speed of travel, toggle lerping boolean, sets current time to 'startTime'

				_camPosition = mainCamera.transform.position;
				lerpDistance = (Vector3.Distance (mainCamera.transform.position, _target));
				startTime = Time.time;
				lerping = true;
			}
			_pastChar = StatsManager.character; // store current char state to "past" state
	}

	void snapCamera(){
		if (!lerping) {
			//print ("snapping");
			switch (StatsManager.character) {

			case StatsManager.charForm.human:
				mainCamera.transform.position = new Vector3 (human.transform.position.x, human.transform.position.y, -1f);
				human.GetComponent<character> ().enabled = true;
				animal.GetComponent<character> ().enabled = false;
				android.GetComponent<character> ().enabled = false;
				break;
			case StatsManager.charForm.animal:
				mainCamera.transform.position = new Vector3 (animal.transform.position.x, animal.transform.position.y, -1f);
				human.GetComponent<character> ().enabled = false;
				animal.GetComponent<character> ().enabled = true;
				android.GetComponent<character> ().enabled = false;
				break;
			case StatsManager.charForm.android:
				mainCamera.transform.position = new Vector3 (android.transform.position.x, android.transform.position.y, -1f);
				human.GetComponent<character> ().enabled = false;
				animal.GetComponent<character> ().enabled = false;
				android.GetComponent<character> ().enabled = true;
				break;
			default:
				mainCamera.transform.position = new Vector3 (human.transform.position.x, human.transform.position.y, -1f);
				human.GetComponent<character> ().enabled = true;
				animal.GetComponent<character> ().enabled = false;
				android.GetComponent<character> ().enabled = false;
				break;
			}
		}
	}

	void lerpCamera (){			
		if (lerping) {
			//print(Vector3.Distance (mainCamera.transform.position, _target));
			float distCovered = (Time.time - startTime) * lerpCamSpeed;
			float fracJourney = distCovered / lerpDistance;

			print (lerpDistance);
			//print (fracJourney);

			mainCamera.transform.position = Vector3.Lerp (_camPosition, _target, fracJourney);
			if (Vector3.Distance (mainCamera.transform.position, _target) < .01f) {
				lerping = false;
				print (Vector3.Distance (mainCamera.transform.position, _target));
			}
		}
	}
}