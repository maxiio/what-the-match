using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class BugFixer : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{

    public FloatingJoystick floatingJoystick;
    
    public void OnPointerDown(PointerEventData eventData)
    {
      Debug.Log("test");
      floatingJoystick.OnPointerDown(eventData);
    }
    
    public void OnPointerUp(PointerEventData eventData)
    {
      floatingJoystick.OnPointerUp(eventData);
    }
    
    public void OnDrag(PointerEventData eventData)
    {
      //nothing
    }
}
