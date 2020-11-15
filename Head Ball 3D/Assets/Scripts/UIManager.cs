using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    
    public static UIManager Instance;

    [SerializeField] private Canvas inGameCanvas;
    [SerializeField] private Canvas mainMenuCanvas;
    [SerializeField] private Canvas scoreCanvas;

    [SerializeField] private GameObject loseText;
    [SerializeField] private GameObject winText;

  

    [SerializeField] private GameObject winButton;
    [SerializeField] private GameObject loseButton;
    
    
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
       EventManager.Instance.OnNextRound += NextRound;
       EventManager.Instance.OnOpponentWinMatch += OpponentWinMatch;
       EventManager.Instance.OnPlayerWinMatch += PlayerWinMatch;
        
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

    
    public void PlayerWin()
    {
        scoreCanvas.gameObject.SetActive(true);   
    }

    public void OpponentWin()
    {
        scoreCanvas.gameObject.SetActive(true);   
    }

    public void NextRound()
    {
        scoreCanvas.gameObject.SetActive(false);
    }

    public void OpponentWinMatch()
    {
        loseText.SetActive(true);
        loseButton.SetActive(true);
    }

    public void PlayerWinMatch()
    {
        winButton.SetActive(true);
        winText.SetActive(true);
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
