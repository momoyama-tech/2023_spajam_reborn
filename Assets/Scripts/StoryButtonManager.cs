using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine .UI;

public class StoryButtonManager : MonoBehaviour
{
    public Button Button01;
    public Button Button02;
    public Button Button03;
    public GameObject StoryManager;

    public void  OnClickButton01()
    {
        // Button01
        Button01.image.color = Color.red;
        Button02.image.color = Color.red;
        Button03.image.color = Color.red;
    }

    public void OnClickButton02()
    {
        // Button01
    }

    public void OnClickButton03()
    {
        // Button01
    }
}
