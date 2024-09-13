using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedrasCaindo : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            transform.root.GetComponent<PedraController>().AtivarGravidade();
        }
    }
}
