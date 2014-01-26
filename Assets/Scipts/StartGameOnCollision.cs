using UnityEngine;
using System.Collections;

public class StartGameOnCollision : MonoBehaviour {

	public Player player;

	/// <summary>
	/// These objects are hidden on play
	/// </summary>
	public GameObject[] removeOnPlay;
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

			foreach (GameObject g in removeOnPlay) {
				g.SetActive (false);
			}
			player.gameObject.SetActive (true);
			hasBeenCollidedWith = true;
		}
	}
}
