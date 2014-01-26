using UnityEngine;
using System.Collections;

public class StaticScene : MonoBehaviour {

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
