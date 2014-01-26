using UnityEngine;
using System.Collections;

public class MoveConnectedObject : MonoBehaviour {



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter (Collision c) {
		c.gameObject.transform.parent = this.transform;
	}
	
	void OnCollisionExit (Collision c) {
		c.gameObject.transform.parent = null;
	}
}
