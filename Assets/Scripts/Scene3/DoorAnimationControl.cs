using UnityEngine;
using System.Collections;

public class DoorAnimationControl : MonoBehaviour {

	private Animator animator;
	
	// Use this for initialization
	void Start()
	{
		animator = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OpenDoor(){
		animator.SetTrigger("DoorOpened");
	}


}
