using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Movement_OnBoard : IState {

    public StateMachine SMac { get; set; }

    public void Enter(StateMachine sm) {
        SMac = sm;
        SMac.StateText.text = "Movement_On";
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