using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScreen : MonoBehaviour
{

    ///Array for sprite display

    [SerializeField] Sprite [] arrowImages;


    [SerializeField] SpriteRenderer spriteRenderer;
    int randomArrow;

    public void XButton()
    {
        SceneManager.LoadSceneAsync("menu");
    }

    public void ArrowRandomizer()
    {
        randomArrow = Random.Range(1, arrowImages.Length + 1);
        spriteRenderer.sprite = arrowImages[randomArrow - 1];
        print(randomArrow);
    }
}
