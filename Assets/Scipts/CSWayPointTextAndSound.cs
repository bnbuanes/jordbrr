
using UnityEngine;
using System.Collections;

public class CSWayPointTextAndSound : CSWaypoint {

	public GUIText text;
	private AudioSource sound;
	private bool started = false;

	void Start () {
		sound = GetComponent<AudioSource> ();
	}

	protected override void DoWaypointCutscene () {
		if (!started) {
			started = true;
			text.enabled = true;

			if (sound != null)
				sound.Play ();

		} else {
			if (IsFinished ()) {
				text.enabled = false;
				stopCutscene = true;
			}
		}
	}

}
