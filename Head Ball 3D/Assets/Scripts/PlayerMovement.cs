using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public static PlayerMovement Instance;

    private Rigidbody rigidbody;
    private Vector2 units;
    
    void Start()
    {
        SingletonPattern();
        rigidbody = gameObject.GetComponent<Rigidbody>();
        
        EventManager.Instance.OnPlayerMoved += MovePlayer;
        EventManager.Instance.OnNextRound += NextRound;
    }
    
    #region Singleton

    private void SingletonPattern()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
    

    #endregion

    public void Activatergb()
    {
        rigidbody.constraints = RigidbodyConstraints.None;
    }


     // sağ üst x 15.58 z 38.79
     // sol alt x -15.43 z 0.29
     // distance 49
     private void MovePlayer(Vector2 destination)
    {
        //units = CalculateUnits(destination);

            
            

            if (gameObject.transform.localPosition.x <= -14.8f)
            {
                gameObject.GetComponent<Rigidbody>().MovePosition(transform.position + new Vector3(.2f,0,0));
            }
            else if(gameObject.transform.localPosition.x >= 14.4f)
            {
                gameObject.GetComponent<Rigidbody>().MovePosition(transform.position - new Vector3(.2f,0,0));
            }
            else if (gameObject.transform.localPosition.z <= -14)
            {
                gameObject.GetComponent<Rigidbody>().MovePosition(transform.position + new Vector3(0,0,.2f));
            }
            else if (gameObject.transform.localPosition.z >= 20)
            {
                gameObject.GetComponent<Rigidbody>().MovePosition(transform.position - new Vector3(0,0,.2f));
            }
            else
            {
                rigidbody.MovePosition(new Vector3(
                    transform.position.x + (destination.x * speed * Time.fixedDeltaTime),
                    transform.position.y,
                    transform.position.z + (destination.y * speed * Time.fixedDeltaTime)
                )); 
            }
            
           


    }

    /*private Vector2 CalculateUnits(Vector2 destination)
    {
        destination.x = Mathf.Lerp(-1, 1,destination.x);
        destination.y = Mathf.Lerp(-1, 1, destination.y);
        //float horizontal = Mathf.Lerp(-1, 1, , destination.x));
        //float vertical = Mathf.Lerp(-1, 1, Mathf.InverseLerp(-Screen.height / 4, Screen.height / 4, destination.y));

        return new Vector2(destination.x, destination.y);
    }*/
    
    public void NextRound()
    {
       units = Vector2.zero;
    }
    
}
