using UnityEngine;
using System.Collections;

public class HellFireCamera : MonoBehaviour {	
	public Camera mainCamera;

	public GameObject player;
	public GameObject EndSpawn;
	private Vector3 endSpawnVector;
	private bool hasMoved;
	private bool hasCameraRotated;

	// Use this for initialization
	void Start ()
	{
		//mainCamera = Camera.main;
		hasMoved = false;
		hasCameraRotated = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		float distance = Vector3.Distance (player.transform.position, mainCamera.transform.position);

		if (distance < 20 && hasMoved.Equals (false)) {
			raiseCamera (distance);
		} else { 
			lowerCamera (distance);
			hasMoved = true;
			//transform.position = new Vector3 (EndSpawn.transform.position.x, 5f, EndSpawn.transform.position.z);
		}
	}
		
	void raiseCamera (float distance)
	{
		float y = 1f + 0.3f * distance;

		transform.position = new Vector3 (transform.position.x, y, transform.position.y);

	}

	void lowerCamera (float distance)
	{	
		endSpawnVector = EndSpawn.transform.position;
		float y = 0.5f + (distance - 1.3f) / distance;


		transform.position = new Vector3 (EndSpawn.transform.position.x, y, EndSpawn.transform.position.z);
		if (hasCameraRotated.Equals (false)) {
			transform.RotateAround (transform.position, transform.up, 180f);
			hasCameraRotated = true;
		}
	}
}