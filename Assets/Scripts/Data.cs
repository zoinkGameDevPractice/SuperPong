using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
    public static Data instance;

    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public int pointsToWin = 10;
    public float playerSpeed = 6f;
    public float ballSpeed = 5f;

    public float musicVolume = 0f;
    public float soundVolume = 0f;
}
