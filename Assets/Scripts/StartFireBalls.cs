using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartFireBalls : MonoBehaviour
{

    private BoxCollider2D boxCollider;
    private bool startFireballs;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            startFireballs = true;
        }
    }

    public bool VerifyStartFireballs()
    {
        return startFireballs;
    }


    
}
