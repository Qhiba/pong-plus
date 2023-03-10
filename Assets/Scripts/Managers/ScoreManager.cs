using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private static ScoreManager instance = null;
    public static ScoreManager Instance
    {
        get { return instance; }
    }

    [SerializeField] private Text leftPaddleScoreText;
    [SerializeField] private Text rightPaddleScoreText;
    [SerializeField] private int MaxScore;

    private float leftPaddleScore = 0;
    private float rightPaddleScore = 0;
    private string maxScoreHolder;

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
        ResetAllScore();
    }

    private void ResetAllScore()
    {
        leftPaddleScore = 0;
        rightPaddleScore = 0;
        maxScoreHolder = "";        
    }

    private void Update()
    {
        if (leftPaddleScore >= MaxScore || rightPaddleScore >= MaxScore)
        {
            GameManager.Instance.GameEnds(maxScoreHolder);
            ResetAllScore();
        }
    }

    #region Update Score
    // Update left paddle score if the ball entered right paddle's goal.
    // paddleName is the name of the paddle that got scored.
    public void UpdateLeftPaddleScore(string paddleName)
    {
        leftPaddleScore++;
        leftPaddleScoreText.text = leftPaddleScore.ToString();

        if (leftPaddleScore > rightPaddleScore)
            maxScoreHolder = paddleName;
    }

    // Update right paddle score if the ball entered left paddle's goal.
    // paddleName is the name of the paddle that got scored.
    public void UpdateRightPaddleScore(string paddleName)
    {
        Debug.Log(paddleName);

        rightPaddleScore++;
        rightPaddleScoreText.text = rightPaddleScore.ToString();

        if (rightPaddleScore > leftPaddleScore)
            maxScoreHolder = paddleName;
    }
    #endregion
}
