using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using MiniJSON;
using UnityEngine.SceneManagement;

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

    public Text TextInputFieldHajike;

    public Text TextCheckCanvas;

    public Button Button01;
    public Button Button02;
    public Button Button03;

    public string Story = "";

    private bool aiFlag = false;

    // private string BackendUrl = "http://localhost:3000";
    private string BackendUrl = "http://165.232.131.66:3000";

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
        if (Story == "")
        {
            yield return 0;
        }
        UnityWebRequest request = UnityWebRequest.PostWwwForm(BackendUrl + "/api/v1/stories", Story);

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

    private IEnumerator HajikeStoriesCreate()
    {
        Debug.Log(TextInputFieldHajike.text);
        if (TextInputFieldHajike.text == "")
        {
            yield return 0;
        }
        UnityWebRequest request = UnityWebRequest.PostWwwForm(BackendUrl + "/api/v1/hajike_stories", TextInputFieldHajike.text);

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
        aiFlag = true;
        StartCoroutine(GeneStoriesIndex());
    }

    public void ShowLoadCanvas()
    {
        GeneCanvas.SetActive(false);
        HajikeCanvas.SetActive(false);
        LoadCanvas.SetActive(true);
        if (aiFlag)
        {
            StartCoroutine(GeneStoriesCreate());
        }
        else
        {
            StartCoroutine(HajikeStoriesCreate());
        }
        
    }

    public void ShowLoadHajikeCanvas()
    {
        GeneCanvas.SetActive(false);
        HajikeCanvas.SetActive(false);
        LoadCanvas.SetActive(true);
        StartCoroutine(HajikeStoriesCreate());
    }

    public void ShowCheckCanvas()
    {
        LoadCanvas.SetActive(false);
        CheckCanvas.SetActive(true);
        if (aiFlag)
        {
            TextCheckCanvas.text = "AI";
        }
        else
        {
            TextCheckCanvas.text = "Human";
        }
        StartCoroutine(DelayCoroutine());
    }

    public void  ReGenerateStory()
    {
        StartCoroutine(GeneStoriesIndex());
    }

    public void OnClickButton01()
    {
        Button01.image.color = Color.red;
        Button02.image.color = Color.white;
        Button03.image.color = Color.white;
        Story = Button01.transform.GetComponentInChildren<Text>().text;
    }

    public void OnClickButton02()
    {
        Button01.image.color = Color.white;
        Button02.image.color = Color.red;
        Button03.image.color = Color.white;
        Story = Button02.transform.GetComponentInChildren<Text>().text;
    }

    public void OnClickButton03()
    {
        Button01.image.color = Color.white;
        Button02.image.color = Color.white;
        Button03.image.color = Color.red;
        Story = Button03.transform.GetComponentInChildren<Text>().text;
    }

    private IEnumerator DelayCoroutine()
    {
        transform.position = Vector3.one;

        // 3????
        yield return new WaitForSeconds(3);

        SceneManager.LoadScene("Talk", LoadSceneMode.Single);
    }
}
