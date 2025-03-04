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
        ArrowRandomizer();
    }

    public void ArrowRandomizer()
    {
        randomLength = Random.Range(3, 5);
        for (int i = 0; i < randomLength; i++)
        {
            randomArrow = Random.Range(0, 4);
            spriteRenderer.sprite = arrowImages[randomArrow];
            print(randomArrow);
        }
    }
}
