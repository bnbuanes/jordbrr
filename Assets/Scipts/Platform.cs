using UnityEngine;
using System.Collections;
using System.Collections.Generic;


/// <summary>
/// Platform moves between it's original position and it's goal
/// </summary>
public class Platform : MonoBehaviour {

	/// <summary>
	/// Where the platform is moving towards
	/// </summary>
	public Transform goal;

	/// <summary>
	/// The original position of the platform
	/// </summary>
	private Vector3 originalPos;

	/// <summary>
	/// possition of Goal
	/// </summary>
	private Vector3 goalPos;

	/// <summary>
	/// How fast the platform is moving
	/// </summary>
	public float speed;

	/// <summary>
	/// Are we moving towards the goal?
	/// </summary>
	private bool movingTowardsGoal = true;

	/// <summary>
	/// The things standing on this platform
	/// </summary>
	private List<Transform> standers;

	// Use this for initialization
	void Start () {
		originalPos = transform.position;
		goalPos = goal.position;
		standers = new List<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (movingTowardsGoal) {
			MoveTowards (goalPos);
			if (transform.position.Equals (goalPos))
				movingTowardsGoal = false;

		} else {
			MoveTowards (originalPos);
			if (transform.position.Equals (originalPos))
				movingTowardsGoal = true;
		}
	}

	/// <summary>
	/// Moves the platform and everything standing on it towards a target
	/// </summary>
	/// <param name="goal">The target the platform should move towards</param>
	void MoveTowards (Vector3 goal) {


		transform.position = Vector3.MoveTowards (transform.position, goal, speed * Time.deltaTime);
		foreach (Transform t in standers) {
			Vector3 standerGoal = new Vector3 (goal.x, t.position.y, goal.z);
			t.position = Vector3.MoveTowards (t.position, standerGoal, speed * Time.deltaTime);
		}
	}

	void OnCollisionEnter (Collision c) {
		standers.Add (c.gameObject.transform);
	}

	void OnCollisionExit (Collision c) {
		standers.Remove (c.gameObject.transform);
	}
}
