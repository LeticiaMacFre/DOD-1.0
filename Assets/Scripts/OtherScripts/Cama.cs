using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cama : MonoBehaviour
{
    public GameObject objetoInteragir;
    private bool estaInteragindo;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void Interact()
    {
        Debug.Log("Jogador interagiu com cama!");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Vector3.Distance(transform.position, objetoInteragir.transform.position) < 2f)
        {
         
        }
    }

}
