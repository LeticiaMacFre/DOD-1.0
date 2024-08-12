using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Batalha : MonoBehaviour
{
    private BoxCollider2D collider;
    public bool startBatalha;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            startBatalha = true;
        }
    }

    public bool VerificaSeBatalhaIniciou()
    {
        return startBatalha;
    }
}
