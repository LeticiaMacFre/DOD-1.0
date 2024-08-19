using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueJogador : MonoBehaviour
{
    [SerializeField]
    private Transform pontoAtaque;

    [SerializeField]
    private float raioAtaque;

    [SerializeField]
    private LayerMask LayersAtaque;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Atacar();
        }
    }

    private void OnDrawGizmos() {
        if (this.pontoAtaque != null) {
            Gizmos.DrawWireSphere(this.pontoAtaque.position, this.raioAtaque);
        }
    }

    private void Atacar() {
        Collider2D colliderInimigo = Physics2D.OverlapCircle(this.pontoAtaque.position, this.raioAtaque, this.LayersAtaque);
        if (colliderInimigo != null)
        {
            Debug.Log("Atacando objeto" +  colliderInimigo.name);

            // Causar dano a um inimigo
            Inimigo inimigo = colliderInimigo.GetComponent<Inimigo>();
            if (inimigo != null)
            {
                inimigo.ReceberDano();
            }
        }
    }
}                                                                                   
    