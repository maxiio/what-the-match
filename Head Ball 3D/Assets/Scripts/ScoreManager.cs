using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    private int playerCounter = 0;
    private int opponentCounter = 0;

    [SerializeField] private GameObject yourScore;
    [SerializeField] private GameObject oppScore;
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
        yourScore.GetComponent<Text>().text = "YOU : " + playerCounter.ToString();
        oppScore.GetComponent<Text>().text = "OPPONENT : " + opponentCounter.ToString();

        if (playerCounter == 3)
        {
            //EventManager.Instance.PlayerWinMatch;
        }
    }

    public void AddOpponentScore()
    {
        opponentCounter++;
        
        yourScore.GetComponent<Text>().text = "YOU : " + playerCounter.ToString();
        oppScore.GetComponent<Text>().text = "OPPONENT : " + opponentCounter.ToString();

        if (opponentCounter == 3)
        {
            //EventManager.Instance.OpponentWinMatch;
        }
    }
}
