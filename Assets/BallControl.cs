using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour {

	public Transform beam;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			float dir = Random.Range (-10f, 10f);
			gameObject.GetComponent<Rigidbody> ().AddForce (beam.transform.right * dir, ForceMode.Impulse);
		}
	}
}
