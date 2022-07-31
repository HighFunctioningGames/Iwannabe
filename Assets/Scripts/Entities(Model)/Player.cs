using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour  {

    public Transform rotater;

    public Vector3 velocity, velMax;

    public float stoppingSpeed, rotateAngle, turnSpeed;

    public bool canLookTowardsVelocity, canTiltTowardsVelocity, isTalking;

    void Awake( ) {
        rotateAngle = 0f;
        rotater = this.transform.GetChild(0);
        velocity = new Vector3 (0f,0f,0f);
        velMax = new Vector3(20f,5f,20f);
        stoppingSpeed = 20f;
        canLookTowardsVelocity = canTiltTowardsVelocity = isTalking = false;
    }
}