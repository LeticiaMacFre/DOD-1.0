using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class robsonMove : MonoBehaviour
{

    public float Speed;
    public float JumpForce;
    public bool isJumping;
    public Animator fade;
    public GameObject image;
    private Rigidbody2D rig;



    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        fade = image.GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        Jump();
    }

    private void Move()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * Speed; 
    }

    private void Jump()
    {
        if(Input.GetButtonDown("Jump") && !isJumping)
        {
            rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
            isJumping = true;
        }
    }

    void OnCollisionEnter2D(Collision2D collisor)
    {
        if (collisor.gameObject.CompareTag("ground"))
        {
            isJumping = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Entra_Caverna")
        {
            StartCoroutine("FadeFinalCena");
            SceneManager.LoadScene("Caverna");
        }
    }

    IEnumerable FadeFinalCena()
    {
        image.SetActive(true);
        fade.enabled = true;
        fade.PlayInFixedTime("Base Layer.Fade");
        yield return new WaitForSeconds(3);
       
    }
}
