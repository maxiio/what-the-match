using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private BallController ballController;
    [SerializeField] private OpponentAI opponentAI;
    [SerializeField] private RandomObjectGenerator randomObjectGenerator;

    private void Awake()
    {
        SingletonPattern();
        DeactiveScripts();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        EventManager.Instance.OnGameStarted += GameStarted;
        EventManager.Instance.OnPlayerWin += PlayerWin;
        EventManager.Instance.OnOpponentWin += OpponentWin;
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

    private void GameStarted()
    {
        ActivateScripts();
    }

    private void DeactiveScripts()
    {
        playerInput.enabled = false;
        playerMovement.enabled = false;
        ballController.enabled = false;
        opponentAI.enabled = false;
        randomObjectGenerator.enabled = false;
    }

    private void ActivateScripts()
    {
        playerInput.enabled = true;
        playerMovement.enabled = true;
        ballController.enabled = true;
        opponentAI.enabled = true;
        randomObjectGenerator.enabled = true;
    }
    
    private void OnApplicationQuit()
    {
        SaveGame();
    }

    private void OnApplicationPause(bool pauseStatus)
    {
        SaveGame();
    }
    
    private void SaveGame()
    {
        SavedDatas savedDatas = new SavedDatas();
        savedDatas.SaveLevel(LevelManager.Instance.GetCurrentLevel());
        PlayerPrefs.Save();
    }

    public void PlayerWin()
    {
        DeactiveScripts();
    }

    public void OpponentWin()
    {
        DeactiveScripts();
    }
}
