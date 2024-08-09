using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atirador : MonoBehaviour
{
    public GameObject fireball;
    public GameObject mira;
    private bool areaAtaque;
    private bool atirando;
    // Start is called before the first frame update
    void Start()
    {
        areaAtaque = true;
        StartCoroutine("Atira");
    }

    // Update is called once per frame
    void Update()
    {
        if(areaAtaque && atirando)
        {
            StopCoroutine("Atira");
        }
        else if(!areaAtaque && !atirando)
        {
            StartCoroutine("Atira");
            atirando = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Player"))
        {

        }
    }

    public void Fire()
    {

    }
    IEnumerator Atira()
    {
        Fire();
        yield return new WaitForSeconds(Random.Range(1, 3));
    }
} 

