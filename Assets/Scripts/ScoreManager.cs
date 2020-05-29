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

    public GameObject winState;
    public GameObject winTextObject;
    private TextMeshProUGUI winText;

    AudioSource source;

    private void Start()
    {
        scoreP1 = scoreP1Object.GetComponent<TextMeshProUGUI>();
        scoreP2 = scoreP2Object.GetComponent<TextMeshProUGUI>();
        ball = ballObject.GetComponent<Ball>();
        ballRB = ballObject.GetComponent<Rigidbody2D>();
        winText = winTextObject.GetComponent<TextMeshProUGUI>();
        source = GetComponent<AudioSource>();
        if(Data.instance != null)
            pointsToWin = Data.instance.pointsToWin;
    }

    public void AddPoint(int index)
    {
        if (index == 1)
        {
            P1 += 1;
            if (P1 >= pointsToWin)
                Win(1);
            scoreP1.text = P1.ToString();
            StartCoroutine(ResetBall());
        }
        if (index == 0)
        {
            P2 += 1;
            if (P2 >= pointsToWin)
                Win(0);
            scoreP2.text = P2.ToString();
            StartCoroutine(ResetBall());
        }
        else
            return;
    }

    IEnumerator ResetBall()
    {
        ballRB.velocity = new Vector2(0, 0);
        yield return new WaitForSeconds(0.4f);
        ballRB.transform.position = new Vector2(0, 0);
        StartCoroutine(ball.Launch());
    }

    void Win(int index)
    {
        winState.SetActive(true);
        source.Play();
        Time.timeScale = 0f;

        if (index == 1)
            winText.text = "Player 1 Wins!";
        if (index == 0)
            winText.text = "Player 2 Wins!";
    }
}
