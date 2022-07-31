using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnIdleState : ISubState {

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
        sm.pc.p.canLookTowardsVelocity = false;
        
        // Decays the player's velocity
        if(sm.pc.p.velocity.x > 0.1) {
            sm.pc.p.velocity.x -= 1 * Time.deltaTime * sm.pc.p.stoppingSpeed / 5;
        } else if(sm.pc.p.velocity.x < -0.1) {
            sm.pc.p.velocity.x += 1 * Time.deltaTime * sm.pc.p.stoppingSpeed / 5;
        } 
        if(sm.pc.p.velocity.z > 0.1) {
            sm.pc.p.velocity.z -= 1 * Time.deltaTime * sm.pc.p.stoppingSpeed / 5;
        } else if(sm.pc.p.velocity.z < -0.1) {
            sm.pc.p.velocity.z += 1 * Time.deltaTime * sm.pc.p.stoppingSpeed / 5;
        } 

        // This is to bring to a full stop
        if(sm.pc.p.velocity.x < 0.1 && sm.pc.p.velocity.x > 0) {
            sm.pc.p.velocity.x = 0;
        } else if(sm.pc.p.velocity.x > -0.1 && sm.pc.p.velocity.x < 0) {
            sm.pc.p.velocity.x = 0;
        } 
        if(sm.pc.p.velocity.z < 0.1 && sm.pc.p.velocity.z > 0) {
            sm.pc.p.velocity.z = 0;
        } else if(sm.pc.p.velocity.z > -0.1 && sm.pc.p.velocity.z < 0) {
            sm.pc.p.velocity.z = 0;
        } 
    }

    public void AnimUpdate() {
        
    }
#endregion
}