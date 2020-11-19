using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private bool IsTouchEnded = true;
    private bool TouchedFirstTime = false;
    //private Vector2 tempVector;
    private Vector2 destination;
    private Vector2 offset;
    private List<Vector2> tempVector;
    private List<Vector2> tempList = new List<Vector2>();

    [SerializeField] private GameObject joystickInnerCircle;
    [SerializeField] private GameObject joystickOuterCircle;
    
    protected class TrackedTouch
    {
        public Vector2 startPos;
        public Vector2 currentPos;
    }

    private TrackedTouch newTouch;
    
    private void Start()
    {
        newTouch = new TrackedTouch();
    }

    private void Update()
    {
        _UpdateTouches();
    }

    private void FixedUpdate()
    {
        if (TouchedFirstTime == true)
        {
            PlayerMovement.Instance.Activatergb();
            CameraManager.Instance.dynamicCam = true;
            TouchedFirstTime = false;
        }
    }

    public void _UpdateTouches()
    {
        int multiplier = 100;
        int numTouches = Input.touchCount;
        for(int touchIndex = 0; touchIndex < numTouches; ++touchIndex)
        {
            Touch touch = Input.touches[touchIndex];
            if(touch.phase == TouchPhase.Began)
            {
                TouchedFirstTime = true;
                //Debug.Log("Touch " + touch.fingerId + "Started at : " + touch.position);

                newTouch.startPos = Camera.main.ScreenToWorldPoint(touch.position);
                newTouch.currentPos = Camera.main.ScreenToWorldPoint(touch.position);
                
                //joystickInnerCircle.SetActive(true);
                //joystickOuterCircle.SetActive(true);
                /*Debug.Log(newTouch.startPos);
                Debug.Log(newTouch.currentPos);*/
                //_touches.Add(touch.fingerId, newTouch);
            }
            else if(touch.phase == TouchPhase.Canceled || touch.phase == TouchPhase.Ended)
            {
                //Debug.Log("Touch " + touch.fingerId + "Ended at : " + touch.position);
                //_touches.Remove(touch.fingerId);
                EventManager.Instance.PlayerStopped();
                //joystickOuterCircle.SetActive(false);
                //joystickInnerCircle.SetActive(false);
            }
            else
            {
                
                //Debug.Log("i am moving" + Time.deltaTime);
                
                //newTouch.currentPos = Camera.main.scre
                offset = newTouch.currentPos - newTouch.startPos;
                destination = Vector2.ClampMagnitude(offset,1.0f);
               
                Debug.Log(destination);

                /*if (tempList.Count < 3)
                {
                    tempList.Add(newTouch.currentPos);
                    //Debug.Log("3 ten kücügüm bebem" + Time.deltaTime);
                }
                else if(tempList.Count == 3)
                {
                    //Debug.Log("akosadsko");
                    //Control on X-Direction

                    if (tempList[0].x < tempList[1].x && tempList[1].x < tempList[2].x)
                    {
                        Debug.Log("i am going right");
                        tempList.RemoveAt(0);
                    }
                    else if (tempList[0].x > tempList[1].x && tempList[1].x > tempList[2].x)
                    {
                        Debug.Log("i am going left");
                        tempList.RemoveAt(0);
                    }
                    
                    /*else if (tempList[0].x < tempList[1].x && tempList[1].x > tempList[2].x)
                    {
                        Debug.Log("my direction changed");
                        newTouch.startPos.x = (newTouch.startPos.x + tempList[1].x) / 2;
                        tempList.RemoveAt(0); 
                    }
                    else if (tempList[0].x > tempList[1].x && tempList[1].x < tempList[2].x)
                    {
                        Debug.Log("my direction changed");
                        //newTouch.startPos.x = (newTouch.startPos.x + tempList[1].x) / 2;
                        tempList.RemoveAt(0); 
                    }#1#
                    else
                    {
                        tempList.RemoveAt(0);
                    }
                 
                }*/
                
               
                
               
                
             
               // int mytemp = tempQueue.Dequeue();
               // Debug.Log("mytemp moruk" + mytemp);
               

                /*if (tempVector != destination)
                {
                    
                    
                }*/

               // tempVector = destination;
                
                //Debug.Log(destination.normalized);
                
                EventManager.Instance.PlayerMoved(destination.normalized);
                
                
                
            }
        }
 
    }
    
    
    
    /*protected Vector2 GetScreenJoystick(bool left)
    {
        foreach(TrackedTouch touch in _touches.Values)
        {
            float halfScreenWidth = Screen.width * 0.5f;
            if((left && touch.startPos.x < halfScreenWidth) ||
               (!left && touch.startPos.x > halfScreenWidth))
            {
                Vector2 screenJoy = touch.currentPos - touch.startPos;
                screenJoy.x = Mathf.Clamp(screenJoy.x / (halfScreenWidth * 0.5f * TouchScreenLookScale), -1f, 1f);
                screenJoy.y = Mathf.Clamp(screenJoy.y / (Screen.height * 0.5f * TouchScreenLookScale), -1f, 1f);
                return screenJoy;
            }
        }
        return Vector2.zero;
    }*/
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
}