using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DiretorBatalha : MonoBehaviour
{
    public robsonAndando robson;
    public BatalhaVilao dragaoVilao;
    public GameObject player;
    public GameObject vilao;
    private Vector3 playerPosition;
    private Vector3 vilaoPosition;

    private float distanciaPlayerVilao;
    private float distanciaAtaqueVilao = 10f;

    public bool robAtacando = false;
    private bool gameOver = false;

    private bool startBatalha = false;
    public ZonaDeAtaque zonaAtaque;
    public bool levantaPata = false;
    //public int danoVilao = (10,20, 30... ) maior peso pro 10, médio peso pro 20 e as vezes 30
    //o diretor sortear o valor que será o dano
    // dano = ao valor sorteado
    
    // Start is called before the first frame update
    void Start()
    {
        robson = GameObject.FindGameObjectWithTag("Player").GetComponent<robsonAndando>();
        dragaoVilao = GameObject.FindGameObjectWithTag("vilao").GetComponent<BatalhaVilao>();
        zonaAtaque = GameObject.Find("zona ataque").GetComponent<ZonaDeAtaque>();

    }

    void FixedUptade()
    {
        playerPosition = player.transform.position;
        vilaoPosition = vilao.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
         GameOver();

        if(zonaAtaque.PlayerZonaDeAtaque() && !levantaPata)
        {
            levantaPata = true;
            StartCoroutine("LevantaPata");
        }
        
    }

    IEnumerator LevantaPata()
    {
        dragaoVilao.AntecipaAtaque();
        yield return new WaitForSeconds(2);
        dragaoVilao.Ataque();
        yield return new WaitForSeconds(1);
        dragaoVilao.Idle();
        levantaPata = false;
    }

    IEnumerator AtaqueRobson()
    {
        robAtacando = true;
        robson.AtaqueRob();
        yield return new WaitForSeconds(3);
        dragaoVilao.DanoVilao();
        robAtacando = false;

    }


    private void GameOver()
    {
        if (!robson.EstaVivo())
        {
            gameOver = true;
        }

        if (gameOver)
        {
            Time.timeScale = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            startBatalha = true;
            Debug.Log("Batalha Inicia");
            vilao.SetActive(true);

        }
    }
   


}
