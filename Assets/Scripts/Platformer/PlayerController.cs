using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed;
    private float Move;

    public float jump;
    public bool isJumping;

    private Rigidbody2D player;

    // Define the goal position (adjust as needed)
    public float goalX = 10f;

    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move = Input.GetAxis("Horizontal");
        player.velocity = new Vector2(Speed * Move, player.velocity.y);

        // Move jump input check inside Update()
        if (Input.GetButtonDown("Jump"))
        {
            player.AddForce(new Vector2(player.velocity.x, jump), ForceMode2D.Impulse);
            Debug.Log("jump");
        }
    }
    // Method to check if player has reached the goal
    public bool HasReachedGoal()
    {
        return transform.position.x >= goalX;
    }
}