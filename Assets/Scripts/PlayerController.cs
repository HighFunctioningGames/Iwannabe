using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour {


    public Vector3 velocity, velMax;

    public float stoppingSpeed, rotateAngle, turnSpeed;

    public bool canLookTowardsVelocity, isTalking;

    public Camera prototypeCamera;

    public Transform rotater;

    public void Start() {
        rotateAngle = 0f;
        rotater = this.transform.GetChild(0);
        velocity = new Vector3 (0f,0f,0f);
        velMax = new Vector3(20f,5f,20f);
        stoppingSpeed = 20f;
        canLookTowardsVelocity = isTalking = false;
    }

    public void Update() {
        VelocityCap();
        Move();
    }

    void Move() {
        this.transform.Translate(velocity * Time.deltaTime);
        prototypeCamera.transform.Translate(velocity * Time.deltaTime);

        // Player automatically looks in direction of velocity
        if (canLookTowardsVelocity) {
            rotater.rotation = Quaternion.Slerp (
                this.transform.rotation, 
                Quaternion.LookRotation (velocity), 
                Time.deltaTime * 80f
            );
        }

        // Player controls rotation
        rotater.rotation =  rotater.rotation * Quaternion.AngleAxis( 
            rotateAngle * turnSpeed, Vector3.forward
        ); 
    }

    void VelocityCap() {
        if(this.velocity.x > velMax.x) {
            this.velocity.x = velMax.x;
        } else if(this.velocity.x < -velMax.x) {
            this.velocity.x = -velMax.x;
        }
        if(this.velocity.y > velMax.y) {
            this.velocity.y = velMax.y;
        } else if(this.velocity.y < -velMax.y) {
            this.velocity.y = -velMax.y;
        }
        if(this.velocity.z > velMax.z) {
            this.velocity.z = velMax.z;
        } else if(this.velocity.z < -velMax.z) {
            this.velocity.z = -velMax.z;
        }
    }
}