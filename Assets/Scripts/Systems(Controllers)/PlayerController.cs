using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour {

   
    public Camera prototypeCamera;

    public PlayerInputs pi;

    private InputAction walk;

    Vector2 move;
    
    bool l2Press, r2Press; 
    
    public bool switchOnOff, isMoving, canJump; 

    void OnEnable() 
    {
        pi.OffBoard.Enable();
    }

    void OnDisable() 
    {
        pi.OffBoard.Disable();
    }

    void Awake() 
    {
        pi = new PlayerInputs();

        // movement
        pi.OffBoard.Movement.started += _ => isMoving = true;
        pi.OffBoard.Movement.performed += _ => move = _.ReadValue<Vector2>();
        pi.OffBoard.Movement.canceled += _ => isMoving = false;

        // squatting
        pi.OffBoard.LeftTriggerPress.performed += _ => l2Press = true;
        pi.OffBoard.RightTriggerPress.performed += _ => r2Press = true;
        pi.OffBoard.LeftTriggerPress.canceled += _ => SetJumpInput();
        pi.OffBoard.RightTriggerPress.canceled += _ => SetJumpInput();

        // switch board on/off
        pi.OffBoard.Use.performed += _ => switchOnOff = _.ReadValueAsButton();
        pi.OffBoard.Use.canceled += _ => switchOnOff = false;
    }

    void SetJumpInput() 
    {
        canJump = true;
        l2Press = r2Press = false;
    }

    public bool JumpInput() 
    {
        if((canJump))
        {
            return true;
        }
        return false;
    }

    public bool SquatInput() 
    {
        if(l2Press && r2Press) 
        {
            return true;
        }
        return false;
    }

    public Vector2 WalkInput() 
    {
        return move;
    }
}