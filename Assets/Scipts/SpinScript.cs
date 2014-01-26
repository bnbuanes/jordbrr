using UnityEngine;
using System.Collections;

public class SpinScript : MonoBehaviour {

	public float speed;
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (0f, speed, 0f);
	}
}
