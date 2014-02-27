using UnityEngine;
using System.Collections;

public class Ammopickuptrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	/*
	 * if the player hits this, he picks up an arrow and the object goes away
	 */
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") {
			HUDManager.pickupArrow ();
			Destroy(gameObject);
		}

	}
}
