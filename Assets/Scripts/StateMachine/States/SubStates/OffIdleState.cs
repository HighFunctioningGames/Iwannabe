using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffIdleState : ISubState {

    public StateMachine sm { get; set; }

    public void Enter(StateMachine _sm) {
        sm = _sm;
    }

    public void Execute() {
        this.LogicUpdate();
        this.AnimUpdate();
    }

    public void Exit() {

    }
    
#region Execute
    public void LogicUpdate() {

         // Stop looking in direction of movement
        sm.pc.canLookTowardsVelocity = false;
        
        // Decays the player's velocity
        if(sm.pc.velocity.x > 0.1) {
            sm.pc.velocity.x -= 1 * Time.deltaTime * sm.pc.stoppingSpeed;
        } else if(sm.pc.velocity.x < -0.1) {
            sm.pc.velocity.x += 1 * Time.deltaTime * sm.pc.stoppingSpeed;
        } 
        if(sm.pc.velocity.z > 0.1) {
            sm.pc.velocity.z -= 1 * Time.deltaTime * sm.pc.stoppingSpeed;
        } else if(sm.pc.velocity.z < -0.1) {
            sm.pc.velocity.z += 1 * Time.deltaTime * sm.pc.stoppingSpeed;
        } 

        // This is to bring to a full stop
        if(sm.pc.velocity.x < 0.1 && sm.pc.velocity.x > 0) {
            sm.pc.velocity.x = 0;
        } else if(sm.pc.velocity.x > -0.1 && sm.pc.velocity.x < 0) {
            sm.pc.velocity.x = 0;
        } 
        if(sm.pc.velocity.z < 0.1 && sm.pc.velocity.z > 0) {
            sm.pc.velocity.z = 0;
        } else if(sm.pc.velocity.z > -0.1 && sm.pc.velocity.z < 0) {
            sm.pc.velocity.z = 0;
        } 
    }

    public void AnimUpdate() {
        
    }
#endregion
}