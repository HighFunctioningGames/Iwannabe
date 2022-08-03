using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SquattingState : ISubState {

    public StateMachine sm { get; set; }

    public void Enter(StateMachine _sm) {
        sm = _sm;
        sm.pc.p.isSquatting = true;
        sm.pc.p.canLookTowardsVelocity = false;
        Vector3 rotation = sm.pc.p.rotater.rotation.eulerAngles;
        rotation.x = 0;
        sm.pc.p.rotater.rotation = Quaternion.Euler(rotation);
    }

    public void Execute() {
        this.LogicUpdate();
        this.AnimUpdate();
    }

    public void Exit() {
        Transform collider = sm.pc.p.rotater.transform.GetChild(0).GetChild(0);
        collider.transform.position = collider.transform.position + new Vector3(0, 0.5f, 0);

        // p.isS LOL!
        sm.pc.p.isSquatting = false;
        sm.pc.p.isCrouched = false;
    }
    
#region Execute
    public void LogicUpdate() {
        Vector2 leftStickInput = new Vector2(sm.im.LeftStick().x, sm.im.LeftStick().y);

        sm.pc.p.velocity.x = leftStickInput.x;
        sm.pc.p.velocity.z = leftStickInput.y;
    }

    public void AnimUpdate() {
        
    }
#endregion
}