using System;
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

        //EventManager.Instance.GameStarted += LoadNextLevel;
    }

    private void Start()
    {
        PlayerPrefs.SetInt("SAVED_LEVEL",currentLevel);
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
        int targetScene = currentLevel + 1;
        if (targetScene == SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(1); 
        }
        else
        {
            SceneManager.LoadScene(targetScene);
        }
       
    }

    
   

}
