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

    public bool robAtacando = false;
    
    //public int danoVilao = (10,20, 30... ) maior peso pro 10, médio peso pro 20 e as vezes 30
    //o diretor sortear o valor que será o dano
    // dano = ao valor sorteado
    
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


        if (distanciaPlayerVilao <= distanciaAtaqueVilao && !robAtacando)
        {
            StartCoroutine(AtaqueSoco());
        }

        if (distanciaPlayerVilao <= distanciaAtaqueVilao && Input.GetMouseButton(0))
        {
            StartCoroutine(AtaqueRobson());
        }
    }

    IEnumerator AtaqueSoco()
    {
        dragaoVilao.AntecipaAtaque();
        yield return new WaitForSeconds(velAtaque);
        if(distanciaPlayerVilao <= distanciaAtaqueVilao)
        {
            dragaoVilao.Ataque();
            robson.Dano();
        }
    }

    IEnumerator AtaqueRobson()
    {
        robAtacando = true;
        robson.AtaqueRob();
        yield return new WaitForSeconds(5);
        dragaoVilao.DanoVilao();
        robAtacando = false;

    }

    
    

   

    
}
