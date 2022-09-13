using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffIdleState : ISubState {

    public StateMachine sm { get; set; }

    public void Enter(StateMachine _sm) {
        sm = _sm;
        sm.p.isIdle = true;
        Vector3 rotation = sm.p.rotater.rotation.eulerAngles;
        rotation.x = 0;
        sm.p.rotater.rotation = Quaternion.Euler(rotation);
    }

    public void Execute() {
        this.LogicUpdate();
        this.AnimUpdate();
    }

    public void Exit() {
        sm.p.isIdle = false;
    }
    
#region Execute
    public void LogicUpdate() {
        float decayRate = sm.p.isRunning ? 3f : 2f;
        sm.p.velocity = Vector3.MoveTowards(sm.p.velocity, Vector3.zero, Time.deltaTime / decayRate);
         
        // Stop looking in direction of movement
        sm.p.canLookTowardsVelocity = false;
    }

    public void AnimUpdate() {
        
    }
#endregion
}