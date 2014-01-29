using UnityEngine;
using System.Collections;

public class FlashSoundController : MonoBehaviour {

	float Timer = 0f;

	public float[] TimeOut;

	public float LongTimeOut = 5f;
	public int CounterTimeOut = 4;

	float actualTimeOut;

	int counter;
	int index = 0;




	// Use this for initialization
	void Start () {
		actualTimeOut = TimeOut[index];
		counter = 0;
	}
	
	// Update is called once per frame
	void Update () {

		Timer += Time.deltaTime;
		
		if(Timer >= actualTimeOut){

			counter++;

			if(actualTimeOut == LongTimeOut)
				actualTimeOut = TimeOut[index];
			else{
				actualTimeOut = TimeOut[index];
				index++;
				if(index == TimeOut.Length)
					index  = 0;
			}

			if(counter > CounterTimeOut){
				actualTimeOut = LongTimeOut;
				counter = 0;
			}

			audio.Play ();
			Timer = 0f;
		}
	
	}
}
