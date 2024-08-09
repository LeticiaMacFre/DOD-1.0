using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueJogador : MonoBehaviour
{
    [SerializeField]
    private Transform pontoAtaqueDireita;

    [SerializeField]
    private Transform pontoAtaqueEsquerda;

    [SerializeField]
    private float raioAtaque;

    [SerializeField]
    private LayerMask LayersAtaque;

    [SerializeField]
    private robsonAndando Robson;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Atacar();
        }
    }

    private void OnDrawGizmos() {
        if (this.pontoAtaqueDireita != null) {
            Gizmos.DrawWireSphere(this.pontoAtaqueDireita.position, this.raioAtaque);
        }
        if (this.pontoAtaqueDireita != null) {
            Gizmos.DrawWireSphere(this.pontoAtaqueEsquerda.position, this.raioAtaque);
        }
    }

    private void Atacar() {
        Transform pontoAtaque;
        if (this.Robson.direcaoMovimento == DirecaoMovimento.Direita){
            pontoAtaque = this.pontoAtaqueDireita;
        } else {
            pontoAtaque = this.pontoAtaqueEsquerda;
        }
        Collider2D colliderInimigo = Physics2D.OverlapCircle(pontoAtaque.position, this.raioAtaque, this.LayersAtaque);
        if (colliderInimigo != null){

            Debug.Log("Atacando objeto" +  colliderInimigo.name);

            // Causar dano a um inimigo
            Inimigo inimigo = colliderInimigo.GetComponent<Inimigo>();
            if (inimigo != null){
                inimigo.ReceberDano();
            }
        }
    }
}                                                                                   
    