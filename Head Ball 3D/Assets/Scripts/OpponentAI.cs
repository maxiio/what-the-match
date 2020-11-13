using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class OpponentAI : MonoBehaviour
{
    public float speed;
    public float rePositionSpeed;
    public float notCatchSpeed;

    public GameObject ball;

    private BallController ballController;

    private Vector2 destination;

    private float spd;

    private Rigidbody rigidbody;
    private Vector2 units;

    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();

        ballController = ball.GetComponent<BallController>();

        //EventManager.Instance.OnOpponentMoved += MoveOpponent;
    }

    // sağ üst x 15.58 z 38.79
    // sol alt x -15.43 z 0.29
    // distance 49

    private void FixedUpdate()
    {
        if (ballController.turn == BallController.BallState.PlayerShoot)
        {
            if (transform.position.x == ballController.ringPosition.x && transform.position.z == (ballController.ringPosition.z - 1.3f))
            {
                EventManager.Instance.OpponentStopped();
                return;
            }

            destination = new Vector2(ballController.ringPosition.x, (ballController.ringPosition.z - 1.3f)) - new Vector2(ballController.opponentFirstPosititon.x, ballController.opponentFirstPosititon.y);

            EventManager.Instance.OpponentMoved(destination);

            MoveOpponent(destination);
        } else if (ballController.turn == BallController.BallState.OpponentShoot)
        {
            if (transform.position.x == 0 && transform.position.z == 29.8f)
            {
                EventManager.Instance.OpponentStopped();
                return;
            }

            destination = new Vector2(0, 29.8f) - new Vector2(ballController.opponentFirstPosititon.x, ballController.opponentFirstPosititon.y);

            EventManager.Instance.OpponentMoved(destination);

            MoveOpponent(destination);
        }
    }

    private void MoveOpponent(Vector2 destination)
    {
        units = CalculateUnits(destination);

        /*
        Debug.Log(new Vector3(
            transform.position.x + (units.x * speed * Time.fixedDeltaTime),
            transform.position.y,
            transform.position.z + (units.y * speed * Time.fixedDeltaTime)
        ));
        */

        if (ballController.turn == BallController.BallState.OpponentShoot)
        {
            spd = rePositionSpeed;
        } else if (ballController.turn == BallController.BallState.PlayerShoot)
        {
            if (Mathf.Abs(ballController.ringPosition.x) - Mathf.Abs(transform.position.x) < 10 + (15 / (10 - ballController.difficulty)))
            {
                spd = speed;
            } else
            {
                spd = notCatchSpeed;
            }
        }

        rigidbody.MovePosition(new Vector3(
            transform.position.x + (units.x * spd * Time.fixedDeltaTime),
            transform.position.y,
            transform.position.z + (units.y * spd * Time.fixedDeltaTime)
        ));
    }

    private Vector2 CalculateUnits(Vector2 destination)
    {
        float horizontal = Mathf.Lerp(-1, 1, Mathf.InverseLerp(-32, 32, destination.x));
        float vertical = Mathf.Lerp(-1, 1, Mathf.InverseLerp(-39, 39, destination.y));

        return new Vector2(horizontal, vertical);
    }

    /*public GameObject ball;
    public float opponentSpeed;

    private float time;
    private bool isRunning;
    private Vector3 destination;
    private Vector3 finalDest;

    private BallController ballController;
    
    private Rigidbody rigidbody;
    
    private void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();
        
        ballController = ball.GetComponent<BallController>();

        time = 0;
    }

    private void FixedUpdate()
    {
        if (ballController.turn == BallController.BallState.PlayerShoot)
        {
            /*time += opponentSpeed * Time.fixedDeltaTime;

            if (time >= 1)
            {
                return;
            }

            destination = CalculateLinearBezierCurve(time, transform.position,
                new Vector3(ballController.ringPosition.x, transform.position.y, ballController.ringPosition.z + 1.0f));
            
            rigidbody.MovePosition(destination);* /
            

        }
        else
        {
            /*time += opponentSpeed * Time.fixedDeltaTime;

            if (time >= 1)
            {
                return;
            }
            
            destination = CalculateLinearBezierCurve(time, transform.position,
                new Vector3(0, 0.1f, 30f));
            rigidbody.MovePosition(destination); * /
        }

    }
    
    private Vector3 CalculateLinearBezierCurve(float t, Vector3 point1, Vector3 point2)
    {
        return ((1 - t) * point1) + (t * point2);
    }
    
    private Vector2 CalculateUnits(Vector2 destination)
    {
        float horizontal = Mathf.Lerp(-1, 1, Mathf.InverseLerp(-15.5f, 15.5f, destination.x));
        float vertical = Mathf.Lerp(-1, 1, Mathf.InverseLerp(-27f, 27f, destination.y));

        return new Vector2(horizontal, vertical);
    }*/
}
