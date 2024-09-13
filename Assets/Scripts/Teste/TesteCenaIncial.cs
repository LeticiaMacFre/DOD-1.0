using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesteCenaIncial : MonoBehaviour
{
    private Transform posicaoTrigger;
    private int speed = 0;

    private Animator animRob;

    // Start is called before the first frame update
    void Start()
    {
        posicaoTrigger = GameObject.Find("Fala1").transform;
        
        animRob = GetComponent<Animator>();

        animRob.SetLayerWeight(1, 1);
        transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, 0), new Vector2(posicaoTrigger.position.x, 0), speed * Time.deltaTime);


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SeguirJogador()
    { 
       
           
    }

    IEnumerator CenaUm()
    {
     
    }
}
