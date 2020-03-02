using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlapTest1B : MonoBehaviour
{
    private Collider[] colliders;
    private Collider[] collidersNonAlloc = new Collider[10];
    public float radius = 5;
    public LayerMask layer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        OverlapNonAlloc();
    }

    private void Overlap()
    {
        colliders = Physics.OverlapBox(transform.position, Vector3.one,
            Quaternion.identity, layer);

        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i] != null)
                Debug.Log(colliders[i].name);
        }
    }

    private void OverlapNonAlloc()
    {
        int hits = Physics.OverlapSphereNonAlloc(transform.position, radius,
            collidersNonAlloc, layer);

        if (hits > 0)
        {
            for (int i = 0; i < hits; i++)
            {
                Debug.Log(collidersNonAlloc[i].name);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        //Gizmos.DrawWireCube(transform.position, Vector3.one * 2);
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
