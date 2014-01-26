using UnityEngine;
using System.Collections;

/// <summary>
/// Plays a sound whenever hit by a Collision or a Collider - can be used on trigger and nontrigger colliders.
/// </summary>
public class PlayOnImpact : MonoBehaviour {

	private AudioSource sound;
	/// <summary>
	/// Set to true if the script should only play a sound on the first impact
	/// </summary>
	public bool PlayOnlyOnce;
	private bool shouldPlay = true;

	void Start () {
		sound = GetComponent<AudioSource> ();
	}

	void OnCollisionEnter (Collision c) {
		PlaySound ();
	}

	void OnTriggerEnter (Collider c) {
		PlaySound ();
	}

	void PlaySound () {
		if (shouldPlay) {
			sound.Play ();
			if (PlayOnlyOnce)
				shouldPlay = false;
		}
	}
}
