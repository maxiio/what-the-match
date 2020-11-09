using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Touch touch;
    private Vector2 startPosition;
    private Vector2 destination;
    private bool IsTouchEnded = true;
    private bool TouchedFirstTime = false;
    
    private void Update()
    {
        if (Input.touchCount != 1) return;

        touch = Input.GetTouch(0);

        if (touch.phase == TouchPhase.Began)
        {
            startPosition = touch.position;
            TouchedFirstTime = true;
        }

        if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
        {
            destination = touch.position - startPosition;
            IsTouchEnded = false;
        }

        if (touch.phase == TouchPhase.Ended)
        {
            startPosition.Set(0, 0);
            destination.Set(0, 0);
            IsTouchEnded = true;
        }
    }

    private void FixedUpdate()
    {
        if (IsTouchEnded == false)
        {
            EventManager.Instance.PlayerMoved(destination);
        }
        else
        {
            EventManager.Instance.PlayerStopped();
            IsTouchEnded = false;
        }

        if (TouchedFirstTime == true)
        {
            CameraManager.Instance.dynamicCam = true;
            //Debug.Log("i touched");
            TouchedFirstTime = false;
        }
    }

    
}
