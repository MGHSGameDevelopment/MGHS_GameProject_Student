using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed;
    private float Move;
    public float jump; // Force applied to jump
    private Rigidbody2D player;

    public int maxJumps = 15; // Maximum number of jumps allowed
    private int remainingJumps; // Tracks jumps left

    private bool isGrounded; // Tracks if player is grounded

    void Start()
    {
        player = GetComponent<Rigidbody2D>();

        if (player == null)
        {
            Debug.LogError("Rigidbody2D component is missing on the player!");
        }

        remainingJumps = maxJumps; // Initialize remaining jumps
    }

    void Update()
    {
        // Check if player is grounded using a simple velocity check (can be replaced with a better check like Raycast or Collider)
        isGrounded = Mathf.Abs(player.velocity.y) < 0.1f;

        // Handle horizontal movement
        Move = Input.GetAxis("Horizontal");
        player.velocity = new Vector2(Speed * Move, player.velocity.y);

        // Handle jump input (allow jump only if grounded and jumps remaining)
        if (Input.GetButtonDown("Jump") && isGrounded && remainingJumps > 0)
        {
            Jump();
        }
    }

    void FixedUpdate()
    {
        if (player.velocity.y < 0) // Check if player is falling
        {
            player.AddForce(Vector2.down * 5.0f); // Apply additional downward force
        }
    }

    void Jump()
    {
        // Apply jump force
        player.AddForce(new Vector2(0, jump), ForceMode2D.Impulse);
        remainingJumps--; // Decrease remaining jumps
        Debug.Log("Jumps Left: " + remainingJumps);

        // Optional: Debug if jumps run out
        if (remainingJumps <= 0)
        {
            Debug.LogWarning("No jumps remaining!");
        }
    }

    // Keep the FinishBoxTrigger method
    public bool FinishBoxTrigger()
    {
        // Add logic here if needed, or use it to communicate with other scripts
        Debug.Log("FinishBoxTrigger method called in PlayerController.");
        return true; // Example return value
    }
}