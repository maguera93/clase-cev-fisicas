using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlapTest : MonoBehaviour
{
    Collider[] hits;
    Collider[] hitsNonAlloc = new Collider[10];
    public LayerMask layer;
    public float radius = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // OverlapBox();
        OverlapSphere();
    }

    private void OverlapBox()
    {
        hits = Physics.OverlapBox(transform.position, Vector3.one, Quaternion.identity, layer);

        for (int i = 0; i < hits.Length; i++)
        {
            Debug.Log(hits[i].name);
        }
    }

    private void OverlapSphere()
    {
        int colisions = Physics.OverlapSphereNonAlloc(transform.position, radius, hitsNonAlloc);

        if (colisions > 0)
        {
            for (int i = 0; i < colisions; i++)
            {
                Debug.Log(hitsNonAlloc[i].name);
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
