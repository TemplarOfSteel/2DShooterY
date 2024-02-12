using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class FrameCounter : MonoBehaviour
{
    public TextMeshProUGUI text;

    float timer = 0;

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer<0)
        {
            text.text = "FPS: " + Mathf.RoundToInt(1 / Time.deltaTime);
            timer = 1;
        }
        
    }
}
