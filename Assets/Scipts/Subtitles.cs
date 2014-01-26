using UnityEngine;
using System.Collections;

public class Subtitles : MonoBehaviour {

	private AudioSource theSound;
	private GUIText theText;

	void Start () {
		theSound = GetComponent<AudioSource> ();
		theText = GetComponent<GUIText> ();
	}

	// Update is called once per frame
	void Update () {
		if (!theSound.isPlaying)
			theText.enabled = false;
	}
}
