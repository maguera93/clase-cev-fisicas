using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsCollision1B : MonoBehaviour
{
    [Header("Ground")]
    public bool isGrounded;
    public bool wasGrounded;
    public bool justGrounded;
    public LayerMask groundLayer;
    [Header("Wall")]
    public bool touchWall;
    public bool touchedWall;
    public bool justTouchWall;
    public LayerMask wallLayer;

    Ray ray;
    RaycastHit hit;

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
        Vector3 position = transform.position;
        int sign = 1;
        wasGrounded = isGrounded;
        isGrounded = false;
        justGrounded = false;

        for (int i = 0; i < 3; i++)
        {
            position.x += i * 0.5f * sign;
            sign *= -1;

            ray = new Ray(position, Vector3.down);
            hit = new RaycastHit();

            isGrounded = Physics.Raycast(ray, out hit, 1.1f, groundLayer);

            if (isGrounded)
            {
                if (!wasGrounded)
                    justGrounded = true;
                break;
            }
        }
    }
}
