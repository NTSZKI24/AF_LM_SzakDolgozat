using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("Game Screen");

    }

    public void Profile()
    {
        SceneManager.LoadSceneAsync("profile 2");
    }

    public void Settings()
    {
        SceneManager.LoadSceneAsync("SettingsScreen");
    }

    public void Exit()
    {
        Application.Quit();
        Debug.Log("Exit");
    }
}
