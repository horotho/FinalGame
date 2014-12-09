using UnityEngine;
using System.Collections;

public class VimTutorial : MonoBehaviour {

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
			GUI.Label (new Rect (250, 250, 190, 50), "You just collected Vim! Switch to that state with 3. Grow ladders of vines using the F key!");
		}
	}
	
	void OnTriggerEnter2D(Collider2D col)
	{
		// Check if Player collides with the element.
		tutorial = true;
	}
}
