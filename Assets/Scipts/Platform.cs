using UnityEngine;
using System.Collections;

/// <summary>
/// Platform moves between it's original position and it's goal
/// </summary>
public class Platform : MonoBehaviour {

	public Transform goal;
	private Vector3 originalPos;
	private Vector3 goalPos;
	public float speed;
	private bool movingTowardsGoal = true;


	// Use this for initialization
	void Start () {
		originalPos = transform.position;
		goalPos = goal.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (movingTowardsGoal) {
			transform.position = Vector3.MoveTowards (transform.position, goalPos, speed * Time.deltaTime);

			if (transform.position.Equals (goalPos))
				movingTowardsGoal = false;

		} else {
			transform.position = Vector3.MoveTowards (transform.position, originalPos, speed * Time.deltaTime);
			
			if (transform.position.Equals (originalPos))
				movingTowardsGoal = true;
		}
	}
}
