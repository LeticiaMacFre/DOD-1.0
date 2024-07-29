using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] fireballs;

    private Animator anim;
    private robsonAndando robsonAndando;
    private float cooldownTimer = Mathf.Infinity;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        robsonAndando = GetComponent<robsonAndando>();
    }

    private void Update()
    {
        if(Input.GetMouseButton(0) && cooldownTimer > attackCooldown)
        {
            cooldownTimer += Time.deltaTime; 
        }
    }

    private void Attack()
    {
        cooldownTimer = 0;
        fireballs[0].transform.position = firePoint.position;
        
    }

}
