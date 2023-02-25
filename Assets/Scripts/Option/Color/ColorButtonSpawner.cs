using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ColorButtonSpawner : MonoBehaviour
{
    [SerializeField] private Image paddleVisual;
    [SerializeField] private Button buttonPrefab;

    //private List<Button> buttonsList = new List<Button>();

    // Start is called before the first frame update
    void Start()
    {
        SpawnButton();
    }

    private void SpawnButton()
    {
        foreach (var colorKey in ColorSetting.colors.Keys)
        {
            Button newButton = Instantiate(buttonPrefab, this.transform);
            ColorButton colorButton = newButton.GetComponent<ColorButton>();
            ColorBlock colorBlock = newButton.colors;

            colorBlock.normalColor = colorKey;
            newButton.colors = colorBlock;

            newButton.onClick.AddListener(() => colorButton.ChangePaddleColor(paddleVisual, colorKey));

            //buttonsList.Add(newButton);
        }
    }
}
