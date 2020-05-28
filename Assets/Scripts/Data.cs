using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
    public Data instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    public int pointsToWin;
    public int playerSpeed;
    public int ballSpeed;

    public float musicVolume;
    public float soundVolume;
}
