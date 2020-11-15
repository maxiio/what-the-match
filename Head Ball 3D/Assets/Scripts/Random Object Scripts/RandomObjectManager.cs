using System;
using System.Collections;
using System.Collections.Generic;
using RootMotion.Dynamics;
using Unity.Mathematics;
using UnityEngine;


public class RandomObjectManager : MonoBehaviour
{
    [SerializeField] private GameObject baseballR;
    [SerializeField] private GameObject tennisRacketR;
    
    [SerializeField] private GameObject baseballL;
    [SerializeField] private GameObject tennisRacketL;

    [SerializeField] private GameObject handBaseballR;

    [SerializeField] private GameObject rightHand;
    [SerializeField] private GameObject leftHand;
    
    // Start is called before the first frame update
    void Start()
    {
        EventManager.Instance.OnTakingObject += ObjectTaked;
        EventManager.Instance.OnPlayerWin += NextRound;
        EventManager.Instance.OnOpponentWin += NextRound;
    }
    
    private void ObjectTaked(GameObject obj,int whichhand)
    {
        //Debug.Log(obj);
        
        if (States.Instance.playerState == States.PlayerState.Free)
        {
            if (whichhand == 0)
            {
                if (obj.tag.Equals("Baseball"))
                {
                    baseballL.SetActive(true);
                    //Instantiate(handBaseballR, rightHand,quaternion.identity);
                    //baseballL.GetComponent<ConfigurableJoint>() = baseballLConfg;
                    States.Instance.ObjectTaked(obj);
                    obj.gameObject.SetActive(false);
                }
                else if (obj.tag.Equals("TennisRacket"))
                {
                    tennisRacketL.SetActive(true);
                    States.Instance.ObjectTaked(obj);
                    obj.gameObject.SetActive(false);
                }
            }
            else if (whichhand == 1)
            {
                if (obj.tag.Equals("Baseball"))
                {
                    baseballR.SetActive(true);
                    States.Instance.ObjectTaked(obj);
                    obj.gameObject.SetActive(false);
                }
                else if (obj.tag.Equals("TennisRacket"))
                {
                    tennisRacketR.SetActive(true);
                    States.Instance.ObjectTaked(obj);
                    obj.gameObject.SetActive(false);
                }
            }
            
            
        }
       
    }

    public void NextRound()
    {
        if (baseballL.activeSelf)
        {
            ParticleManager.Instance.DestroyBaseballL();
        }
        
        if (baseballR.activeSelf)
        {
            ParticleManager.Instance.DestroyBaseballR();
        }
        baseballL.SetActive(false);
        baseballR.SetActive(false);
        tennisRacketL.SetActive(false);
        tennisRacketR.SetActive(false);
        States.Instance.playerState = States.PlayerState.Free;
    }
    
}

