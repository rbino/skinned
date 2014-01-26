using UnityEngine;
using System.Collections;

public class DoorLocked : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Player"){
			other.GetComponent<PlayerController2D>().setLockDoor();
		}
	}
	
	void OnTriggerExit2D(Collider2D other){
		if(other.tag == "Player"){
			other.GetComponent<PlayerController2D>().resetLockDoor();
		}
	}
}
