using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SquattingState : ISubState {

    public StateMachine sm { get; set; }

    public void Enter(StateMachine _sm) {
        sm = _sm;
        sm.p.isSquatting = true;
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
        Transform collider = sm.p.rotater.transform.GetChild(0).GetChild(0);
        collider.transform.position = collider.transform.position + new Vector3(0, 0.5f, 0);

        // p.isS LOL!
        sm.p.isSquatting = false;
        sm.p.isCrouched = false;
    }
    
#region Execute
    public void LogicUpdate() 
    {
        Vector2 leftStickInput = sm.pc.WalkInput();
        sm.p.velocity.x = leftStickInput.x;
        sm.p.velocity.z = leftStickInput.y;
    }

    public void AnimUpdate() 
    {
        
    }
#endregion
}