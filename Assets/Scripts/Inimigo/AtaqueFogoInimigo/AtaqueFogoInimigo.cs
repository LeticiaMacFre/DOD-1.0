using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueFogoInimigo : MonoBehaviour
{
    //Attack Parameters
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    [SerializeField] private int damage;

    //Ranged Attack
    [SerializeField] private Transform firepoint;
    [SerializeField] private GameObject[] fireballs;

    //Collider Parameters
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;

    //Player Layer
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;


    public ZonaDeAtaque zonaDeAtaque;
    public ZonaDeDano zonaDeDano;

    public bool playerNaZD = false;
    public bool playerNaZA = false;

    //References
    private Animator anim;

    private void Start()
    {
        zonaDeAtaque = GameObject.Find("zona ataque").GetComponent<ZonaDeAtaque>();
        zonaDeDano = GameObject.Find("zona ataque").GetComponent<ZonaDeDano>();
    }


    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        playerNaZA = zonaDeAtaque.PlayerZonaDeAtaque();
        playerNaZD = zonaDeDano.PlayerZonaDeDano();

        cooldownTimer += Time.deltaTime;

        if (!playerNaZA && !playerNaZD)
        {
            if (cooldownTimer >= attackCooldown)
            {
                cooldownTimer = 0;
                anim.SetTrigger("ataqueBolaDeFogo");
            }
        }
    }

    //RangedAttack()
    private void AtaqueBolaDeFogoVilao()
    {
        cooldownTimer = 0;
        fireballs[0].transform.position = firepoint.position;
        //fireballs[0].GetComponent<EnemyProjectile>().ActivateProjectile();
    }
}
