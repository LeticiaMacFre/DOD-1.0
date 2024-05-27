using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FundoMoveContrario : MonoBehaviour
{

    public GameObject cameraPlayer;
    private float velociade;
    private float tamanho, startPos;
    public float velocidadeParallax;



    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position.z;
        tamanho = GetComponent<SpriteRenderer>().bounds.size.z;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float temp = (cameraPlayer.transform.position.z * (1 + velocidadeParallax));
        float dist = (cameraPlayer.transform.position.z * velocidadeParallax);
        
        transform.position = new Vector3(startPos - dist, transform.position.y, transform.position.x);

        if (temp > startPos + tamanho)
            startPos += tamanho;
        }
    }
}
