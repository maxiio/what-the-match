using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private BallController ballController;
    [SerializeField] private OpponentAI opponentAI;
    [SerializeField] private RandomObjectManager randomObjectManager;
    
    private PointerEventData x = null;
    private void Awake()
    {
        SingletonPattern();
        DeactiveScripts();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
        /*fixedJoystick.OnPointerDown(x);
        fixedJoystick.OnPointerUp(x);*/
        //playerMovement.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        EventManager.Instance.OnGameStarted += GameStarted;
        EventManager.Instance.OnPlayerWin += SomeoneWinRound;
        EventManager.Instance.OnOpponentWin += SomeoneWinRound;
        EventManager.Instance.OnNextRound += NextRoundPass;
        EventManager.Instance.OnPlayerWinMatch += MatchEnded;
        EventManager.Instance.OnOpponentWinMatch += MatchEnded;
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
        //play tuşuna basıldı
        ActivateScripts();
    }

    private void DeactiveScripts()
    {
        playerMovement.enabled = false;
        ballController.enabled = false;
        opponentAI.enabled = false;
        randomObjectManager.enabled = false;
    }

    private void ActivateScripts()
    {
        playerMovement.enabled = true;
        ballController.enabled = true;
        opponentAI.enabled = true;
        randomObjectManager.enabled = true;
    }

    public void MatchEnded()
    {
        //oyunu birisi kazandı.
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
