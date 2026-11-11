using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBalling : MonoBehaviour
{
    public Rigidbody rbBall;
    public float ballSpeed;
    public bool isBalling;
    public Transform paddle;
    public static bool BallTouch = false;
    public ArkanoidGameManager agm;
    void Start()
    {
        rbBall = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Debug.Log(rbBall.velocity);
        if (agm.gameOver)
        {
            return;
        }

      //-------------------------------------//
      if (!isBalling)
        {
            transform.position = paddle.position;
        }

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0)) && !isBalling)
        {
            isBalling = true;
            rbBall.AddForce(Vector3.forward * ballSpeed, ForceMode.Impulse);
        }
        //-------------------------------------//
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("ArkanoidBottom"))
        {
            rbBall.velocity = Vector3.zero;
            isBalling = false;
            agm.UpdateLives(-1);
        }

        if (collider.CompareTag("ArkanoidPaddle"))
        {
            Debug.Log("Noice");
            BallTouch = true;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("ArkanoidBrick"))
        {
            BrickScript brickScript = collision.gameObject.GetComponent<BrickScript>();
            if (brickScript.hitsToBreak > 1)
            {
                brickScript.BreakBrick();
            }
            else
            {
                agm.UpdateScore(brickScript.points);
                agm.UpdateBricksNumber();
                brickScript.isBrickBroken = true;
                if (ballSpeed < 200)
                {
                    rbBall.velocity = rbBall.velocity.normalized * 100;
                }
            }
        }
    }


}
