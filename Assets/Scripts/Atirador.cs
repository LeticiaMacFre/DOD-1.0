using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atirador : MonoBehaviour
{

    public GameObject fireball;
    public GameObject mira;

    private GameObject player;
    private Vector3 target;

    private ZonaDeAtaque zonaAtaque;
    private ZonaDeDano zonaDano;

    private bool playerZonaAtaque;
    private bool playerZonaDano;
    private bool atirando;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");
        target = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);

        zonaAtaque = GameObject.Find("zona ataque").GetComponent<ZonaDeAtaque>();
        zonaDano = GameObject.Find("zona dano").GetComponent<ZonaDeDano>();

        playerZonaAtaque = false;
        playerZonaDano = false;

        atirando = true;
        StartCoroutine("Atira");

    }

    // Update is called once per frame
    void Update()
    {
        playerZonaAtaque = zonaAtaque.PlayerZonaDeAtaque();
        playerZonaDano = zonaDano.PlayerZonaDeDano();

        if (!playerZonaAtaque && !atirando)
        {
            //atirar
            StartCoroutine("Atira");
            atirando = true;
        }

        else if (playerZonaAtaque && atirando)
        {
            //o dragão precisa parar e ele vai atacar de outra maneira
            StopCoroutine("Atira");
            atirando = false;
        }


    }

    private void Fogo()
    {
        Instantiate(fireball, mira.transform.position, Quaternion.identity);
    }

    IEnumerator Atira()
    {
        do
        {
            Fogo();
            yield return new WaitForSeconds(Random.Range(3, 5));
        }
        while (atirando);
    }
}


