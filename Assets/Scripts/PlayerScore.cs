﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public float timeLeft = 100;
    public int playerScore = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        
        if (timeLeft < 0.1f)
        {
            GameManager.Instance.GameOver();
            
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        //Debug.Log("clearStage");
        CountScore();
    }

    void CountScore()
    {
        playerScore = playerScore + (int) (timeLeft * 10);
        Debug.Log("playerScore");
    }
}

