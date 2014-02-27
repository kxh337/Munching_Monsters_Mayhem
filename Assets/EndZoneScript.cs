using UnityEngine;
using System.Collections;

public class EndZoneScript : MonoBehaviour {
	
	public GameObject player;

	/*
	 * does nothing right now
	 */
	void Start () {
		
	}

	/*
	 * if the player enters the area, restarts the level, and adds points
	 */
	void OnTriggerEnter(Collider other) {
		if (other.gameObject == player) {
			HUDManager.addPoints (1000);
			GridCreator.levelstart = true;
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
