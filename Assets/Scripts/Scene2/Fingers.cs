using UnityEngine;
using System.Collections;

public class Fingers : MonoBehaviour {
	
	public GameObject face;
	public GameObject start;
	public GameObject end;
	private float startX;
	private float endX;

	private float speedModule = 0.1f;
	private Vector3 speedDirection = new Vector3(-1, 0, 0);
	private const float offset = 0.085f;
	private float oppositeForceModule;
	private Vector3 oppositeForceDirection = new Vector3(1, 0, 0);
	private bool insert = false;

	// Use this for initialization
	void Start () {
		startX = start.GetComponent<Transform>().position.x;
		endX = end.GetComponent<Transform>().position.x;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.LeftArrow)) {
			//fingers go ahead a little
			transform.position = transform.position + (speedDirection * speedModule);
		}
		if (insert) {
			UpdateOppositeForceModule();
			transform.position = transform.position + (oppositeForceDirection * oppositeForceModule);
		}
	}

	private void UpdateOppositeForceModule () {
		float fingersProgress = transform.position.x - startX;
		float endDistance = endX - startX;
		oppositeForceModule = (fingersProgress * (speedModule - offset)) / endDistance;
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.name.Equals("Mouth")) {
			if (!insert) {
				insert = true;
				face.GetComponent<Face>().ChangeSprite();
			}
		}
		if (other.gameObject.name.Equals("DeepThroat")) {
			Debug.Log("End");
		}
	}

	void OnTriggerExit2D (Collider2D other) {
		if (other.gameObject.name.Equals("Mouth")) {
			if (insert) {
				insert = false;
				oppositeForceModule = 0;
				face.GetComponent<Face>().ChangeSprite();
			}
		}
	}
}
