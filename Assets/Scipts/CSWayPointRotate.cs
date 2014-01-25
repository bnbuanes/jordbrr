using UnityEngine;
using System.Collections;

public class CSWayPointRotate : CSWaypoint {

	public float DegreesToRotate;
	private float degreesRotated;


	void Start () {
		degreesRotated = 0f;
	}

	protected override void DoWaypointCutscene () {

		if (degreesRotated < 90f) {
			mainCutscene.transform.RotateAround (mainCutscene.rotateObject.position, Vector3.right, 2f);
			degreesRotated += 2f;
		} else {
			stopCutscene = true;
		}
	}
}
