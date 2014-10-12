using UnityEngine;
using System.Collections;

public class MirrorSceneAct2 : MonoBehaviour {
	
	enum MirrorState{
		nothing,
		flickering,
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
			
			if(state == MirrorState.end)
				Application.LoadLevel("Act4Scene3");
		}
		
		
	}
	
	IEnumerator SetEndStateWithDelay() {
		yield return new WaitForSeconds(1);
		state = MirrorState.end;
	}
	
	IEnumerator flickering(){
		
		for(int i = 0; i < NumberOfFlickering; i++){

			if(players[0].transform.localScale.x == 1)
				players[0].transform.localScale = new Vector3(1.5f, 1, 1);
			else
				players[0].transform.localScale = new Vector3(1, 1, 1);
			
			yield return new WaitForSeconds(TimeOutFlickering);
		}

		players[0].transform.localScale = new Vector3(1.5f, 1, 1);
		
		state = MirrorState.end;
		
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

