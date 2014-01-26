using UnityEngine;
using System.Collections;

public class FlashSoundController : MonoBehaviour {

	float Timer = 0f;
	
	public float TimeOut = 1.5f;


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
