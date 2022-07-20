using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
*   State that initalizes the player, top use-case is to instantiate and pool animations, could be helpful for other cases, maybe lol
*/ 
public class InitState_Player : IState 
{
    Player  player;
    
    public StateMachine SMac { get; set; }

    public void Enter(StateMachine sm) {
        SMac = sm;
        SMac.StateText.text = "init";
    }

    public void Execute() {
        this.HandleInput();
        this.LogicUpdate();
        this.AnimUpdate();
        this.PhysicsUpdate();
        Exit();
    }
  
    public void Exit() {
        
    }

#region Execute
    public void HandleInput() {
       SMac.ChangeState(new MoveState_OffBoard());
    }
    public void LogicUpdate() {

    }
    public void AnimUpdate() {

    }
    public void PhysicsUpdate() {

    }
#endregion


}