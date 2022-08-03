using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class OffBoardState : IState {

    public StateMachine sm { get; set; }

     public void Enter(StateMachine _sm) {
        sm = _sm;
        sm.im.canGetInput = true;
        sm.pc.p.canMove = true;
    }

    public void Execute() {
        this.HandleInput();
        sm.SubStateExecute();
        this.PhysicsUpdate();
    }
    
    public void Exit() {
        sm.pc.p.canMove = false;
    }
        
#region Execute

    private void HandleInput() {
        if(sm.im.canGetInput) {
            if(sm.pc.p.isTalking){
                sm.im.canGetInput = false;
                sm.im.TalkInput(this.sm);
            } else {
                if(sm.pc.p.isSquatting) {
                    sm.im.JumpInput(sm);
                }
                sm.im.OffBoardInput(sm);
            }
            
        }
    }

    private void PhysicsUpdate() {
        
    }

#endregion
}