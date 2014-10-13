using UnityEngine;
using System.Collections;

public class RequestAutorization : MonoBehaviour {

	public static bool IsMicrophoneEnabled = true;

	// Use this for initialization
	void Start () {

		StartCoroutine(RequestMicrophone());
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator RequestMicrophone () {
		
		# if UNITY_WEBPLAYER
		yield return Application.RequestUserAuthorization(UserAuthorization.Microphone);
		
		
		if (Application.HasUserAuthorization(UserAuthorization.Microphone)) 
		{
			IsMicrophoneEnabled = true;
			
		} else {
			IsMicrophoneEnabled = false;
			
		}           
		#endif
		
		yield return null;
		
	}
}
