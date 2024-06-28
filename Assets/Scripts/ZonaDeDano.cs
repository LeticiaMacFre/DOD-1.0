using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonaDeDano : MonoBehaviour
{
    public bool robsonAtaque = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            robsonAtaque = !robsonAtaque;
            Debug.Log("entrou na zona de dano");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            robsonAtaque = !robsonAtaque;
            Debug.Log("saiu da zona de dano");
        }
    }

    public bool PlayerZonaDeDano()
    {
        return robsonAtaque;
    }
}
