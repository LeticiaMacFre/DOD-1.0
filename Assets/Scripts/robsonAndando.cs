using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class robsonAndando : MonoBehaviour
{
    public float speedAndando;
    private Rigidbody2D rigAndando;
    public Animator animPlayer;
    private SpriteRenderer sprite;
    public float JumpForce;
    public bool isJumping;
    public bool cinematic = false;
    public GameObject Dragao;
    private Animator AnimOvo;
    public GameObject Ovo;
    private Vector3 movement;
    public float moveH;

    // Start is called before the first frame update
    void Start()
    {
        rigAndando = GetComponent<Rigidbody2D>();
        animPlayer = GetComponent<Animator>();
        AnimOvo = Ovo.GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (!cinematic)
        {

            if (Input.GetKey(KeyCode.A))
            {
                animPlayer.SetLayerWeight(1, 1);
                sprite.flipX = true;
                MoveAndando();
            }
            else if (Input.GetKey(KeyCode.D))
            {
                animPlayer.SetLayerWeight(1, 1);
                sprite.flipX = false;
                MoveAndando();
            }
            else
            {
                animPlayer.SetLayerWeight(1, 0);
            }
            
            if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
            {
                Pulando();
            }

           
        }
    }
    void FixedUpdate()
    {
        //if (!cinematic)
        //{
        //    MoveAndando();
        //    Pulando();
        //}
    }

    private void MoveAndando()
    {
        moveH = Input.GetAxis("Horizontal");
        movement = new Vector3(moveH, 0f, 0f);
        transform.position += movement * Time.deltaTime * speedAndando;
    }

    private void Pulando()
    {
        rigAndando.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
        animPlayer.SetLayerWeight(2, 1);
        isJumping = true;
    }

    void OnCollisionEnter2D(Collision2D collisor)
    {
        if (collisor.gameObject.CompareTag("ground"))
        {
            isJumping = false;
            animPlayer.SetLayerWeight(2, 0);
        }
    }

    // INTERAÇÃO CAVERNA
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "ovo")
        {
            cinematic = true;
            animPlayer.SetLayerWeight(1, 0);
            animPlayer.SetLayerWeight(2, 0);
            animPlayer.SetLayerWeight(3, 0);
            StartCoroutine("CinematicOvo");

        }
    }


    IEnumerator CinematicOvo()
    {
        AnimOvo.SetLayerWeight(1,1);
        yield return new WaitForSeconds(5.0f);
        Dragao.gameObject.SetActive(true);
        Dragao.GetComponent<AureliusMove>().enabled = true;
        Ovo.gameObject.SetActive(false);
        cinematic = false;

    }

}
    