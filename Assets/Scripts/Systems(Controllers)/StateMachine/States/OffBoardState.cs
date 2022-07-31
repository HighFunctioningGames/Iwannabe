using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class OffBoardState : IState {

    public StateMachine sm { get; set; }

     public void Enter(StateMachine _sm) {
        sm = _sm;
        sm.im.canGetInput = true;
    }

    public void Execute() {
        this.HandleInput();
        sm.SubStateExecute();
        this.PhysicsUpdate();
    }
    
    public void Exit() {

    }
        
#region Execute

    private void HandleInput() {
        if(sm.im.canGetInput) {
            if(sm.pc.p.isTalking){
                sm.im.canGetInput = false;
                sm.im.TalkInput(this.sm);
            } else {
                sm.im.OffBoardInput(sm);
                sm.im.RotationInput(sm);
            }
        }
    }

    private void PhysicsUpdate() {
        
    }

#endregion
}