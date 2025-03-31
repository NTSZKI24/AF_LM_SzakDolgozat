using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ProfileManager : MonoBehaviour 
{
    [Header("UI")]
    public Text errorText;
    public InputField loginNameField;
    public InputField loginPasswordField; 
    public InputField registerNameField; 
    public InputField registerMailField;  
    public InputField registerPasswordField;
    public Button signInButton;
    public Button signUpButton;

    /*
    public void Start()
    {
        signInButton.onClick.AddListener(OnSignInButtonClick);
        signUpButton.onClick.AddListener(OnSignUpButtonClick);

    }
    */

    public void OnSignInButtonClick()
    {
        var logUs = loginNameField.text;
        var logPw = loginPasswordField.text;

        var teszt = "asd";

        if (logUs == teszt && logPw == teszt)
        {
            SceneManager.LoadSceneAsync("Game Screen");
        } 
        else
        {
            errorText.text= "Wrong username or password!";
        }
    }

    public void OnSignUpButtonClick()
    {
        var regUs = registerNameField;
        var regEm = registerMailField;
        var regPw = registerPasswordField;

        if (regUs == regPw)
        {
            errorText.text = "Username and password can't match!";
        }
        else
        {
            //
        }
    }

    public void XButton()
    {
        SceneManager.LoadSceneAsync("menu");
    }

}