using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;
    public static GameManager Instance
    {
        get { return instance; }
    }

    [SerializeField] private GameObject GameEndScreen;
    [SerializeField] private Text championNameText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameEnds(string championName)
    {
        GameEndScreen.SetActive(true);
        Time.timeScale = 0;

        // Champion full name will be "Paddle Color + Paddle". This line will take the champion paddle color in RGBA format.
        Color championColorCode = GameObject.Find(championName).GetComponent<SpriteRenderer>().color;
        string championColorName = ColorSetting.GetColorName(championColorCode);

        championNameText.text = string.Format("{0} Paddle", championColorName);
    }
}
