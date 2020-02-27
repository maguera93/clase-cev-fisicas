using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsTest : MonoBehaviour
{
    Ray ray; // rayo
    RaycastHit hit; // objeto con el que ha chocado el rayo
    public LayerMask layer; // capa de lo que choca con el rayo

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 pos = transform.position;
        int sign = 1;

        for (int i = 0; i < 3; i++)
        {
            pos.x += 0.5f * i * sign;
            sign *= -1;

            ray = new Ray(transform.position, Vector3.down);
            hit = new RaycastHit();

            if (Physics.Raycast(ray, out hit, 1.1f, layer))
            {
                Debug.Log(hit.transform.name);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color32(254, 10, 251, 255);

        Vector3 pos = transform.position;
        int sign = 1;

        for (int i = 0; i < 3; i++)
        {
            pos.x += 0.5f * i * sign;
            sign *= -1;

            Gizmos.DrawRay(pos, Vector3.down);
        }
    }
}
