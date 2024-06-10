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
    private float velAtaque = 1f;

    private bool Atacando = false;
    // Start is called before the first frame update
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
        distanciaPlayerVilao = Vector3.Distance(playerPosition, vilaoPosition);
        if (distanciaPlayerVilao <= distanciaAtaqueVilao && Atacando)
        {
            StartCoroutine(AtaqueSoco());
        }
    }

    IEnumerator AtaqueSoco()
    {
        Atacando = true;
        dragaoVilao.Ataque();
        yield return new WaitForSeconds(velAtaque);
        robson.Dano();
        Atacando = false;

    }
    
}
