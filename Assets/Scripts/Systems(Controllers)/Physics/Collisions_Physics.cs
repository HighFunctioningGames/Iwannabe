using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions_Physics : MonoBehaviour
{
    public Vector3 collision;
    public LayerMask layer;

    // Start is called before the first frame update
    void Start()
    {
        collision = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        var ray = new Ray(this.transform.position, this.transform.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100)) {
            
        }
    }

    void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(collision, 0.2f);
    }
}
