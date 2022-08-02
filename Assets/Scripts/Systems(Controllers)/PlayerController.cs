using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour {

   
    public Camera prototypeCamera;

    public Player p;

    public void Start() {
        p = this.GetComponent<Player>();
    }

    public void Update() {
    }
}