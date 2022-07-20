using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    // Ps4 Buttons
    private string cross, square, triangle, circle, l1, l2, l3, r1, r2, r3, leftStickX, leftStickY, rightStickX, rightStickY, l2Trigger, r2Trigger, dPadX, dPadY, share, options, ps, padPress;
    private bool grounded, leftKneeRaised, rightKneeRaised, pushing, canBrake, waitForInput, leftCrouching, rightCrouching, readyToPop, leftPopd, rightPopd;
    public bool steering;

    public StateMachine owner;

    // Start is called before the first frame update
    public void Awake() {
        #region Ps4 Buttons
        cross = "Cross";
        square = "Square";
        circle = "Circle";
        triangle = "Triangle";
        l1 = "L1";
        l2 = "L2";
        l3 = "L3";        
        r1 = "R1";
        r2 = "R2";
        r3 = "R3";
        leftStickX = "LeftStickX";
        leftStickY = "LeftStickY";
        rightStickX = "RightStickX";
        rightStickY = "RightStickY";
        l2Trigger = "L2Trigger";
        r2Trigger = "R2Trigger";
        dPadX = "DPadX";
        dPadY = "DPadY";
        share = "Share";
        options = "Options";
        ps = "PS";
        padPress = "PadPress";
        #endregion

        #region Input Booleans
        grounded = true;
        leftKneeRaised = false;
        rightKneeRaised = false;
        pushing = false;
        steering = false;
        canBrake = true;
        waitForInput = true;
        leftCrouching = false;
        rightCrouching = false;
        leftPopd = false;
        rightPopd = false;
        #endregion
    }

    public void Update() {
        GetInput();
    }

    public Vector2 LeftStick() {
        return new Vector2(Input.GetAxisRaw(leftStickX), Input.GetAxisRaw(leftStickY));
    }

    public Vector2 RightStick() {
        return new Vector2(Input.GetAxisRaw(rightStickX), Input.GetAxisRaw(rightStickY));
    }

    public void GetInput() {
        if (waitForInput) {
            if (grounded) {
                GetBrakeInput();
                GetSteerInput();
                GetPushInput();
                GetPopInput();
            } else {
                GetKickflipInput();
                GetOllieInput();
            }
        }
        GetIdleInput();
    }

    IEnumerator WaitForInput() {
        waitForInput = false;
        yield return new WaitForSeconds(1f);
        waitForInput = true;
        if (grounded) {
   //         owner.ChangeState(new IdleState());
        }
    }

    IEnumerator InAir() {
        waitForInput = false;
        yield return new WaitForSeconds(2f);
        waitForInput = true;
        grounded = true;
        leftPopd = false;
        rightPopd = false;
    //    owner.ChangeState(new IdleState());
    }

    private void GetPushInput() {
        Vector2 leftStickInput = LeftStick();
        Vector2 rightStickInput = RightStick(); 
        pushing = false;
        if (leftStickInput.y > 0.15f) {
            leftKneeRaised = true;
            canBrake = false;
        } else if (rightStickInput.y > 0.15f) {
            rightKneeRaised = true;
            canBrake = false;
        }
        if (leftKneeRaised) {
            leftStickInput = LeftStick();
            if (leftStickInput.y < -0.4f) {
                if (!pushing) {
//                    owner.NextState(owner.pushState);
                    leftKneeRaised = false;
                    pushing = true;
                    canBrake = true;
                    StartCoroutine(WaitForInput());   
                }
            }
        } else if (rightKneeRaised) {
            rightStickInput = RightStick();
            if (rightStickInput.y < -0.4f) {
                if (!pushing) {
//                    owner.NextState(owner.pushState);
                    rightKneeRaised = false;
                    pushing = true;
                    canBrake = true;
                    StartCoroutine(WaitForInput());
                }
            }
        }
    }

    private void GetIdleInput() {
        // if no input after 5 secs transition idle state
    }

    private void GetSteerInput() {
        Vector2 leftStickInput = LeftStick();
        Vector2 rightStickInput = RightStick();
        if (!pushing) {
            if (leftStickInput.x > 0.15f || leftStickInput.x < -0.15f) {
                if (!steering) {
//                    if (owner.activeState != owner.steerState) {
//                        owner.NextState(owner.steerState);
//                        StartCoroutine(WaitForInput());
//                    }
                }
            } else if (rightStickInput.x > 0.15f || rightStickInput.x < -0.15f) {
                if (!steering) {
//                    if (owner.activeState != owner.steerState) {
//                        owner.NextState(owner.steerState);
//                        StartCoroutine(WaitForInput());
//                    }
                }
            }
        }
    }

    private void GetBrakeInput() {
        Vector2 leftStickInput = LeftStick();
        Vector2 rightStickInput = RightStick();
        if (canBrake) {
            if (!leftCrouching || !rightCrouching) {
                if (leftStickInput.y <= -1f || rightStickInput.y <= -1f) {
//                    if (owner.activeState != owner.brakeState) {
//                        owner.NextState(owner.brakeState);
//                        StartCoroutine(WaitForInput());
//                    }
                }
            }
        }
    }

    private void GetPopInput() {
        Vector2 leftStickInput = LeftStick();
        Vector2 rightStickInput = RightStick();
        if (!pushing) {
            if (Input.GetButton(l3)) {
                leftCrouching = true;
            } else if (Input.GetButton(r3)) {
                rightCrouching = true;
            }
            if (leftCrouching) {
                if (leftStickInput.y <= -.6f) {
                    readyToPop = true;
                }
            } else if (rightCrouching) {
                if (rightStickInput.y <= -.6f) {
                    readyToPop = true;
                }
            }
            if (readyToPop) {
                if (leftStickInput.y == 0 && leftCrouching) {
//                    owner.NextState(owner.popState);
                    leftPopd = true;
                    leftCrouching = false;
                    readyToPop = false;
                    grounded = false;
                    StartCoroutine(InAir());
                    StartCoroutine(WaitForInput());
                } else if (rightStickInput.y == 0 && rightCrouching) {
//                    owner.NextState(owner.popState);
                    rightPopd = true;
                    rightCrouching = false;
                    readyToPop = false;
                    grounded = false;
                    StartCoroutine(InAir());
                    StartCoroutine(WaitForInput());
                }
            }
        }
    }

    private void GetOllieInput() {
        Vector2 leftStickInput = LeftStick();
        Vector2 rightStickInput = RightStick();
        if (leftPopd) {
            if (rightStickInput.y > 0.5f && leftStickInput.y == 0) {
//                owner.NextState(owner.ollieState);
                leftPopd = false;
                StartCoroutine(WaitForInput());
            }
        } else if (rightPopd) {
            if (leftStickInput.y > 0.5f && rightStickInput.y == 0) {
//                owner.NextState(owner.ollieState);
                rightPopd = false;
                StartCoroutine(WaitForInput());
            }
        }
    }

    private void GetKickflipInput() {
        Vector2 leftStickInput = LeftStick();
        Vector2 rightStickInput = RightStick();
        if (leftPopd) {
            if (leftStickInput.x < -0.5f && leftStickInput.y < -0.5f && rightStickInput.x > 0.5f && rightStickInput.y > 0.5f) {
//                owner.NextState(owner.kickflipState);
                leftPopd = false;
                StartCoroutine(WaitForInput());
            }
        } else if (rightPopd) {
            if (leftStickInput.x < -0.5f && rightStickInput.y < -0.5f && rightStickInput.x > 0.5f && leftStickInput.y > 0.5f) {
//                owner.NextState(owner.kickflipState);
                rightPopd = false;
                StartCoroutine(WaitForInput());
            }
        }
    }
}
