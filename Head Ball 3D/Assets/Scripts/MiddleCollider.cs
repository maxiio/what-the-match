﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleCollider : MonoBehaviour
{
    [SerializeField] private GameObject forcePlace;
    // Start is called before the first frame update
 
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer.Equals(9))
        {
           forcePlace.GetComponent<Rigidbody>().MovePosition(forcePlace.transform.position - new Vector3(0,0,.2f));
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer.Equals(9))
        {
            forcePlace.GetComponent<Rigidbody>().MovePosition(forcePlace.transform.position - new Vector3(0,0,.2f));
        }
    }
}
