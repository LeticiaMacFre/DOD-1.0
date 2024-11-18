using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArvoresCaindo : MonoBehaviour
{
    public GameObject arvore;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            arvore.SetActive(true);
        }
    }
}
