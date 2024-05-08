using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuScript : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject mainPauseMenu;
    public GameObject optionsMenu;
    public GameObject aYSMainMenuScreen;
    public GameObject aYSQuitScreen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(pauseMenu.activeSelf == false)
            {
                pauseMenu.SetActive(true);
            }
            else if(pauseMenu.activeSelf == true)
            {
                if(optionsMenu.activeSelf == true)
                {
                    optionsMenu.SetActive(false);
                    mainPauseMenu.SetActive(true);
                }
                else if (aYSMainMenuScreen.activeSelf == true)
                {
                    aYSMainMenuScreen.SetActive(false);
                    mainPauseMenu.SetActive(true);
                }
                else if(aYSQuitScreen.activeSelf == true)
                {
                    aYSQuitScreen.SetActive(false);
                    mainPauseMenu.SetActive(true);
                }
                else
                {
                    pauseMenu.SetActive(false);
                }
            }
        }
    }
}