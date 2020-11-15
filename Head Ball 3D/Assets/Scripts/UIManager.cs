using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    
    public static UIManager Instance;

    [SerializeField] private Canvas inGameCanvas;
    [SerializeField] private Canvas mainMenuCanvas;
    [SerializeField] private Canvas nextLevelCanvas;
    [SerializeField] private Canvas deadCanvas;
    private void Awake()
    {
        SingletonPattern();
       
    }

    // Start is called before the first frame update
    void Start()
    {
       EventManager.Instance.OnGameStarted += GameStarted;
       EventManager.Instance.OnPlayerWin += PlayerWin;
       EventManager.Instance.OnOpponentWin += OpponentWin;
        
       inGameCanvas.gameObject.SetActive(false);
       //nextLevelCanvas.gameObject.SetActive(false);
       //deadCanvas.gameObject.SetActive(false);
       mainMenuCanvas.gameObject.SetActive(true);
    }

    public void GameStarted()
    {
        mainMenuCanvas.gameObject.SetActive(false);
        inGameCanvas.gameObject.SetActive(true);
    }

    public void GameOver()
    {
    }

    public void NextLevel()
    {
        //inGameCanvas.gameObject.SetActive(false);
        nextLevelCanvas.gameObject.SetActive(true);
    }

    public void PlayerWin()
    {
        
    }

    public void OpponentWin()
    {
        
    }


    #region Singleton

    
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


    #endregion
}
