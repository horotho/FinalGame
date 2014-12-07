using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		OnMouseDown ();
	}

	public void OnMouseDown(){
		if(Input.GetMouseButtonDown(0))
			Application.LoadLevel("Level 1");
	}
}
