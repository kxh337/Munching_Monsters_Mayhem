using UnityEngine;
using System.Collections;

public class Torchpickuptrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") {
			HUDManager.pickupFuel ();
			Destroy(gameObject);
		}
		
	}
}
