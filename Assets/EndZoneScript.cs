using UnityEngine;
using System.Collections;

public class EndZoneScript : MonoBehaviour {
	
	public GameObject player;

	// Use this for initialization
	void Start () {
		
	}

	void OnTriggerEnter(Collider other) {
		if(other.gameObject == player)
			GridCreator.levelstart = true;
	}

	// Update is called once per frame
	void Update () {
	
	}
}
