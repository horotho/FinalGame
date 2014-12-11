using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InGameMenu : MonoBehaviour
{
    public GameObject textGameObject;
    public Image flux, vim, ether;
    public GameObject menu;
    private bool isMenuActive;

    // Use this for initialization
    void Start()
    {
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

    void FullAlpha(Image image)
    {
        Color c = image.color;
        c.a = 1f;
        image.color = c;
    }


    public void SetIndicatorActive(string ind)
    {
        Debug.Log("TAG IS " + ind);
        if(ind == "VIM") FullAlpha(vim);
        else if(ind == "FLUX") FullAlpha(flux);
        else if(ind == "ETHER") FullAlpha(ether);
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
