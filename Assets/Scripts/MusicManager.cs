using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

	public AudioClip newMusic;

	void Awake(){

		GameObject music = GameObject.Find("Music");
		if(music == null){
			music = new GameObject();
			music.name = "Music";
			music.AddComponent<Music>();
			music.AddComponent("AudioSource");
			music.audio.loop = true;
			music.audio.playOnAwake = true;
			music.audio.volume = 1;
		}

		music.audio.clip = newMusic;
		music.audio.Play();

	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
