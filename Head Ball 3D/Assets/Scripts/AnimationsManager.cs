using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEditor;
using UnityEngine;

public class AnimationsManager : MonoBehaviour
{
    
    public static AnimationsManager Instance;

    
    [SerializeField] private GameObject player;
   

    private void Awake()
    {
        DOTween.Init();
        SingletonPattern();
    }

    // Start is called before the first frame update
    void Start()
    {
        EventManager.Instance.OnPlayerMoved += PlayerMoving;
        EventManager.Instance.OnPlayerStopped += PlayerStopped;
        EventManager.Instance.OnObjectCreated += NewObjectCreated;
        EventManager.Instance.OnPlayerWin += PlayerWin;
        EventManager.Instance.OnOpponentWin += PlayerLose;
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
    
    public void PlayerMoving(Vector2 destination)
    {
        player.GetComponent<Animator>().SetFloat("VelX",destination.x);
        player.GetComponent<Animator>().SetFloat("VelY",destination.y);
        
    }

    public void PlayerStopped()
    {
        player.GetComponent<Animator>().SetFloat("VelX",0);
        player.GetComponent<Animator>().SetFloat("VelY",0);
    }

    public void NewObjectCreated(GameObject obj)
    {
        Sequence objSeq = DOTween.Sequence();
        //Debug.Log("obje var mi yok mu" + obj );
        if (obj != null)
        {
            objSeq.Append(obj.transform.DOPunchScale(new Vector3(.5f, .5f, .5f), .5f));
            //obj.transform.DOMoveY(3f, 1f).SetLoops(10,LoopType.Yoyo);
        }
    
    }

    public void ThunderAnim(GameObject obj)
    {
        obj.SetActive(true);
        obj.transform.DOScale(0, 0);
        obj.transform.DOScale(.3f,.8f).SetEase(Ease.OutBounce).OnComplete((() => obj.SetActive(false)));
        
    }
    public void PlayerWin()
    {
        player.GetComponent<Animator>().SetBool("PlayerWin",true);
    }
    
    public void PlayerLose()
    {
        player.GetComponent<Animator>().SetBool("PlayerLose",true);
    }

   

    public void NextRound()
    {
        player.GetComponent<Animator>().SetBool("PlayerWin",false);
        player.GetComponent<Animator>().SetBool("PlayerLose",false);
        player.GetComponent<Animator>().SetFloat("VelX",0);
        player.GetComponent<Animator>().SetFloat("VelY",0);
    }
}
