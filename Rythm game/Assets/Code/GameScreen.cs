using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScreen : MonoBehaviour
{

    ///Array for sprite display

    [SerializeField] Sprite [] arrowImages;


    [SerializeField] SpriteRenderer spriteRenderer;

    int randomArrow;
    int randomLength;

    public void XButton()
    {
        SceneManager.LoadSceneAsync("menu");
    }

    private void Start()
    {
    
    }
}
