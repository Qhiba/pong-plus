using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb2D;
    public float ballSpeed = 10f;
    public float maxSpeed = 20f;
    public float acceleration = 1f;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.velocity = new Vector2(ballSpeed, ballSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Paddle")
        {
            if (rb2D.velocity.magnitude < maxSpeed)
            {
                rb2D.velocity = rb2D.velocity.normalized * (rb2D.velocity.magnitude + acceleration);
            }
        }
    }
}
