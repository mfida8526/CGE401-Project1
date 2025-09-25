using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;

    bool isGrounded = false;
    private Rigidbody2D rb;
    private float horizontalInput;
    private Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        
        if (groundCheck == null)
        {
            Debug.LogError("GroundCheck not assigned to the player controller!");
        }
    }

    // Update is called once per frame
    void Update()
    {

        horizontalInput = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
            animator.SetBool("isJumping", !isGrounded);
        }
    }

    void FixedUpdate()
    {
       rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

       animator.SetFloat("xVelocity", Mathf.Abs(rb.velocity.x));

       animator.SetFloat("yVelocity", rb.velocity.y);

       isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);


       if (horizontalInput > 0)
       {
            transform.rotation = Quaternion.Euler(0, 0, 0);
       }
       else if (horizontalInput < 0)
       {
            transform.rotation = Quaternion.Euler(0, 180, 0);
       }

    }

    private void OnTriggerEnter2D(Collider2D collison)
    {
           isGrounded = true;
           animator.SetBool("isJumping", !isGrounded);
    }
}
