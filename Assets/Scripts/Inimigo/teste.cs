using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teste : MonoBehaviour
{
    [SerializeField] private float valorDoTempo;
    [SerializeField] private float range;
    [SerializeField] private float colliderDistance;
    [SerializeField] private int valorDano;
    [SerializeField] private PolygonCollider2D polygonCollider;
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;

    private Animator anim;
    private vida vida;
    private TesteDois enemyPatrol;


    private void Awake()
    {
        anim = GetComponent<Animator>();
        enemyPatrol = GetComponentInParent<TesteDois>();
    }

    private void Update()
    {
        valorDoTempo += Time.deltaTime;

        if (PlayerDentro())
        {
            if (cooldownTimer >= valorDoTempo)
            {
                cooldownTimer = 0;
                anim.SetTrigger("");
                Debug.Log("player em risco");

            }

            if (enemyPatrol != null)
            {
                enemyPatrol.enabled = !PlayerDentro();            
            }

        }
    }

    private bool PlayerDentro()
    {
        RaycastHit2D hit = Physics2D.BoxCast(polygonCollider.bounds.center + transform.right * range * colliderDistance, polygonCollider.bounds.size, 0, Vector2.left, 0, playerLayer);

        if (hit.collider != null)
            vida = hit.transform.GetComponent<vida>();

        return hit.collider != null;

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(polygonCollider.bounds.center + transform.right * range, polygonCollider.bounds.size);
    }

    private void DamagePlayer()
    {
        if (PlayerDentro())
        {
            vida.ReceberDano();
        }
    }
}
