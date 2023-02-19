using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleAI : PaddleController
{
    private BallMovement ball;

    private void Start()
    {
        ball = FindObjectOfType<BallMovement>();    
    }

    protected override void PaddleMovement()
    {
        Transform ballPosition = ball.gameObject.GetComponent<Transform>();
        Vector3 direction = (ballPosition.position - transform.position).normalized;
        transform.position += new Vector3(0.0f, direction.y, direction.z) * speed * Time.deltaTime;
    }
}
