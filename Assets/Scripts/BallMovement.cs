using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] private float startingSpeed = 10.0f;
    [SerializeField] private float maxSpeed = 10.0f;
    [SerializeField] private float ballStartDelayInSeconds = 1.0f;

    [Range(1.01f, 2.0f)]
    [SerializeField] private float accelerationRate = 1.05f;

    private Rigidbody2D rb2d;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        ResetBall();
    }

    public void ResetBall()
    {
        transform.position = Vector3.zero;
        rb2d.velocity = Vector2.zero;
        Invoke("BallLaunch", ballStartDelayInSeconds);
    }

    private void BallLaunch()
    {
        float randomXValue = Random.Range(0.0f, 1.0f) > 0.5 ? 1 : -1;
        float randomYValue = Random.Range(-0.99f, 1.0f);

        rb2d.velocity = new Vector2(randomXValue, randomYValue).normalized * startingSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Paddle"))
        {
            ChageDirectionOnPaddleHit(collision.transform.position.y);

            if (rb2d.velocity.magnitude < maxSpeed)
            {
                rb2d.velocity += rb2d.velocity.normalized * accelerationRate;
            }
        }
    }

    private void ChageDirectionOnPaddleHit(float paddleYValue)
    {
        if (transform.position.y > paddleYValue)
        {
            Debug.Log("UP");
            rb2d.velocity = new Vector2(-rb2d.velocity.x, Random.Range(0.5f, 1.0f));
        }
        else if (transform.position.y < paddleYValue)
        {
            Debug.Log("DOWN");
            rb2d.velocity = new Vector2(-rb2d.velocity.x, Random.Range(-0.99f, -0.5f));
        }
        else
        {
            Debug.Log("STRAIGHT");
            rb2d.velocity = new Vector2(-rb2d.velocity.x, 0.0f);
        }
    }
}
