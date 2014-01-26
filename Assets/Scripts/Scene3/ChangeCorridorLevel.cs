using UnityEngine;
using System.Collections;

public class ChangeCorridorLevel : MonoBehaviour {

	public Transform camera;

	GameObject soundtrack;

	int index = 1;

	// Use this for initialization
	void Start () {
		soundtrack = GameObject.Find("Soundtrack");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {

		if(other.tag == "Player"){
			other.gameObject.transform.position += Vector3.down*1.8f;
			index++;
			soundtrack.GetComponent<SoundTrackController>().NextClip();
		}
	}
}
