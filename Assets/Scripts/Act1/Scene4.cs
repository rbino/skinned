using UnityEngine;
using System.Collections;

public class Scene4 : MonoBehaviour {

	public string nextScene;
	private GameObject music;

	// Use this for initialization
	void Start () {
		GameObject.Find("Music");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.UpArrow)) {
			Destroy(music);
			Application.LoadLevel(nextScene);
		}
	}
}
