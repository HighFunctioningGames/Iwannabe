using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class InputHold : IState {

    bool inputHeld;
    
    public StateMachine sm { get; set; }

    public void Enter(StateMachine _sm) {
        sm = _sm;
        sm.im.canGetInput = false;
        inputHeld = false;
    }

    public void Execute() {
        this.HandleInput();
        sm.SubStateExecute();
        this.PhysicsUpdate();
    }
    
    public void Exit() {

    }

#region Execute

    public void HandleInput() {
        if(!inputHeld) {
            sm.im.PauseFor(1f);
            inputHeld = true;
        }
    }

    public void PhysicsUpdate() {
       
        if(sm.im.canGetInput) {
            sm.ChangeState(sm.GetPreviousState(), sm.GetPreviousSubState());
        }
    }

#endregion
}