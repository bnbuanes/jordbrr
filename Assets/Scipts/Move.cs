using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

	public float speed;
	/// <summary>
	/// Collider on the feet of the player, to check if the player is standing
	/// </summary>
	public FeetCollider fc;

	private Platform standingOn;
		
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () { 
		if (Input.GetKey (KeyCode.W)) {
			//rigidbody.AddRelativeForce (Vector3.forward * Time.deltaTime * speed);
			transform.Translate (Vector3.forward * Time.deltaTime * speed);
		}

		float dir = Input.GetAxis ("Mouse X");
		transform.Rotate (0f, dir * 5f, 0f);

		if (Input.GetKeyDown (KeyCode.Space)) {
			if (fc.isOnGround ())
				rigidbody.AddForce (Vector3.up * 300f);
		}

	}
}
