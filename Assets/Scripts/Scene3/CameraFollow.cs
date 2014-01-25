using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraFollow : MonoBehaviour
{
/*	public float xMargin = 1f;		// Distance in the x axis the player can move before the camera follows.
	public float yMargin = 1f;		// Distance in the y axis the player can move before the camera follows.
	public float xSmooth = 8f;		// How smoothly the camera catches up with it's target movement in the x axis.
	public float ySmooth = 8f;		// How smoothly the camera catches up with it's target movement in the y axis.
	public float zoomSmooth = 12f;
	public float minzoom = 6;
	public float maxzoom = 15;
	private float zoom = 15;
	private float zoominouttarget;
	public bool delayed = false;
	private bool playerChanged = false;
	private Transform player;		// Reference to the player's transform.
	public GameObject[] symbolList;
	private PlayerControl pControl;
	private float initialSymbolScale = 5.33f;
	
	void Awake()
	{
		// Setting up the reference.
		//player = GameObject.FindGameObjectWithTag("Player").transform;
		this.camera.orthographicSize = zoom;
	}

	void Start()
	{
		this.camera.orthographicSize = zoom;
		zoominouttarget = minzoom;
	}

	public void Follow(Transform player)
	{
		// Setting up the reference.
		//player = GameObject.FindGameObjectWithTag("Player").transform;
		this.player = player;
		playerChanged = true;
	}
	
	public IEnumerator DelayFollow(float delayTime)
	{
		PlayerControl p = PlayersManager.GetIt.getActivePlayer();
		if (p) {
			p.disableControl();
			PlayersManager.GetIt.setSwitchControl(false);
			delayed = true;
			yield return new WaitForSeconds(delayTime);
			delayed = false;
			p = PlayersManager.GetIt.getActivePlayer();
			p.activateControl();
			PlayersManager.GetIt.setSwitchControl(true);
		}
	}
	
	bool CheckXMargin()
	{
		// Returns true if the distance between the camera and the player in the x axis is greater than the x margin.
		return Mathf.Abs(transform.position.x - player.position.x) > xMargin;
	}
	
	bool CheckYMargin()
	{
		// Returns true if the distance between the camera and the player in the y axis is greater than the y margin.
		return Mathf.Abs(transform.position.y - player.position.y) > yMargin;
	}
	
	void Update()
	{
		if (Input.anyKeyDown && !Input.GetButtonDown("Ability")) {
			PlayersManager.GetIt.getActivePlayer().activateControl();
			delayed = false;
		}
		if (Input.GetButton("Zoom") || Input.GetAxis("Zoom") < 0) {
			zoominouttarget = maxzoom;
		} else {
			zoominouttarget = minzoom;
		}
		float ztarget = Mathf.Lerp(this.camera.orthographicSize, zoominouttarget, xSmooth * Time.deltaTime);
		if (this.camera.orthographicSize != zoominouttarget) {
			zoom = this.camera.orthographicSize;
			this.camera.orthographicSize = ztarget;
			setSymbolsPosition();
		}
	}
	
	void FixedUpdate()
	{
		if (!delayed) {
			TrackPlayer();
			if (playerChanged) {
				playerChanged = false;
				PlayersManager.GetIt.getActivePlayer().playSelectionSound();
			}
		}
	}

	void setSymbolsPosition()
	{
		if (symbolList != null) {
			for (int i=0; i<symbolList.Length; i++) {
				symbolList [i].transform.position = getSymbolsPosition(i);
				symbolList [i].transform.localScale = getSymbolsScale();
			}
		}
	}

	public Vector3 getSymbolsScale()
	{
		return zoom / initialSymbolScale * Vector3.one;
	}
	
	public Vector3 getSymbolsPosition(int i)
	{
		return Camera.main.ViewportToWorldPoint(new Vector3(0.98f - 0.03f * i, 0.03f, 8));
	}
	
	void TrackPlayer()
	{
		// By default the target x and y coordinates of the camera are it's current x and y coordinates.
		float targetX = transform.position.x;
		float targetY = transform.position.y;
		
		// If the player has moved beyond the x margin...
		if (CheckXMargin())
			// ... the target x coordinate should be a Lerp between the camera's current x position and the player's current x position.
			targetX = Mathf.Lerp(transform.position.x, player.position.x, xSmooth * Time.deltaTime);
		
		// If the player has moved beyond the y margin...
		if (CheckYMargin())
			// ... the target y coordinate should be a Lerp between the camera's current y position and the player's current y position.
			targetY = Mathf.Lerp(transform.position.y, player.position.y, ySmooth * Time.deltaTime);
		
		// Set the camera's position to the target position with the same z component.
		transform.position = new Vector3(targetX, targetY, transform.position.z);
	}*/
}
