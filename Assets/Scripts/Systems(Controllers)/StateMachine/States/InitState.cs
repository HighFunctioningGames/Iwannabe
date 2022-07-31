using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class InitState : IState {
    
    public StateMachine sm { get; set; }

    public void Enter(StateMachine _sm) {
        sm = _sm;
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
                 
    }

    public void PhysicsUpdate() {

    }

#endregion
}