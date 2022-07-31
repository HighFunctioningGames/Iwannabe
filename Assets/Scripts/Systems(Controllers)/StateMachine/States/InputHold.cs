using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class InputHold : IState {

    bool inputHeld;
    
    public StateMachine sm { get; set; }

    public void Enter(StateMachine _sm) {
        sm = _sm;
        sm.im.canGetInput = false;
        inputHeld = false;
    }

    public void Execute() {
        this.HandleInput();
        sm.SubStateExecute();
        this.PhysicsUpdate();
    }
    
    public void Exit() {

    }

#region Execute

    public void HandleInput() {
        if(!inputHeld) {
            sm.im.PauseFor(1f);
            inputHeld = true;
        }
    }

    public void PhysicsUpdate() {
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
        if(sm.im.canGetInput) {
            sm.ChangeState(sm.GetPreviousState(), sm.GetPreviousSubState());
        }
    }

#endregion
}