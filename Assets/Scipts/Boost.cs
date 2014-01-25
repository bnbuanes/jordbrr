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
		//rigidbody.AddForce (Vector3.forward * Time.deltaTime * speed);
	}

	void OnTriggerEnter(Collider c) {
		c.gameObject.rigidbody.AddForce (200f,200f,-600f);

}
}