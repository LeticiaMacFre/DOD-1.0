using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class BatalhaVilao : Character 
{
    public bool isPlayerControlled = true;

    private Animator animVilao;

    private SpriteRenderer spriteInimigo;

    public float speed;
    
    
    // Start is called before the first frame update
    void Start()
    {  
        spriteInimigo = GetComponent<SpriteRenderer>();
        animVilao = GetComponent<Animator>();
        characterName = "Dragão";
       
    }

}
