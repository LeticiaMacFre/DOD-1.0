using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonaDeDano : MonoBehaviour
{
    public bool playerAttack = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerAttack = !playerAttack;
            Debug.Log("Player entrou na Zona de Ataque");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerAttack = !playerAttack;
            Debug.Log("Player saiu na Zona de Ataque");
        }
    }

    public bool PlayerZonaDeDano()
    {
        return playerAttack;
    }
}
