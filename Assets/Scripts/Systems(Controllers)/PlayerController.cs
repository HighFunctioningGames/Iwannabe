using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour {


   
    public Camera prototypeCamera;

    public Player p;

    public void Start() {
        p = this.GetComponent<Player>();
    }

    public void Update() {
        VelocityCap();
    }

    void Move(bool isMoving) {
        if(!isMoving) {
            new Move();
        }
    }

    void VelocityCap() {
        Vector3 vel = p.velocity;
        Vector3 max = p.velMax;
        if(vel.x > max.x) {
            vel.x = max.x;
        } else if(vel.x < -max.x) {
            vel.x = -max.x;
        }
        if(vel.y > max.y) {
            vel.y = max.y;
        } else if(vel.y < -max.y) {
            vel.y = -max.y;
        }
        if(vel.z > max.z) {
            vel.z = max.z;
        } else if(vel.z < -max.z) {
            vel.z = -max.z;
        }
        p.velocity = vel;
        p.velMax = max;
    }
}