using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 5f;
    Rigidbody2D rb;
    [HideInInspector]
    public bool needsBoost = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Launch();
    }

    public void Launch()
    {
        float x = Random.Range(1f, 2f);
        float y = Random.Range(1f, 2f);

        rb.velocity = new Vector2(x, y) * speed;
    }

    private void Update()
    {
        if (rb.velocity.x < 2f)
            needsBoost = true;
        else
            needsBoost = false;
    }

    public void ApplyBoost(Vector2 boost)
    {
        rb.velocity += boost;
    }
}
