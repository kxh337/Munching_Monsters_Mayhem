using UnityEngine;
using System.Collections;

public class HUDManager : MonoBehaviour {

	public float health;
	public float fuel;
	public float arrows;
	public bool lanternOn;

	// Use this for initialization
	void Start () {
		health = 100;
		fuel = 100;
		arrows = 5;
	}
	
	// Update is called once per frame
	void Update () {
		if (lanternOn == true && fuel > 0) {
			useFuel ();
		} 
		else {
		// turn off the directional light
		}
	}

	void useFuel () {
		fuel -= Time.deltaTime;
	}


}
