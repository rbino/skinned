using UnityEngine;
using System.Collections;

public class Fingers : MonoBehaviour {
	
	public GameObject face;
	public GameObject start;
	public GameObject end;
	private float startX;
	private float startDimension;
	private float endX;

	private bool isMoving = true;
	private float speedModule = 0.1f;
	private Vector3 speedDirection = new Vector3(-1, 0, 0);
	private const float offset = 0.085f;
	private float oppositeForceModule;
	private Vector3 oppositeForceDirection = new Vector3(1, 0, 0);
	private bool insert = false;
	private bool stage1 = false;
	private bool stage2 = false;

	public GUIText thoughts;
	private GameObject music;

	// Use this for initialization
	void Start () {
		thoughts.text = "I must do it!";
		startX = start.GetComponent<Transform>().position.x;
		startDimension = start.GetComponent<Transform>().localScale.x;
		endX = end.GetComponent<Transform>().position.x;
		music = GameObject.Find("Music");
	}
	
	// Update is called once per frame
	void Update () {
		if (isMoving) {
			if (Input.GetKeyDown(KeyCode.LeftArrow)) {
				//fingers go ahead a little
				transform.position = transform.position + (speedDirection * speedModule);
			}
		}
		if (insert) {
			UpdateOppositeForceModule();
			transform.position = transform.position + (oppositeForceDirection * oppositeForceModule);
		}
	}

	private void UpdateOppositeForceModule () {
		float fingersProgress = transform.position.x - startX - (startDimension / 2);
		float endDistance = endX - startX - (startDimension / 2);
		oppositeForceModule = (fingersProgress * (speedModule - offset)) / endDistance;
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.name.Equals("Mouth")) {
			if (!insert) {
				insert = true;
				face.GetComponent<Face>().ChangeSprite();
				thoughts.color = Color.white;
			}
		}
		if (other.gameObject.name.Equals("DeepThroat")) {
			if (!stage1) {
				isMoving = false;
				thoughts.text = "It's too difficult.";
				face.GetComponent<Face>().SetStage2();
				endX = end.GetComponent<Transform>().position.x;
				stage1 = true;
			} else if (!stage2) {
				isMoving = false;
				thoughts.text = "It's unbearable.";
				face.GetComponent<Face>().SetStage3();
				endX = end.GetComponent<Transform>().position.x;
				stage2 = true;
			} else {
				//Debug.Log("End");
				Destroy(music);
				Application.LoadLevel("Act3Scene3");
			}
		}
	}

	void OnTriggerExit2D (Collider2D other) {
		if (other.gameObject.name.Equals("Mouth")) {
			if (insert) {
				insert = false;
				oppositeForceModule = 0;
				isMoving = true;
				face.GetComponent<Face>().ChangeSprite();
				thoughts.color = Color.black;
			}
		}
	}
}
