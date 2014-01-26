using UnityEngine;
using System.Collections;

public class A3S1DoorAnimationControl : MonoBehaviour {
	private Animator animator;
	// Use this for initialization
	void Start () {
		animator = this.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void CloseDoor(){
		animator.SetTrigger ("CloseBathroomDoor");
	}
}
