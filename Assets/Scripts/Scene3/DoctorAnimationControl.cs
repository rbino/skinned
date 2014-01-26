using UnityEngine;
using System.Collections;

public class DoctorAnimationControl : MonoBehaviour {

	private Animator animator;

	// Use this for initialization
	void Start () {

		animator = animator = this.GetComponent<Animator>();
	
	}
	
	public void StartMoveRight(){
		animator.SetInteger("Direction", 2);
	}

	public void StartMoveLeft(){
		animator.SetInteger("Direction", 1);
	}
}
