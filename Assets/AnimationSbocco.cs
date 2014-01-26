using UnityEngine;
using System.Collections;

public class AnimationSbocco : MonoBehaviour {

	public float minimum = 0;
	public float maximum = 3;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(transform.position.x,
		                                 1.81f - Mathf.Lerp(minimum, maximum, Time.time),
		                                 transform.position.z);
	}
}
