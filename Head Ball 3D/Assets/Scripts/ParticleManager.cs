﻿using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{

    [SerializeField] private GameObject hitTheBall;
    [SerializeField] private GameObject hitTheBall2;

    [SerializeField] private GameObject hitTheBallTennis;    
    
    [SerializeField] private GameObject hitTheBallOp;
    [SerializeField] private GameObject hitTheBallOp2;
    

    
    public static ParticleManager Instance;
    
    // Start is called before the first frame update
    void Start()
    {
        SingletonPattern();
        EventManager.Instance.OnPlayerCollideWithBall += ShootEffect;
        EventManager.Instance.OnOpponentCollideWithBall += ShootEffectOpponent;
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

    public void ShootEffect()
    {
        if (States.Instance.playerState == States.PlayerState.Free)
        {
            hitTheBall.GetComponent<ParticleSystem>().Play();
            hitTheBall2.GetComponent<ParticleSystem>().Play();
        }
        else if (States.Instance.playerState == States.PlayerState.Baseball)
        {
            hitTheBallTennis.GetComponent<ParticleSystem>().Play();
        }
       
    }
    
    public void ShootEffectOpponent()
    {
        hitTheBallOp.GetComponent<ParticleSystem>().Play();
        hitTheBallOp2.GetComponent<ParticleSystem>().Play();
    }
    
}
