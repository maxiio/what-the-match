using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class States : MonoBehaviour
{
    
    public static States Instance;
    
    public enum GameState
    {
        NotStarted,
        Running,
        Finished
    }

    public enum PlayerState
    {
        Free,
        Baseball,
        TennisRacket
    }

    public GameState gameState;
    public PlayerState playerState;

    private void Start()
    {
        SingletonPattern();
        gameState = GameState.NotStarted;
        playerState = PlayerState.Free;
        EventManager.Instance.OnGameStarted += GameStarted;
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

    private void Update()
    {
        //Debug.Log(playerState);
    }

    private void GameStarted()
    {
        gameState = GameState.Running;
    }

    public void ObjectTaked(GameObject obj)
    {
        if (obj.tag.Equals("Baseball"))
        {
            playerState = PlayerState.Baseball;
        }
        else if (obj.tag.Equals("TennisRacket"))
        {
            playerState = PlayerState.TennisRacket;
        }
    }
    
}
