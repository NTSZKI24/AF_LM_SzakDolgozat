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

    public void Register()
    {
        SceneManager.LoadSceneAsync("Register");
    }

    public void ScoreBoard()
    {
        SceneManager.LoadSceneAsync("ScoreBoardScreen");
    }

    public void Exit()
    {
        Application.Quit();
        Debug.Log("Exit");
    }
}
