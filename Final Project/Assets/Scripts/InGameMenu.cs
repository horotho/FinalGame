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
                menu.SetActive(false);
            }

            
        }


    }
}
