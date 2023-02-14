using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalDetector : MonoBehaviour
{
    [SerializeField] private Transform paddle;

    private string paddleName;

    // Start is called before the first frame update
    void Start()
    {
        paddleName = paddle.name;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Ball"))
        {
            BallMovement ballMovement = collision.GetComponent<BallMovement>();
            if (paddleName == "Right Paddle")
            {
                ScoreManager.Instance.UpdateLeftPaddleScore(paddleName);
            }
            else if (paddleName == "Left Paddle")
            {
                ScoreManager.Instance.UpdateRightPaddleScore(paddleName);
            }

            ballMovement.ResetBall();
        }
    }
}
