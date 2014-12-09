﻿using UnityEngine;
using System.Collections;

public class SpikeDeath : MonoBehaviour {

	public GameObject player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D (Collision2D col){
		if (col.gameObject.tag == "Player") {
			//Application.LoadLevel(Application.loadedLevel);
			Controller c = col.gameObject.GetComponent<Controller>();
			ScreenFade.Instance.Fade(Application.loadedLevel, 0.1f, c);
		}
	}
}
