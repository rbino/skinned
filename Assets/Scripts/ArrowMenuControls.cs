using UnityEngine;
using System.Collections;

public class ArrowMenuControls : MonoBehaviour {

	enum ArrowState{
		up,
		down
	}

	public GameObject menuPlay;
	public GameObject menuControls;

	public Vector3 positionUp;
	public Vector3 positionDown;

	public float menuScale = 1.1f;


	ArrowState state = ArrowState.up;

	// Use this for initialization
	void Start () {
		menuPlay.transform.localScale = new Vector3(menuScale, menuScale, 1);
		transform.position = positionUp;
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKey(KeyCode.UpArrow) && state == ArrowState.down){
			menuPlay.transform.localScale = new Vector3(menuScale, menuScale, 1);
			menuControls.transform.localScale = new Vector3(1, 1, 1);
			transform.position = positionUp;
			state = ArrowState.up;
		}

		if(Input.GetKey(KeyCode.DownArrow) && state == ArrowState.up){
			menuControls.transform.localScale = new Vector3(menuScale, menuScale, 1);
			menuPlay.transform.localScale = new Vector3(1, 1, 1);
			transform.position = positionDown;
			state = ArrowState.down;
		}

		if(Input.GetKey(KeyCode.Return)){
			if(state == ArrowState.up)
				Application.LoadLevel("Act1Scene0");
			else
				Application.LoadLevel("Act0Controls");
		}

	
	}
}
