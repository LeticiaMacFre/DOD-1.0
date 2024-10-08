using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatalhaVilao : MonoBehaviour
{ 
    private int vidaVilao = 150;
    private int dano = 30;
    
    private Animator animVilao;

    private SpriteRenderer spriteInimigo;

    public ZonaDeAtaque zonaDeAtaque;

    public ZonaDeDano zonaDeDano;

    private Transform posicaoDoJogador;

    public float speed;

    public bool robAtack = false;
    public bool robAtackDano = false;
    public bool inicioAtaque = false;
    public bool robsonColisao = false;
    
    // Start is called before the first frame update
    void Start()
    {
        posicaoDoJogador = GameObject.FindGameObjectWithTag("Player").transform;
        
        zonaDeAtaque = GameObject.Find("zona ataque").GetComponent<ZonaDeAtaque>();
        zonaDeDano = GameObject.Find("zona dano").GetComponent<ZonaDeDano>();
       
        spriteInimigo = GetComponent<SpriteRenderer>();
        animVilao = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        robAtack = zonaDeAtaque.PlayerZonaDeAtaque();
        robAtackDano = zonaDeDano.PlayerZonaDeDano();

        if(robAtack && !robAtackDano)
        {
            SeguirJogador();
        }


        if(robAtack && robAtackDano && !inicioAtaque)
        {
            StartCoroutine(AtaquePatada());
            animVilao.SetLayerWeight(3, 0);
        }

        else
        {
            StopCoroutine(AtaquePatada());
        }

        if(!robAtack)
        {
            animVilao.SetLayerWeight(3, 0);
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
        animVilao.SetLayerWeight(1, 0);
        animVilao.SetLayerWeight(2, 1);
    }


    public void Idle()
    {
        animVilao.SetLayerWeight(0, 1);
        animVilao.SetLayerWeight(1, 0);
        animVilao.SetLayerWeight(2, 0);
        animVilao.SetLayerWeight(3, 0);
    }

   private void SeguirJogador()
   {
        if (posicaoDoJogador.gameObject != null && !inicioAtaque)
        {
            transform.position = Vector2.MoveTowards(new Vector2(transform.position.x,0), new Vector2(posicaoDoJogador.position.x,0), speed * Time.deltaTime);
            animVilao.SetLayerWeight(3, 1);
        }

       
   }

  
    IEnumerator AtaquePatada()
    {
        inicioAtaque = !inicioAtaque;
        yield return new WaitForSeconds(2.0f);
        AntecipaAtaque();
        yield return new WaitForSeconds(2.0f);
        Ataque();
        yield return new WaitForSeconds(1.0f);
        Idle();
        inicioAtaque = !inicioAtaque;

    }

    

}
