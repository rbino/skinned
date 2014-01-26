using UnityEngine;
using System.Collections;

public class A1S3Chair : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Player"){
			other.GetComponent<A1S3PlayerController2D>().NearChair(true);
		}
	}
	
	void OnTriggerExit2D(Collider2D other){
		if(other.tag == "Player"){
			other.GetComponent<A1S3PlayerController2D>().NearChair(false);
		}
	}
}
