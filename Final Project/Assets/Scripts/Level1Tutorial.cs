using UnityEngine;
using System.Collections;

public class Level1Tutorial : MonoBehaviour {

	//create timer
	private float timer = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
	}

	void OnGUI()
	{
		if (timer < 6) {
			//Render the text  
			GUI.Label (new Rect (250, 250, 190, 50), "I've gotta make it to that doorway using WASD. Press Spacebar to jump!");
		}
	}
}
