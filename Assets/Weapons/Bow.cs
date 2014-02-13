using UnityEngine;
using System.Collections;

public class Bow : MonoBehaviour {
	public Arrow arrow;

	private bool charging;
	private float chargeValue;

	// Use this for initialization
	void Start () {
		charging = false;
		chargeValue = 0;
	}
	
	// Update is called once per frame
	void Update () {
			chargeShot();
			shoot();
	}

	//loads and charges the arrow
	void chargeShot(){
		while(Input.GetMouseButtonDown(0) && Arrow.arrowCount > 0){
			charging = true;

		}
	}

	//shoots the arrow
	void shoot(){
		if(Input.GetMouseButtonUp(1) && charging){
			charging = false;
			Arrow.arrowCount--;
		}
	}


}
