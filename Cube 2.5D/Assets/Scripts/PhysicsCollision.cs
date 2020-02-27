using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsCollision : MonoBehaviour
{
    [Header("Ground")]
    public bool isGrounded;
    public bool justGrounded;
    public bool wasGrounded;
    public LayerMask groundLayer;

    private Ray ray;
    private RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckGround();
    }

    private void CheckGround()
    {
        wasGrounded = isGrounded;
        isGrounded = false;

        Vector3 pos = transform.position;
        int sign = 1;

        for (int i = 0; i < 3; i++)
        {
            pos.x += i * 0.5f * sign;

            ray = new Ray(pos, Vector3.down);
            hit = new RaycastHit();

            isGrounded = Physics.Raycast(ray, out hit, 1.1f, groundLayer);

            if (isGrounded)
            {
                if (!wasGrounded)
                    justGrounded = true;

                return;
            }
        }
    }

    private void OnDrawGizmos()
    {
        DrawGroundGizmos();
    }

    private void DrawGroundGizmos()
    {
        Gizmos.color = Color.magenta;

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
