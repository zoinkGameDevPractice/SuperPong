using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5f;

    Rigidbody2D rb;
    Ball ball;

    bool isPlayerOne;
    Vector2 velocity;

    public float boost = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.FindWithTag("Ball").GetComponent<Ball>();
        rb = GetComponent<Rigidbody2D>();
        if (tag == "Player1")
            isPlayerOne = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlayerOne)
        {
            velocity = new Vector2(rb.velocity.x, Input.GetAxisRaw("Vertical")) * speed;
        } else
        {
            velocity = new Vector2(rb.velocity.x, Input.GetAxisRaw("Vertical2") * speed);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D collider = collision.collider;
        if (collider.CompareTag("Ball"))
            ball.ApplyBoost(new Vector2(boost, 0));
    }
}
