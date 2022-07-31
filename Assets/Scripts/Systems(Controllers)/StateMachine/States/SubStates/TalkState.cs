using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TalkState : ISubState {

    public StateMachine sm { get; set; }

    public void Enter(StateMachine _sm) {
        sm = _sm;
       // sm.pc.isTalking = true;
    }

    public void Execute() {
        this.LogicUpdate();
        this.AnimUpdate();
    }

    public void Exit() {

    }
    
#region Execute
    public void LogicUpdate() {
        
    }
    public void AnimUpdate() {
        
    }
#endregion
}