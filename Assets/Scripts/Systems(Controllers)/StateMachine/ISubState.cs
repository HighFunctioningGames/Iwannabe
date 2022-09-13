using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISubState {    

    StateMachine sm { get; set; }

    public void Enter(StateMachine _sm) 
    {
        sm = _sm;
    }

    public void Execute() 
    {
        this.LogicUpdate();
        this.AnimUpdate();
    }

    public void Exit();
    
#region Execute
    private void LogicUpdate() 
    {

    }
    
    private void AnimUpdate() 
    {

    }
#endregion
}

