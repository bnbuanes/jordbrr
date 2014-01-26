using UnityEngine;
using System.Collections;

public class StartGameOnCollision : MonoBehaviour {

	public Player player;
	public Transform body;
	private bool hasBeenCollidedWith = false;
	private AudioSource playOnCollide;

	void Start () {
		playOnCollide = GetComponent<AudioSource> ();
	}

	void OnTriggerEnter (Collider c) {
		if (!hasBeenCollidedWith) {
			c.gameObject.rigidbody.velocity = Vector3.zero;
			c.gameObject.rigidbody.useGravity = false;
			c.gameObject.rigidbody.isKinematic = true;
			c.gameObject.rigidbody.freezeRotation = true;

			if (playOnCollide != null)
				playOnCollide.Play ();

			body.gameObject.SetActive (false);
			player.gameObject.SetActive (true);
			hasBeenCollidedWith = true;
		}
	}
}
