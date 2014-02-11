using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
	public float speed;
	[Range(1,100)]
	public float sensitivity;
	private Vector3 globalUp = new Vector3 (0, 1, 0);
	private Vector3 globalDown = new Vector3(0,-1,0);

	// Use this for initialization
	void Start () {
		transform.position = new Vector3 (-2, 3, -2);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey ("w")) 
			transform.position += transform.forward * speed * Time.deltaTime;
		if (Input.GetKey ("s")) 
			transform.position -= transform.forward * speed * Time.deltaTime;
		if (Input.GetKey ("d")) 
			transform.position += transform.right * speed * Time.deltaTime;
		if (Input.GetKey ("a")) 
			transform.position -= transform.right * speed * Time.deltaTime;
		if (Input.GetAxis ("Mouse X") > 0)
			transform.Rotate (globalUp * sensitivity*Time.deltaTime);
		if (Input.GetAxis ("Mouse X") < 0)
			transform.Rotate (globalDown * sensitivity * Time.deltaTime);
		if (Input.GetAxis ("Mouse Y") > 0)
			transform.Rotate (Vector3.left * sensitivity * Time.deltaTime);
		if (Input.GetAxis ("Mouse Y") < 0)
			transform.Rotate (Vector3.right * sensitivity * Time.deltaTime);
	}
}
