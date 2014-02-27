using UnityEngine;
using System.Collections;


public class Bow : MonoBehaviour {
	public GameObject  arrow;
	public float defaultArrowSpeed;
	public float pulltime;
	public float maxStrengthPullTime;

	public static bool bowReady;

	private float nextFire;
	private bool charging;
	private GameObject clone;
	private float pullBackStartTime;



	// Use this for initialization
	void Start () {
		charging = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time > nextFire){
			bowReady = true;
		}
		else{
			bowReady = false;
		}
		if(Input.GetMouseButtonDown(0) && HUDManager.arrows > 0 && !HUDManager.isPause){
			chargingShot();
		}
		if (Input.GetMouseButtonUp(0) && charging == true && !HUDManager.isPause){
			shoot();
		}
	}

	//loads and charges the arrow
	void chargingShot(){
		if(Time.time > nextFire){
		charging = true;
		pullBackStartTime = Time.time;
		}
		else{
			charging = false;
		}
	}

	//shoots the arrow
	void shoot(){
		float timePulledBack = Time.time - pullBackStartTime; // this is how long the button was held
		if(timePulledBack > maxStrengthPullTime) // this says max strength is reached 
			timePulledBack = maxStrengthPullTime; // max strength is ArrowSpeed * maxStrengthPullTime
		clone = (GameObject)Instantiate(arrow, transform.position, transform.rotation);
		Rigidbody cloneRigid = clone.rigidbody;
		cloneRigid.AddForce(Camera.main.transform.forward  * defaultArrowSpeed * (timePulledBack+1));
		charging = false;
		nextFire = Time.time + pulltime;
		HUDManager.arrows--;
	}


}
