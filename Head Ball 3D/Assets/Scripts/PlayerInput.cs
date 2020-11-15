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
    private bool inLine = false;
    private bool swipe = false;

    private void Start()
    {
        EventManager.Instance.OnNextRound += NextRound;
    }

    private void Update()
    {
        if (Input.touchCount != 1) return;

        touch = Input.GetTouch(0);

        if (touch.phase == TouchPhase.Began)
        {
            startPosition = touch.position;

            TouchedFirstTime = true;

            if (touch.position.x < Screen.width / 4 || touch.position.x > Screen.width - (Screen.width / 4))
            {
                inLine = false;
            }

            inLine = true;
        }

        if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
        {
            if (inLine)
            {
                if (touch.position.x < Screen.width / 4 || touch.position.x > Screen.width - (Screen.width / 4))
                {
                    destination = touch.position - startPosition;

                    swipe = true;
                } else
                {
                    destination = touch.position - new Vector2(Screen.width / 2, Screen.height / 4);
                    destination *= 2;
                }
            }
            else
            {
                destination = touch.position - startPosition;
            }

            IsTouchEnded = false;
        }
     

        if (touch.phase == TouchPhase.Ended)
        {
            startPosition.Set(0, 0);
            destination.Set(0, 0);
            IsTouchEnded = true;
            swipe = false;
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
            TouchedFirstTime = false;
        }
    }

    public void NextRound()
    {
        startPosition.Set(0, 0);
        destination.Set(0, 0);
    }

    
}
