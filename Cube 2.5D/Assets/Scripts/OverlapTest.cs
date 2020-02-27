using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlapTest : MonoBehaviour
{
    Collider[] hits;
    public LayerMask layer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        hits = Physics.OverlapBox(transform.position, Vector3.one, 
            Quaternion.identity, layer);

        for (int i = 0; i < hits.Length; i++)
        {
            Debug.Log(hits[i].name);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(transform.position, Vector3.one * 2);
    }
}
