using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InGameMenu : MonoBehaviour
{
    public GameObject textGameObject;
    public Image flux, vim, ether;
    public Image one, two, three;
    public GameObject menu;
    private bool isMenuActive;
    private GameObject player;
    private Controller playerController;

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


        if(isMenuActive)
        {
            for(int i = 0; i < 3; i++)
            {
                if(playerController.IsChakraAbilityActive(i))
                {

                }
            }
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
