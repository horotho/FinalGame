using UnityEngine;
using System.Collections;

public class ClimbUpward : MonoBehaviour {

	private bool canClimb;
	public float maxSpeed = 10f;

	// Use this for initialization
	void Start () {
		canClimb = false;
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (canClimb);
		if (canClimb == true){
			if ((Input.GetAxis ("Vertical") == 1) || (Input.GetAxis ("Vertical") == -1)) {
				Debug.Log ("Player pressed button");
				//rigidbody2D.velocity = new Vector2 (move * maxSpeed, rigidbody2D.velocity.y);
			}
		}
	}

	void OnTriggerEnter2D (Collider2D col)
	{

		float move = Input.GetAxis ("Vertical");

		// Check if Player collides with the element.
		if (col.gameObject.tag == "Player") {
			canClimb = true;
			Debug.Log ("canClimb = true");
		}
	}
}
