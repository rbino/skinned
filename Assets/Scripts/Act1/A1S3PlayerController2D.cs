using UnityEngine;
using System.Collections;

public class A1S3PlayerController2D: MonoBehaviour {

	public float DeltaMove = 0.1f;
	public float speed = 2f;
	public float startTime;
	public float xSmooth;
	public SpriteRenderer legs;

	public Transform PlayerInitialPos;
	Transform DoorAnimation;

	bool canMove = true;
	bool nearChair = false;
	bool moved = false;

	Renderer renderer;

	Vector3 initialPos, finalPos;

	// Use this for initialization
	void Start () {
		initialPos = transform.position;
		finalPos = new Vector3(initialPos.x + DeltaMove, initialPos.y, 
		                       initialPos.z);
		startTime = Time.time;
		renderer = transform.GetChild(1).renderer;
	}

	// Update is called once per frame
	void Update () {
		if (canMove){
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

			if(Input.GetKeyDown(KeyCode.UpArrow) && nearChair){
				canMove = false;
				rigidbody2D.velocity = new Vector2(0, 0); //stop the rigidbody
				transform.position = new Vector3(-0.003999157f, -0.37f, 0);
				transform.GetChild(1).GetComponent<CharacterAnimationController>().SitDown();
				StartCoroutine(ShowLegs());
				Invoke("NextLevel", 1f);
			}
		}
	
	}

	void NextLevel(){
		Application.LoadLevel("Act1Scene4");
	}

	void FixedUpdate(){

		if(moved){
			move();
		}
	}

	IEnumerator ShowLegs(){
		yield return new WaitForSeconds(0.25f);
		legs.enabled = true;
	}

	void move(){

		float distCovered = (Time.time - startTime) * speed;
		float fracJourney = distCovered / DeltaMove;
		
		transform.position = Vector3.Lerp(initialPos, finalPos, fracJourney);

		if(transform.position == finalPos){
			moved = false;
		}
	}



	public void NearChair(bool cond){
		nearChair = cond;
	}

	public void ResetPlayerPosition(){
		transform.position = PlayerInitialPos.position;
	}



}
