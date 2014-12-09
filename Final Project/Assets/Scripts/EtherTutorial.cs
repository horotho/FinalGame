using UnityEngine;
using System.Collections;

public class EtherTutorial : MonoBehaviour {
	
	//create timer
	private float timer;
	private bool tutorial;

	// Use this for initialization
	void Start () {
		tutorial = false;
	}
	
	// Update is called once per frame
	void Update () {
		//timer += Time.deltaTime;
	}
	
	void OnGUI()
	{
		if ( tutorial ) {
			GUI.Label (new Rect (250, 250, 190, 80), "You just collected Ether! Switch to that state with 1. Float upwards by holding the Spacebar!");
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		// Check if Player collides with the element.
		tutorial = true;
	}
}
