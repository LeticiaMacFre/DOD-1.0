using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatalhaVilao : MonoBehaviour
{
    private int vidaVilao = 150;
    private int dano;
    private Animator animVilao;

    public GameObject player;

    public float speed;
    

    // Start is called before the first frame update
    void Start()
    {
        animVilao = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
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
        
    }

}
