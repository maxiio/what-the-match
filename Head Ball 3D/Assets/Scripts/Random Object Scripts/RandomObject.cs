using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObject : MonoBehaviour
{
    private Vector3 rotateVector;
    // Start is called before the first frame update
    void Start()
    {
        EventManager.Instance.ObjectCreated(gameObject);
        
        if (gameObject.tag.Equals("TennisRacket"))
        {
            rotateVector = new Vector3(90,Random.Range(0,360),90);
        }
        else if(gameObject.tag.Equals("Baseball"))
        {
            rotateVector = new Vector3(0,Random.Range(0,360),90);
        }
        
        gameObject.transform.Rotate(rotateVector);
    }
    
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer.Equals(9))
        {
            //Debug.Log("i am here");
            
            EventManager.Instance.TookObject(gameObject);

        }
    }
    
}
