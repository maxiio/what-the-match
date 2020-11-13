using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baseball : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Ball"))
        {
            States.Instance.playerState = States.PlayerState.Free;
            gameObject.SetActive(false);
        }
    }
}
