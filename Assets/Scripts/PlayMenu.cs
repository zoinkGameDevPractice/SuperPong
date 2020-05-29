using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayMenu : MonoBehaviour
{
    Data data;

    public TextMeshProUGUI pointText;
    public TextMeshProUGUI playerSpeedText;
    public TextMeshProUGUI ballSpeedText;

    public Slider pointSlider;
    public Slider playerSpeedSlider;
    public Slider ballSpeedSlider;

    public Animator anim;

    private void Start()
    {
        data = Data.instance;
    }

    public void Play()
    {
        data.pointsToWin = (int)pointSlider.value;
        data.playerSpeed = playerSpeedSlider.value;
        data.ballSpeed = ballSpeedSlider.value;
        anim.SetTrigger("End");
    }

    public void SetPointsToWin(float points)
    {
        pointText.text = "Points To Win: " + points;
    }

    public void SetPlayerSpeed(float speed)
    {
        playerSpeedText.text = "Player Speed: " + speed;
    }

    public void SetBallSpeed(float speed)
    {
        ballSpeedText.text = "Ball Speed: " + speed;
    }
}
