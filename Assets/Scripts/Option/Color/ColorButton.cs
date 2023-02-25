using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorButton : MonoBehaviour
{
    public void ChangePaddleColor(Image targetPaddle, Color newColor)
    {
        targetPaddle.color = newColor;
    }
}
