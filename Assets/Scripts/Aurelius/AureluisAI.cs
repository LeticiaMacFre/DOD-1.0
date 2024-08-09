using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AureluisAI : MonoBehaviour
{
    // The player's transform
    public Transform player;

    // The speed at which the NPC moves
    public float speed = 5.0f;

    // The minimum distance between the NPC and the player
    public float minDistance = 3.0f;

    // The animator component
    private Animator animator;

    // The sprite renderer component
    private SpriteRenderer spriteRenderer;

    // The vertical speed at which the NPC moves
    public float verticalSpeed = 5.0f;

    private void Start()
    {
        // Get the animator component
        animator = GetComponent<Animator>();

        // Get the sprite renderer component
        spriteRenderer = GetComponent<SpriteRenderer>();

        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        // Calculate the direction from the NPC to the player
        Vector2 direction = (player.position - transform.position).normalized;

        // Calculate the distance between the NPC and the player
        float distance = Vector2.Distance(transform.position, player.position);

        // If the distance is greater than the minimum distance, move the NPC towards the player
        if (distance > minDistance)
        {
            // Move the NPC towards the player
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.position.x, transform.position.y), speed * Time.deltaTime);

            // Update the NPC's vertical position to match the player's vertical position
            float targetY = player.position.y;
            float deltaY = targetY - transform.position.y;
            transform.position = new Vector2(transform.position.x, transform.position.y + deltaY * verticalSpeed * Time.deltaTime);

            // Flip the NPC's sprite if necessary
            if (direction.x > 0)
            {
                spriteRenderer.flipX = true;
            }
            else
            {
                spriteRenderer.flipX = false;
            }

            // Set the "IsMoving" boolean to true
            animator.SetBool("IsMoving", true); // Used to trigger the walking animation
        }
        else
        {
            // Set the "IsMoving" boolean to false
            animator.SetBool("IsMoving", false); // Used to trigger the idle animation
        }
    }
}

