﻿using UnityEngine;
using System.Collections;

public class MusicAct5 : MonoBehaviour {

	public AudioClip music1;
	public AudioClip music2;
	public AudioClip music3;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this);
	}
	
	// Update is called once per frame
	void Update () {}

	public void ChangeClip (int clipNumber) {
		if (clipNumber == 1) {
			gameObject.GetComponent<AudioSource>().clip = music1;
			gameObject.GetComponent<AudioSource>().Play();
		} else if (clipNumber == 2) {
			gameObject.GetComponent<AudioSource>().clip = music2;
			gameObject.GetComponent<AudioSource>().Play();			
		} else if (clipNumber == 3) {
			gameObject.GetComponent<AudioSource>().clip = music3;
			gameObject.GetComponent<AudioSource>().Play();			
		}
	}
}
