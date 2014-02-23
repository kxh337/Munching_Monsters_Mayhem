using UnityEngine;
using System.Collections;

public class MonsterAI : MonoBehaviour {

	private bool hunt = false;
	private float distance;
	
	
	public float huntDistance;
	private GameObject player;
	public float movespeed = 0.1f;
	public Animator anim;

	// Use this for initialization
	void Start () {
		player = CharacterCollisionHandler.player.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		distance = Vector3.Distance(gameObject.transform.position, player.gameObject.transform.position);

		if(distance < huntDistance){
			hunt = true;
			anim.Play ("walk");
		}
		else{
			hunt = false;
			anim.Play ("idle");
		}
		if (hunt) {
			Vector3 amttorotate;
			amttorotate = Vector3.RotateTowards(transform.forward, player.transform.position - gameObject.transform.position, 2f, 2f);	
			gameObject.transform.rotation = Quaternion.LookRotation(new Vector3(amttorotate.x, 0f, amttorotate.z), new Vector3(0f,1f,0f));
			gameObject.transform.Translate(Vector3.forward * movespeed * Time.deltaTime);
			/*if (gameObject.transform.position.x - player.transform.position.x < 1 && gameObject.transform.position.z - player.transform.position.z < 1) {
				HUDManager.health = HUDManager.health -1*Time.deltaTime;
			}*/

		}
		else {
		}
	}

	void OnTriggerEnter() {

		//hunt = true;

	}

	void OnTriggerExit() {
		//hunt = false;

	}
}
