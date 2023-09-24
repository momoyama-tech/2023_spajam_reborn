using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using MiniJSON;

public class TalkManager : MonoBehaviour
{
    public Text textHeaderPlayerName;
    public Text text01;
    public Text text02;

    // Start is called before the first frame update
    //private string BackendUrl = "http://localhost:3000";
    private string BackendUrl = "http://165.232.131.66:3000";

    void Start()
    {
        textHeaderPlayerName.text = PlayerPrefs.GetString("PlayerName", "");
        StartCoroutine(Method());
    }

    private IEnumerator Method()
    {
        UnityWebRequest request = UnityWebRequest.Get(BackendUrl + "/api/v1/stories");

        yield return request.SendWebRequest();

        if (request.isHttpError || request.isNetworkError)
        {
            Debug.Log(request.error);
        }
        else
        {
            Debug.Log(request.downloadHandler.text);
            Dictionary<string, object> response = Json.Deserialize(request.downloadHandler.text) as Dictionary<string, object>;
            text01.text = response["story01"].ToString();
            text02.text = response["story02"].ToString();
        }

    }
}
