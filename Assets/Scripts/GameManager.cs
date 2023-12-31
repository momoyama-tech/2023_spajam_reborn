using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public InputField inputFieldYourName;
    public string PlayerName = "";
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        inputFieldYourName.text = PlayerPrefs.GetString("PlayerName", "");
    }

    public void SwitchLobbyScene()
    {
        if (inputFieldYourName.text == "")
        {
            return;
        }
        PlayerPrefs.SetString("PlayerName", inputFieldYourName.text);
        SceneManager.LoadScene("Lobby", LoadSceneMode.Single);
    }
}
