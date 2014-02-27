using UnityEngine;
using System.Collections;

public class MonsterAI : MonoBehaviour {

	private bool hunt = false; // determines if the monster is trying to kill the player
	private float distance; // distance from the monster to the player
	
	
	public float huntDistance; // distance where the monster will try to hunt the player
	private GameObject player; // the player
	public float movespeed = 0.1f; // monster move speed
	public Animator anim; // the animator
	public float health; // monster health

	/*
	 * initializes the monster
	 */
	void Start () {
		player = CharacterCollisionHandler.player.gameObject;
		health = GridCreator.Level * 100;
	}
	
	/*
	 * if the game isn't paused, the monster goes towards the player if the player is close enough
	 * if the monster dies, it adds points
	 */
	void Update () {
		if (!HUDManager.isPause) {
			distance = Vector3.Distance (gameObject.transform.position, player.gameObject.transform.position);

			if (distance < huntDistance) {
				hunt = true;
				anim.Play ("walk");
			}
			else {
				hunt = false;
				anim.Play ("idle");
			}
			if (hunt) {
				Vector3 amttorotate;
				amttorotate = Vector3.RotateTowards (transform.forward, player.transform.position - gameObject.transform.position, 2f, 2f);	
				gameObject.transform.rotation = Quaternion.LookRotation (new Vector3 (amttorotate.x, 0f, amttorotate.z), new Vector3 (0f, 1f, 0f));
				gameObject.transform.Translate (Vector3.forward * movespeed * Time.deltaTime);
			} 
			else {}
			if (health <= 0) {
				HUDManager.addPoints (Mathf.Pow (10, GridCreator.Level));

				Destroy (gameObject);
			}
		}
	}

	/*
	 * if an arrow hits the monster, the monster takes damage
	 * if it is a player, the player takes damage
	 */
	void OnCollisionEnter(Collision collision) {
		if ((collision.gameObject.tag == "Arrow")) {
			health -= 100;
		}
	
		if ((collision.gameObject.tag == "Player")) {
			HUDManager.health -= 1;;
		}
	}

}
