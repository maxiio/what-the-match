using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class AnimationsManager : MonoBehaviour
{
    
    public static AnimationsManager Instance;

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject currentLevelText;

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
        EventManager.Instance.OnGameStarted += GameStartText;
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
            obj.transform.DOMoveY(3f, 1f).SetLoops(10,LoopType.Yoyo);
        }
    
    }

    public void GameStartText()
    {
        currentLevelText.transform.DOScale(1f,1f).SetEase(Ease.OutBounce).OnComplete((() => currentLevelText.transform.DOScale(0f,.5f)));
    }
}
