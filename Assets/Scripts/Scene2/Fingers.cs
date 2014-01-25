using UnityEngine;
using System.Collections;

public class Fingers : MonoBehaviour {

	public GameObject start;
	public GameObject end;
	private float startX;
	private float endX;

	private float speedModule = 0.05f;
	private Vector3 speedDirection = new Vector3(-1, 0, 0);
	private float oppositeForceModule;
	private Vector3 oppositeForceDirection = new Vector3(1, 0, 0);
	private bool insert = false;
	private bool tillTheEnd = false;

	// Use this for initialization
	void Start () {
		startX = start.GetComponent<Transform>().position.x;
		endX = end.GetComponent<Transform>().position.x;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.LeftArrow)) {
			//fingers go ahead a little
			transform.position = transform.position + (speedDirection * speedModule);
		}
		if (insert) {
			//opposite force at work
		}
		if (tillTheEnd) {
			//Winning condition
		}
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.name.Equals("Mouth")) {
			if (!insert) {
				insert = true;
			}
		}
		if (other.gameObject.name.Equals("DeepThroat")) {
			tillTheEnd = true;
		}
	}

	void OnTriggerExit2D (Collider2D other) {
		if (other.gameObject.name.Equals("Mouth")) {
			if (insert) {
				insert = false;
			}
		}
	}
}
