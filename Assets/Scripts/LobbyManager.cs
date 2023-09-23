using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LobbyManager : MonoBehaviour
{
    public Text textHeaderPlayerName;
    // Start is called before the first frame update
    void Start()
    {
        textHeaderPlayerName.text = PlayerPrefs.GetString("PlayerName", "");
    }

    public void SwitchStoryScene()
    {
        SceneManager.LoadScene("Story", LoadSceneMode.Single);
    }
}
