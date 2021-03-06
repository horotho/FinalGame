﻿using UnityEngine;
using System.Collections;

public class ScreenFade : MonoBehaviour
{
    //The amount between 0 and 1 that we're currently faded
    private float amount;
    //The texture we're overlaying on the screen to do the fade
    private Texture2D texture;

    //Our singleton instance
    private static ScreenFade instance = null;
    public static ScreenFade Instance
    {
        get
        {
            if(instance == null)
                instance = new GameObject("Screen Fade", typeof(ScreenFade)).GetComponent<ScreenFade>();
            return instance;
        }
    }

    //When the singleton is created, do some setup
    void Start()
    {
        texture = new Texture2D(1, 1);
        texture.SetPixel(0, 0, Color.white);
        texture.Apply();
        DontDestroyOnLoad(gameObject);
    }

    //The static method we can call to set up the instance and perform the fade
    public void Fade(int toLevel, float fadeTime, Controller controller)
    {
        Instance.StartCoroutine(Instance.performFade(toLevel, fadeTime, controller));
    }

    //The static method we can call to set up the instance and perform the fade
    public void Fade(int toLevel, float fadeTime)
    {
        Instance.StartCoroutine(Instance.performFade(toLevel, fadeTime, null));
    }

    //The coroutine that performs the fade
    private IEnumerator performFade(int level, float fadeTime, Controller controller)
    {
		if(controller != null) controller.movementAllowed = false;
        float time = Time.time;

        //fade to black
        while((amount = (Time.time - time)/fadeTime) < 1)
        {
            yield return null;
        }

		Application.LoadLevel(level);
        yield return new WaitForSeconds(0.25f);

        time = Time.time;
        //fade from black
        while((amount = fadeTime - (Time.time - time)) > 0f)
        {
            yield return null;
        }

        if(controller != null) controller.movementAllowed = true;
        Destroy(Instance.gameObject);

    }

    //The Unity event that we tap into to show the fade texture
    void OnGUI()
    {
        GUI.color = new Color(0f, 0f, 0f, amount);
        GUI.DrawTexture(new Rect(0f, 0f, Screen.width, Screen.height), texture);
    }
}