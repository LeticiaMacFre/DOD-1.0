using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialogo : MonoBehaviour
{
    public bool InicioDialogo = false;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            InicioDialogo = !InicioDialogo;
        }
    }

    public bool ComecarDialogo()
    {
        return InicioDialogo;
    }




}