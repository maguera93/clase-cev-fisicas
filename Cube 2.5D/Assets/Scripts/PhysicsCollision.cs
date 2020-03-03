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
    [Header("Wall")]
    public bool touchWall;
    public bool touchedWall;
    public bool justTouchWall;
    public LayerMask wallLayer;
    public bool isFacingRight = true;
    private Vector3 direction = Vector3.right;
    public Transform graphicTransform;

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
        CheckWall();
    }

    private void CheckGround()
    {
        wasGrounded = isGrounded;
        isGrounded = false;
        justGrounded = false;
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

                break;
            }
        }
    }

    private void CheckWall()
    {
        Vector3 position = transform.position;
        int sign = 1;

        touchedWall = touchWall;
        justTouchWall = false;

        for (int i = 0; i < 3; i++)
        {
            position.y += i * 0.5f * sign;
            ray = new Ray(position, direction);
            hit = new RaycastHit();

            touchWall = Physics.Raycast(ray, out hit, 1.1f, wallLayer);

            if (touchWall)
            {
                if (!touchedWall)
                    justTouchWall = true;

                break;
            }
        }
    }

    private void OnDrawGizmos()
    {
        DrawGroundGizmos();
        DrawWallGizmos();
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
    
    private void DrawWallGizmos()
    {
        Gizmos.color = Color.green;

        Vector3 pos = transform.position;
        int sign = 1;

        for (int i = 0; i < 3; i++)
        {
            pos.y += 0.5f * i * sign;
            sign *= -1;

            Gizmos.DrawRay(pos, direction);
        }
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;

        /* PARA 2D ES ASI
        Vector3 scale = graphicTransform.localScale;
        scale.x *= -1;
        graphicTransform.localScale = scale;*/

        Vector3 rotation = graphicTransform.eulerAngles;
        rotation.y *= -1;
        graphicTransform.eulerAngles = rotation;

        direction *= -1;
    }
}
