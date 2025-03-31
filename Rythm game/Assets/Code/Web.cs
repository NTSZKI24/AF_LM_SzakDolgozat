using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

public class Web : MonoBehaviour 
{

    private void Start()
    {
        StartCoroutine(getUser());
        //StartCoroutine(Login("teszt", "123456"));
        //StartCoroutine(RegisterUser("testuser", "jelszo"));
    }
    IEnumerator getUser()
    {
        using (UnityWebRequest www = UnityWebRequest.Get("http://localhost/rythmn/getUsers.php")) {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError){
                Debug.LogError(www.error);
            }
            else{
                Debug.Log(www.downloadHandler.text);

                byte[] results = www.downloadHandler.data;
            }
        }
    }

    IEnumerator Login(string name, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", name);
        form.AddField("loginPass", password);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/rythmn/login.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.data);
            }
        }
    }

    IEnumerator RegisterUser(string name, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUser", name);
        form.AddField("loginPass", password);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/rythmn/registerUser.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.data);
            }
        }
    }

}
