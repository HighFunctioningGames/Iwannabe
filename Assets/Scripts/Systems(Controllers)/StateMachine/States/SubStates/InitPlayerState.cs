using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitPlayerState : ISubState {

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
        sm.ChangeState(new OffBoardState(), new OffIdleState());
    }
    public void AnimUpdate() {
        
    }
#endregion
}