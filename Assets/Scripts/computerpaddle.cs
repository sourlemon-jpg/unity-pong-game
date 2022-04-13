using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class computerpaddle : MonoBehaviour

{
    public Transform ball;
    private Rigidbody2D aiRb;
    public Rigidbody2D ballRb;

    public float speed = 7;

    private void Awake()
    {
        aiRb = GetComponent<Rigidbody2D>();
        ballRb = ball.GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (ballRb.velocity.x > 0)
        {
            if (ballRb.position.y > transform.position.y)
            {
                aiRb.AddForce(Vector2.up * speed);
            }
            else
            {
                aiRb.AddForce(Vector2.down * speed);
            }
        
        }
        else
        {
            if (transform.position.y > 0.0f)
            {
                aiRb.AddForce(Vector2.down * speed);
            }
            else
            {
                aiRb.AddForce(Vector2.up * speed);
            }
        }
    }

}
