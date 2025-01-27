using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsScreen : MonoBehaviour
{
    public void XButton()
    {
        SceneManager.LoadSceneAsync("menu");
    }
}
