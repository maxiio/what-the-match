using System;
using System.Collections;
using System.Collections.Generic;
using Scenes.Levels.example.input.AxisManipulation;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private OneAxisManipulator playerMain;
    [SerializeField] private OneAxisManipulator playerMain2;
    [SerializeField] private OneAxisManipulator playerPup;
    [SerializeField] private OneAxisManipulator playerPup2;
    [SerializeField] private BallController ballController;
    [SerializeField] private OpponentAI opponentAI;
    [SerializeField] private GameObject randomObjectManager;

    private void Awake()
    {
        SingletonPattern();
        DeactiveScripts();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        EventManager.Instance.OnGameStarted += GameStarted;
        EventManager.Instance.OnPlayerWin += SomeoneWinRound;
        EventManager.Instance.OnOpponentWin += SomeoneWinRound;
        EventManager.Instance.OnNextRound += NextRoundPass;
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
        playerMain.enabled = false;
        playerMain2.enabled = false;
        playerPup.enabled = false;
        playerPup2.enabled = false;
        ballController.enabled = false;
        opponentAI.enabled = false;
       
        
    }

    private void ActivateScripts()
    {
        playerMain.enabled = true;
        playerMain2.enabled = true;
        playerPup.enabled = true;
        playerPup2.enabled = true;
        ballController.enabled = true;
        opponentAI.enabled = true;
        
    }
    
    /*private void OnApplicationQuit()
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
    }*/

    public void SomeoneWinRound()
    {
        DeactiveScripts();
        StartCoroutine(NextRound());
    }


    public IEnumerator NextRound()
    {
        yield return new WaitForSeconds(2f);

        if (ScoreManager.Instance.playerCounter == 3 || ScoreManager.Instance.opponentCounter == 3)
        {
            
        }
        else
        {
            EventManager.Instance.NextRound();
        }

       
    }

    public void NextRoundPass()
    {
        ActivateScripts();
    }

    
}
