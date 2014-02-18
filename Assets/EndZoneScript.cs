using UnityEngine;
using System.Collections;

public class EndZoneScript : MonoBehaviour {
	

	// Use this for initialization
	void Start () {
		
	}

	void OnTriggerEnter() {
//		GridCreator.Level++;
//		GameObject.FindWithTag ("Player").transform.Translate (0f, -2f, 0f);
//		GameObject todestroy;
//		todestroy = GameObject.FindWithTag ("Monster");
//		while (todestroy != null) {
//			Destroy (todestroy);
//			todestroy = GameObject.FindWithTag ("Monster");
//		}
//		todestroy = GameObject.FindWithTag ("Torch");
//		while (todestroy != null) {
//			Destroy (todestroy);
//			todestroy = GameObject.FindWithTag ("Torch");
//		}
//		todestroy = GameObject.FindWithTag ("Weapon");
//		while (todestroy != null) {
//			Destroy (todestroy);
//			todestroy = GameObject.FindWithTag ("Weapon");
//		}
		GridCreator.levelstart = true;
	}

	// Update is called once per frame
	void Update () {
	
	}
}
