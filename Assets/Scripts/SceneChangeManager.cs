using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SwitchLobbyScene()
    {
        SceneManager.LoadScene("Lobby", LoadSceneMode.Single);
    }
    public void SwitchHistoryScene()
    {
        SceneManager.LoadScene("History", LoadSceneMode.Single);
    }
    public void SwitchTitleScene()
    {
        SceneManager.LoadScene("Title", LoadSceneMode.Single);
    }
}
