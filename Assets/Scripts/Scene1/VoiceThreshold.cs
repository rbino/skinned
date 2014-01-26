using UnityEngine;
using System.Collections;

public class VoiceThreshold : MonoBehaviour {

	public GUIText counterText;
	private int counter=0;
	private int iteration=0;
	private bool backHome=true;
	private Collider2D square;
	public SpriteRenderer[] guiTexts;
	private int index=0;
	public AudioSource noise;

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
	}

	void OnTriggerEnter2D(Collider2D other){
		square = other;
		if (backHome){
			guiTexts[index].enabled = false;
			index++;
			guiTexts[index].enabled = true;
			//counterText.enabled = true;
			if (iteration < 2){
				if (++counter >= 3){
					counter = 0;
					iteration++;
					noise.audio.volume += 0.3f;
					transform.position = new Vector3 (transform.position.x, transform.position.y + 0.4f, transform.position.z);
					backHome = false;
				}
			} else if (iteration ==2){
				
			}
			//counterText.text = "" + counter;
		}
	}
}
