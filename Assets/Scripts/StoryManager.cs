using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryManager : MonoBehaviour
{
    public GameObject GeneHajikeCanvas;
    public GameObject GeneCanvas;
    public GameObject HajikeCanvas;
    public GameObject LoadCanvas;
    public GameObject CheckCanvas;

    public void ShowHajikeCanvas()
    {
        GeneHajikeCanvas.SetActive(false);
        HajikeCanvas.SetActive(true);
    }

    public void ShowGeneCanvas()
    {
        GeneHajikeCanvas.SetActive(false);
        GeneCanvas.SetActive(true);
    }

    public void ShowLoadCanvas()
    {
        GeneCanvas.SetActive(false);
        HajikeCanvas.SetActive(false);
        LoadCanvas.SetActive(true);
    }

    public void ShowCheckCanvas()
    {
        LoadCanvas.SetActive(false);
        CheckCanvas.SetActive(true);
    }

    public void  ReGenerateStory()
    {
        Debug.Log("re");
    }
}
