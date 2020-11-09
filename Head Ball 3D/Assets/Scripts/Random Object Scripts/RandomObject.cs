using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EventManager.Instance.ObjectCreated(gameObject);
    }
    
}
