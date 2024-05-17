using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class AureliusOvo : MonoBehaviour
{
    private bool interagir;
    public Animator animAurelius;
    
    // Start is called before the first frame update
    void Start()
    {
        interagir = false;
        
        animAurelius = GetComponent<Animator>();

       
    }

    /*void OnCollisionEnter2D(Collision2D collisor)
    {
        if (collisor.gameObject.CompareTag("Player")) 
        {
            interagir = true;
            animAurelius.SetLayerWeight(1, 1);
            
        }
        
    }*/
    
    // Update is called once per frame
    void Update()
    {

    }
}
