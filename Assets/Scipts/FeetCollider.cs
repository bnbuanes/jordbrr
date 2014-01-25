using UnityEngine;
using System.Collections;

public class FeetCollider : MonoBehaviour {

	private bool grounded = true;
	private bool jumpStarted = false;

	public bool IsOnGround () {
		return grounded;
	}

	public bool JumpOver () {
		return !jumpStarted;
	}

	public void StartJumping () {
		jumpStarted = true;
	}

	void OnTriggerEnter (Collider c) {
		jumpStarted = false;
		grounded = true;
	}

	void OnTriggerExit (Collider c) {
		grounded = false;
	}
	
	void OnTriggerStay (Collider c) {
		grounded = true;
	}
}
