using UnityEngine;
using System.Collections;

public class LightAnimation : MonoBehaviour {

	enum StateLight{
		shadow,
		flick1,
		flick2,
		flick3
	}

	StateLight state = StateLight.flick1;

	float timer = 0f;
	float TimeOut = .3f;

	public float TimeOutLight = .1f;
	public float TimeOutShadow = 1f;

	bool active = true;

	// Use this for initialization
	void Start () {
		TimeOut = TimeOutLight;
	}
	
	// Update is called once per frame
	void Update () {

		timer += Time.deltaTime;

		if(timer >= TimeOut){

			for(int i = 0; i < transform.childCount; i++)		
				transform.GetChild(i).gameObject.SetActive(active);

			active =!active;

			switch(state){

			case StateLight.shadow:
				state = StateLight.flick1;
				TimeOut = TimeOutLight;
				break;

			case StateLight.flick1:
				state = StateLight.flick2;
				TimeOut = TimeOutLight;
				break;
			
			case StateLight.flick2:
				state = StateLight.flick3;
				TimeOut = TimeOutLight;
				break;

			case StateLight.flick3:
				state = StateLight.shadow;
				TimeOut = TimeOutShadow;
				break;

			default:
				break;

			}

			timer = 0f;
		}

	}
}
