using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class JumpState : ISubState {

    public StateMachine sm { get; set; }

    public void Enter(StateMachine _sm) {
        sm = _sm;
        sm.pc.canJump = false;
        sm.p.canLookTowardsVelocity = false;
        Vector3 rotation = sm.p.rotater.rotation.eulerAngles;
        rotation.x = 0;
        sm.p.rotater.rotation = Quaternion.Euler(rotation);
    }

    public void Execute() {
        this.LogicUpdate();
        this.AnimUpdate();
    }

    public void Exit() {
    }
    
#region Execute
    public void LogicUpdate() 
    {
        sm.p.velocity.y += 2f;
        sm.ChangeSubState(new OffMoveState());
    }

    public void AnimUpdate() 
    {
        
    }
#endregion
}