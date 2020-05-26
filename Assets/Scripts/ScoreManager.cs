using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    #region Singleton
    public static ScoreManager instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    public int pointsToWin = 10;

    [HideInInspector]
    public int P1 = 0;
    [HideInInspector]
    public int P2 = 0;

    public GameObject scoreP1Object;
    public GameObject scoreP2Object;
    private TextMeshProUGUI scoreP1;
    private TextMeshProUGUI scoreP2;

    public GameObject ballObject;
    private Ball ball;
    private Rigidbody2D ballRB;

    public float resetDelay = 1f;

    private void Start()
    {
        scoreP1 = scoreP1Object.GetComponent<TextMeshProUGUI>();
        scoreP2 = scoreP2Object.GetComponent<TextMeshProUGUI>();
        ball = ballObject.GetComponent<Ball>();
        ballRB = ballObject.GetComponent<Rigidbody2D>();
    }

    public void AddPoint(int index)
    {
        if (index == 1)
        {
            P1 += 1;
            scoreP1.text = P1.ToString();
            ResetBall();
        }
        if (index == 0)
        {
            P2 += 1;
            scoreP2.text = P2.ToString();
            ResetBall();
        }
        else
            return;
    }

    void ResetBall()
    {
        ballRB.velocity = new Vector2(0, 0);
        ballRB.transform.position = new Vector2(0, 0);
        StartCoroutine(Launch());
    }

    IEnumerator Launch()
    {
        yield return new WaitForSeconds(resetDelay);
        ball.Launch();
    }
}
