using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentAnimationsManager : MonoBehaviour
{

    public static OpponentAnimationsManager Instance;

    [SerializeField] private GameObject Opponent;

    private void Awake()
    {
        SingletonPattern();
    }

    // Start is called before the first frame update
    void Start()
    {
        EventManager.Instance.OnOpponentMoved += OpponentMoving;
        EventManager.Instance.OnOpponentStopped += OpponentStopped;
        EventManager.Instance.OnOpponentWin += OpponentWin;
        EventManager.Instance.OnPlayerWin += OpponentLose;
        EventManager.Instance.OnNextRound += NextRound;
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

    public void OpponentMoving(Vector2 destination)
    {
        Opponent.GetComponent<Animator>().SetFloat("VelX", -destination.x);
        Opponent.GetComponent<Animator>().SetFloat("VelY", destination.y);
    }

    public void OpponentStopped()
    {
        Opponent.GetComponent<Animator>().SetFloat("VelX", 0);
        Opponent.GetComponent<Animator>().SetFloat("VelY", 0);
    }

    public void OpponentWin()
    {
        Opponent.GetComponent<Animator>().SetBool("OpponentWin",true);
    }
    
    public void OpponentLose()
    {
        Opponent.GetComponent<Animator>().SetBool("OpponentLose",true);
    }
    
    public void NextRound()
    {
        Opponent.GetComponent<Animator>().SetBool("OpponentWin",false);
        Opponent.GetComponent<Animator>().SetBool("OpponentLose",false);
    }

    public void Fall()
    {
        Opponent.GetComponent<Animator>().SetBool("Fall",true);
        StartCoroutine(DeactiveFall());
    }

    public IEnumerator DeactiveFall()
    {
        yield return  new WaitForSeconds(1.5f);
        
        Opponent.GetComponent<Animator>().SetBool("Fall",false);
    }
}
