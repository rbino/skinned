using UnityEngine;
using System.Collections;

public class A1S4SoundEffect : MonoBehaviour {

	public GameObject applausoSound, flashSound;

	float Timer = 0f;

	public float TimeOut = 5f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
		Timer += Time.deltaTime;

		if(Timer >= TimeOut){
			playFlash();
			//Invoke ("playFlash", 0.01f);
			//Invoke ("playFlash", 0.05f);
			//Invoke ("playApplauso", 0.02f);
		}

	}

	void playFlash(){
		flashSound.audio.Play();

	}

	void playApplauso(){
		applausoSound.audio.Play();
	}
}
