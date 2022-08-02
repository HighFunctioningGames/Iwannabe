using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Camera prototypeCamera;
    public Player p;
    public float tiltAngle;
    public float walkSpeed, runSpeed, walkTilt, runTilt, turnSpeed;

    void Awake() {
        prototypeCamera = Camera.main;
        tiltAngle = 0;
        walkSpeed = 3f;
        runSpeed = 6f;
        walkTilt = 6f;
        runTilt = 12f;
        turnSpeed =  100f;
    }

    void FixedUpdate() {
        Moving();
        if (p.canLookTowardsVelocity) {
            RotateTowards();
        }
    }

    void Moving() {
        float speed = p.isRunning ? runSpeed : walkSpeed;
        Vector3 vel = Vector3.MoveTowards(p.velocity, Vector3.zero, speed * Time.deltaTime / 3);
        this.transform.Translate(vel);
        prototypeCamera.transform.Translate(vel);
    }

    void RotateTowards() {
        Vector3 rotation = p.velocity;
        p.rotater.rotation = Quaternion.Slerp(
            this.transform.rotation,
            Quaternion.LookRotation(rotation),
            Time.deltaTime * turnSpeed
        );
        Vector3 quaternionToAngle = p.rotater.rotation.eulerAngles;
        quaternionToAngle.x = (p.isRunning ? runTilt : walkTilt) 
            * Mathf.Abs(p.velocity.x) + Mathf.Abs(p.velocity.z);
        p.rotater.rotation = Quaternion.Euler(quaternionToAngle);
    }
}