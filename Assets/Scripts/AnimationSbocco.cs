using UnityEngine;
using System.Collections;

public class AnimationSbocco : MonoBehaviour {

	public float minimum = 0;
	public float maximum = 3;

	float time;

	// Use this for initialization
	void Start () {
		time = 0;
	}
	
	// Update is called once per frame
	void Update () {

		time += Time.deltaTime;
		transform.position = new Vector3(transform.position.x,
		                                 1.81f - Mathf.Lerp(minimum, maximum, time),
		                                 transform.position.z);
	}
}
