using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour {
	public float damage;
	public float timelength;
	private float depth;
	private float destroytime;
	
	
	private bool hitground;
	
	// Use this for initialization
	void Start () {
		depth = 0;
		hitground = false;
		destroytime = Time.time + timelength;
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > destroytime){
			Destroy(gameObject);
		}
	}
	void FixedUpdate () {
		//transform.LookAt (transform.position + rigidbody.velocity);
	}
	
	//if arrow hits enemy the arrow will get stuck on enemy.
	//
	void OnCollisionEnter(Collision collision){
		print(hitground);
		if(collision.gameObject.tag == "Ground" ){
			gameObject.tag = "ArrowGround";

		}
		
		if(collision.gameObject.tag == "Player" && hitground == true){
			HUDManager.arrows++;
			Destroy(gameObject);
		}
		Debug.Log(collision.gameObject.tag);
		//check if collided with enemy and stay stuck with enemy
		if((collision.gameObject.tag == "Enemy" && !hitground)){
			Destroy(gameObject);
			//deal damage
			
		}
	}
}
