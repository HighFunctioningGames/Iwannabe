using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffMoveState : ISubState {

     Vector2 velocity;

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

        // Add velocity from input
        sm.pc.velocity.x += sm.im.LeftStick().x;
        sm.pc.velocity.z += sm.im.LeftStick().y;
        
        // Look in direction of movement
        sm.pc.canLookTowardsVelocity = true;
        
    }

    public void AnimUpdate() {

    }
#endregion

}