using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PID : MonoBehaviour {

	public float Kp;
	public float Ki;
	public float Kd;

	public Transform target;
	public Transform ball;

	// Error Measurements
	float error = 0;
	float I_error = 0;
	float d_error = 0;

	//float lastError = 0f;

	float zRot = 0;

	IEnumerator Start() {
		enabled = false;
		yield return StartCoroutine (Delay());
	}


	// Update is called once per frame
	void Update () {
		
		UpdateError ();
		Update_IError ();
		Update_dError ();
			
		zRot = ((error * Kp) + (I_error * Ki) - (d_error * Kd)) * Time.deltaTime;
		//Mathf.Clamp (zRot, -45, 45);
		//transform.eulerAngles = new Vector3 (0, 0, zRot);
		Debug.Log (zRot);
		transform.Rotate (new Vector3 (	0, 0, -zRot), Space.Self);
	}


	//#########################################################

	void UpdateError(){
		error = target.position.x - ball.position.x;
		Debug.Log("ErrorX: " + error);
	}

	void Update_IError() {
		I_error += (error * Time.deltaTime);
	}

	void Update_dError (){
		d_error = ball.GetComponent<Rigidbody> ().velocity.x;
		//d_error = (error - lastError)/ Time.deltaTime;
		//lastError = error;
	}

	IEnumerator Delay() {
		yield return new WaitForSecondsRealtime (3);
		enabled = true;
	}
}


