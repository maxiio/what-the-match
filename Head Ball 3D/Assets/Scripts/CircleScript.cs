using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleScript : MonoBehaviour
{
    public float rotateSpeed;

    private void Start()
    {
        EventManager.Instance.OnPlayerShoot += ResetRotation;
    }

    void Update()
    {
        gameObject.transform.Rotate(0, (rotateSpeed * Time.deltaTime), 0, Space.Self);
    }

    private void ResetRotation()
    {
        gameObject.transform.Rotate(0, 0, 0, Space.Self);
    }
}