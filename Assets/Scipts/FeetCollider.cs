using UnityEngine;
using System.Collections;

public class FeetCollider : MonoBehaviour {

	private bool grounded = true;

	public bool isOnGround () {
		return grounded;
	}

	void OnCollisionEnter (Collision c) {
		Debug.Log ("collided");
		grounded = true;
	}

	void OnCollisionExit (Collision c) {
		Debug.Log ("uncollided");
		grounded = false;
	}
	
	void OnCollisionStay (Collision c) {
		grounded = true;
	}
}
