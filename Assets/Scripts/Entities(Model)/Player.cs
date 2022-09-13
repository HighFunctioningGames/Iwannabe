using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour  
{

    public Skateboard board;

    public Transform rotater;

    public Vector3 velocity;

    public bool canLookTowardsVelocity, canGetInput, isTalking, isRunning, isIdle, isSquatting, isCrouched, canMove, isGrounded;

    void Start( ) 
    {
        rotater = this.transform.GetChild(0);

        // I'm sorry. Will fix later.
        board = this.transform.GetChild(0).GetChild(0).GetChild(1).GetChild(0).GetComponent<Skateboard>();
        velocity = new Vector3 (0f,0f,0f);
        canLookTowardsVelocity = isTalking = isRunning = 
            isIdle = isSquatting = isCrouched = canMove = 
            isGrounded = false;
    }
}