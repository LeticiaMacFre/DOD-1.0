using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialogo : MonoBehaviour
{
    public bool DialogoTrigger = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            DialogoTrigger = !DialogoTrigger;
        }
    }

    public bool PlayerPrimeiroDialogo()
    {
        return DialogoTrigger;
    }

}