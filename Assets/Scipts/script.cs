﻿using UnityEngine;
using System.Collections;

public class script : MonoBehaviour {

	public GameObject player;
	private float speed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		rigidbody.AddForce (Vector3.forward * Time.deltaTime * speed);
	
	}
}
