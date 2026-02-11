using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInputHandler), typeof(Rigidbody2D))]
public class Player : Character
{
    // Jumping logic
    [Header("Movement Settings")]
    [SerializeField] private float jumpForce = 12f;             // The force of my jump
    [SerializeField] private LayerMask groundLayer;             // Checking to see if I'm standing on the ground layer
    [SerializeField] private Transform groundCheck;             // Position of my ground check
    [SerializeField] private float groundCheckRadius = 0.2f;    // Size of my ground check

    // Private variables
    private Rigidbody2D rBody;          // Used to apply a force to move or jump
    private PlayerInputHandler input;   // Reads the input
    private bool isGrounded;            // Holds the result of the ground check operation
    private bool GravityBool = true;
    private float currentSpeedModifier = 1f;

    /*
     * TO-DO: Add isGrounded property to help trigger animation
    */

    protected override void Awake()
    {
        base.Awake();
        // Initialize
        rBody = GetComponent<Rigidbody2D>();
        input = GetComponent<PlayerInputHandler>();
    }

    private void Update()
    { 
        // Perform my ground check
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        Debug.Log(isGrounded);

        anim.SetFloat("xVelocity", Mathf.Abs(rBody.linearVelocity.x));

        // Jumping
        anim.SetBool("isGrounded", isGrounded);
        anim.SetFloat("yVelocity", rBody.linearVelocity.y);

        // Handle sprite flipping
        if(input.MoveInput.x != 0 && !isDead)
        {
            transform.localScale = new Vector3(Mathf.Sign(input.MoveInput.x), 1, 1);
        }
    }

    void FixedUpdate()
    {
        if(IsDead)
        {
            return;
        }

        // Handle movement
        HandleMovement();
        // Handle jumping
        HandleJump();
        // Optional: Handle mario-like falling

        if (GravityBool == true)
        {

        }
    }



    private void HandleMovement()
    {
        // We get MoveInput from InputHandler
        // We get MoveSpeed from our Parent class (Character)
        float horizontalVelocity = input.MoveInput.x * MoveSpeed * currentSpeedModifier;

        rBody.linearVelocity = new Vector2(horizontalVelocity, rBody.linearVelocity.y);

        currentSpeedModifier = 1f;
    }

    private void HandleJump()
    {
        // Only jump if the input handle's jump property is true
        if(input.JumpTriggered && isGrounded)
        {
            // Apply Jump Force
            ApplyJumpForce();

            // "Consume the jump"
        }
    }

    private void ApplyJumpForce()
    {
        // Reset vertical velocity first to ensure consistent jump height.
        rBody.linearVelocity = new Vector2(rBody.linearVelocity.x, 0);

        rBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    public void ApplySpeedModifier(float speedModifier)
    {
        currentSpeedModifier = speedModifier;
    }

    public override void Die()
    {
        isDead = true;
        Debug.Log("Player has died");


        // Player DEATH Logic!
        // =============================
        //Add player specific death logic
       // Set death animation
       // Trigger death UI
       // Initate Level Reset Logic
    }

    public void Gravity()
    {
        Debug.Log("Shouldn't you be on the roof right now");
        rBody.gravityScale = -2;
        this.transform.rotation = Quaternion.Euler(0f, 0f, -180f);
    }
    public void Normal()
    {
        rBody.gravityScale = 5;
        this.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
    }
}
