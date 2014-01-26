using UnityEngine;
using System.Collections;

public class Thoughts : MonoBehaviour {

	public Sprite phrase1B;
	public Sprite phrase2B;
	public Sprite phrase3B;	
	public Sprite phrase1W;
	public Sprite phrase2W;
	public Sprite phrase3W;
	private bool isWhite = false;
	private int index = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {}

	/*
	public void Phrase1 () {
		if (isWhite) {
			gameObject.GetComponent<SpriteRenderer>().sprite = phrase1W;
		} else {
			gameObject.GetComponent<SpriteRenderer>().sprite = phrase1B;			
		}
		index = 1;
	}
	*/
	
	public void Phrase2 () {
		if (isWhite) {
			gameObject.GetComponent<SpriteRenderer>().sprite = phrase2W;
		} else {
			gameObject.GetComponent<SpriteRenderer>().sprite = phrase2B;			
		}
		index = 2;
	}
	
	public void Phrase3 () {
		if (isWhite) {
			gameObject.GetComponent<SpriteRenderer>().sprite = phrase3W;
		} else {
			gameObject.GetComponent<SpriteRenderer>().sprite = phrase3B;			
		}
		index = 3;
	}

	public void ChangeColor () {
		if (index == 1) {
			if (isWhite) {
				gameObject.GetComponent<SpriteRenderer>().sprite = phrase1B;
				isWhite = false;
			} else {
				gameObject.GetComponent<SpriteRenderer>().sprite = phrase1W;
				isWhite = true;
			}
		} else if (index == 2) {
			if (isWhite) {
				gameObject.GetComponent<SpriteRenderer>().sprite = phrase2B;
				isWhite = false;
			} else {
				gameObject.GetComponent<SpriteRenderer>().sprite = phrase2W;
				isWhite = true;
			}
		} else if (index == 3) {
			if (isWhite) {
				gameObject.GetComponent<SpriteRenderer>().sprite = phrase3B;
				isWhite = false;
			} else {
				gameObject.GetComponent<SpriteRenderer>().sprite = phrase3W;
				isWhite = true;
			}
		}
	}
}
