using UnityEngine;
using System.Collections;

public class Scene0 : MonoBehaviour {

	public string nextScene;

	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.UpArrow)) {
			Application.LoadLevel(nextScene);
		}
	}
	
}
