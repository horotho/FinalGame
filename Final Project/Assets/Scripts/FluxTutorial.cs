using UnityEngine;
using System.Collections;

public class FluxTutorial : MonoBehaviour {
	
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
			//Render the text 
			GUI.Label (new Rect (250, 250, 190, 50), "You just collected Flux! Switch to that state with 2. Fit through tight spaces using the F key!");
		}
	}
	
	void OnTriggerEnter2D(Collider2D col)
	{
		// Check if Player collides with the element.
		tutorial = true;
	}
}
