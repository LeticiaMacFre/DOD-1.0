using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AureliusOffset : MonoBehaviour
{
    public float idleOffsetDistance = 3.0f; // adjust this value to your liking
    public float idleOffsetSpeed = 3.0f; // adjust this value to your liking

    private Transform player;
    private Transform npc;
    private Vector2 idleOffsetPosition;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        npc = transform;
    }

    void Update()
    {
        // Check if the player is moving
        float playerSpeed = player.GetComponent<Rigidbody2D>().velocity.magnitude;
        if (playerSpeed < 0.1f) // adjust this value to your liking
        {
            // Player is not moving, set idle offset
            SetIdleOffset();
        }
        else
        {
            // Player is moving, cancel idle offset
            CancelIdleOffset();
        }
    }

    void SetIdleOffset()
    {
        // Calculate the idle offset position
        idleOffsetPosition = npc.position + (npc.position - player.position).normalized * idleOffsetDistance;

        // Move the NPC to the idle offset position
        npc.position = Vector2.MoveTowards(npc.position, idleOffsetPosition, idleOffsetSpeed * Time.deltaTime);
    }

    void CancelIdleOffset()
    {
        // Move the NPC back to the player
        npc.position = Vector2.MoveTowards(npc.position, player.position, idleOffsetSpeed * Time.deltaTime);
    }
}