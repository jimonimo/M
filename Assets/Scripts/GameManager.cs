﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
     
    private static GameManager _instance;//실제이름
    public static GameManager Instance//밖에서 쓰이는 이름
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameManager();
            }
            return _instance;
        }


    }

    private void Awake()
    {
        _instance = this;//게임매니저는 나다
    }


    public Player player;
    public UiManager uiManager;
    private int currentCoin = 0;
    private int currentLife = 3;
    public bool gameOver = false;
    public bool gamePause = false;
    public float timeLeft = 100;
    

    void Start()
    {
        uiManager.OnOffPopUp(false);
        Load();
        player.SetPlayer();
    }


    void Update()
    {
        if (GameManager.Instance.gamePause == false)
        {
            timeLeft -= Time.deltaTime;
            int i = (int)Math.Ceiling(timeLeft);
            uiManager.ShowTimeLeftCount(i);
            if (timeLeft < 0.1f)
            {
                GameOver();
            }
        }
    }
    public void Save()
    {
        Debug.Log("저장"+currentCoin);
        PlayerPrefs.SetInt("Coin", currentCoin);
        PlayerPrefs.SetInt("Life", currentLife);
        PlayerPrefs.Save();
    }
    public void Load()
    {
        
        if (PlayerPrefs.HasKey("Coin"))
        { 
            currentCoin = PlayerPrefs.GetInt("Coin");
        }
        else
        {
            currentCoin = 0;
        }

        if (PlayerPrefs.HasKey("Life"))
        {
            currentLife = PlayerPrefs.GetInt("Life");
        }
        else
        {
            currentLife = 0;
        }
        Debug.Log("로드" + currentCoin);
    }
    
    public void ClearPlayerPrefs()
    {
        currentCoin = 0;
        currentLife = 0;
        Save();

    }
    
    
    public void CountCoin(int coin)
    {
        //코인갯수 더해줌
        currentCoin = currentCoin + coin;
        uiManager.ShowCoinCount(currentCoin);
        //값을 바뀔친구가 앞에
        //더해준 코인을 ui매니저가 알도록해서 Text로 띄워줌
    }
    public void CountLife(int life)
    {
        currentLife = currentLife + life;
        uiManager.ShowLifeCount(currentLife);
    }

    
    public void CountDieLife(int life)
    {
        Debug.Log("-Life");
        currentLife = currentLife - life;
        uiManager.ShowLifeCount(currentLife);
    }

    

    public void GameOver()
    {
        gameOver = true;
        Save();
        uiManager.OnOffPopUp(true);
        uiManager.ShowPopupText(currentCoin, currentLife);
    }

    public void GamePause()
    {
        if (gamePause == true)
        {
            gamePause = false;
        }
        else
        {
            gamePause = true;
            Debug.Log("멈춤");
        }
    }

    



}



