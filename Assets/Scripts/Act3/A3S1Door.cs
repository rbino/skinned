using UnityEngine;
using System.Collections;

public class A3S1Door : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Player"){
			other.GetComponent<A3S1PlayerController>().NearDoor(true, transform.GetChild(0));
		}
	}
	
	void OnTriggerExit2D(Collider2D other){
		if(other.tag == "Player"){
			other.GetComponent<A3S1PlayerController>().NearDoor(false, null);
		}
	}
}
