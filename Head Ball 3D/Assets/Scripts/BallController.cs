using System;
using System.Collections;
using System.Collections.Generic;
using RootMotion.Demos;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallController : MonoBehaviour
{
    [Header("Ball Speed")] 
    public float ballSpeed;
    public float opponentBallSpeedMultiplier;
    
    [Header("Difficulty (Max difficult 10)")] 
    public float difficulty;
    
    [Header("Shoot Touch Margin")] 
    public float touchMargin;
    public float secondMargin;
    
    [Header("Max Ball Height")] 
    public float ballHeight;
    
    [Header("Pitch Half-Width")] 
    public float pitchHalfWidth;
    
    [Header("Ball Fall Radius (Depends difficulty)")] 
    public float fallRadius;
    
    [Header("Ball Drop Distance")] 
    public float dropDistance;
    
    [Header("Ball Drop Radius")] 
    public float dropRadius;

    [Header("Ball Waypoints")] 
    public Vector3 startPosition;
    public Vector3 secondPosition;
    public Vector3 finalPosition;

    [Header("Players")]
    public GameObject player;
    public GameObject opponent;
    
    [Header("Ring")]
    public GameObject ring;

    public Vector3 ringPosition; 

    public Vector2 opponentFirstPosititon;
    
    private float time = 0;
    private bool isThrowed = false;
    private Vector3 destination;
    private Rigidbody rigidbody;
    private Vector3 collisionPoint;
    
    public enum BallState
    {
        PlayerShoot,
        OpponentShoot
    }

    public BallState turn;

    private void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // if (Input.GetKey(KeyCode.Space)) ThrowBall(new Vector3(0, 7.5f, 29), new Vector3(0, 30, 0), new Vector3(-4, 1.25f, -27));
    }

    private void FixedUpdate()
    {
        ringPosition = ring.transform.position;
        
        if (!isThrowed) return;

        if (turn == BallState.OpponentShoot)
        {
            time += ballSpeed * opponentBallSpeedMultiplier * Time.fixedDeltaTime;
        }
        else
        {
            time += ballSpeed * Time.fixedDeltaTime;
        }

        if (time >= 1) {
            time = 0;
            isThrowed = false;

            return;
        }
        
        destination = CalculateQuadraticBezierCurve(time, startPosition, secondPosition, finalPosition);

        rigidbody.MovePosition(
            destination
        );

        if (turn == BallState.OpponentShoot)
            rigidbody.velocity = new Vector3(rigidbody.velocity.x, rigidbody.velocity.y, 10);
        else
            rigidbody.velocity = new Vector3(rigidbody.velocity.x, rigidbody.velocity.y, -10);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Equals("Ground"))
        {
            turn = BallState.OpponentShoot;

            //ThrowBall(new Vector3(0, 7.5f, 29), new Vector3(0, 30, 0), new Vector3(-4, 1.25f, -27));
            ThrowBall(-5, 5);
            
            SetRingPosition(0.94f);

            opponentFirstPosititon = new Vector2(opponent.transform.position.x, opponent.transform.position.z);
        }
        
        if (other.tag.Equals("Player"))
        {
            turn = BallState.PlayerShoot;

            Shoot(BallState.PlayerShoot, other);
            
            SetRingPosition(0.94f);

            opponentFirstPosititon = new Vector2(opponent.transform.position.x, opponent.transform.position.z);
        } 
        
        if (other.tag.Equals("Opponent"))
        {
            turn = BallState.OpponentShoot;

            Shoot(BallState.OpponentShoot, other);
            
            SetRingPosition(0.94f);
            
            opponentFirstPosititon = new Vector2(opponent.transform.position.x, opponent.transform.position.z);
        }
    }

    private void Shoot(BallState ballState, Collider collision)
    {
        // if opponent shots
        if (ballState == BallState.OpponentShoot)
        {
            if (Random.value > 0.8f)
            {
                Debug.Log("perfect");
                if (opponent.transform.position.x < 0)
                {
                    ThrowBall(pitchHalfWidth - (7 / Mathf.Clamp(difficulty / 2, 1f, 7f)), pitchHalfWidth - (5 / Mathf.Clamp(difficulty / 2, 1f, 5f)));
                }
                else if (opponent.transform.position.x >= 0)
                {
                    ThrowBall(-pitchHalfWidth + (7 / Mathf.Clamp(difficulty / 2, 1f, 7f)), -pitchHalfWidth + (5 / Mathf.Clamp(difficulty / 2, 1f, 5f)));
                }
            }
            else
            {
                ThrowBall(-pitchHalfWidth / (10 / difficulty), pitchHalfWidth / (10 / difficulty));
            }
            

            return;
        }
        
        // ball length 2 unit

        // if player hit from the right side
        if (collision.transform.position.x > transform.position.x + touchMargin)
        {
            // max right 15.5f
            
            // if player on the left side of his own pitch
            // send ball to the left corner of the opponent pitch
            if (collision.transform.position.x < 0)
            {
                ThrowBall(-pitchHalfWidth + fallRadius, -pitchHalfWidth);
            }
            
            // if player on the right side of his own pitch
            // send ball to the right corner of the opponent pitch
            if (collision.transform.position.x > 0)
            {
                ThrowBall(-pitchHalfWidth + fallRadius, -pitchHalfWidth);
            }
        }
        
        // if player hit from the left side
        if (collision.transform.position.x < transform.position.x - touchMargin)
        {
            // max left -15.5
            
            // if player on the left side of his own pitch
            // send ball to the right corner of the opponent pitch
            if (collision.transform.position.x < 0)
            {
                ThrowBall(pitchHalfWidth - fallRadius, pitchHalfWidth);
            }
            
            // if player on the right side of his own pitch
            // send ball to the right corner of the opponent pitch
            if (collision.transform.position.x > 0)
            {
                ThrowBall(pitchHalfWidth - fallRadius, pitchHalfWidth);
            }
        }
        
        // if player hit from middle point
        // send ball to towards
        if (collision.transform.position.x <= transform.position.x + touchMargin && collision.transform.position.x >= transform.position.x - touchMargin)
        {
            ThrowBall(transform.position.x - fallRadius / 3f, transform.position.x + fallRadius / 3f);
        }
        
        SetRingPosition(0.94f);
    }

    private void ThrowBall(float min, float max)
    {
        float fallPoint = Random.Range(min, max);
        float fallDistance = Random.Range(dropDistance - dropRadius, dropDistance + dropRadius);

        if (turn == BallState.OpponentShoot)
        {
            fallDistance *= -1;
        }

        startPosition = transform.position;
        secondPosition = new Vector3(fallPoint / 2, ballHeight, 0);
        finalPosition = new Vector3(fallPoint, 1.25f, fallDistance);

        isThrowed = true;
        time = 0;
    }

    private void SetRingPosition(float time)
    {
        Vector3 bezier = CalculateQuadraticBezierCurve(time, startPosition, secondPosition, finalPosition);
        ring.transform.position = new Vector3(bezier.x, ring.transform.position.y, bezier.z);

        EventManager.Instance.PlayerShoot();
    }

    private Vector3 CalculateQuadraticBezierCurve(float t, Vector3 point1, Vector3 point2, Vector3 point3)
    {
        return (((1 - t) * (1 - t)) * point1) + (2 * (1 - t) * t * point2) + ((t*t) * point3);
    }
}
