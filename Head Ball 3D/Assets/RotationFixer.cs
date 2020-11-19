using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationFixer : MonoBehaviour
{
    public Quaternion rotation;
    void Awake()
    {
        rotation = transform.localRotation;
    }
    void LateUpdate()
    {
        transform.localRotation = rotation;
    }
}
