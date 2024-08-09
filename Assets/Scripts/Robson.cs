using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robson : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rigidbody;

    [SerializeField]
    private float velociadeMovimento;


    // Update is called once per frame
    void Update()
    {
        float esquerda = Input.GetAxisRaw("esquerda");
        float direita = Input.GetAxisRaw("direita");

        Vector2 direcao = new Vector2 (esquerda, direita);
        direcao = direcao.normalized;

        Debug.Log(direcao + " => " +  direcao.magnitude);

        this.rigidbody.velocity = direcao * this.velociadeMovimento;
        
    }
}
