using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffMoveState : ISubState {

    public StateMachine sm { get; set; }

    public void Enter(StateMachine _sm) {
        sm = _sm;
        if(sm.p.GetComponent<Move>() == null) 
            new Move();
        sm.p.canLookTowardsVelocity = true;
    }

    public void Execute() {
        this.LogicUpdate();
        this.AnimUpdate();
    }
    
    public void Exit() {
        sm.p.isRunning = false;
    }

#region Execute
    public void LogicUpdate() {
        Vector2 leftStickInput = sm.pc.WalkInput();
        sm.p.velocity.x = leftStickInput.x;
        sm.p.velocity.z = leftStickInput.y;

        if(Mathf.Abs(leftStickInput.magnitude) >= .99f) 
        {
            sm.p.isRunning = true;
        } 
        else 
        {
            sm.p.isRunning = false;
        }
    }

    public void AnimUpdate() {

    }
#endregion

}