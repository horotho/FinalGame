using UnityEngine;
using System.Collections;

public class SpawnLadder : MonoBehaviour {

	public bool canSpawn;
	public GameObject[] ladders;

	// Use this for initialization
	void Start () {
		canSpawn = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (canSpawn == true) {
			if (Input.GetKey (KeyCode.F)) {
				//Debug.Log ("Player pressed F button");
				//player.rigidbody2D.velocity = new Vector2 (0, move * maxSpeed);
				ladders = GameObject.FindGameObjectsWithTag("Ladder");
				for(int i = 0; i < ladders.Length; i++){
					//Debug.Log(ladders[i]);
					ladders[i].renderer.enabled = true;
				}
			}
		}
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		// Check when Player enters trigger.
		if (col.gameObject.tag == "Player") {
			if (GameObject.Find ("VIM").GetComponent<Controller>().currentController.abilityIsActive) {
				canSpawn = true;
				//Debug.Log ("CanSpawn = true");
			}
		}
	}
	
	void OnTriggerExit2D (Collider2D col)
	{
		// Check when Player exits trigger.
		if (col.gameObject.tag == "Player") {
			canSpawn = false;
			//Debug.Log ("canSpawn = false");
		}
	}
}
