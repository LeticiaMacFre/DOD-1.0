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
    public GameObject fogo;

    private Vector3 playerPosition;
    private Vector3 vilaoPosition;

    private float distanciaPlayerVilao;
    private float distanciaAtaqueVilao = 10f;

    public bool robAtacando = false;
    private bool gameOver = false;

    private bool startBatalha = false;
    public bool levantaPata = false;
 

 

    void Start()
    {
        robson = GameObject.FindGameObjectWithTag("Player").GetComponent<robsonAndando>();
        dragaoVilao = GameObject.FindGameObjectWithTag("vilao").GetComponent<BatalhaVilao>();

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
