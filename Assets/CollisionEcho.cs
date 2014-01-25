using UnityEngine;
using System.Collections;

public class CollisionEcho : MonoBehaviour {

	/*void OnCollisionEnter (Collision c) {
		foreach (ContactPoint cn in c.contacts)
			Debug.Log ("enter: " + cn.thisCollider);
		
	}

	void OnCollisionExit (Collision c) {
		foreach (ContactPoint cn in c.contacts)
			Debug.Log ("exit: " + cn.thisCollider);
	}

*/
	void OnTriggerEnter (Collider c) {
		Debug.Log ("On trigger enter: " + c);
	}
}
