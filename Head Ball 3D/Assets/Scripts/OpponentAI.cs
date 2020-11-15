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

    private bool falseDest = false;
    private Vector2 lastPos;
    private BallController.BallState exAction = BallController.BallState.OpponentShoot; 

    void Start()
    {
        EventManager.Instance.PlayerShooted += TriggerOpponent;

        rigidbody = gameObject.GetComponent<Rigidbody>();

        ballController = ball.GetComponent<BallController>();
        exAction = BallController.BallState.OpponentShoot;
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

            Debug.Log(falseDest);

            if (falseDest)
            {

                destination = new Vector2(ballController.ringPosition.x, ballController.opponentFirstPosititon.y) - new Vector2(ballController.opponentFirstPosititon.x, ballController.opponentFirstPosititon.y);

                Debug.Log(transform.position.x + "  " + ballController.ringPosition.x);
                if (transform.position.x >= ballController.ringPosition.x - 1 && transform.position.x <= ballController.ringPosition.x + 1)
                {
                    lastPos = new Vector2(transform.position.x, transform.position.z);
                    falseDest = false;
                }
            } else
            {
                destination = new Vector2(ballController.ringPosition.x, (ballController.ringPosition.z - 1.3f)) - new Vector2(lastPos.x, lastPos.y);
            }

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

    private void TriggerOpponent()
    {
        falseDest = true;
    }

    private void MoveOpponent(Vector2 destination)
    {
        units = CalculateUnits(destination);

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
}
