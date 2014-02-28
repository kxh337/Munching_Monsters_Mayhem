using UnityEngine;
using System.Collections;

public class lightControls : MonoBehaviour {

	public Light lightToDim = null; //Light to be Dimmed

	
	// Update is called once per frame
	void Update () {

		//When collecting fuel for the torch, this caps the fuel at 100
		if (HUDManager.fuel >= 100)
			HUDManager.fuel = 100;

		//Sets the intensity level of the torch, which is a function of the fuel level
		else
			lightToDim.intensity =  HUDManager.fuel / 200 + 0.075f;

		//Slowly decreases te fuel level
		HUDManager.fuel -= Time.deltaTime;

		//Once fuel level reaches below 0, resets level to 0 and keeps it there
		if (HUDManager.fuel <= 0)
			HUDManager.fuel = 0;

	}
}
