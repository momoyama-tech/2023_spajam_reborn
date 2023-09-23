using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using WebSocketSharp;
using System.Text.Json;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using MiniJSON;
using static WebSocketRequestMessage;
using static WebSocketRequestSubscribe;

public class WebSocketResponse
{
    public string identifier;
    public string message;
}

public class WebSocketPingResponse
{
    public string identifier;
    public string message;
    public string type;
}

public class WebSocketManager : MonoBehaviour
{
    private WebSocket ws;
    // private string BackendUrl = "http://localhost:3000";
    private string BackendUrl = "https://spajam2023.tunnelto.dev";
    // private string  WsUrl = "ws://localhost:3000";
    private string  WsUrl = "wss://spajam2023.tunnelto.dev";
    public Text LobbyCountText;

    void Start()
    {
        var context = SynchronizationContext.Current;

        ws = new WebSocket(WsUrl + "/cable/");
        ws.OnOpen += (sender, e) =>
        {
            Debug.Log("WebSocket Open");
            if (SceneManager.GetActiveScene().name == "Lobby")
            {
                var webSocketRequestSubscribe = new WebSocketRequestSubscribe("subscribe", "LobbyChannel");
                ws.Send(JsonSerializer.Serialize(webSocketRequestSubscribe));
                Debug.Log("WebSocket LobbyChannel Subscribe");
                var webSocketRequestMessage = new WebSocketRequestMessage("message", "LobbyChannel", "lobbies", "lobby_init");
                ws.Send(JsonSerializer.Serialize(webSocketRequestMessage));
                Debug.Log("WebSocket Get Lobbies");
            }
            else if (SceneManager.GetActiveScene().name == "Game")
            {
                Debug.Log("GameScene");
                var webSocketRequestSubscribe = new WebSocketRequestSubscribe("subscribe", "GameChannel");
                ws.Send(JsonSerializer.Serialize(webSocketRequestSubscribe));
                Debug.Log("WebSocket GameChannel Subscribe");
                var webSocketRequestMessage = new WebSocketRequestMessage("message", "GameChannel", "game", "init");
                ws.Send(JsonSerializer.Serialize(webSocketRequestMessage));
            }
        };

        ws.OnMessage += (sender, e) =>
        {
            WebSocketPingResponse webSocketPingResponse = JsonUtility.FromJson<WebSocketPingResponse>(e.Data);
            if (webSocketPingResponse.type == "ping")
            {
                 // Debug.Log("WebSocket Message: " + e.Data);
                return;
            }

            WebSocketResponse webSocketResponse = JsonUtility.FromJson<WebSocketResponse>(e.Data);
            if (webSocketResponse.message == "lobby_init")
            {
                context.Post(state => {
                    StartCoroutine(LobbiesIndex());
                }, e.Data);
            }
            else if (webSocketResponse.message == "continue")
            {
                Debug.Log("111111");
            }
        };

        ws.OnError += (sender, e) =>
        {
            Debug.Log("WebSocket Error Message: " + e.Message);
        };

        ws.OnClose += (sender, e) =>
        {
            Debug.Log("WebSocket Close");
        };

        ws.Connect();
    }

    void OnDestroy()
    {
        ws.Close();
        ws = null;
    }

    private IEnumerator LobbiesIndex()
    {
        UnityWebRequest request = UnityWebRequest.Get(BackendUrl + "/api/v1/lobbies");

        yield return request.SendWebRequest();

        if (request.isHttpError || request.isNetworkError)
        {
            Debug.Log(request.error);
        }
        else
        {
            // Debug.Log("lobby_index: " + request.downloadHandler.text);
            Dictionary<string, object> response = Json.Deserialize(request.downloadHandler.text) as Dictionary<string, object>;
            Debug.Log("lobby_index: " + response["userCount"]);
            LobbyCountText.text = "ただいま " + response["userCount"] .ToString() + "人です";
        }

    }
}

