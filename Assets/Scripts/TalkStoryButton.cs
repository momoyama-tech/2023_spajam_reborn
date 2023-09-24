using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkStoryButton : MonoBehaviour
{
    public Button buttonObj;
    int colorIndex = 0;
    public void OnClickMethod()
    {
        if (colorIndex == 0)
        {
            buttonObj.image.color = Color.red;
            colorIndex = 1;
        } else if (colorIndex == 1)
        {
            buttonObj.image.color = Color.blue;
            colorIndex = 2;
        }
        else if (colorIndex == 2)
        {
            buttonObj.image.color = Color.white;
            colorIndex = 0;
        }
        else
        {
            colorIndex = 0;
            buttonObj.image.color = Color.white;
        }
    }
}
