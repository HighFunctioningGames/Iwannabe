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
        sm.pc.p.velocity.x += sm.im.LeftStick().x;
        sm.pc.p.velocity.z += sm.im.LeftStick().y;
        
        // Look in direction of movement
        sm.pc.p.canLookTowardsVelocity = true;

        // Add tilt to movement in direction of velocity
        sm.pc.p.canTiltTowardsVelocity = true;
        
    }

    public void AnimUpdate() {

    }
#endregion

}