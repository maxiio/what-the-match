﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    private int currentLevel;
 

    [SerializeField] private GameObject currentLevelText;

    private void Awake()
    {
        SingletonPattern();
        currentLevel = SceneManager.GetActiveScene().buildIndex;
        EventManager.Instance.OnGameStarted += GameStartLevelText;
        
        //EventManager.Instance.GameStarted += LoadNextLevel;
    }

    private void SingletonPattern()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
    
    public int GetCurrentLevel()
    {
        return currentLevel;
    }
    
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void GameStartLevelText()
    {
        currentLevelText.GetComponent<Text>().text = "Level " + currentLevel.ToString();
    }

   

}
