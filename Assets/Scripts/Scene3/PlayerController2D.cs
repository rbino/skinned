using UnityEngine;
using System.Collections;

public class PlayerController2D : MonoBehaviour {

	public float DeltaMove = 0.1f;
	public float speed = 1f;
	public float startTime;
	public float xSmooth;

	public Transform PlayerInitialPos;
	public Transform DoorAnimation;

	bool moved = false;
	bool nearDoor = false;

	Vector3 initialPos, finalPos;

	// Use this for initialization
	void Start () {
		initialPos = transform.position;
		finalPos = new Vector3(initialPos.x + DeltaMove, initialPos.y, 
		                       initialPos.z);
		startTime = Time.time;
	}

	// Update is called once per frame
	void Update () {

		if(!moved && renderer.enabled){

			if(Input.GetKey(KeyCode.RightArrow)){

				rigidbody2D.velocity = new Vector2(speed, 0);
				GetComponent<CharacterAnimationController>().StartMoveRight();

			}

			if(Input.GetKeyUp(KeyCode.RightArrow)){
				rigidbody2D.velocity = new Vector2(0, 0);
				//GetComponent<CharacterAnimationController>().StopMoving();
			}

			if(Input.GetKey(KeyCode.LeftArrow)){

				rigidbody2D.velocity = new Vector2(-speed, 0);
			}

			if(Input.GetKeyUp(KeyCode.LeftArrow)){
				rigidbody2D.velocity = new Vector2(0, 0);
			}


			if(Input.GetKey(KeyCode.UpArrow) && nearDoor){
				collider2D.enabled = false;
				renderer.enabled = false;

				DoorAnimation.GetComponent<DoorAnimationControl>().OpenDoor();

			}

		}
		else{
			if(Input.GetKey(KeyCode.DownArrow)){
				collider2D.enabled = true;
				renderer.enabled = true;

				DoorAnimation.GetComponent<DoorAnimationControl>().OpenDoor();
			}
		}
	}

	void FixedUpdate(){

		if(moved){
			move();
		}
	}

	void move(){

		float distCovered = (Time.time - startTime) * speed;
		float fracJourney = distCovered / DeltaMove;
		
		transform.position = Vector3.Lerp(initialPos, finalPos, fracJourney);

		if(transform.position == finalPos){
			moved = false;
		}
	}

	public void NearDoor(bool cond){
		nearDoor = cond;
	}

	public void ResetPlayerPosition(){
		transform.position = PlayerInitialPos.position;
	}



}
