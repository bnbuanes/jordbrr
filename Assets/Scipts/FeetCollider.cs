using UnityEngine;
using System.Collections;

public class FeetCollider : MonoBehaviour {

	private bool grounded = true;

	public bool isOnGround () {
		return grounded;
	}

	void OnCollisionEnter (Collision c) {
		grounded = true;
	}

	void OnCollisionExit (Collision c) {
		grounded = false;
	}
	
	void OnCollisionStay (Collision c) {
		grounded = true;
	}
}
