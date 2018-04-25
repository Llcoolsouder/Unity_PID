using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTarget : MonoBehaviour {

	float xMove = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		xMove = Input.GetAxis ("Horizontal") * Time.deltaTime;
		transform.localPosition += new Vector3 (xMove, 0, 0);
	}
}
