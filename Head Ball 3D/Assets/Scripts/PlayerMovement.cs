using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;

    private Rigidbody rigidbody;
    private Vector2 units;
    
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();
        EventManager.Instance.OnPlayerMoved += MovePlayer;
        EventManager.Instance.OnNextRound += NextRound;
    }

     // sağ üst x 15.58 z 38.79
     // sol alt x -15.43 z 0.29
     // distance 49
     private void MovePlayer(Vector2 destination)
    {
        units = CalculateUnits(destination);

        rigidbody.MovePosition(new Vector3(
            transform.position.x + (units.x * speed * Time.fixedDeltaTime),
            transform.position.y, 
            transform.position.z + (units.y * speed * Time.fixedDeltaTime)
        ));
    }

    private Vector2 CalculateUnits(Vector2 destination)
    {
        float horizontal = Mathf.Lerp(-1, 1, Mathf.InverseLerp(-Screen.width / 2, Screen.width / 2, destination.x));
        float vertical = Mathf.Lerp(-1, 1, Mathf.InverseLerp(-Screen.height / 4, Screen.height / 4, destination.y));

        return new Vector2(horizontal, vertical);
    }
    
    public void NextRound()
    {
       units = Vector2.zero;
    }
    
}
