using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Player"){
			other.GetComponent<PlayerController2D>().NearDoor(true, transform.GetChild(0));
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if(other.tag == "Player"){
			other.GetComponent<PlayerController2D>().NearDoor(false, null);
		}
	}
}
