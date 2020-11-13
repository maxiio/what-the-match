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
        if (other.gameObject.tag.Equals("LeftSidePlayer"))
        {
            Debug.Log("from left side");
            EventManager.Instance.TookObject(gameObject,0);
        }
        else if (other.gameObject.tag.Equals("RightSidePlayer"))
        {
            Debug.Log("from right side");
            EventManager.Instance.TookObject(gameObject,1);
        }
        /*if (other.gameObject.layer.Equals(9))
        {
            //Debug.Log("i am here");
            
            
        }*/
        
    }
    
}
