using UnityEngine;
using System.Collections;


public class Teleport : MonoBehaviour {

	public GameObject spawnPoint;
	private Vector3 spawnLocation;

	// Use this for initialization
	void Start () {
		spawnLocation = spawnPoint.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter (Collision c) {
		Debug.Log ("collided with: " + c.collider.gameObject);
		c.gameObject.transform.position = spawnLocation;
	}
}
