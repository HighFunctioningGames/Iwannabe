using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TransitionState : ISubState {

    public StateMachine sm { get; set; }

    public void Enter(StateMachine _sm) {
        sm = _sm;
    }

    public void Execute() {
        this.LogicUpdate();
        this.AnimUpdate();
    }

    public void Exit() {

    }
    
#region Execute
    public void LogicUpdate() {
        if(sm.WasThisThePreviousState("OffBoardState")) 
            sm.ChangeState(new OnBoardState(), new OnIdleState());
        else if(sm.WasThisThePreviousState("OnBoardState")) 
            sm.ChangeState(new OffBoardState(), new OffIdleState());
        else sm.ChangeState(sm.GetPreviousState(), sm.GetPreviousSubState());
    }
    public void AnimUpdate() {
        
    }
#endregion
}