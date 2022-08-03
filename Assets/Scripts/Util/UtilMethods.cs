using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class UtilMethods : MonoBehaviour {

      //dumb util method, scales lol
    public string TrimString(string str) {
        string[] endingsToBeTrimmed = { "State" };
        foreach(string ending in endingsToBeTrimmed) {
            if(str.EndsWith(ending)) {
                str = str.Substring(0, str.Length-ending.Length);
            }
        }
        return str;
    }
}