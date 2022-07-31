using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Move : MonoBehaviour {

        public Camera prototypeCamera;

        public Player p;

        void Awake() {
            prototypeCamera = Camera.main;
        }

       void FixedUpdate() {
         this.transform.Translate(p.velocity * Time.deltaTime);
         prototypeCamera.transform.Translate(p.velocity * Time.deltaTime);

        // Player automatically looks in direction of velocity
        if (p.canLookTowardsVelocity) {
            p.rotater.rotation = Quaternion.Slerp (
                this.transform.rotation, 
                Quaternion.LookRotation (p.velocity), 
                Time.deltaTime * 80f
            );
        }

        // if (p.canTiltTowardsVelocity) {
        //     float angle = Vector2.Dot(p.velocity, Vector2.up);
        //     p.rotater.rotation = Quaternion.Slerp(
        //         this.transform.rotation,
        //         Quaternion.Euler(angle, 0, 0),
        //         Time.deltaTime * 30f
        //     );
        // }

        // // Player controls rotation
        // p.rotater.rotation =  p.rotater.rotation * Quaternion.AngleAxis( 
        //     p.rotateAngle * p.turnSpeed, Vector3.forward
        // ); 
    }
}