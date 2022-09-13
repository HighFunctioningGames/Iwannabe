using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions_Physics : MonoBehaviour
{
    CollisionData c;

    int rayCount;
    public StateMachine sm;

    void Start() 
    {
        rayCount = 6;
        c = new CollisionData(rayCount, this.transform.GetChild(0).GetChild(0));
        c.InitDebugRayColorArray();
        sm = GameObject.FindGameObjectWithTag("GameController").GetComponent<StateMachine>();
    }

    void Update() 
    {
        c.DrawRays(Callback);
        ApplyGravity();
    }

    void ApplyGravity() 
    {
        if(!sm.p.isGrounded)
        {
            if(sm.p.velocity.y > -1.5f) 
            {
                sm.p.velocity.y -= 0.1f;
            } 
            else 
            {
                sm.p.velocity.y = -1.5f;
            }
        } 
        else 
        {
            sm.p.velocity.y = 0;      
        }
    }

    void Callback(int i) 
    {
        RaycastHit hit;
        if(Physics.Raycast(c.rays[i], out hit, 20)) 
        {
            if(hit.transform.gameObject.CompareTag("Ground"))
            {
                sm.SetCollisionText(i);
                if(i == 3) 
                {
                    Debug.Log("test");
                }
                sm.p.isGrounded = true;
            } 
            else 
            {
                sm.p.isGrounded = false;
            }
        }
    }
}

struct CollisionData 
{
    Transform colliderBody;

    public Ray[] rays;

    public bool raycastSwitch;

    public Color[] debugRayColor;

    public CollisionData(int rayCount, Transform body) 
    {
        rays = new Ray[rayCount];
        colliderBody = body;
        raycastSwitch = true;
        debugRayColor = new Color[rayCount];
    }

    public delegate void CallBack(int i);
    public void DrawRays(CallBack obj) 
    {
        for(int i=0; i<rays.Length; i++) 
        {
            rays[i] = new Ray(colliderBody.position, Direction.rayDir.GetDirRel(i));
            if(raycastSwitch) 
            {
                Debug.DrawRay(rays[i].origin, rays[i].direction * 2, debugRayColor[i]);
            }
            obj(i);
        }      
    }

    public void InitDebugRayColorArray() 
    {
        for(int i=0; i<rays.Length; i++) 
        {
            debugRayColor[i] = Color.black; 
            switch(i) 
            {
                case 0:
                    debugRayColor[i] = Color.blue;
                    break;
                case 1:
                    debugRayColor[i] = Color.cyan;
                    break;
                case 2:
                    debugRayColor[i] = Color.green;
                    break;
                case 3:
                    debugRayColor[i] = Color.magenta;
                    break;
                case 4:
                    debugRayColor[i] = Color.red;
                    break;
                case 5:
                    debugRayColor[i] = Color.yellow;
                    break;
            }
        }  
    }

}
