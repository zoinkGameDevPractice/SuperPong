using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 5f;
    Rigidbody2D rb;
    [HideInInspector]
    public bool needsBoost = false;

    public float launchDelay = 2f;

    AudioSource source;
    public ParticleSystem ps;

    // Start is called before the first frame update
    void Start()
    {
        if(Data.instance != null)
            speed = Data.instance.ballSpeed;
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(Launch());
    }

    public IEnumerator Launch()
    {
        yield return new WaitForSeconds(launchDelay);
        rb.velocity = GetVelocity() * speed;
    }

    private void Update()
    {
        if (rb.velocity.x < 3.5f)
            needsBoost = true;
        else
            needsBoost = false;
    }

    public void ApplyBoost(Vector2 boost)
    {
        rb.velocity += boost;
    }

    Vector2 GetVelocity()
    {
        int x = Random.Range(1, 3);
        int y = Random.Range(1, 3);

        if (x == 2)
            x = -1;
        if (y == 2)
            y = -1;

        return new Vector2(x, y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<AudioSource>())
        {
            ps.Play();
            source = collision.gameObject.GetComponent<AudioSource>();
            source.Play();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<AudioSource>())
        {
            source = collision.gameObject.GetComponent<AudioSource>();
            source.Play();
        }
    }
}
