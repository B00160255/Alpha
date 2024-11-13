using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f; // Movement speed
    public float jumpForce = 10f; // Jump force
    public bool isOnGround = true; // Whether the player is on the ground (default to true)
    private Rigidbody rb;
    private Animator animator;

    public bool gameOver = false; // Flag to track if the game is over

    void Start()
    {
        // Get the Rigidbody and Animator components
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // If the game is over, stop movement and don't process any further actions
        if (gameOver)
        {
            return; // Exit the update method early if the game is over
        }

        // Handle horizontal movement (A/D or Left/Right arrow keys)
        float moveHorizontal = Input.GetAxis("Horizontal");

        // Calculate the movement vector along the X-axis
        Vector3 movement = new Vector3(moveHorizontal, 0, 0) * speed;

        // Apply the movement to the Rigidbody (keep Y velocity to prevent falling)
        rb.velocity = new Vector3(movement.x, rb.velocity.y, rb.velocity.z);

        // Set the Speed parameter in Animator (positive for forward, negative for backward)
        if (animator != null)
        {
            animator.SetFloat("Speed", moveHorizontal);
        }

        // Handle jumping (only if player is on the ground)
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            Jump();
        }
    }

    private void Jump()
    {
        // Apply an upward force to simulate jumping
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        // Set isOnGround to false to prevent further jumps until landing
        isOnGround = false;

        // Optionally, trigger a jump animation (you can customize this as needed)
        if (animator != null)
        {
            animator.SetTrigger("Jump_trig");
        }
    }

    // This method is called when the player collides with something
    void OnCollisionEnter(Collision collision)
    {
        // Check if the player is colliding with the ground (or anything you consider ground)
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true; // Set isOnGround to true when the player touches the ground
        }

        // Check if the player is colliding with the "Killbox"
        if (collision.gameObject.CompareTag("Killbox") && !gameOver)
        {
            gameOver = true; // Set gameOver to true when the player touches the killbox
        }
    }
}
