using UnityEngine;
using System.Collections;

public class CharacterAnimationController : MonoBehaviour {

	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = this.GetComponent<Animator>();
	}
	
	public void StartMoveRight(){
		animator.SetInteger("Direction", 1);
	}

	public void StopMoving(){
		animator.SetInteger("Direction", 0);
	}

	public void StartMoveLeft(){
		animator.SetInteger("Direction", 2);
	}
	public void SitDown(){
		animator.SetTrigger ("Sit");
	}

	public void Collapse(){
		animator.SetTrigger("Collapse");
	}   
}
