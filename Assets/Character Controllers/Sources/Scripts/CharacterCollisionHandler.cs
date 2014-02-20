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
	
	}
	//Use this for when the Player runs into anything
	void OnControllerColliderHit(ControllerColliderHit hit){
		//Enemy
		if(hit.gameObject.tag == "Enemy"){
			print("Ouch hit enemies");
		}
		//weapon
		if(hit.gameObject.tag == "ArrowItem"){
			print("Got some Arrows");
			HUDManager.arrows++;
			Destroy(hit.gameObject);
		}
		//Torch
		if(hit.gameObject.tag == "TorchItem"){
			print("Hit the torch");
			Destroy(hit.gameObject);
		}
	}

}
