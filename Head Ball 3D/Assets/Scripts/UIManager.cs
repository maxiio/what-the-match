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
    
    [SerializeField] private GameObject thunder;

    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject losePanel;
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

    
    
    public void PlayerWin()
    {
        scoreCanvas.gameObject.SetActive(true);   
    }

    public void OpponentWin()
    {
        scoreCanvas.gameObject.SetActive(true);   
    }

    public void Thunder()
    {
        AnimationsManager.Instance.ThunderAnim(thunder);
    }
   

    public void OpponentWinMatch()
    {
        /*loseText.SetActive(true);
        loseButton.SetActive(true);*/
        losePanel.SetActive(true);
    }

    public void PlayerWinMatch()
    {
        /*winButton.SetActive(true);
        winText.SetActive(true);
        winText2.SetActive(true);
        cup.SetActive(true);*/
        winPanel.SetActive(true);
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
