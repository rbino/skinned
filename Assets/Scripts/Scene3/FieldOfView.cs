using UnityEngine;
using System.Collections;

public class FieldOfView : MonoBehaviour {

	GameObject soundtrackController;

	// Use this for initialization
	void Start () {
		soundtrackController = GameObject.Find("Soundtrack");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Player"){
			transform.parent.GetComponent<DoctorMove>().PlayerDetected();
			other.transform.GetComponent<PlayerController2D>().ResetPlayerPosition();
			soundtrackController.GetComponent<SoundTrackController>().ResetClip();
		}
	}
}
