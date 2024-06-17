using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonaDeAtaque : MonoBehaviour
{
    public bool playerAtacando = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerAtacando = !playerAtacando;
            Debug.Log("Player entrou na Zona de Ataque");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerAtacando = !playerAtacando;
            Debug.Log("Player saiu na Zona de Ataque");
        }
    }

    public bool PlayerZonaDeAtaque()
    {
        return playerAtacando;
    }
}
