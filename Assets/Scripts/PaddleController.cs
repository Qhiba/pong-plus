using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    [Range(1f, 20f)]
    [SerializeField] private float speed = 1.0f;

    [SerializeField] private KeyCode moveUpKey = KeyCode.W;
    [SerializeField] private KeyCode moveDownKey = KeyCode.S;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 velocity = new Vector2(0.0f, PaddleInput());
        rb.velocity = velocity;
    }

    private float PaddleInput()
    {
        //Paddle Input
        if (Input.GetKey(moveUpKey))
            return speed;
        else if (Input.GetKey(moveDownKey))
            return -speed;
        
        return 0;
    }
}
