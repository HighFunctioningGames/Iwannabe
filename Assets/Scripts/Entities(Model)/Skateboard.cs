using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skateboard : MonoBehaviour
{
    GameObject owner;

    public float durability;

    // Start is called before the first frame update
    void Awake()
    {
        owner = this.gameObject;
        durability = 100f;
        this.gameObject.SetActive(false);
    }

    public void SwitchOff() 
    {
        this.gameObject.SetActive(false);
    }

    public void SwitchOn() 
    {
        this.gameObject.SetActive(true);
    }
}
