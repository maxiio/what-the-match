using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;

public class RandomObjectTriggerCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer.Equals(9))
        {
            EventManager.Instance.TookObject(gameObject.transform.parent.gameObject);
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
    
}
