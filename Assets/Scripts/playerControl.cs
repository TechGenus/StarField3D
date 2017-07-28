using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour {

	public float movementSpeed;

	private Transform t;
	private float hAxis;
	private float vAxis;

	// Use this for initialization
	void Start () {
		t = GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		hAxis = Input.GetAxis ("Horizontal");
		vAxis = Input.GetAxis ("Vertical");

		Vector3 offset = new Vector3 (hAxis, vAxis, 0) * movementSpeed;
		t.position += offset * Time.deltaTime;
	}
}
