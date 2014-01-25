using UnityEngine;
using System.Collections;

public class VoiceThreshold : MonoBehaviour {

	public GUIText counterText;
	private int counter=0;

	// Use this for initialization
	void Start () {
//		timer.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){

	//	StartCoroutine (thresholdTimer());
		counterText.enabled = true;
		if (++counter >= 3){
			counter = 0;
			transform.position = new Vector3 (transform.position.x, transform.position.y + 0.4f, transform.position.z);
		}
		counterText.text = "" + counter;
	}

	void OnTriggerExit2D(Collider2D other){
	//	timer.enabled = false;
	//	timer.text = "-1";
	}

	IEnumerator thresholdTimer(){
		while (int.Parse(counterText.text)>0) {
			counterText.text = (int.Parse(counterText.text) - 1).ToString();
			yield return new WaitForSeconds(1.0f);
		}
		counterText.enabled = false;
		if (int.Parse (counterText.text) == 0) {
			transform.position = new Vector3 (transform.position.x, transform.position.y + 0.5f, transform.position.z);
		}
		
	}
}
