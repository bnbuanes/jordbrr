using UnityEngine;
using System.Collections;

public class Boost : MonoBehaviour {
	
	public GameObject player;
	private float speed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		}

	void OnCollisionEnter (Collision c) {
		Debug.Log ("collided with: " + c.collider.gameObject);
		c.gameObject.rigidbody.transform.Translate(Vector3.forward * 5);
	}
}

