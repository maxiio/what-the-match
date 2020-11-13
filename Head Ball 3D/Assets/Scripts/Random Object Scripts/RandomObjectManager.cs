using System;
using System.Collections;
using System.Collections.Generic;
using RootMotion.Dynamics;
using Unity.Mathematics;
using UnityEngine;


public class RandomObjectManager : MonoBehaviour
{
    [SerializeField] private GameObject baseball;
    [SerializeField] private GameObject tennisRacket;
    
    // Start is called before the first frame update
    void Start()
    {
        EventManager.Instance.OnTakingObject += ObjectTaked;
    }
    
    private void ObjectTaked(GameObject obj)
    {
        //Debug.Log(obj);
        Debug.Log(States.Instance.playerState);
        if (States.Instance.playerState == States.PlayerState.Free)
        {
            if (obj.tag.Equals("Baseball"))
            {
                baseball.SetActive(true);
                States.Instance.ObjectTaked(obj);
                Destroy(obj);
            }
            else if (obj.tag.Equals("TennisRacket"))
            {
                tennisRacket.SetActive(true);
                States.Instance.ObjectTaked(obj);
                Destroy(obj);
            }
            
        }
       
    }
    
}

