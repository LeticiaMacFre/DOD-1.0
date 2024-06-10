using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AureliusMove : MonoBehaviour
{
    private GameObject robson;
    private robsonAndando robsonMove;
    private Animator animAurelius;
    private SpriteRenderer spriteAurelius;
    private Vector3 robPosition;
    private Vector3 posAtual;
    private Vector3 posProx;
    public float offset = 2.5f;
    public float velocidade = 0.1f;
    
    // Start is called before the first frame update
    void Start()
    {
        robson = GameObject.FindGameObjectWithTag("Player");
        robsonMove = robson.GetComponent<robsonAndando>();
        animAurelius = GetComponent<Animator>();
        spriteAurelius = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        robPosition = robson.transform.position;

        if(robsonMove.IsMoving() == "parado")
        {
            posAtual = transform.position;
            animAurelius.SetLayerWeight(1, 0);
        }
        
        if(robsonMove.IsMoving() == "direita")
        {
            spriteAurelius.flipX = true;
            animAurelius.SetLayerWeight(1, 1);
            posProx = new Vector3(robPosition.x + offset, posAtual.y, 0);
            transform.position = Vector3.Lerp(posAtual, posProx, velocidade);
        }
        
        if(robsonMove.IsMoving() == "esquerda")
        {
            spriteAurelius.flipX = false;
            animAurelius.SetLayerWeight(1, 1);
            posProx = new Vector3(robPosition.x - offset, posAtual.y, 0);
            transform.position = Vector3.Lerp(posAtual, posProx, velocidade);
        }   
        
    
    }
}
