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

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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

    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y); // Movement in fixed update

        //isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer); // Checking ground using empty player object

    }
    void OnDrawGizmosSelected() // Select the player to check the OverlapCircle
    {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, 0.2f);
    }

}
