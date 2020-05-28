using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayMenu : MonoBehaviour
{
    Data data;

    private void Start()
    {
        data = Data.instance;
    }

    public void Play()
    {
        SceneManager.LoadScene("Game");
    }

    public void SetPointsToWin(string sPoints)
    {
        int points;
        bool isParsable = Int32.TryParse(sPoints, out points);
        if (isParsable)
            data.pointsToWin = points;
    }

    public void SetPlayerSpeed(string sSpeed)
    {
        float speed;
        bool isParsable = float.TryParse(sSpeed, out speed);
        if (isParsable)
            data.playerSpeed = speed;
    }

    public void SetBallSpeed(string sSpeed)
    {
        float speed;
        bool isParsable = float.TryParse(sSpeed, out speed);
        if (isParsable)
            data.ballSpeed = speed;
    }
}
