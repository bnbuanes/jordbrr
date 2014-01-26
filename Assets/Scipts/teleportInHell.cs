using UnityEngine;
using System.Collections;

public class teleportInHell : Teleport {

	public Camera cam;
	public HellFireCamera hf;

	private Quaternion cRot;
	private Vector3 cPos;

	public override void Start () {
		base.Start ();
		cPos = cam.transform.position;
		cRot = cam.transform.rotation;
	}


	public override void OnCollisionEnter (Collision c) {
		base.OnCollisionEnter (c);
		cam.transform.position = cPos;
		cam.transform.rotation = cRot;
		hf.Reset ();
	}
}