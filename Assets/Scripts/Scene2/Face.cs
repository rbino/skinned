using UnityEngine;
using System.Collections;

public class Face : MonoBehaviour {

	public Sprite inside;
	private Sprite outside;
	private bool insert = false;

	// Use this for initialization
	void Start () {
		outside = this.gameObject.GetComponent<SpriteRenderer>().sprite;
	}
	
	// Update is called once per frame
	void Update () {}

	public void ChangeSprite () {
		if (!insert) {
			this.gameObject.GetComponent<SpriteRenderer>().sprite = inside;
			insert = true;
		} else {
			this.gameObject.GetComponent<SpriteRenderer>().sprite = outside;
			insert = false;			
		}
	}
}
