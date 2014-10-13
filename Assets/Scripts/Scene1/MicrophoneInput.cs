using UnityEngine;
using System.Collections;

public class MicrophoneInput : MonoBehaviour {

	private string device;
	private AudioClip clipRecord;
	private float[] avg;
	private int avgSize = 15;
	private int ix = 0;
	private float avgSum = 0;
	float min=100f;
	float max=-1f;

	// Use this for initialization
	void Start () {
		if(RequestAutorization.IsMicrophoneEnabled){
			if (device == null) {
				device = Microphone.devices [0];
			}
			clipRecord = Microphone.Start(device, true, 999, 44100);
			avg = new float[avgSize];
		}
		else{
			Application.Quit();
		}
		/*
		while (!(Microphone.GetPosition(device) > 0)) {
			audio.Play ();
		}
		*/
	}
	
	// Update is called once per frame
	void Update () {
		float micLevel = getMicLevel ();
		avgSum -= avg[ix];
		avg [ix] = micLevel;
		avgSum += avg [ix];
		ix++;
		if (ix >= avgSize) {
			ix = 0;	
		}
		float transformy = -0.9f + 1.8f * (avgSum / avgSize);
		// float transformy = -0.9f + 1.8f * micLevel;
		if (micLevel < min && micLevel != 0f) {
			min = micLevel;
		}
		if (micLevel > max) {
			max = micLevel;
		}
		transform.position = new Vector3 (transform.position.x, transformy, transform.position.z);
	}

	float getMicLevel(){
		int dec = 128;
		float[] waveData = new float[dec];
		int micPosition = Microphone.GetPosition(null)-(dec+1); // null means the first microphone

		if (micPosition > 0) {
			clipRecord.GetData (waveData, micPosition);
			// Getting a peak on the last 128 samples
			float levelMax = 0;
			float wavePeak = 0;
			for (int i = 0; i < dec; i++) {
					wavePeak = waveData [i] * waveData [i];
					if (levelMax < wavePeak) {
							levelMax = wavePeak;		
					}	
			}
			return levelMax;
		} else {
			return 0f;
		}
	}
}
