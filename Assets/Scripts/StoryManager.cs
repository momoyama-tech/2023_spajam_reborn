using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using MiniJSON;

public class StoryManager : MonoBehaviour
{
    public GameObject GeneHajikeCanvas;
    public GameObject GeneCanvas;
    public GameObject HajikeCanvas;
    public GameObject LoadCanvas;
    public GameObject CheckCanvas;

    public Text TextGeneButton01;
    public Text TextGeneButton02;
    public Text TextGeneButton03;

    private string Story = "";

    private string BackendUrl = "http://localhost:3000";
    // private string BackendUrl = "http://174.138.40.241:3000";

    private IEnumerator GeneStoriesIndex()
    {
        UnityWebRequest request = UnityWebRequest.Get(BackendUrl + "/api/v1/gene_stories");

        yield return request.SendWebRequest();

        if (request.isHttpError || request.isNetworkError)
        {
            Debug.Log(request.error);
        }
        else
        {
            Dictionary<string, object> response = Json.Deserialize(request.downloadHandler.text) as Dictionary<string, object>;
            Debug.Log("geneStory_index: " + response["geneStory01"] + " " + response["geneStory02"] + " " + response["geneStory03"]);
            TextGeneButton01.text = response["geneStory01"].ToString();
            TextGeneButton02.text = response["geneStory02"].ToString();
            TextGeneButton03.text = response["geneStory03"].ToString();
        }
    }

    private IEnumerator GeneStoriesCreate()
    {
        UnityWebRequest request = UnityWebRequest.PostWwwForm(BackendUrl + "/api/v1/gene_stories", Story);

        yield return request.SendWebRequest();

        if (request.isHttpError || request.isNetworkError)
        {
            Debug.Log(request.error);
        }
        else
        {
             //
        }
    }

    public void ShowHajikeCanvas()
    {
        GeneHajikeCanvas.SetActive(false);
        HajikeCanvas.SetActive(true);
    }

    public void ShowGeneCanvas()
    {
        GeneHajikeCanvas.SetActive(false);
        GeneCanvas.SetActive(true);
        StartCoroutine(GeneStoriesIndex());
    }

    public void ShowLoadCanvas()
    {
        GeneCanvas.SetActive(false);
        HajikeCanvas.SetActive(false);
        LoadCanvas.SetActive(true);
        StartCoroutine(GeneStoriesCreate());
    }

    public void ShowCheckCanvas()
    {
        LoadCanvas.SetActive(false);
        CheckCanvas.SetActive(true);
    }

    public void  ReGenerateStory()
    {
        StartCoroutine(GeneStoriesIndex());
    }
}
