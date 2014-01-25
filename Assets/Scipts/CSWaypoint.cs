using UnityEngine;
using System.Collections;

public class CSWaypoint : MonoBehaviour {

	protected CutscenePlayer mainCutscene;
	protected float timeOfControll;
	protected bool stopCutscene = false;
	public float duration;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (mainCutscene != null) {

			DoWaypointCutscene ();

			//Do our stuff
			if (stopCutscene) {
				ReturnControll ();
			}
		}
	}

	public void GiveControll (CutscenePlayer main) {
		mainCutscene = main;
		timeOfControll = Time.time;
	}

	private void ReturnControll () {
		mainCutscene.GiveControll ();
		mainCutscene = null;
	}

	protected virtual void DoWaypointCutscene () {
		if (IsFinished ())
			stopCutscene = true;
	}

	protected bool IsFinished () {
		return Time.time - timeOfControll > duration;
	}
}
