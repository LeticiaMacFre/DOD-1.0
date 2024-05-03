using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class robsonAndando : MonoBehaviour
{
    public float speedAndando;
    private Rigidbody2D rigAndando;
    public Animator animPlayer;
    private float scaleX;
    public float JumpForce;
    public bool isJumping;
    // Start is called before the first frame update
    void Start()
    {
        rigAndando = GetComponent<Rigidbody2D>();
        animPlayer = GetComponent<Animator>();
    }

    private void Update()
    {
        

        if(Input.GetKey(KeyCode.A))
        {
            animPlayer.SetLayerWeight(2, 1);
            MoveAndando();
        }
        else
        {
            animPlayer.SetLayerWeight(2, 0);
        }

        if(Input.GetKey(KeyCode.D))
        {
            animPlayer.SetLayerWeight(1, 1);
            MoveAndando();
        }
        else
        {
            animPlayer.SetLayerWeight(1, 0);
        }
        if(Input.GetKey(KeyCode.Space) && !isJumping)
        {
            animPlayer.SetLayerWeight(3, 1);
            Pulando();
        }
        else
        {
            animPlayer.SetLayerWeight(3, 0);
        }
    }
    void FixedUpdate()
    {
        MoveAndando();
        Pulando();
    }

    private void MoveAndando()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * speedAndando;
    }

    private void Pulando()
    {
        rigAndando.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
        isJumping = true;
    }

    void OnCollisionEnter2D(Collision2D collisor)
    {
        if (collisor.gameObject.CompareTag("ground"))
        {
            isJumping = false;
        }
    }



  

}
