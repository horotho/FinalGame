using UnityEngine;
using System.Collections;

public class SpawnLadder : MonoBehaviour {

	public bool canSpawn;
	public bool isSpawned;
	public GameObject[] ladders;
	private Controller controller;

	// Use this for initialization
	void Start () {
		canSpawn = false;
		isSpawned = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (canSpawn == true && !isSpawned) {
				//Debug.Log ("Player pressed F button");
				//player.rigidbody2D.velocity = new Vector2 (0, move * maxSpeed);
				isSpawned = true;
				ladders = GameObject.FindGameObjectsWithTag("Ladder");
				for(int i = 0; i < ladders.Length; i++){
					//Debug.Log(ladders[i]);
					ladders[i].renderer.enabled = true;
			}
		}
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		// Check when Player enters trigger.

		
	}

	void OnTriggerStay2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
			controller = col.gameObject.GetComponent<Controller>();
			//Debug.Log ("CanSpawn = true");
			//}
			if (controller.IsChakraAbilityActive((int)ChakraController.Chakras.VIM)) {
				canSpawn = true; 
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
