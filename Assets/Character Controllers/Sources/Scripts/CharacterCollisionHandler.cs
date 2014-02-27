using UnityEngine;
using System.Collections;

public class CharacterCollisionHandler : MonoBehaviour {
	public static GameObject player;

	// Use this for initialization
	void Start () {
		player  = gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if (HUDManager.isPause) {

		}
	
	}
	//Use this for when the Player runs into anything
	void OnControllerColliderHit(ControllerColliderHit hit){
		//Enemy
		if(hit.gameObject.tag == "Enemy"){
			print("Ouch hit enemies");
			HUDManager.health -= 1;
		}
		//weapon
		if(hit.gameObject.tag == "ArrowItem"){
			print("Got some Arrows");
			HUDManager.arrows++;
			Destroy(hit.gameObject);
		}
		//Torch
		if(hit.gameObject.tag == "ArrowGround"){
			print("Hit the Arrow");
			HUDManager.arrows++;
			Destroy(hit.gameObject);
		}
	}

}
