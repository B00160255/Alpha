using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 90f; // how fast the player moves
    public float jumpForce = 10f; // how high the player jumps
    public bool isOnGround = true; // checks if the player is on the ground (default is true)
    private Rigidbody rb;
    private Animator animator;

    public bool gameOver = false; // tracks if the game is over

    void Start()
    {
        // grab the Rigidbody and Animator components attached to the player
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // if the game is over, stop the player from moving or doing anything
        if (gameOver)
        {
            return; // exit early if the game is over
        }

        // get player input for horizontal movement (A/D or Left/Right arrow keys)
        float moveHorizontal = Input.GetAxis("Horizontal");

        // create the movement vector along the X-axis based on input and speed
        Vector3 movement = new Vector3(moveHorizontal, 0, 0) * speed;

        // apply the movement to the Rigidbody (keep the Y velocity for falling)
        rb.velocity = new Vector3(movement.x, rb.velocity.y, rb.velocity.z);

        // update the Animator with the movement speed for animations (positive for forward, negative for backward)
        if (animator != null)
        {
            animator.SetFloat("Speed", moveHorizontal);
        }

        // check for jump input (spacebar) and if the player is on the ground
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            Jump(); // make the player jump
        }
    }

    private void Jump()
    {
        // apply an upward force to simulate the jump
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        // set isOnGround to false to prevent another jump while in the air
        isOnGround = false;

        // trigger a jump animation if one exists
        if (animator != null)
        {
            animator.SetTrigger("Jump_trig");
        }
    }

    // this method is called when the player collides with something
    void OnCollisionEnter(Collision collision)
    {
        // check if the player is colliding with the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true; // player is back on the ground, so allow jumping again
        }

        // check if the player collides with a "Killbox" (e.g., area that ends the game)
        if (collision.gameObject.CompareTag("Killbox") && !gameOver)
        {
            gameOver = true; // set the game over flag if the player hits a killbox
        }
    }
}
