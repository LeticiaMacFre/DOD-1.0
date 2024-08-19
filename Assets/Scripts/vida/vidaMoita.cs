using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vidaMoita : MonoBehaviour
{
    public int vidaMob;
    public int vidaAtualMob;


    // Start is called before the first frame update
    void Start()
    {
        vidaAtualMob = vidaMob;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReceberDano()
    {
        vidaAtualMob -= 1;

        if (vidaAtualMob <= 0)
        {
           
            Morte();
        }
    }

    public void Morte()
    {
        Destroy(this.gameObject);
    }

}
