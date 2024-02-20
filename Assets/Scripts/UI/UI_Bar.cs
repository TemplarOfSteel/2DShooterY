using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Bar : MonoBehaviour
{
    public Image fill;
    public bool scaleX = false;
    public bool scaleY = false;

    public void SetFill(float percentage)
    {
        fill.transform.localScale = new Vector3(
            scaleX ? percentage : fill.transform.localScale.x,
            scaleY ? percentage : fill.transform.localScale.y,
            fill.transform.localScale.z);
    }
}
