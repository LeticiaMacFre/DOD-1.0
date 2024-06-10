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
    void FixedUpdate()
    {
        //float posAurelius = robPosition.x + offset;
        //transform.position = new Vector3(Mathf.Lerp(posAtual.x, robPosition.x + offset, velocidade), posAtual.y, 0);
        //transform.position = new Vector3(posAurelius, posAtual.y, 0);
    }

    private void Update()
    {
        robPosition = robson.transform.position;

        /*
        if (Input.GetKey(KeyCode.A))
        {
            animAurelius.SetLayerWeight(1, 1);
            spriteAurelius.flipX = false;
        }
        else
        {
            animAurelius.SetLayerWeight(1, 0);
            
        }

        if (Input.GetKey(KeyCode.D))
        {
            animAurelius.SetLayerWeight(1, 1);
            spriteAurelius.flipX = true;
        }
        else
        {
            animAurelius.SetLayerWeight(1, 0);
        }
        */

        if(robsonMove.IsMoving() == "parado")
        {
            posAtual = transform.position;
        }
        else if(robsonMove.IsMoving() == "direita")
        {
            spriteAurelius.flipX = true;
            posProx = new Vector3(robPosition.x + offset, posAtual.y, 0);
            transform.position = Vector3.Lerp(posAtual, posProx, velocidade);
        }
        else if(robsonMove.IsMoving() == "esquerda")
        {
            spriteAurelius.flipX = false;
            posProx = new Vector3(robPosition.x - offset, posAtual.y, 0);
            transform.position = Vector3.Lerp(posAtual, posProx, velocidade);
        }   
        
    
    }
}
