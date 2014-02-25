using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {
	public float damage;



	private bool stuck;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}
	void FixedUpdate () {
		//transform.LookAt (transform.position + rigidbody.velocity);
	}

	//if arrow hits enemy the arrow will get stuck on enemy.
	//
	void OnCollisionEnter(Collision collision){
		Debug.Log(collision.gameObject.tag);
		//check if collided with enemy and stay stuck with enemy
		if((collision.gameObject.tag == "Enemy")){
			//gameObject.transform.parent = collision.transform;
			stuck = true;
			HUDManager.addPoints(30);
			//deal damage
		}
	}
}
