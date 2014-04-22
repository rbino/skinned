using UnityEngine;
using System.Collections;

public class TheEnd : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKey(KeyCode.UpArrow)){
			Application.LoadLevel("Act5Credits");
		}
	
	}
}
