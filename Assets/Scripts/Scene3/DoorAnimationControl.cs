using UnityEngine;
using System.Collections;

public class DoorAnimationControl : MonoBehaviour {

	private Animator animator;

	public GameObject soundOpen, soundClose;
	
	// Use this for initialization
	void Start()
	{
		animator = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OpenDoor(){
		animator.SetTrigger("DoorOpened");
		soundOpen.audio.Play();
		Invoke ("PlayCloseDoor", 0.01f);

	}

	void PlayCloseDoor(){
		soundClose.audio.Play();
	}


}
