using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{

    [SerializeField] private GameObject hitTheBall;
    [SerializeField] private GameObject hitTheBall2;

    [SerializeField] private GameObject hitTheBallTennisL;    
    [SerializeField] private GameObject hitTheBallTennisR;
    
    [SerializeField] private GameObject DestroyBaseballEffectL;    
    [SerializeField] private GameObject DestroyBaseballEffectR;    
    
    [SerializeField] private GameObject hitTheBallOp;
    [SerializeField] private GameObject hitTheBallOp2;
    

    
    public static ParticleManager Instance;
    
    // Start is called before the first frame update
    void Start()
    {
        SingletonPattern();
        EventManager.Instance.OnPlayerCollideWithBall += ShootEffect;
        EventManager.Instance.OnOpponentCollideWithBall += ShootEffectOpponent;
        EventManager.Instance.OnBaseballRCollideWithBall += BaseballREffect;
        EventManager.Instance.OnBaseballLCollideWithBall += BaseballLEffect;
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
        hitTheBallTennisR.GetComponent<ParticleSystem>().Play();
    }
    
    public void BaseballLEffect()
    {
        hitTheBallTennisL.GetComponent<ParticleSystem>().Play();
    }

    public void DestroyBaseballL()
    {
        DestroyBaseballEffectL.GetComponent<ParticleSystem>().Play();
    }
    
    public void DestroyBaseballR()
    {
        DestroyBaseballEffectR.GetComponent<ParticleSystem>().Play();
    }
    
    
   
    
}
