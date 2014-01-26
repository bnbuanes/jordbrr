using UnityEngine;
using System.Collections;

public class Boost : MonoBehaviour {

	/// <summary>
	/// The power of the bool.
	/// </summary>
	public float power;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		//rigidbody.AddForce (Vector3.forward * Time.deltaTime * speed);
	}

	void OnTriggerEnter (Collider c) {	
		Transform t = c.transform.parent;
		if (t != null) {
			Rigidbody r = c.transform.parent.gameObject.rigidbody;
			if (r != null)
				r.AddForce (0f, 100f * power, -200f * power);
		}
	}
}