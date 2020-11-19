using System.Collections;
using System.Collections.Generic;
using DitzeGames.MobileJoystick;
using UnityEngine;
using UnityEngine.EventSystems;

public class AutoJoystick : MonoBehaviour ,IPointerDownHandler,IPointerUpHandler,IDragHandler
{
    public RectTransform joyStickOuterCircle;

    public Joystick joy;

    public void OnPointerDown(PointerEventData eventData)
    {
        joyStickOuterCircle.gameObject.SetActive(true);
        Vector2 diff = eventData.position - (Vector2) GetComponent<RectTransform>().position;
        Vector2 modifiedDiff = diff * (1f / GetComponentInParent<Canvas>().scaleFactor);
        joyStickOuterCircle.localPosition = modifiedDiff;
    }

    public void OnDrag(PointerEventData eventData)
    {
        //joy.chan
        //joy.chan
    }

    public void OnPointerUp(PointerEventData eventData)
    {
       joyStickOuterCircle.gameObject.SetActive(false);
    }

   
}
