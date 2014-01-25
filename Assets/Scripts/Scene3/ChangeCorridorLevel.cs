using UnityEngine;
using System.Collections;

public class ChangeCorridorLevel : MonoBehaviour {

	public Transform camera;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		Debug.Log("enter");
		camera.GetComponent<CameraMove>().BeginMoveDown();
	}
}
