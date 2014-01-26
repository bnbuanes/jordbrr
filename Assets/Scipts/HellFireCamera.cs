using UnityEngine;
using System.Collections;

public class HellFireCamera : MonoBehaviour {	

	public GameObject player;
	public GameObject EndSpawn;

	public Transform switchPoint;
	private float distanceBeforeSwitch;
	private bool hasMoved;
	private bool hasCameraRotated;

	// Use this for initialization
	void Start () {
		distanceBeforeSwitch = Vector3.Distance (transform.position, switchPoint.position);
		hasMoved = false;
		hasCameraRotated = false;

	}
	
	// Update is called once per frame
	void Update () {
		float distance = Vector3.Distance (player.transform.position, transform.position);

		if (distance < distanceBeforeSwitch && hasMoved.Equals (false)) {
			raiseCamera (distance);
		} else { 
			lowerCamera (distance);
			hasMoved = true;
		}
	}
		
	void raiseCamera (float distance) {
		float y = 0f + (distance) / 2f;

		transform.position = new Vector3 (transform.position.x, y, transform.position.z);
	}

	void lowerCamera (float distance) {	
		float y = 1f + (distance) / 5f;

		transform.position = new Vector3 (EndSpawn.transform.position.x, y, EndSpawn.transform.position.z);
		if (hasCameraRotated.Equals (false)) {
			transform.RotateAround (transform.position, transform.up, 180f);
			transform.RotateAround (transform.position, transform.right, 40f);
			hasCameraRotated = true;
		}
	}
}