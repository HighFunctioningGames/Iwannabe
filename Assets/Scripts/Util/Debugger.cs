using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debugger : MonoBehaviour {

    GameObject player;

    TrailRenderer playerTrail;


    bool playerTrailSwitch;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        playerTrail = player.transform.GetComponentInChildren<TrailRenderer>();
        playerTrailSwitch = false;
        playerTrail.enabled = false;
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.T)) {
            TrailSwitch();
        }
    }

    void TrailSwitch() {
        if(playerTrailSwitch) {
            playerTrailSwitch = false;
            StartCoroutine(TrailReduce());
        } else if(!playerTrailSwitch) {
            playerTrailSwitch = true;
            StartCoroutine(TrailExpand());
        }
    }

    IEnumerator TrailReduce() {
            while(playerTrail.time > 0.1) {
                playerTrail.time = Mathf.Lerp(playerTrail.time, 0f, 2 * Time.deltaTime);
                yield return new WaitForEndOfFrame();
            }
            playerTrail.enabled = false;
    }

    IEnumerator TrailExpand() {
            playerTrail.enabled = true;
            while(playerTrail.time < 4.9) {
                playerTrail.time = Mathf.Lerp(playerTrail.time, 5f, Time.deltaTime);
                yield return new WaitForEndOfFrame();
            }
    }

}