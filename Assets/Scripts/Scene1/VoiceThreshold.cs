using UnityEngine;
using System.Collections;

public class VoiceThreshold : MonoBehaviour {

	public GUIText counterText;
	private int counter=0;
	private bool backHome=true;
	private Collider2D square;

	// Use this for initialization
	void Start () {
//		timer.enabled = false;
	}

	// Update is called once per frame
	void Update () {
		if (square){
			if (square.transform.position.y < -0.8){
				backHome = true;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		square = other;
		if (backHome){
		counterText.enabled = true;
		if (++counter >= 3){
			counter = 0;
			transform.position = new Vector3 (transform.position.x, transform.position.y + 0.4f, transform.position.z);
		}
		counterText.text = "" + counter;
		}
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
