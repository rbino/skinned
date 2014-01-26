using UnityEngine;
using System.Collections;

public class LightAnimation : MonoBehaviour {

	// Use this for initialization
	void Start () {

		StartCoroutine("Fade");
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator Fade() {

		yield return new WaitForSeconds(.1f);
	}
}
