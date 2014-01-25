
using UnityEngine;
using System.Collections;

public class CSWayPointText : CSWaypoint {

	public GUIText text;
	private bool started = false;

	void Start () {

	}

	protected override void DoWaypointCutscene () {
		if (!started) {
			started = true;
			text.enabled = true;
		} else {
			if (IsFinished ()) {
				text.enabled = false;
				stopCutscene = true;
			}
		}
	}

}
