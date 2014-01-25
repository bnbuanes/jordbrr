using UnityEngine;
using System.Collections;

public class StartGameOnCollision : MonoBehaviour {

	public Player player;
	public Transform body;

	void OnTriggerEnter (Collider c) {
		c.gameObject.rigidbody.velocity = Vector3.zero;
		c.gameObject.rigidbody.useGravity = false;
		c.gameObject.rigidbody.isKinematic = true;
		c.gameObject.rigidbody.freezeRotation = true;

		body.gameObject.SetActive (false);
		player.gameObject.SetActive (true);
	}
}
