using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starSpawner : MonoBehaviour {

	public GameObject starPrefab;
	public GameObject camera;

	public int ammountOfStarsInScene;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < ammountOfStarsInScene; i++) {

			GameObject newObj = Instantiate(starPrefab);
			newObj.name = "Star" + i + 1;
			newObj.transform.parent = transform;
		}
	}
}
