using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentAnimationsManager : MonoBehaviour
{

    public static OpponentAnimationsManager Instance;

    [SerializeField] private GameObject player;

    private void Awake()
    {
        SingletonPattern();
    }

    // Start is called before the first frame update
    void Start()
    {
        EventManager.Instance.OnOpponentMoved += OpponentMoving;
        EventManager.Instance.OnOpponentStopped += OpponentStopped;
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
        player.GetComponent<Animator>().SetFloat("VelX", -destination.x);
        player.GetComponent<Animator>().SetFloat("VelY", -destination.y);
    }

    public void OpponentStopped()
    {
        player.GetComponent<Animator>().SetFloat("VelX", 0);
        player.GetComponent<Animator>().SetFloat("VelY", 0);
    }
}
