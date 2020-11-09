using System;
using System.Collections;
using System.Collections.Generic;
using RootMotion.Dynamics;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomObjectManager : MonoBehaviour
{
    [SerializeField] private PropMuscle rightHandProp;
    [SerializeField] private PropMuscle leftHandProp;
    
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
            rightHandProp.currentProp = obj.GetComponent<PuppetMasterProp>();
            States.Instance.ObjectTaked(obj);
        }
       
    }
    
}

