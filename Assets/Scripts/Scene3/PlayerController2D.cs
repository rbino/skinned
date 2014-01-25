using UnityEngine;
using System.Collections;

public class PlayerController2D : MonoBehaviour {

	public float DeltaMove = 0.1f;
	public float speed = 1f;
	public float startTime;
	public float xSmooth;

	bool moved = false;

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

		if(Input.GetKey(KeyCode.RightArrow) && !moved){

			moved = true;
			initialPos = transform.position;
			finalPos = new Vector3(initialPos.x + DeltaMove, initialPos.y, 
			                       initialPos.z);
			startTime = Time.time;

			move ();


		}

		if(Input.GetKey(KeyCode.LeftArrow) && !moved){

			moved = true;
			initialPos = transform.position;
			finalPos = new Vector3(initialPos.x - DeltaMove, initialPos.y, 
			                       initialPos.z);
			startTime = Time.time;

			move ();
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
		
		transform.position = Vector3.Lerp(initialPos, finalPos, Time.deltaTime*xSmooth);

		if(transform.position == finalPos){
			moved = false;
		}
	}



}
