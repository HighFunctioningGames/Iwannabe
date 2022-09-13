using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class OnBoardState : IState {

    public StateMachine sm { get; set; }

     public void Enter(StateMachine _sm) {
        sm = _sm;
        sm.p.canMove = false;
        sm.p.board.SwitchOn();
        sm.p.velocity *= 2;
    }

    public void Execute() {
        this.HandleInput();
        sm.SubStateExecute();
        this.PhysicsUpdate();
    }
    
    public void Exit() {
        sm.p.board.SwitchOff();
        sm.p.canMove = false;
    }
        
#region Execute
    private void HandleInput() 
    {
         if(sm.pc.switchOnOff) 
        {
            sm.ChangeState(new OffBoardState(), new OffIdleState());   
        }
    }

    private void PhysicsUpdate() {
        
    }
#endregion
}