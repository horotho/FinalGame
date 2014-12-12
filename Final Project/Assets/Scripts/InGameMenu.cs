using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InGameMenu : MonoBehaviour
{
    public GameObject menu, tutorial, textGameObject, tutorialTextGameObject;
    public Image flux, vim, ether;
    public Image one, two, three;

    private Text tutorialText;
    private bool isMenuActive;
    private GameObject player;
    private Controller playerController;

	void Awake()
	{
		tutorialText = tutorialTextGameObject.GetComponent<Text>();
	}

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<Controller>();

        Text text = textGameObject.GetComponent<Text>();
        text.text = "Level " + (Application.loadedLevel - 1);
       
        menu.SetActive(false);
        isMenuActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            isMenuActive = !isMenuActive;

            if(isMenuActive)
            {
                menu.SetActive(true);
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
                menu.SetActive(false);
            }
        }
    }

    void OnLevelWasLoaded(int level)
    {
        switch(level)
        {
            // Ether
            case 3:
                tutorial.SetActive(true);
                tutorialText.text = "Pickup the Ether element by moving over it. Select Ether by pressing 1. Hold down space bar to float!";
                break;
            // Flux
            case 4:
                tutorial.SetActive(true);
                tutorialText.text = "Pickup the Flux element by moving over it. Select Flux by pressing 2. Use F to turn into water and slide down the gap!";
                break;
            // Vim
            case 5:
                tutorial.SetActive(true);
                tutorialText.text = "Pickup the Vim element by moving over it. Select Vim by pressing 3. Use F to spawn a ladder!";
                break;

            case 7:
                tutorial.SetActive(true);
                tutorialText.text = "Beware the spikes!";
                break;

            case 9:
                tutorial.SetActive(true);
                tutorialText.text = "Beware the water!";
                break;

            default:
                tutorial.SetActive(false);
                break;
        }
    }

    void FullAlpha(Image image)
    {
        Color c = image.color;
        c.a = 1f;
        image.color = c;
    }


    public void SetIndicatorActive(string ind)
    {
        if(ind == "VIM")
        {
            FullAlpha(vim);
            FullAlpha(three);
        }
        else if(ind == "FLUX")
        {
            FullAlpha(two);
            FullAlpha(flux);
        }
        else if(ind == "ETHER")
        {
            FullAlpha(one);
            FullAlpha(ether);
        }
    }


    public void Exit()
    {
        Time.timeScale = 1;
        Application.Quit();
    }

    public void Restart()
    {
        Time.timeScale = 1;
        ScreenFade.Instance.Fade(Application.loadedLevel, 0.1f);
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        ScreenFade.Instance.Fade(0, 0.5f);
    }
}
