using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public int playerCounter = 0;
    public int opponentCounter = 0;
    
    
    [SerializeField] private GameObject P1;
    [SerializeField] private GameObject P2;
    [SerializeField] private GameObject P3;
    
    [SerializeField] private GameObject O1;
    [SerializeField] private GameObject O2;
    [SerializeField] private GameObject O3;
    // Start is called before the first frame update
    void Start()
    {
        SingletonPattern();
        EventManager.Instance.OnPlayerWin += AddPlayerScore;
        EventManager.Instance.OnOpponentWin += AddOpponentScore;
    }

    // Update is called once per frame
    void Update()
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

    public void AddPlayerScore()
    {
        playerCounter++;

        if (playerCounter == 1)
        {
            P1.SetActive(true);
        }
        
        if (playerCounter == 2)
        {
            P2.SetActive(true);
        }
        
        if (playerCounter == 3)
        {
            P3.SetActive(true);
            EventManager.Instance.PlayerWinMatch();
        }
    }

    public void AddOpponentScore()
    {
        opponentCounter++;

        if (opponentCounter == 1)
        {
            O1.SetActive(true);
        }
        
        if (opponentCounter == 2)
        {
            O2.SetActive(true);
        }

        if (opponentCounter == 3)
        {
            O3.SetActive(true);
            EventManager.Instance.OpponentWinMatch();
        }
    }
}
