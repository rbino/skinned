using UnityEngine;
using System.Collections;

public class SoundTrackController : MonoBehaviour {

	GameObject soundtrack;

	int index = 1;

	// Use this for initialization
	void Start () {

		soundtrack = GameObject.Find("Music");
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void NextClip(){
		index++;
		soundtrack.GetComponent<MusicAct5>().ChangeClip(index);
	}

	public void ResetClip(){
		index = 1;
		soundtrack.GetComponent<MusicAct5>().ChangeClip(index);
	}
}
