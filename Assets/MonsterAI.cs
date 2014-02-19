using UnityEngine;
using System.Collections;

public class MonsterAI : MonoBehaviour {

	private bool hunt = false;
	public GameObject player;
	public float movespeed = 0.1f;

	// Use this for initialization
	void Start () {
		//player = GameObject.FindWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (hunt) {
			Vector3 amttorotate;
			amttorotate = Vector3.RotateTowards(transform.forward, player.transform.position - gameObject.transform.position, 2f, 2f);
			//gameObject.transform.Rotate(0f, 0f + amttorotate, 0f);	
			gameObject.transform.rotation = Quaternion.LookRotation(new Vector3(amttorotate.x, 0f, amttorotate.z), new Vector3(0f,1f,0f));
			gameObject.transform.Translate(Vector3.forward * movespeed * Time.deltaTime);
			//gameObject.animation.Play("walk");
			//Destroy(gameObject);
		}
		else {
		}
	}

	void OnTriggerEnter() {
		player = GameObject.FindWithTag ("Player");
		hunt = true;
	}

	void OnTriggerExit() {
		hunt = false;
	}
}
