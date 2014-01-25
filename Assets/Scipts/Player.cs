﻿using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed;
	/// <summary>
	/// Collider on the feet of the player, to check if the player is standing
	/// </summary>
	public FeetCollider fc;

	private Platform standingOn;

	private PlayerAnimation anim;

	private bool isJumping = false;
		
	// Use this for initialization
	void Start () {
		anim = GetComponent<PlayerAnimation> ();
	}
	
	// Update is called once per frame
	void Update () { 
		if (isJumping) {
			if (fc.JumpOver ()) {
				isJumping = false;
			}
		} else {
			if (Input.GetKey (KeyCode.W)) {
				anim.SetState (1);
				//rigidbody.AddRelativeForce (Vector3.forward * Time.deltaTime * speed);
				transform.Translate (Vector3.forward * Time.deltaTime * speed);
			} else {
				anim.SetState (0);
			}
		}

		float dir = Input.GetAxis ("Mouse X");
		transform.Rotate (0f, dir * 5f, 0f);

		if (Input.GetKeyDown (KeyCode.Space)) {
			if (fc.IsOnGround ()) {
				fc.StartJumping ();
				isJumping = true;
				anim.SetState (2);
				rigidbody.AddForce ((Vector3.up + transform.forward) * 300f);
			}
		}

	}
}