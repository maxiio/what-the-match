using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    
    
    [SerializeField] private Material ballFastEffect;
    [SerializeField] private Material ballNormalEffect;
    [SerializeField] private GameObject ball;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Ball"))
        {
            if (States.Instance.playerState == States.PlayerState.Baseball)
            {
                ball.gameObject.GetComponent<TrailRenderer>().material = ballFastEffect;
            }

            else if (States.Instance.playerState == States.PlayerState.Free)
            {
               ball.gameObject.GetComponent<TrailRenderer>().material = ballNormalEffect;
            }
        }
    }
}
