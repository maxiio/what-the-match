using System;
using System.Collections;
using System.Collections.Generic;
using Scenes.Levels.example.input.AxisManipulation;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private PlayerController playerController;
    [SerializeField] private PlayerMovement playerMovement;
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
        playerMovement.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
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
        playerController.enabled = false;
        playerMovement.enabled = false;
        //ballController.enabled = false;
        opponentAI.enabled = false;
    }

    private void ActivateScripts()
    {
        playerController.enabled = true;
        playerMovement.enabled = true;
        //ballController.enabled = true;
        opponentAI.enabled = true;
        
    }
    


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
