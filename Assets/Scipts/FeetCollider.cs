using UnityEngine;
using System.Collections;

public class FeetCollider : MonoBehaviour {

	private bool grounded = true;

	public bool IsOnGround () {
		return grounded;

	}

	void OnTriggerEnter (Collider c) {
		grounded = true;
	}

	void OnTriggerExit (Collider c) {
		grounded = false;
	}
	
	void OnTriggerStay (Collider c) {
		grounded = true;
	}
}
