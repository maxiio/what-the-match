using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elimination : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer.Equals(9) || other.gameObject.layer.Equals(10))
        EventManager.Instance.OpponentWinMatch();
    }


}
