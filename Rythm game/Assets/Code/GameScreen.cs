using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScreen : MonoBehaviour
{
    public void XButton()
    {
        SceneManager.LoadSceneAsync("menu");
    }
}
