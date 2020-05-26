using UnityEngine;

public class Goal : MonoBehaviour
{
    int index;
    ScoreManager score;

    private void Start()
    {
        score = ScoreManager.instance;
        if (tag == "Goal1")
            index = 0;
        else
            index = 1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Ball"))
        {
            score.AddPoint(index);
        }
    }
}
