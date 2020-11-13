﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance;
    
    private void Awake()
    {
        SingletonPattern();
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
    
    // Actions
    public event Action OnGameStarted;
    public event Action OnGameFinished;

    public event Action<Vector2> OnPlayerMoved;
    public event Action OnPlayerStopped;

    public event Action<Vector2> OnOpponentMoved;
    public event Action OnOpponentStopped;
    
    public event Action OnPlayerShoot;
    public event Action OnPlayerCollideWithBall;
    public event Action OnOpponentCollideWithBall;
    public event Action OnBaseballCollideWithBall;

    public event Action<GameObject> OnObjectCreated;
    public event Action<GameObject,int> OnTakingObject;

    public event Action OnPlayerWin;
    public event Action OnOpponentWin;


    // Functions
    public void StartGame()
    {
        OnGameStarted?.Invoke();
    }

    public void FinishGame()
    {
        OnGameFinished?.Invoke();
    }

    public void PlayerShoot()
    {
        OnPlayerShoot?.Invoke();
    }
    
    public void PlayerCollideWithBall()
    {
        OnPlayerCollideWithBall?.Invoke();
    }
    
    public void OpponentCollideWithBall()
    {
        OnOpponentCollideWithBall?.Invoke();
    }

    public void BaseballCollideWithBall()
    {
        OnBaseballCollideWithBall?.Invoke();
    }

    public void PlayerMoved(Vector2 destination)
    {
        OnPlayerMoved?.Invoke(destination);
    }

    public void PlayerStopped()
    {
        OnPlayerStopped?.Invoke();
    }

    public void OpponentMoved(Vector2 destination)
    {
        OnOpponentMoved?.Invoke(destination);
    }

    public void OpponentStopped()
    {
        OnOpponentStopped?.Invoke();
    }

    public void PlayerWin()
    {
        OnPlayerWin?.Invoke();
    }

    public void OpponentWin()
    {
        OnOpponentWin?.Invoke();
    }

    public void ObjectCreated(GameObject obj)
    {
        OnObjectCreated?.Invoke(obj);
    }

    public void TookObject(GameObject obj,int hand)
    {
        OnTakingObject?.Invoke(obj,hand);
    }
    
    
    
}
