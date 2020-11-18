using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Vector2 finalPos;
    private Vector3 finalTouch;
    public Rigidbody rigidbody;
    private bool isMoving = false;
    
    void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            Debug.Log("wtf bro");
            if (touch.phase == TouchPhase.Began)
            {
                finalPos = Input.mousePosition;
                isMoving = true;
            }
 
            if (touch.phase == TouchPhase.Moved)
            {
                finalPos = Input.mousePosition;
                isMoving = true;
            }
 
            if (touch.phase == TouchPhase.Ended)
            {
                finalPos = Input.mousePosition;
                isMoving = true;
            }
 
            if (touch.phase == TouchPhase.Stationary)
            {
                isMoving = false;
            }
        }
        if (isMoving)
        {
            Ray finalRay = Camera.main.ScreenPointToRay(finalPos);
            RaycastHit hit_touch;
            if (Physics.Raycast(finalRay, out hit_touch, Mathf.Infinity))
            {
                finalTouch = new Vector3(hit_touch.point.x, 0.75f, hit_touch.point.z);
            }
            Ray mouseRay = new Ray(finalTouch, finalTouch - gameObject.transform.position);
            if (mouseRay.direction.x != 0 && mouseRay.direction.y != 0)
            {
                rigidbody.velocity = new Vector3(mouseRay.direction.x * 5, 0, mouseRay.direction.z * 5);
            }
        }
    }
}
