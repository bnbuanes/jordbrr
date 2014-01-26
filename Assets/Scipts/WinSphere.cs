﻿using UnityEngine;
using System.Collections;

/// <summary>
/// 
/// </summary>
public class WinSphere : MonoBehaviour {

	public GUIText winText;
	public string nextLevel;
	private bool hasWon = false;
	private float winTime;

	public Player player;

	public GameObject ignoreObject;

	void Update () {
		if (hasWon) {
			if (Time.time - winTime > 2f) {
				Application.LoadLevel (nextLevel);
			}
		}
	}


	void OnTriggerEnter (Collider c) {
		if (c.gameObject != ignoreObject) {
			if (winText != null) {
				winText.enabled = true;
			}
			hasWon = true;
			winTime = Time.time;
			player.DeactivateControlls ();
		}
	}
}