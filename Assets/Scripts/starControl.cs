using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starControl : MonoBehaviour {
	
	// player variables
	public GameObject player;
	private Transform playerTransform;

	// star variables
	public float minSpeed;
	public float maxSpeed;
	public float speedIncriment;
	public float minPosX;
	public float maxPosX;
	public float minPosY;
	public float maxPosY;
	public float minPosZ;
	public float maxPosZ;
	public float hyperSpeed;

	private Transform t;
	private TrailRenderer trailRend;
	private MeshRenderer meshRend;
	private float speed;
	private float originalMinPosX;
	private float originalMaxPosX;
	private float originalMinPosY;
	private float originalMaxPosY;
	private float originalMinPosZ;
	private float originalMaxPosZ;

	// Use this for initialization
	void Start () {
		// player components
		player = GameObject.FindGameObjectWithTag("Player");
		playerTransform = player.GetComponent<Transform> ();
		// star components
		t = GetComponent<Transform> ();
		trailRend = GetComponent<TrailRenderer> ();
		meshRend = GetComponent<MeshRenderer> ();
		// star properties
		t.position = newRandomPos ();
		speed = Random.Range (minSpeed, maxSpeed);
		trailRend.time = 0.05f;
		originalMinPosX = minPosX;
		originalMaxPosX = maxPosX;
		originalMinPosY = minPosY;
		originalMaxPosY = maxPosY;
		originalMinPosZ = minPosZ;
		originalMaxPosZ = maxPosZ;
	}
	
	// Update is called once per frame
	void Update () {
		t.Translate (0, 0, -speed * Time.deltaTime);
		speed += speedIncriment;

		if (Input.GetKeyDown(KeyCode.Space)) { // if space is pressed down
			trailRend.time = 0.5f;
			meshRend.enabled = false;
		}
		if (Input.GetKeyUp (KeyCode.Space)) { // if space is released
			trailRend.time = 0.05f;
			meshRend.enabled = true;
		}
		if (Input.GetKey (KeyCode.Space)) { // if space is held down
			speed += hyperSpeed;
		}

		resetStarPos ();
		recalculateMinMax ();
	}

	public void recalculateMinMax() {
		minPosX = playerTransform.position.x + originalMinPosX;
		maxPosX = playerTransform.position.x + originalMaxPosX;
		minPosY = playerTransform.position.y + originalMinPosY;
		maxPosY = playerTransform.position.y + originalMaxPosY;
		minPosZ = playerTransform.position.z + originalMinPosZ;
		maxPosZ = playerTransform.position.z + originalMaxPosZ;
	}

	private void resetStarPos() {
		if (t.position.z < playerTransform.position.z) {
			speed = Random.Range (minSpeed, maxSpeed);
			t.position = newRandomPos ();
			trailRend.Clear ();
		}
	}

	// Use this method to generate new random positions to relocate stars after they are out of the view of the camera
	private Vector3 newRandomPos() {
		float posX = Random.Range (minPosX, maxPosX);
		float posY = Random.Range (minPosY, maxPosY);
		float posZ = Random.Range (minPosZ, maxPosZ);

		// the following if statement stops stars from being too close to the camera so they dont hit you in the face...
		if (posX > -1 && posX < 1 && posY > -1 && posY < 1) { // if the position of the star is between -1 and 1 for x and y axis
			return newRandomPos (); // get new random position
		}
		return new Vector3 (posX, posY, posZ);
	}
}
