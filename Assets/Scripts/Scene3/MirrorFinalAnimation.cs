using UnityEngine;
using System.Collections;

public class MirrorFinalAnimation : MonoBehaviour {

	enum MirrorState{
		nothing,
		flickering,
		collapse
	}

	public float TimeOutFlickering = 0.5f;
	public int NumberOfFlickering = 4;
	public Renderer FlickeringObject;

	public GameObject[] players;

	MirrorState state = MirrorState.nothing;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKey(KeyCode.UpArrow)){

			if(state == MirrorState.flickering){
				StartCoroutine("flickering");
			}

			if(state == MirrorState.collapse){
				foreach(GameObject player in players)
					player.transform.GetChild(0).GetComponent<CharacterAnimationController>().Collapse();
			}
		}

	
	}

	IEnumerator flickering(){

		for(int i = 0; i < NumberOfFlickering; i++){

			if(FlickeringObject.enabled)
				FlickeringObject.enabled = false;
			else
				FlickeringObject.enabled = true;

			yield return new WaitForSeconds(TimeOutFlickering);
		}

		state = MirrorState.collapse;

		yield return new WaitForSeconds(0);
	}

	void OnTriggerEnter2D(Collider2D other){

		if(other.tag == "Player"){
			state = MirrorState.flickering;

			foreach(GameObject player in players)
				player.GetComponent<PlayerController2DGeneric>().Block();

		}

	}
}
