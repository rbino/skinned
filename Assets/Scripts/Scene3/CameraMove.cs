﻿using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {

	public Transform startMarker;
	public Transform endMarker;
	public float speed = 1.0F;
	private float startTime;
	private float journeyLength;
	public Transform target;
	public float smooth = 5.0F;

	// Use this for initialization
	void Start () {
		startTime = Time.time;
		journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
	}
	
	// Update is called once per frame
	void Update () {
		float distCovered = (Time.time - startTime) * speed;
		float fracJourney = distCovered / journeyLength;
		Debug.Log (transform.position);
		transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fracJourney);
	}
}
