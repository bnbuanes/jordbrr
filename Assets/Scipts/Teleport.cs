using UnityEngine;
using System.Collections;

/// <summary>
/// Teleports any objects that collide to a set point
/// </summary>
public class Teleport : MonoBehaviour {

	/// <summary>
	/// The spawn point colliding objects should be teleported to
	/// </summary>
	public GameObject spawnPoint;
	private Vector3 spawnLocation;

	// Use this for initialization
	void Start () {
		spawnLocation = spawnPoint.transform.position;
	}

	void OnCollisionEnter (Collision c) {
		if (c.gameObject.rigidbody != null) {
			//Stop current object spinning
			c.gameObject.rigidbody.angularVelocity = Vector3.zero;
		}

		c.gameObject.transform.position = spawnLocation;
	}
}
