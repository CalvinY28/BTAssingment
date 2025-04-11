using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 5f;
    public float jumpForce = 12f;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private float moveInput;
    private bool isGrounded;

    // Slowing the player when hit by stuff
    private bool isSlowed = false;
    private float slowTimer = 0f;
    public float slowDuration = 1f;
    private float originalMoveSpeed;
    private float originalJumpForce;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        originalMoveSpeed = moveSpeed;
        originalJumpForce = jumpForce;
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal"); // Raw for move mechanical movements

        if (Input.GetButtonDown("Jump") && isGrounded) // Check for jump
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer); // Checking ground using empty player object

        if (isSlowed) // Restore movement after time
        {
            slowTimer -= Time.deltaTime;
            if (slowTimer <= 0f)
            {
                moveSpeed = originalMoveSpeed;
                jumpForce = originalJumpForce;
                isSlowed = false;
            }
        }

    }

    void FixedUpdate()
    {

        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y); // Movement in fixed update

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bana") /*|| collision.gameObject.CompareTag("Poop")*/) // Removing poop collision debuff becasue they congest on platforms
        {
            ApplySlowEffect();
        }
    }

    private void ApplySlowEffect()
    {
        if (!isSlowed)
        {
            moveSpeed *= 0.5f; // Slow movement by half
            //jumpForce *= 0.5f; // Reduce jump by half // removing this becasue too OP
            isSlowed = true;
            slowTimer = slowDuration;
        }
        else
        {
            slowTimer = slowDuration; // If already slowed, reset the timer
        }
    }


    void OnDrawGizmosSelected() // Select the player to check the OverlapCircle
    {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, 0.2f);
    }

}
