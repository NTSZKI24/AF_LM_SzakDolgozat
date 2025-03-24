using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ProfileManager : MonoBehaviour {
    [Header("UI")]
    public Text errorText;
    public InputField loginNameField;
    public InputField loginPasswordField; 
    public InputField registerNameField; 
    public InputField registerMailField;  
    public InputField registerPasswordField;
    public Button signInButton;
    public Button signUpButton;

    void Start()
    {
        signInButton.onClick.AddListener(OnSignInButtonClick);
        signUpButton.onClick.AddListener(OnSignUpButtonClick);

    }

    void OnSignInButtonClick()
    {
        string logUs = loginNameField.text;
        string logPw = loginPasswordField.text;

        string teszt = "";

        if (logUs == teszt && logPw == teszt)
        {
            SceneManager.LoadSceneAsync("Game Screen");
        } 
        else
        {
            errorText.text="Wrong username or password!";
        }
    }

    void OnSignUpButtonClick()
    {
        string regUs = registerNameField;
        string regEm = registerMailField;
        string regPw = registerPasswordField;

        if (regUs == regPw)
        {
            errorText.text("Username and password can't match!");
        }
        else
        {
            //
        }
    }

}