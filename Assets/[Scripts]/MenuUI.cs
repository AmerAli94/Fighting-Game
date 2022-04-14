using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


public class MenuUI : MonoBehaviour
{
    public GameObject optionsMenuScreen;
    public GameObject mainMenuScreen;
    public GameObject optionsSelectButton;
    public GameObject menuSelectButton;


    public void Start()
    {
        mainMenuScreen.SetActive(true);
    }
    public void OnPlayButtonPressed()
    {
        SceneManager.LoadScene("Main");
    }

    public void OnQuitPressed()
    {
        Application.Quit();
    }

    public void OnOptionsPressed()
    {
        mainMenuScreen.SetActive(false);
        optionsMenuScreen.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(optionsSelectButton);
    }

    public void OnBackButtonPressed()
    {
        mainMenuScreen.SetActive(true);
        optionsMenuScreen.SetActive(false);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(menuSelectButton);
    }
}
