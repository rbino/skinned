using UnityEngine;
using System.Collections;

public class Face : MonoBehaviour {

	public GameObject deepThroat;
	private Vector3 stage2 = new Vector3(0.2f, -0.5f, 0);
	private Vector3 stage3 = new Vector3(-0.1f, -0.5f, 0);

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

	public void SetStage2 () {
		deepThroat.transform.position = stage2;
	}

	public void SetStage3 () {
		deepThroat.transform.position = stage3;
	}
}
