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

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {}

	public void Phrase1 () {
		if (isWhite) {
			gameObject.GetComponent<SpriteRenderer>().sprite = phrase1W;
		} else {
			gameObject.GetComponent<SpriteRenderer>().sprite = phrase1B;			
		}
	}
}
