using UnityEngine;
using System.Collections;

public class HUDManager : MonoBehaviour {
	public static HUDManager instance; // this HUDManager
	public GUIText healthText; // for display of health
	public GUIText fuelText; // for display of fuel
	public GUIText arrowsText; // for display of ammo
	public GUIText scoreText; // for display of score
	public static float Score = 0; // the amount of points the player has
	public static float health = 100; // player health
	public static float maxHealth = 100;
	public static float fuel = 100; // lantern/torch fuel
	public static float maxFuel = 100; 
	public static float arrows = 1; // arrows for bow for combat
	public static bool isPause = false; // pause state boolean
	public static bool restart = false;
	public static bool dead = false;

	public bool lanternOn = true;

	// Use this for initialization
	void Start () {
		instance = this;
		arrowsText.color = Color.red;
	
	}

	/*
	 * When isPause is true, creates a shop menu where the player can trade points for ammo, health, and faster bow fire rate.
	 * If the palyer dies, then it alerts the player and allows him to restart the game.
	 */
	void OnGUI() {
		if (isPause) {
			GUI.Box(new Rect(100,100,500,500), "Shop");
			if (GUI.Button(new Rect(250,120,200,50), "Buy Arrow: 500 Points") && Score >= 500){
				arrows++;
				Score = Score - 500;
			}
			if (GUI.Button(new Rect(250,170,200,50), "Buy Health: 100 Points") && Score >= 100 && health < 100){
				health = health + 5;
				Score = Score - 100;
			}
			if (GUI.Button(new Rect(250,220,200,50), "Buy Strength: 1000 Points") && Score >= 1000){
				Bow.pulltime = Bow.pulltime * 0.75f;
				Bow.maxStrengthPullTime = Bow.maxStrengthPullTime * 0.75f;
				Score = Score - 1000;
			}
		}
		if (health <= 0) {
			dead = true;
			isPause = true;
			// make everything stop, trigger death
			if(GUI.Button(new Rect(Screen.width/2-300, Screen.height/2-150,600,300), " You Died \n Game Over! \n Restart from the beginning?")){
				restart = true;
				isPause = false;
			}
		}
		
	}

	/* 
	 * Update is called once per frame
	 * Manages health/fuel/score/ammo levels as dispalyed by the HUD
	 */
	void Update () {
		if (Input.GetButtonDown ("esc")) {
			isPause = !isPause;		
		}

		// HEALTH
		healthText.text = Mathf.Floor(health).ToString();
		// low health warning
		if (health < 30) {
			instance.healthText.color = Color.red;
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
						instance.fuelText.color = Color.red;
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

	/*
	 * Used on collision with a torch object to increase fuel and give the character points
	 */
	public static void pickupFuel () {
		// onCollision
		// make that item disappear
		
		fuel += 10;
		addPoints (50);
	}

	/*
	 * Used on collision with an ammo object to increase arrows and give the character points
	 */
	public static void pickupArrow() {
		arrows += 1;
		addPoints (50);
	}

	/*
	 * Used by all point increasing actions to add points
	 * @param points the amount of points to be added
	 */
	public static void addPoints(float points) {
		//used by events to increase score
		Score += points;
	}


}