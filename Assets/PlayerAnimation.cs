using UnityEngine;
using System.Collections;

public class PlayerAnimation : MonoBehaviour {

	private Animation anim;
	private float timeOfLast;
	private AudioSource footStep;

	/// <summary>
	/// 0: idle, 1: running, 2: jumping
	/// </summary>
	private int state;

	private bool stateChanged;

	// Use this for initialization
	void Start () {
		anim = GetComponentInChildren<Animation> ();
		footStep = GetComponent<AudioSource> ();
		timeOfLast = anim ["Run"].time;
		stateChanged = false;
	}
	
	// Update is called once per frame
	void Update () {
		switch (state) {
		case 0:
			IdleStateUpdate ();
			break;
		case 1:
			RunStateUpdate ();
			break;
		case 2:
			JumpStateUpdate ();
			break;
		default:
			Debug.Log ("animator in faulty state: " + state);
			break;
		}

	}

	void SetState (int state) {
		stateChanged = true;
		this.state = state;
	}

	void RunStateUpdate () {
		if (stateChanged) {
			anim.Play ("Run");
		}

		float animTime = anim ["Run"].time;
		if (animTime - timeOfLast > 0.33f) {
			footStep.Play ();
			Debug.Log ("time");
			timeOfLast = animTime;
		}
	}
}
