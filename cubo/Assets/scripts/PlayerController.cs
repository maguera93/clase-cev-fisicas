using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PhysicsCollision
{
    private Rigidbody rb;
    public float speed;
    private float axisX;
    private Vector2 velocity;
    public float jumpForce = 5;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    protected override void FixedUpdate()
    {
        base.FixedUpdate();

        velocity = rb.velocity;
        velocity.x = speed * axisX;
        if (touchWall)
            velocity.x = 0;

        rb.velocity = velocity;

        animator.SetBool("IsGrounded", isGrounded);
    }

    public void SetAxis(float x)
    {
        axisX = x;

        if (x > 0 && !isFacingRight || x < 0 && isFacingRight)
            Flip();

        animator.SetFloat("Speed", Mathf.Abs(x));
    }

    public void Jump()
    {
        if (!isGrounded)
            return;

        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
