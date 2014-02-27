using UnityEngine;
using System.Collections;

public class HUDManager : MonoBehaviour {
	public static HUDManager instance;
	public GUIText healthText;
	public GUIText fuelText;
	public GUIText arrowsText;
	public GUIText scoreText;
	public static float Score = 0;
	public static float health = 100;
	public static float maxHealth = 100;
	public static float fuel = 30;
	public static float maxFuel = 100;
	public static float arrows = 1;
	public static bool isPause = false;

	public bool lanternOn = true;

	// Use this for initialization
	void Start () {
		instance = this;
		arrowsText.color = Color.red;
	}

	void OnGUI() {
		if (isPause) {
			GUI.Box(new Rect(0,0,1000,1000), "Shop");
			if (GUI.Button(new Rect(20,20,200,50), "Buy Arrow: 500 Points") && Score >= 500){
				arrows++;
				Score = Score - 500;
			}
			if (GUI.Button(new Rect(20,70,200,50), "Buy Health: 100 Points") && Score >= 100){
				health = health + 5;
				Score = Score - 100;
			}
		}
		
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("esc")) {
			isPause = !isPause;		
		}
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
			// make everything stop, trigger death
			}
		else if ( health > maxHealth ) {
			health = maxHealth; // prevents having health higher than 100 (%).
		}
		else {
			instance.healthText.color = Color.white;
		}


		// FUEL
		fuelText.text = Mathf.Floor(fuel).ToString ();
		// low fuel warning
		if (fuel < 20) {
						instance.healthText.color = Color.red;
				} else if (fuel > 100) {
						fuel = 100;
				} else {
						instance.fuelText.color = Color.white;
				}






		// ARROWS
		arrowsText.text = arrows.ToString();
		if(Bow.bowReady == true){
			arrowsText.color = Color.green;
		}
		else{
			arrowsText.color = Color.grey;
		}

		scoreText.text = "Score: " + Score.ToString ();

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
		
		fuel += 10;
		addPoints (50);
	}
	
	public static void pickupArrow() {
		arrows += 1;
		addPoints (50);
	}

	public static void addPoints(float points) {
		//used by events to increase score
		Score += points;
	}


}