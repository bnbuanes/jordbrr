using UnityEngine;
using System.Collections;

public class HellFireCamera : MonoBehaviour {	
	private GameObject startCamera;
	private GameObject endCamera;
	float distance;
	private GameObject player;

	// Use this for initialization
	void Start ()
	{
		player = GameObject.Find ("Player");
		startCamera = GameObject.Find ("Start camera");
		endCamera = GameObject.Find ("End camera");
		//endCamera.enabled = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		distance = Vector3.Distance (player.transform.position, endCamera.transform.position);
		if (distance < 20f) {
			lowerCamera (distance);
		} else { 
			raiseCamera (distance);
		}
	}
		
	void raiseCamera (float distance)
	{
		//startCamera.enabled = false;
		//endCamera.enabled = true;
		float y = 1f + 0.3f * distance;
		transform.position = new Vector3 (transform.position.x, y, transform.position.y);

	}
	void lowerCamera (float distance)
	{
				
		float y = 1f + 0.3f * distance;
		transform.position = new Vector3 (transform.position.x, y, transform.position.z);
	}
}
			

