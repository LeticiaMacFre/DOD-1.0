using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AureliusController : MonoBehaviour
{

    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public float directionChangeThreshold = 0.1f;

    //private Rigidbody2D rb;
    //private BoxCollider2D collider;
    private SpriteRenderer spriteRenderer;
    private float previousDirection = 0f;
    private Transform playerTransform;
    private bool isGrounded = true;

    private Collider2D npcCollider;


    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        npcCollider = GetComponent<Collider2D>();
    }

    void Update()
    {
        float playerDirection = (playerTransform.position.x - transform.position.x) / Mathf.Abs(playerTransform.position.x - transform.position.x);

        // Check if the direction has changed
        if (Mathf.Abs(playerDirection - previousDirection) > directionChangeThreshold)
        {
            // Invert the sprite if the direction has changed
            if (playerDirection > 0f)
            {
                spriteRenderer.flipX = true;
            }
            else if (playerDirection < 0f)
            {
                spriteRenderer.flipX = false;
            }

            previousDirection = playerDirection;
        }

        // Move the NPC in the opposite direction of the player
       // rb.velocity = new Vector2(-playerDirection * moveSpeed, rb.velocity.y);

        // Jump when the player jumps
        if (IsPlayerJumping() && isGrounded)
        {
           // rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }

        // Check if the player is close to the NPC
        float distanceToPlayer = Vector2.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position);
        if (distanceToPlayer < 3.0f) 
        {

            npcCollider.enabled = false;
        }
        else
        {
            // Enable the NPC's collider
            npcCollider.enabled = true;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    bool IsPlayerJumping()
    {
        // Raycast down from the player to check if they are grounded
        RaycastHit2D hit = Physics2D.Raycast(playerTransform.position, Vector2.down, 0.1f);
        if (hit.collider != null)
        {
            // If the player is grounded, check if their vertical velocity is greater than 0
            if (hit.collider.gameObject.CompareTag("ground") && playerTransform.GetComponent<Rigidbody2D>().velocity.y > 0f)
            {
                return true;
            }
        }
        return false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string nome = collision.gameObject.name;
        Debug.Log($"Colisão com: {nome}");
    }
}