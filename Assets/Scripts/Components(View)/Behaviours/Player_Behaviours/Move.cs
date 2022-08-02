using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Camera prototypeCamera;
    public Player p;
    public float tiltAngle;
    public float walkSpeed, runSpeed, walkTilt, runTilt, turnSpeed, crabSpeed;

    void Awake() {
        p = this.GetComponent<Player>();
        prototypeCamera = Camera.main;
        tiltAngle = 0;
        crabSpeed = 1.75f;
        walkSpeed = 3f;
        runSpeed = 4f;
        walkTilt = 7f;
        runTilt = 10f;
        turnSpeed =  100f;
    }

    void FixedUpdate() {
          
        // This is because I'm doing things in a dumb way lol, ie. moving camera here
        // 'nother will fix later LOLOLOL
        Moving();
     
        if(p.canMove) {
            if (p.canLookTowardsVelocity) 
                RotateTowards();
            if (p.isSquatting && !p.isCrouched) 
                Crouch();
        }
    }

    void Moving() {
        float speed = p.isRunning ? runSpeed : p.isSquatting ? crabSpeed : walkSpeed;
        this.transform.position = Vector3.Lerp(
            this.transform.position, 
            this.transform.position + p.velocity * speed,
            speed * Time.deltaTime
        );
        prototypeCamera.transform.position = Vector3.Lerp(
            prototypeCamera.transform.position, 
            this.transform.position + new Vector3(0.6f, 0.75f, -5f),
            speed * Time.deltaTime * 2
        ); 
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
            * (Mathf.Abs(p.velocity.x) + Mathf.Abs(p.velocity.z));
        p.rotater.rotation = Quaternion.Euler(quaternionToAngle);
    }

    void Crouch() {
       Transform collider = p.rotater.transform.GetChild(0).GetChild(0);
        collider.transform.position = collider.transform.position - new Vector3(0, 0.5f, 0);
        p.isCrouched = true;
    }
}