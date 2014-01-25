using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {

	Vector3 startMarker, endMarker;
	public float speed = 1.0F;
	private float startTime;
	private float journeyLength;
	public float smooth = 5.0F;

	public Transform player;
	public float xMargin = 1.5f;
	public float xSmooth = 15f;
	public float deltaY = 1.8f;

	bool isMovingDown = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate(){
		TrackPlayer();

		if(isMovingDown){
			MoveDown();
		}
	}

	bool CheckXMargin()
	{
		// Returns true if the distance between the camera and the player in the x axis is greater than the x margin.
		return Mathf.Abs(transform.position.x - player.position.x) > xMargin;
	}

	void TrackPlayer()
	{
		// By default the target x and y coordinates of the camera are it's current x and y coordinates.
		float targetX = transform.position.x;
		
		// If the player has moved beyond the x margin...
		if (CheckXMargin())
			// ... the target x coordinate should be a Lerp between the camera's current x position and the player's current x position.
			targetX = Mathf.Lerp(transform.position.x, player.position.x, xSmooth * Time.deltaTime);
		
		// Set the camera's position to the target position with the same z component.
		transform.position = new Vector3(targetX, transform.position.y, transform.position.z);
	}

	public void BeginMoveDown(){
		startTime = Time.time;
		//journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
		isMovingDown = true;

		startMarker = transform.position;
		endMarker = new Vector3(startMarker.x, startMarker.y - deltaY, startMarker.z);
	}

	void MoveDown(){
		float distCovered = (Time.time - startTime) * speed;
		float fracJourney = distCovered / journeyLength;
		transform.position = Vector3.Lerp(startMarker, endMarker, fracJourney);

		if(transform.position == endMarker)
			isMovingDown = false;
	}
}
