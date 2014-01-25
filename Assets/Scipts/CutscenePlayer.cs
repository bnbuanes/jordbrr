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

	/// <summary>
	/// The object used as a basis axis for the Cutscene Player's rotation
	/// </summary>
	public Transform rotateObject;
	
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
			} else {
				Vector3 targetVector = waypoints [nextWaypointIndex].transform.position;
				Vector3 targetAdjHeight = new Vector3 (targetVector.x, transform.position.y, targetVector.z);
				transform.position = Vector3.MoveTowards (transform.position, targetAdjHeight, speed * Time.deltaTime);
			
				if (transform.position.x == waypoints [nextWaypointIndex].transform.position.x && transform.position.z == waypoints [nextWaypointIndex].transform.position.z) {
					GiveControllTo (nextWaypointIndex);
					nextWaypointIndex++;
				}
			}
		} else if (finished) {
			head.parent = null;
			head.rigidbody.isKinematic = false;
		}
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
