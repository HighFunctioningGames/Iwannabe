using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState {    

    StateMachine sm { get; set; }

    public void Enter(StateMachine _sm) 
    {
        sm = _sm;
    }

    public void Execute() 
    {
        this.HandleInput();
        sm.SubStateExecute();
        this.PhysicsUpdate();
    }
    
    public void Exit();
    
#region Execute
    private void HandleInput() 
    {

    }

    private void PhysicsUpdate() 
    {
        
    }
#endregion
}


