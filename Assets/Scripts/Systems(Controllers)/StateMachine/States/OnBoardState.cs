using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class OnBoardState : IState {

    public StateMachine sm { get; set; }

     public void Enter(StateMachine _sm) {
        sm = _sm;
        sm.pc.p.canMove = false;
        sm.pc.p.board.SwitchOn();
    }

    public void Execute() {
        this.HandleInput();
        sm.SubStateExecute();
        this.PhysicsUpdate();
    }
    
    public void Exit() {
        sm.pc.p.board.SwitchOff();
        sm.pc.p.canMove = false;
    }
        
#region Execute
    private void HandleInput() {
        sm.im.TransitionInput(sm);
    }

    private void PhysicsUpdate() {
        
    }
#endregion
}