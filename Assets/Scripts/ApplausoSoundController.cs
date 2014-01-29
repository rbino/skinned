using UnityEngine;
using System.Collections;

public class ApplausoSoundController : MonoBehaviour {

	float Timer = 0f;
	
	public float TimeOut = 7f;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		Timer += Time.deltaTime;
		
		if(Timer >= TimeOut){
			audio.Play ();
			Timer = 0f;
		}
	
	}
}
