using UnityEngine;
using System.Collections;

public class fuelBar : MonoBehaviour {
	public float fuelBarLength;
	public float fuel;
	public float maxFuel = 100;

	// Use this for initialization
	void Start () {
		fuelBarLength = Screen.width;
	}
	
	// Update is called once per frame
	void Update () {
		adjustCurrentFuel ();
	}

	void onGUI() {
		GUI.Box (new Rect(10, 10, fuelBarLength, 20), "Fuel");
	}

	public void adjustCurrentFuel() {
		fuel = HUDManager.fuel;
		fuelBarLength = Screen.width * (HUDManager.fuel / 100);
	}
}
