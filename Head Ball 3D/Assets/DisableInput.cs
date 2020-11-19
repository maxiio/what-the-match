using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableInput : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private PlayerController playerController;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer.Equals(9) || other.gameObject.layer.Equals(10))
        {
            playerMovement.enabled = false;
            playerController.enabled = false;
        }
    }
    
    
}
