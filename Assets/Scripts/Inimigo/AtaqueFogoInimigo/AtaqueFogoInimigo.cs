using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueFogoInimigo : MonoBehaviour
{
    public Transform posicaoDoPlayer;

    private float velocidade = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        posicaoDoPlayer = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Trajetoria()
    {
        transform.position = Vector2.MoveTowards(transform.position, posicaoDoPlayer.position, velocidade * Time.deltaTime);
    }
}
