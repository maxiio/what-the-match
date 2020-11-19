using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
   
    private bool TouchedFirstTime = false;
    public float speed;
    public static PlayerMovement Instance;

    private Rigidbody rigidbody;
    
    private Vector2 newV;
    public FloatingJoystick joystick;
    
    void Start()
    {
        SingletonPattern();
        rigidbody = gameObject.GetComponent<Rigidbody>();
        
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

    /*public void Activatergb()
    {
        rigidbody.constraints = RigidbodyConstraints.None;
    }*/

    private void FixedUpdate()
    {
        
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
                transform.position.x + (joystick.Horizontal * speed * Time.fixedDeltaTime),
                transform.position.y,
                transform.position.z + (joystick.Vertical * speed * Time.fixedDeltaTime)
            ));
            newV.x = joystick.Horizontal;
            newV.y = joystick.Vertical;
            EventManager.Instance.PlayerMoved(newV);
            if (TouchedFirstTime == false)
            {
                CameraManager.Instance.dynamicCam = true;
                TouchedFirstTime = true;
            }
            
        }
    }
    
}
