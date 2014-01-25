using UnityEngine;
using System.Collections;

public class Finder : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
		Debug.Log ("cameras: " + Object.FindObjectsOfType<HellFireCamera> ());
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
