using UnityEngine;
using System.Collections;

public class MirrorFinalAnimation : MonoBehaviour {

	enum MirrorState{
		nothing,
		flickering,
		collapse,
		end
	}

	public float TimeOutFlickering = 0.5f;
	public int NumberOfFlickering = 4;
	public Renderer[] FlickeringObject;

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

				StartCoroutine("SetEndStateWithDelay");
			}

			if(state == MirrorState.end)
				Application.LoadLevel("Act5End");
		}

	
	}

	IEnumerator SetEndStateWithDelay() {
		yield return new WaitForSeconds(1);
		state = MirrorState.end;
	}

	IEnumerator flickering(){

		for(int i = 0; i < NumberOfFlickering; i++){

			if(FlickeringObject[0].enabled){
				FlickeringObject[0].enabled = false;
				FlickeringObject[1].enabled = true;
			}
			else
			{
				FlickeringObject[0].enabled = true;
				FlickeringObject[1].enabled = false;
			}

			yield return new WaitForSeconds(TimeOutFlickering);
		}

		FlickeringObject[0].enabled = false;

		FlickeringObject[1].enabled = true;

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
