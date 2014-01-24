using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour
{
		private LolScript l;
		public float speed;

		// Use this for initialization
		void Start ()
		{
				l = GetComponent<LolScript> ();
		}
	
		// Update is called once per frame
		void Update ()
		{
				rigidbody.AddForce (1f, 0, 0);
		}
}
