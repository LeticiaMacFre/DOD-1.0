using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Atirador : MonoBehaviour
{
    public GameObject fireball;
    public GameObject mira;
    private bool areaAtaque;
    private bool atirando;

    public StartFireBalls startFB;
    private bool startFireAttack;

    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("Fire", 1, 1);
        areaAtaque = false;
        atirando = true;
        StartCoroutine("Atira");
        startFB = GameObject.Find("Inicio").GetComponent<StartFireBalls>();
    }

    // Update is called once per frame
    void Update()
    {
        startFireAttack = startFB.VerifyStartFireballs();

        if (startFireAttack)
        {
                if (areaAtaque && atirando)
                {
                    StopCoroutine("Atira");
                    atirando = false;
                }
                else if (!areaAtaque && !atirando)
                {
                    StartCoroutine("Atira");
                    atirando = true;
                }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            areaAtaque = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            areaAtaque = false;
        }

    }

    public void Fire()
    {
        Instantiate(fireball, mira.transform.position, Quaternion.identity);
    }

    IEnumerator Atira()
    {
        do
        {
            Fire();
            yield return new WaitForSeconds(5F);
        } while (atirando);

    }
}