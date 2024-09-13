using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCenaTeste : MonoBehaviour
{
    public bool fala1 = false;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            fala1 = !fala1;
        }

        
    }

    public bool Dialogo1()
    {
        return fala1;
    }
}
