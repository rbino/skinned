using UnityEngine;
using System.Collections;

public class DoctorMove : MonoBehaviour {

	enum DoctorState{
		Right, Left
	}
	
	public float Speed = 1f;
	public float TimeOutSpeed = 1f;

	public Transform DoctorInitialPos, DoctorFinalPos; 

	Transform FieldOfView;

	float FieldOfViewMoveRight =  0.225f;
	float FieldOfViewMoveLeft = - 0.45f;
	float FieldOfViewMove = 0.255f;
	float FieldOfViewAngle =  180;
	float startTime, distance;

	DoctorState state = DoctorState.Right;


	// Use this for initialization
	void Start () {
		FieldOfView = transform.GetChild(0);

		startTime = Time.time;
		distance = DoctorFinalPos.position.x - DoctorInitialPos.position.x;
	}
	
	// Update is called once per frame
	void Update () {

		transform.position = Vector3.Lerp(DoctorInitialPos.position, DoctorFinalPos.position, 
		                                 (Time.time - startTime)*Speed/distance);

		if(transform.position == DoctorFinalPos.position)
			ReturnBack();
	}

	void ReturnBack(){

		if(state == DoctorState.Left){
			state = DoctorState.Right;
			transform.GetChild(1).GetComponent<DoctorAnimationControl>().StartMoveRight();
			FieldOfViewMove = FieldOfViewMoveRight*2;
		}else{
			state = DoctorState.Left;
			transform.GetChild(1).GetComponent<DoctorAnimationControl>().StartMoveLeft();
			FieldOfViewMove = FieldOfViewMoveLeft;
		}

		startTime = Time.time;

		DoctorFinalPos.position = DoctorInitialPos.position;
		DoctorInitialPos.position = transform.position;
		FieldOfViewAngle = - FieldOfViewAngle;

		FieldOfView.position = new Vector3(FieldOfView.transform.position.x + FieldOfViewMove,
                                           FieldOfView.transform.position.y,
                                           FieldOfView.transform.position.z);

		FieldOfView.eulerAngles += new Vector3(0, FieldOfViewAngle, 0);
	}

	public void PlayerDetected(){

		/*if(state == DoctorState.Normal){
			ChangeSpeed();
			state = DoctorState.Alert;
		}else{*/
			Debug.Log("catch player");
		//}

	}

	void ChangeSpeed(){
		Speed += 0.1f;
		Invoke ("NormalSpeed", TimeOutSpeed);
	}

	void NormalSpeed(){
		Speed -= 0.1f;
	}

	
}
