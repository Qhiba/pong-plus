using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private static ScoreManager instance = null;
    public static ScoreManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<ScoreManager>();
            }
            return instance;
        }
    }

    [SerializeField] private Text leftPaddleScoreText;
    [SerializeField] private Text rightPaddleScoreText;

    private float leftPaddleScore = 0;
    private float rightPaddleScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        leftPaddleScore = 0;
        rightPaddleScore = 0;

        leftPaddleScoreText.text = leftPaddleScore.ToString();
        rightPaddleScoreText.text = rightPaddleScore.ToString();
    }

    public void UpdateLeftPaddleScore()
    {
        leftPaddleScore++;
        leftPaddleScoreText.text = leftPaddleScore.ToString();
    }

    public void UpdateRightPaddleScore()
    {
        rightPaddleScore++;
        rightPaddleScoreText.text = rightPaddleScore.ToString();
    }
}
