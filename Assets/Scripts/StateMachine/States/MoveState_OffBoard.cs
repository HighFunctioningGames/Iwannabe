using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState_OffBoard : IState {

    public StateMachine SMac { get; set; }

    public void Enter(StateMachine sm) {
        SMac = sm;
        SMac.StateText.text = "Move_Off";
        SMac.ChangeSubState(new IdleState());
    }

    public void Execute() {
        this.HandleInput();
        this.LogicUpdate();
        this.AnimUpdate();
        this.PhysicsUpdate();
    }
    
    public void Exit() {

    }

#region Execute
    public void HandleInput() {

    }
    public void LogicUpdate() {

    }
    public void AnimUpdate() {

    }
    public void PhysicsUpdate() {

    }
#endregion

}