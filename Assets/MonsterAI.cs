using UnityEngine;
using System.Collections;

public class MonsterAI : MonoBehaviour {

	private bool hunt = false;
	public GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (hunt) {
			//gameObject.transform.rotation.Set(gameObject.transform.rotation.x, Mathf.Atan((player.transform.position.y - gameObject.transform.position.y) / (player.transform.position.x - gameObject.transform.position.x)), gameObject.transform.rotation.z, gameObject.transform.rotation.w);		
			Destroy(gameObject);
		}
		else {
		}
	}

	void OnTriggerEnter() {
		hunt = true;
	}

	void OnTriggerExit() {
		hunt = false;
	}
}
