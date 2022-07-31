using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class OnBoardState : IState {

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
        if(sm.im.TransitionInput()) {
            sm.ChangeState(new InputHold(), new TransitionState());
        }
    }

    private void PhysicsUpdate() {
        
    }

#endregion
}