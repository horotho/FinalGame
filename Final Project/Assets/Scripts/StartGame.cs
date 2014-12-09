using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void StartGamePlay()
	{
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		ScreenFade.Instance.Fade(1, 1, player.GetComponent<Controller>());
	}
}
