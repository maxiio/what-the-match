using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

public class ParticleManager : MonoBehaviour
{

    [SerializeField] private GameObject hitTheBall;
    [SerializeField] private GameObject hitTheBall2;

    [FormerlySerializedAs("hitTheBallTennisL")] [SerializeField] private GameObject hitTheBallBaseballL;    
    [FormerlySerializedAs("hitTheBallTennisR")] [SerializeField] private GameObject hitTheBallBaseballR;

    [SerializeField] private GameObject TennisL;
    [SerializeField] private GameObject TennisR;
    
    [SerializeField] private GameObject DestroyBaseballEffectL;    
    [SerializeField] private GameObject DestroyBaseballEffectR;    
    
    [SerializeField] private GameObject hitTheBallOp;
    [SerializeField] private GameObject hitTheBallOp2;

    [SerializeField] private GameObject fastHitBall;

    [SerializeField] private GameObject confetti;
    

    
    public static ParticleManager Instance;
    
    // Start is called before the first frame update
    void Start()
    {
        SingletonPattern();
        EventManager.Instance.OnPlayerCollideWithBall += ShootEffect;
        EventManager.Instance.OnOpponentCollideWithBall += ShootEffectOpponent;
        EventManager.Instance.OnBaseballRCollideWithBall += BaseballREffect;
        EventManager.Instance.OnBaseballLCollideWithBall += BaseballLEffect;
        EventManager.Instance.OnTennisLCollideWithBall += TennisLEffect;
        EventManager.Instance.OnTennisRCollideWithBall += TennisREffect;
        EventManager.Instance.OnPlayerWinMatch += PlayerWin;
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
        hitTheBall.GetComponent<ParticleSystem>().Play();
        hitTheBall2.GetComponent<ParticleSystem>().Play();
        //hitTheBallTennis.GetComponent<ParticleSystem>().Play();
    }
    
    public void ShootEffectOpponent()
    {
        hitTheBallOp.GetComponent<ParticleSystem>().Play();
        hitTheBallOp2.GetComponent<ParticleSystem>().Play();
    }

    public void BaseballREffect()
    {
        hitTheBallBaseballR.GetComponent<ParticleSystem>().Play();
    }
    
    public void BaseballLEffect()
    {
        hitTheBallBaseballL.GetComponent<ParticleSystem>().Play();
    }
    
    

    public void DestroyBaseballL()
    {
        DestroyBaseballEffectL.GetComponent<ParticleSystem>().Play();
    }
    
    public void DestroyBaseballR()
    {
        DestroyBaseballEffectR.GetComponent<ParticleSystem>().Play();
    }

    public void DestroyTennisL()
    {
        DestroyBaseballEffectL.GetComponent<ParticleSystem>().Play();
    }
    
    public void DestroyTennisR()
    {
        DestroyBaseballEffectR.GetComponent<ParticleSystem>().Play();
    }


  

    public void TennisLEffect()
    {
        TennisL.GetComponent<ParticleSystem>().Play();
    }
    
    public void TennisREffect()
    {
        TennisR.GetComponent<ParticleSystem>().Play();
    }

    public void PlayerWin()
    {
        confetti.GetComponent<ParticleSystem>().Play();
    }
    
    
   
    
}
