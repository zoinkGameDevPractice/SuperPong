using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5f;

    Rigidbody2D rb;

    bool isPlayerOne;
    Vector2 velocity;

    // Start is called before the first frame update
    void Start()
    {
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
}
