using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{

    [SerializeField] private GameObject hitTheBall;
    
    public static ParticleManager Instance;
    // Start is called before the first frame update
    void Start()
    {
        SingletonPattern();
        EventManager.Instance.OnPlayerCollideWithBall += ShootEffect;
    }

    // Update is called once per frame
    void Update()
    {
        
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
    }
}
