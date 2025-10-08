using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
/*
* Mimi Davis and Maile Fidale
* Project1
* Player movement and sound effects
*/
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;

    bool isGrounded = false;
    private Rigidbody2D rb;
    private float horizontalInput;
    private Animator animator;
    public AudioClip jumpSound;
    private AudioSource playerAudio;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAudio = GetComponent<AudioSource>();
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
            playerAudio.PlayOneShot(jumpSound, 1.0f);
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

    private void OnTriggerEnter2D(Collider2D other)
    {
           isGrounded = true;
           animator.SetBool("isJumping", !isGrounded);
    }
}
