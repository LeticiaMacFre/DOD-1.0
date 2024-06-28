using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatalhaVilao : MonoBehaviour
{
    private int vidaVilao = 150;
    private int dano;
    
    private Animator animVilao;

    private SpriteRenderer spriteInimigo;

    public ZonaDeAtaque zonaDeAtaque;

    private Transform posicaoDoJogador;

    public float speed;

    public bool robAtack = false;

    // Start is called before the first frame update
    void Start()
    {
        posicaoDoJogador = GameObject.FindGameObjectWithTag("Player").transform;
        zonaDeAtaque = GameObject.Find("zona ataque").GetComponent<ZonaDeAtaque>();
        spriteInimigo = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

        robAtack = zonaDeAtaque.PlayerZonaDeAtaque();

        if(robAtack)
        {
            SeguirJogador();
        }
    }

    public void AntecipaAtaque()
    {
        animVilao.SetLayerWeight(1, 1);
    }

    public void DanoVilao()
    {
        
        vidaVilao = vidaVilao - dano;
    }

    public void Ataque()
    {
        animVilao.SetLayerWeight(2, 1);
    }


    public void Idle()
    {
        animVilao.SetLayerWeight(1, 0);
        animVilao.SetLayerWeight(2, 0);
    }

   private void SeguirJogador()
   {
        if (posicaoDoJogador.gameObject != null)
        {
            transform.position = Vector2.MoveTowards(new Vector2(transform.position.x,0), new Vector2(posicaoDoJogador.position.x,0), speed * Time.deltaTime);
        }
       
   }

}
