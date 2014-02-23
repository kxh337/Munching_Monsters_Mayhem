using UnityEngine;
using System.Collections;

public class lightControls : MonoBehaviour {

	public Light lightToDim = null;
	public float maxTime = 15; //30 seconds
	public float lightFuel = 15; //30 seconds

	private float mEndTime = 0;
	private float mStartTime = 0;

	// Use this for initialization
	void Start () {
	
	}

	void Awake() {
				
		mStartTime = Time.time;
		mEndTime = mStartTime + maxTime;
	}
	
	// Update is called once per frame
	void Update () {
			lightToDim.intensity =  HUDManager.fuel / 100;
			HUDManager.fuel -= Time.deltaTime;
		if (HUDManager.fuel <= 0)
			HUDManager.fuel = 0;

	}
}
