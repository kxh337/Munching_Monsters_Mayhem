using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {
	public float damage;

	public static float arrowCount;

	private bool stuck;

	// Use this for initialization
	void Start () {
		arrowCount = 10;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//if arrow hits enemy the arrow will get stuck on enemy.
	//
	void OnCollisionEnter(Collision collision){
		//check if collided with enemy
		if((collision.gameObject.tag == "Enemy")){
			transform.parent = collision.transform;
			stuck = true;
		}
		//check if collided with player and add arrow count if it did
		if(collision.gameObject.tag == "Player"){
			stuck = false;
			arrowCount++;
		}
	}
}
