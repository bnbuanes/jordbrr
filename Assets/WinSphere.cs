using UnityEngine;
using System.Collections;

/// <summary>
/// 
/// </summary>
public class WinSphere : MonoBehaviour {

	public GUIText winText;
	public string nextLevel;
	private bool hasWon = false;
	private float winTime;

	void Update () {
		if (hasWon) {
			if (Time.time - winTime > 5f) {
				Application.LoadLevel (nextLevel);
			}
		}
	}


	void OnTriggerEnter (Collider c) {
		winText.enabled = true;
		hasWon = true;
		winTime = Time.time;
	}
}
