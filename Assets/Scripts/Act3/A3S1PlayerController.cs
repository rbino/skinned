using UnityEngine;
using System.Collections;

public class A3S1PlayerController : MonoBehaviour {

	public float DeltaMove = 0.1f;
	public float speed = 2f;
	public float startTime;
	public float xSmooth;
	
	public Transform PlayerInitialPos;
	Transform DoorAnimation;
	
	bool moved = false;
	bool nearDoor = false;
	
	Renderer renderer;
	
	Vector3 initialPos, finalPos;
	
	// Use this for initialization
	void Start () {
		initialPos = transform.position;
		finalPos = new Vector3(initialPos.x + DeltaMove, initialPos.y, 
		                       initialPos.z);
		startTime = Time.time;
		transform.GetChild(1).GetComponent<CharacterAnimationController>().StopMoving();
		
		renderer = transform.GetChild(1).renderer;
	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetKey(KeyCode.RightArrow)){
			
			rigidbody2D.velocity = new Vector2(speed, 0);
			transform.GetChild(1).GetComponent<CharacterAnimationController>().StartMoveRight();
			
		}
		
		if(Input.GetKeyUp(KeyCode.RightArrow)){
			rigidbody2D.velocity = new Vector2(0, 0);
			transform.GetChild(1).GetComponent<CharacterAnimationController>().StopMoving();
		}
		
		if(Input.GetKey(KeyCode.LeftArrow)){
			transform.GetChild(1).GetComponent<CharacterAnimationController>().StartMoveLeft();
			rigidbody2D.velocity = new Vector2(-speed, 0);
		}
		
		if(Input.GetKeyUp(KeyCode.LeftArrow)){
			rigidbody2D.velocity = new Vector2(0, 0);
			transform.GetChild(1).GetComponent<CharacterAnimationController>().StopMoving();
		}

		
		if(Input.GetKeyDown(KeyCode.UpArrow) && nearDoor){
			rigidbody2D.velocity = new Vector2(0, 0);
			transform.position = new Vector3(transform.position.x, -0.27f, transform.position.x);
			renderer.sortingOrder = 1;
			DoorAnimation.GetComponent<A3S1DoorAnimationControl>().CloseDoor();
			nearDoor = false;
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
	
	public void NearDoor(bool cond, Transform doorAnimation){
		nearDoor = cond;
		DoorAnimation = doorAnimation;
	}
	
	public void ResetPlayerPosition(){
		transform.position = PlayerInitialPos.position;
	}

}
