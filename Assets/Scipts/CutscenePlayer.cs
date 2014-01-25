using UnityEngine;
using System.Collections;

public class CutscenePlayer : MonoBehaviour {

	/// <summary>
	/// The waypoints the Cutscene Player should follow.
	/// </summary>
	public CSWaypoint[] waypoints;
	private int nextWaypointIndex;
	private float speed = 3f;
	private bool finished = false;

	public Animation anim;

	protected float rotationSpeed = 0.3f;

	/// <summary>
	/// The object used as a basis axis for the Cutscene Player's rotation
	/// </summary>
	public Transform rotateObject;

	public Camera camera;
	
	/// <summary>
	/// Indicates if the cutscene is in controll. If false, a waypoint should have controll.
	/// </summary>
	private bool hasControll = true;

	public Transform head;

	// Use this for initialization
	void Start () {
		//We are before the first waypoint
		nextWaypointIndex = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (!finished && hasControll) {

			if (nextWaypointIndex >= waypoints.Length) {
				finished = true;
				if (anim != null) {
					anim.Play ();
				}
				camera.transform.parent = head;
				head.parent = null;
				head.rigidbody.isKinematic = false;
			} else {
				// Move towards target position
				Vector3 targetVector = waypoints [nextWaypointIndex].transform.position;
				//Vector3 targetAdjHeight = new Vector3 (targetVector.x, transform.position.y, targetVector.z);
				transform.position = Vector3.MoveTowards (transform.position, targetVector, speed * Time.deltaTime);
			

				Vector3 targetLookDirection = waypoints [nextWaypointIndex].transform.forward;
				Vector3 rotation = Vector3.RotateTowards (transform.forward, targetLookDirection, rotationSpeed * Time.deltaTime, rotationSpeed * Time.deltaTime);
				transform.forward = rotation;
				Debug.Log (targetLookDirection);
				//transform.forward = targetLookDirection;

				bool equalDirection = Round (transform.forward.x) == Round (targetLookDirection.x);
				equalDirection &= Round (transform.forward.y) == Round (targetLookDirection.y);
				equalDirection &= Round (transform.forward.z) == Round (targetLookDirection.z);

				if (transform.position.Equals (targetVector) && equalDirection) {
					GiveControllTo (nextWaypointIndex);
					nextWaypointIndex++;
				}
			}
		}
	}

	private float Round (float f) {
		return f = Mathf.Round (f * 1000f) / 1000f;

	}

	/// <summary>
	/// Gives controll to a waypoint.
	/// </summary>
	/// <param name="index">Index of the waypoint</param>
	private void GiveControllTo (int index) {
		hasControll = false;
		waypoints [index].GiveControll (this);
	}

	/// <summary>
	/// Returns controll to this Cutscene
	/// </summary>
	public void GiveControll () {
		hasControll = true;
	}
}
