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

	// Use this for initialization
	void Start ()
	{
		anim = GetComponentInChildren<Animation> ();
		footStep = GetComponent<AudioSource> ();
		timeOfLast = anim ["Run"].time;
	}
	
	// Update is called once per frame
	void Update ()
	{
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

	public void SetState (int state)
	{
		if (this.state != state) {
			this.state = state;
			switch (state) {
			case 0:
				ChangeState ("Idle");
				break;
			case 1:
				ChangeState ("Run");
				break;
			case 2:
				ChangeState ("Jump");
				break;
			}
		}
	}

	void ChangeState (string state)
	{
		anim.Play (state);
	}

	void IdleStateUpdate ()
	{
	}

	void RunStateUpdate ()
	{
		float animTime = anim ["Run"].time;
		if (animTime - timeOfLast > 0.33f) {
			footStep.Play ();
			timeOfLast = animTime;
		}
	}

	void JumpStateUpdate ()
	{
	}
}
