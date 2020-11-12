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
    
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer.Equals(9))
        {
            //Debug.Log("i am here");
            EventManager.Instance.TookObject(gameObject);
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
    
}
