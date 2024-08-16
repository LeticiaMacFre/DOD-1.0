using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class fireBalls : MonoBehaviour
{

    public float speed;
    public int hit;
    private GameObject player;
    private Animator animBF;
    private Vector3 target;
    public float tempo = 1.1f;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        target = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);

        animBF = GetComponent<Animator>();
        // o código está indicando passo a passo como encontrar os três valores numéricos. 
    }


    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
    }

    public void FollowPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if(transform.position == target)
        {
            StartCoroutine("Contador");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }


    IEnumerator Contador()
    {
        yield return new WaitForSeconds(tempo);
        animBF.SetLayerWeight(1, 1);
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
    }

}
