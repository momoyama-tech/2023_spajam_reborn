using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class BackendManager : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Method());
    }

    private IEnumerator Method()
    {
        UnityWebRequest request = UnityWebRequest.Get("http://localhost:3000/api/v1/lobbies");

        yield return request.SendWebRequest();

        if (request.isHttpError || request.isNetworkError)
        {
            Debug.Log(request.error);
        }
        else
        {
            Debug.Log(request.downloadHandler.text);
        }

    }
}
