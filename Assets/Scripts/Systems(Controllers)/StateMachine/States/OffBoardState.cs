using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class OffBoardState : IState {

    public StateMachine sm { get; set; }

     public void Enter(StateMachine _sm) 
     {
        sm = _sm;
        sm.p.canGetInput = true;
        sm.p.canMove = true;
    }

    public void Execute() 
    {
        this.HandleInput();
        sm.SubStateExecute();
        this.PhysicsUpdate();
    }
    
    public void Exit() 
    {
        sm.p.canMove = false;
        sm.pc.switchOnOff = false;
    }
        
#region Execute

    private void HandleInput() 
    {
        if(!sm.pc.isMoving) 
        {
            sm.ChangeSubState(new OffIdleState());
        } 
        else 
        {
            if(sm.pc.switchOnOff) 
            {
                sm.ChangeState(new OnBoardState(), new OnIdleState());   
            }

            else if(sm.pc.JumpInput() && sm.p.isGrounded) 
            {
                sm.ChangeSubState(new JumpState());
            }

            else if(sm.pc.SquatInput()) 
            {
                if(!sm.IsThisTheCurrentSubState("SquattingState")) 
                {
                    sm.ChangeSubState(new SquattingState());
                }
            } 

            else 
            {
                sm.ChangeSubState(new OffMoveState());
            }
        }
    }

    private void PhysicsUpdate() 
    {
        
    }

#endregion
}