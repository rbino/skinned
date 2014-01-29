using UnityEngine;
using System.Collections;

public class PlayerController2DGeneric : MonoBehaviour {
	
	public float speed = 1f;
	public bool mirrored = false;
	
	// Use this for initialization
	void Start () {
		transform.GetChild(0).GetComponent<CharacterAnimationController>().StopMoving();

		if(mirrored)
			speed = -speed;
	}
	
	// Update is called once per frame
	void Update () {

			
		if(Input.GetKey(KeyCode.RightArrow)){
			
			rigidbody2D.velocity = new Vector2(speed, 0);
			transform.GetChild(0).GetComponent<CharacterAnimationController>().StartMoveRight();
			
		}
		
		if(Input.GetKeyUp(KeyCode.RightArrow)){
			rigidbody2D.velocity = new Vector2(0, 0);
			transform.GetChild(0).GetComponent<CharacterAnimationController>().StopMoving();
		}
		
		if(Input.GetKey(KeyCode.LeftArrow)){
			transform.GetChild(0).GetComponent<CharacterAnimationController>().StartMoveLeft();
			rigidbody2D.velocity = new Vector2(-speed, 0);
		}
		
		if(Input.GetKeyUp(KeyCode.LeftArrow)){
			rigidbody2D.velocity = new Vector2(0, 0);
			transform.GetChild(0).GetComponent<CharacterAnimationController>().StopMoving();
		}

	}

	public void Block(){
		rigidbody2D.velocity = new Vector2(0, 0);
		transform.GetChild(0).GetComponent<CharacterAnimationController>().StopMoving();
		GetComponent<PlayerController2DGeneric>().enabled = false;
	}
}
