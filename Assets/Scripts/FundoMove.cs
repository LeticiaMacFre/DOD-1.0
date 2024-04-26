using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FundoMove : MonoBehaviour
{

    public GameObject cameraPlayer;
    private float velociade;
    private float tamanho, startPos;
    public float velocidadeParallax;



    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position.x;
        tamanho = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        float temp = (cameraPlayer.transform.position.x * (1 - velocidadeParallax));
        float dist = (cameraPlayer.transform.position.x * velocidadeParallax);

        transform.position = new Vector3(startPos + dist, transform.position.y, transform.position.z);

        if(temp > startPos + tamanho)
        {
            startPos += tamanho;
        }
    }
}
