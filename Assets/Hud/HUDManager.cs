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
	public GUITexture deathTexture;


	public bool lanternOn = true;

	private Color deathColor;
	// Use this for initialization
	void Start () {
		deathColor = deathTexture.color;
		deathColor.a = 0;
		deathTexture.color = deathColor;
		instance = this;
		arrowsText.color = Color.red;
	
	}

	void OnGUI() {
		if (isPause && !dead) {
			GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "Shop");
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
			deathFade(0,1,10);
			if(GUI.Button(new Rect(0, 0, Screen.width, Screen.height), " You Died \n Game Over! \n Restart from the beginning?")){
				restart = true;
			}

		}
		
	}
		
	
	
	
	void deathFade ( float startLevel, float endLevel, float duration) {
		
		float speed = 1.0f/duration;   
		
		for (float t = 0.0f; t < 1.0f; t += Time.deltaTime * speed) {
			deathTexture.color = deathColor;
			deathColor.a = Mathf.Lerp(startLevel, endLevel, t);
			deathTexture.color = deathColor;
		}
		
	}
	// Update is called once per frame
	void Update () {
		if (health <=0 ){
			health = 0;
		}
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

		else if ( health > maxHealth ) {
			health = maxHealth; // prevents having health higher than 100 (%).
		}
		else {
			healthText.color = Color.white;
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