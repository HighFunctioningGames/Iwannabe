using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour  {

    public Transform rotater;

    public Vector3 velocity;

    public bool canLookTowardsVelocity, isTalking, isRunning, isIdle;

    void Start( ) {
        rotater = this.transform.GetChild(0);
        velocity = new Vector3 (0f,0f,0f);
        canLookTowardsVelocity = isTalking = isRunning = isIdle = false;
    }
}