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
            if(sm.pc.isTalking){
                sm.im.canGetInput = false;
                sm.im.TalkInput(this.sm);
            } else {
                sm.im.OffBoardInput(sm);
                sm.im.RotationInput(sm);
            }
        }
        
        // switch(subState) {
        //     case OffMoveState:
        //         smac.ChangeSubState(subState);
        //     break;

        //     // the reason for doing things this way is to account for substates that incite a state change, 
        //     // i should group cases this way, i don't know exactly how to make that a case
        //     case OffIdleState:
        //         smac.ChangeSubState(subState);
        //     break;
        // }
    }

    private void PhysicsUpdate() {
        
    }

#endregion
}