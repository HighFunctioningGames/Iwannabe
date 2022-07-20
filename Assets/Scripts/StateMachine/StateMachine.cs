using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StateMachine : MonoBehaviour{
    IState  currentState;
    ISubState currentSubState;

    public TMP_Text StateText, SubStateText;

    public void Awake() {
        Initalize(new InitState_Player());
    }

    public void Initalize(IState startingState) {
        currentState = startingState;
        startingState.Enter(this);
    }
    public void ChangeState(IState newState) {
        if (currentState != null)
            currentState.Exit();
        currentState = newState;
        currentState.Enter(this);
    }

    public void ChangeSubState(ISubState newSubState) {
        if (currentSubState != null)
            currentSubState.Exit();
        currentSubState = newSubState;
        currentSubState.Enter(this);
    }

    public void Update() {
        if (currentState != null) currentState.Execute();
        if (currentSubState != null) currentSubState.Execute();
    }
}

