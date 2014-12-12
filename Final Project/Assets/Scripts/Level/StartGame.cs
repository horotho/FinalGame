using UnityEngine;
using System.Collections;

public class StartGame : MonoBehaviour 
{

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void StartGamePlay()
	{
		ScreenFade.Instance.Fade(2, 1, null);
	}

	public void StartInstructions()
	{
		ScreenFade.Instance.Fade(1, 1, null);
	}

	public void GoMainMenu()
	{
		ScreenFade.Instance.Fade(0, 1, null);
	}

	public void Exit()
	{
		Application.Quit();
	}
}
