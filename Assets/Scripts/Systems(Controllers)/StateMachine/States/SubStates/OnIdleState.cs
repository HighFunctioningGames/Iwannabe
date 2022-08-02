using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnIdleState : ISubState {

    public StateMachine sm { get; set; }

    public void Enter(StateMachine _sm) {
        sm = _sm;
        sm.pc.p.isIdle = true;
        Vector3 rotation = sm.pc.p.rotater.rotation.eulerAngles;
        rotation.x = 0;
        sm.pc.p.rotater.rotation = Quaternion.Euler(rotation);

    }

    public void Execute() {
        this.LogicUpdate();
        this.AnimUpdate();
    }

    public void Exit() {
        sm.pc.p.isIdle = false;
    }
    
#region Execute
    public void LogicUpdate() {
        sm.pc.p.velocity = Vector3.MoveTowards(sm.pc.p.velocity, Vector3.zero, Time.deltaTime / 10);
        sm.pc.p.canLookTowardsVelocity = false;
    }

    public void AnimUpdate() {
        
    }
#endregion
}