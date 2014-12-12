using UnityEngine;
using System.Collections;

public class KeepAudioOnInstructions : MonoBehaviour
{
    public AudioClip mainMenu, mainGame;

    private static KeepAudioOnInstructions instance = null;

    public static KeepAudioOnInstructions Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
    }

    void OnLevelWasLoaded(int level)
    {
        if(level == 2)
        {
            audio.Stop();
            audio.clip = mainGame;
            audio.Play();
        }
    }

}
