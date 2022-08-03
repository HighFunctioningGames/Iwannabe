using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StateMachine : MonoBehaviour{

    IState  currentState, previousState;
    ISubState currentSubState, previousSubState;

    public UtilMethods util;

    public InputManager im;

    public PlayerController pc;

    public GameObject player;

    // For Prototyping
    public TMP_Text StateText, SubStateText;

    public void SetText(string sText, string ssText) {
        StateText.text = sText;
        SubStateText.text = ssText;
    }

    public void Awake() {
        player = GameObject.FindGameObjectWithTag("Player");
        im = this.GetComponent<InputManager>();
        pc = player.GetComponent<PlayerController>();
        Initalize();
    }

    public void Initalize() {
        util = this.GetComponent<UtilMethods>();
        ChangeState(new InitState(), new InitPlayerState());
    }

    public IState GetCurrentState() {
        return this.currentState;
    }

    public IState GetPreviousState() {
        return this.previousState;
    }

    public ISubState GetCurrentSubState() {
        return currentSubState;
    }

    public ISubState GetPreviousSubState() {
        return previousSubState;
    }

    // !!! DANGER DUMB DUMB CODE !!!
    public bool WasThisThePreviousState(string nameParam) {
        
        // uh oh, string comparisons !! it's the cheapest and most convienent option i could think of - will change latter.
        // DO NOT MISSPELL xD
        if(nameParam.CompareTo(previousState.ToString()) == 0) {
            return true;
        }
        else return false;
    }

    public bool WasThisThePreviousSubState(string nameParam) {
        if(nameParam.CompareTo(previousSubState.ToString()) == 0) {
            return true;
        }
        else return false;
    }

    public bool IsThisTheCurrentState(string nameParam) {
        if(nameParam.CompareTo(currentState.ToString()) == 0) {
            return true;
        }
        else return false;
    }

    public bool IsThisTheCurrentSubState(string nameParam) {
        if(nameParam.CompareTo(currentSubState.ToString()) == 0) {
            return true;
        }
        else return false;
    }

    public void ChangeState(IState newState, ISubState newSubState) {
        if (currentState != newState) {
            if (currentState != null) {
                previousState = currentState;
                currentState.Exit();
            }
            currentState = newState;
            currentState.Enter(this);
            SetText(
                util.TrimString(newState.ToString()), 
                util.TrimString(newSubState.ToString())
            );
            ChangeSubState(newSubState);
        }
    }

    public void ChangeSubState(ISubState newSubState) {
        if (currentSubState != newSubState) {
            if (currentSubState != null) {
                previousSubState = currentSubState;
                currentSubState.Exit();
            }
            currentSubState = newSubState;
            currentSubState.Enter(this);
            SetText(
                util.TrimString(currentState.ToString()), 
                util.TrimString(newSubState.ToString())
            );
        }
    }

    public void Update() {
        if (currentState != null) currentState.Execute();
    }

    public void SubStateExecute() {
        if (currentSubState != null) currentSubState.Execute();
    }
}

