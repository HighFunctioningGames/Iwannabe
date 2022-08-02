using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffMoveState : ISubState {

     Vector2 velocity;

    public StateMachine sm { get; set; }

    public void Enter(StateMachine _sm) {
        sm = _sm;
        if(sm.pc.GetComponent<Move>() == null) 
            new Move();
    }

    public void Execute() {
        this.LogicUpdate();
        this.AnimUpdate();
    }
    
    public void Exit() {
        sm.pc.p.isRunning = false;
    }

#region Execute
    public void LogicUpdate() {
        Vector2 leftStickInput = new Vector2(sm.im.LeftStick().x, sm.im.LeftStick().y);

        if (Mathf.Abs(leftStickInput.x) + Mathf.Abs(leftStickInput.y) >= 1.3f 
            || Mathf.Abs(leftStickInput.x) >= 0.97f || Mathf.Abs(leftStickInput.y) >= 0.97f) 
            sm.pc.p.isRunning = true;
        else 
            sm.pc.p.isRunning = false;    

        // Add velocity from input
        sm.pc.p.velocity.x = leftStickInput.x;
        sm.pc.p.velocity.z = leftStickInput.y;
        
        // Look in direction of movement
        sm.pc.p.canLookTowardsVelocity = true;
    }

    public void AnimUpdate() {

    }
#endregion

}