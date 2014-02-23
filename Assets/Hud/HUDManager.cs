using UnityEngine;
using System.Collections;

public class HUDManager : MonoBehaviour {
	public static HUDManager instance;
	public GUIText healthText;
	public GUIText fuelText;
	public GUIText arrowsText;
	public static float health = 100;
	public static float fuel = 30;
	public static float arrows = 1;

	public bool lanternOn = true;

	// Use this for initialization
	void Start () {
		instance = this;
		arrowsText.color = Color.red;
	}
	
	// Update is called once per frame
	void Update () {
		if (lanternOn == true && fuel > 0) {
						// useFuel ();
				} else {
						// turn off the directional light
				}
		// hit monster, decrease health

		// HEALTH
		healthText.text = Mathf.Floor(health).ToString();
		// low health warning
		if (health < 30) {
			instance.healthText.color = Color.red;
		}
		else if (health <= 0) {
			// death


			}
		else {
			instance.healthText.color = Color.white;
		}


		// FUEL
		fuelText.text = Mathf.Floor(fuel).ToString ();

		// low fuel warning
		if (fuel < 20) instance.healthText.color = Color.red;
		else instance.fuelText.color = Color.white;


		// ARROWS
		arrowsText.text = arrows.ToString();
		if(Bow.bowReady == true){
			arrowsText.color = Color.green;
		}
		else{
			arrowsText.color = Color.grey;
		}

	}



	public void SetHealth(int health) {
		instance.healthText.text = health.ToString ();
	}

	public void SetFuel (int fuel) {
				instance.fuelText.text = fuel.ToString ();
		}

	public void SetArrows (int arrows) {
		instance.arrowsText.text = arrows.ToString ();
	}

	public void onHit() {
		health -= (10 + Random.Range(-5, 5));
	}

	private void useFuel () {
		fuel -= Time.timeSinceLevelLoad;
	}
	
	public static void pickupFuel () {
		// onCollision
		// make that item disappear
		
		fuel += 20;
	}
	
	public static void pickupArrow() {
		// onCollision
		// make that item disappear
		arrows += 1;
	}


}