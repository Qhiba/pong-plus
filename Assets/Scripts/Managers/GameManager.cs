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
            DontDestroyOnLoad(transform.parent);
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
        string championRGBAColorName = GameObject.Find(championName).GetComponent<SpriteRenderer>().color.ToString();
        Color championColor;

        Debug.Log(championRGBAColorName);
        // Change the RGBA color format into readable color name.
        if (ColorUtility.TryParseHtmlString(championRGBAColorName, out championColor))
        {
            Debug.Log(championColor);
            string championColorName = championColor.ToString();
            championNameText.text = string.Format("{0} Paddle", championColorName);
        }
    }
}
