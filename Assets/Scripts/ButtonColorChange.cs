using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonColorChange : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OChangeColor()
    {
        Button self = GetComponent<Button>();
        if (self.color == Color.white)
        {
            self.color = Color.red;
        }
        else
        {
            self.color = Color.blue;
        }
    }
}
