using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState {    

    StateMachine SMac { get; set; }

    public void Enter(StateMachine sm) {
        SMac = sm;
    }
    public void Execute() {

    }
    public void Exit();
    
}

