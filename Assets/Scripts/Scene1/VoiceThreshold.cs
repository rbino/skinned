﻿using UnityEngine;
using System.Collections;

public class VoiceThreshold : MonoBehaviour {

	public GUIText counterText;
	private int counter=0;
	private int iteration=0;
	private bool backHome=true;
	private Collider2D square;
	public SpriteRenderer[] guiTexts;
	public SpriteRenderer[] louders;
	private int index=0;
	public AudioSource noise;
	public AudioClip scream;
	bool mustChange=false;

	// Use this for initialization
	void Start () {
		guiTexts [index].enabled = true;
	}

	// Update is called once per frame
	void Update () {
		if (square){
			if (square.transform.position.y < -0.8){
				backHome = true;
			}
		}
		if (mustChange) {
			if (!noise.isPlaying){
				Application.LoadLevel("Act2Scene4");
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other){
		square = other;
		if (backHome){
			backHome = false;
			if (index < 6){
				guiTexts[index].enabled = false;
				index++;
				guiTexts[index].enabled = true;
			}
			//counterText.enabled = true;
			if (iteration < 2){
				if (++counter >= 3){
					counter = 0;
					if (iteration==1){
						louders[iteration-1].enabled = false;	
					}
					louders[iteration].enabled = true;
					iteration++;
					noise.audio.volume += 0.3f;
					transform.position = new Vector3 (transform.position.x, transform.position.y + 0.4f, transform.position.z);
				}
			} else if (iteration == 2){
				noise.Stop();
				noise.clip = scream;
				noise.loop = false;
				noise.volume = 1f;
				noise.priority = 150;
				noise.Play();
				mustChange = true;
			}
			//counterText.text = "" + counter;
		}
	}
}
