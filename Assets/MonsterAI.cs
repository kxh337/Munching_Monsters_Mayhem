using UnityEngine;
using System.Collections;

public class MonsterAI : MonoBehaviour {

	private bool hunt = false;
	public GameObject player;
	public float movespeed = 0.1f;
	public Animator anim;

	// Use this for initialization
	void Start () {
		//player = GameObject.FindWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (hunt) {
			Vector3 amttorotate;
			amttorotate = Vector3.RotateTowards(transform.forward, player.transform.position - gameObject.transform.position, 2f, 2f);	
			gameObject.transform.rotation = Quaternion.LookRotation(new Vector3(amttorotate.x, 0f, amttorotate.z), new Vector3(0f,1f,0f));
			gameObject.transform.Translate(Vector3.forward * movespeed * Time.deltaTime);
			if (gameObject.transform.position.x - player.transform.position.x < 1 && gameObject.transform.position.z - player.transform.position.z < 1) {
				HUDManager.health = HUDManager.health -1*Time.deltaTime;
			}

		}
		else {
		}
	}

	void OnTriggerEnter() {
		player = GameObject.FindWithTag ("Player");
		hunt = true;
		anim.Play ("walk");
	}

	void OnTriggerExit() {
		hunt = false;
		anim.Play ("idle");
	}
}
