using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AureliusMove : MonoBehaviour
{
    public GameObject robson;
    public Vector3 robPosition;
    public float offset = 2.5f;
    public float velocidade = 0.1f;
    public Vector3 posAtual;
    public Animator animAurelius;

    // Start is called before the first frame update

    void Start()
    {
        posAtual = transform.position;
        animAurelius = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        robPosition = robson.transform.position;

        transform.position = new Vector3(Mathf.Lerp(posAtual.x, robPosition.x + offset, velocidade), posAtual.y, 0);


    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            animAurelius.SetLayerWeight(1, 1);
        }
        else
        {
            animAurelius.SetLayerWeight(1, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            animAurelius.SetLayerWeight(2, 1);
        }
        else
        {
            animAurelius.SetLayerWeight(2, 0);
        }
    }
}
 /*
    void OnCollisionEnter2D(Collision2D collisor)
    {
        if (collisor.gameObject.CompareTag("ground"))
        {
            isJumping = false;
        }
    }
}
*/