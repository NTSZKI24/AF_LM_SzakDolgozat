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

    private void Start()
    {
        ArrowRandomizer();
    }

    public void ArrowRandomizer()
    {
        randomArrow = Random.Range(1, 5);
        spriteRenderer.sprite = arrowImages[randomArrow];
        print(randomArrow);
    }
}
