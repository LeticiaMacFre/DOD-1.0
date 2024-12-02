
using UnityEngine;
using UnityEngine.UI;

public class robsonAndando : Character
{

    private Rigidbody2D rigAndando;
    private Animator animPlayer;
    private SpriteRenderer sprite;
    
    private AudioSource audio;
    public AudioClip jump;

    public Button esqButton;
    public Button dirButton;
    public Button jumpButton;
    
    public float JumpForce = 5.0f;
    public float speedAndando;
    private float moveH;

    private Vector3 movement;

    private string nomeObjetoTrigger;
    
    private bool estaVivo = true;
    private bool isJumping;
    public bool cinematic = false;
    

    // Start is called before the first frame update
    void Start()
    {
        rigAndando = GetComponent<Rigidbody2D>();
        animPlayer = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        audio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (!cinematic)
        {

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                MoveAndando();
            }
            
         
            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                MoveAndando();
            }
            
            else
            {
                animPlayer.SetLayerWeight(1, 0);
            }

            if(Input.GetKeyDown(KeyCode.Space))
            {
                Pulando();
            }
           
        } 

        if (health <= 0)
        {
            estaVivo = false;
        }
    }

    private void MoveAndando()
    {
        moveH = Input.GetAxis("Horizontal");
        movement = new Vector3(moveH * Time.deltaTime * speedAndando, 0f, 0f);
        transform.position += movement;
        if(moveH < 0)
        {
            animPlayer.SetLayerWeight(1, 1);
            sprite.flipX = true;
        }
        else if(moveH > 0)
        {
            animPlayer.SetLayerWeight(1, 1);
            sprite.flipX = false;
        }
        
    }

    private void Pulando()
    {
        if(!isJumping)
        {
            rigAndando.AddForce(transform.up * JumpForce, ForceMode2D.Impulse);
            animPlayer.SetLayerWeight(2, 1);
            audio.clip = jump;
            audio.Play();
            isJumping = true;
        }
        
    }

    void OnCollisionEnter2D(Collision2D collisor)
    {
        if (collisor.gameObject.CompareTag("ground") || collisor.gameObject.CompareTag("Pedra"))
        {
            isJumping = false;
            animPlayer.SetLayerWeight(2, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "ovo")
        {
            nomeObjetoTrigger = collision.gameObject.name;
        }

        if (collision.gameObject.CompareTag("Trigger"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().simulated = true;
        }

        if (collision.gameObject.CompareTag("Dialogar"))
        {
            EstaDialogando();
            animPlayer.SetLayerWeight(1, 0);
            animPlayer.SetLayerWeight(3, 1);
           
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "ovo")
        {
            nomeObjetoTrigger = "";
        }
    }

    public void Cinematic()
    {
        cinematic = !cinematic;
    }

    public string GetTrigger()
    {
        return nomeObjetoTrigger;
    }

    public string IsMoving()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("esquerda");
            return "esquerda";
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("direita");
            return "direita";
        }
        else
        {
            Debug.Log("parado");
            return "parado";
        }
    }

    public bool EstaVivo()
    {
        return estaVivo;
    }

    public void AndaEsquerda()
    {
        moveH = -1;
    }

    public void AndaDireita()
    {
        moveH = 1;
    }

    public void Pulo()
    {
        Pulando();
    }

    public void EstaDialogando()
    {
        cinematic = true;
    }

    public void FimDialogo()
    {
        cinematic = false;
        animPlayer.SetLayerWeight(3, 0);
    }
}
