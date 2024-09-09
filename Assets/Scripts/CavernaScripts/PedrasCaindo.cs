using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedrasCaindo : MonoBehaviour
{
    Rigidbody rb;
    BoxCollider2D boxCollider2D;
    public float distance;
    bool isFalling = false;



    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        Physics2D.queriesStartInColliders = false;
        if(isFalling == false)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position,Vector2.down,distance);
            Debug.DrawRay(transform.position,Vector2.down * distance, Color.black);

            if(hit.transform != null) 
            {
                if(hit.transform.tag == "Player")
                {
                      
                    isFalling = true;
                }
            }
        }
    }
}
