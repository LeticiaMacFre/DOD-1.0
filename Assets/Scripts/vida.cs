using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class vida : MonoBehaviour
{
    public int vidaRob;
    public int vidaAtual;

 
    // Start is called before the first frame update
    void Start()
    {
        vidaAtual = vidaRob;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReceberDano()
    {
        vidaAtual -= 1;

        if(vidaAtual <= 0)
        {
            Debug.Log("Game Over");
            Morte();
        }
    }
   
    public void Morte()
    {
        Destroy(this.gameObject);
    }
    
}
