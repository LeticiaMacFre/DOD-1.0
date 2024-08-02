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
    private void Update()
    {
        valorDoTempo += Time.deltaTime;

        if (PlayerDentro())
        {
            if (cooldownTimer >= valorDoTempo)
            {
                cooldownTimer = 0;

            }
        }
    }

    private bool PlayerDentro()
    {
        RaycastHit2D hit = Physics2D.BoxCast(polygonCollider.bounds.center + transform.right * range * colliderDistance, polygonCollider.bounds.size, 0, Vector2.left, 0, playerLayer);

        return hit.collider != null;

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(polygonCollider.bounds.center + transform.right * range, polygonCollider.bounds.size);
    }
}
