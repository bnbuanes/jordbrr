
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(GUIText))]
public class CSWayPointText : CSWaypoint {

	private GUIText text;
	private bool started = false;

	void Start () {
		text = GetComponent<GUIText> ();
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
