using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions_Physics : MonoBehaviour
{
    CollisionData c;

    int rayCount;


    void Start() {
        rayCount = 10;
        c = new CollisionData(rayCount, this.transform.GetChild(0).GetChild(0));
    }

    void Update() {
        c.DrawRays(Callback);
    }

    void Callback(int i) {
        if(Physics.Raycast(c.rays[i], 100)) {
            Debug.Log(i);
        }
    }
}

struct CollisionData {
    Transform colliderBody;

    public Ray[] rays;

    public bool raycastSwitch;

    public CollisionData(int rayCount, Transform body) {
        rays = new Ray[rayCount];
        colliderBody = body;
        raycastSwitch = true;
    }

    public delegate void CallBack(int i);
    
    public void DrawRays(CallBack obj) {
        ClearRays();
        DrawCardinalDirectionRays(obj);
        if(raycastSwitch) {
            DrawDebugRays();
        }
    }

    void ClearRays() {
        for(int i=0; i<rays.Length; i++) {
            rays[0] = new Ray();
        }
    }

    void DrawCardinalDirectionRays(CallBack obj) {
        Vector3 pos = colliderBody.position;
        Vector3 dir = new Vector3();
        for(int i=0; i<6; i++) {
            switch(i) {
                case 0:
                dir = colliderBody.forward;
                break;
                case 1:
                dir = -colliderBody.forward;
                break;
                case 2:
                dir = colliderBody.up;
                break;
                case 3:
                dir = -colliderBody.up;
                break;
                case 4:
                dir = colliderBody.right;
                break;
                case 5:
                dir = -colliderBody.right;
                break;
            }
            rays[i] = new Ray(pos, dir);
            obj(i);
        }
    }

    void DrawDebugRays() {
        for(int i=0; i<rays.Length; i++) {
            Debug.DrawRay(rays[i].origin, rays[i].direction, Color.cyan);
        }
    }
}
