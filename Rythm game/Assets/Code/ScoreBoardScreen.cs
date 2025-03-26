using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreBoardScreen : MonoBehaviour
{
    public void XButton()
    {
        SceneManager.LoadSceneAsync("menu");
    }
}
