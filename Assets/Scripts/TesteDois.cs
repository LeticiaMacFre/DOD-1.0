using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesteDois : MonoBehaviour
{
    [Header("Patrol Points")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;

    [Header("Enemy")]
    [SerializeField] private Transform enemy;

    [Header("Idle Behaviour")]
    [SerializeField] private float idleDuration;
    private float idleTimer;

    [Header("Movement Parameters")]
    [SerializeField] private float speed;
    private Vector3 initScale;
    private bool movingLeft;

    [Header("Enemy Animator")]
    [SerializeField] private Animator anim;
    private void Update()
    {
        if (movingLeft)
        {
            if (enemy.position.x >= leftEdge.position.x)
            {
                MoveInDirection(-1);
            }
            else
            {
                DirectionChange();
            }

        }

        else
        {
            if (enemy.position.x <= rightEdge.position.x)
            {
                MoveInDirection(1);
            }

            else
            {
                DirectionChange();
            }
        }


    }

    private void DirectionChange()
    {
        //anim.SetBool("move", false);

        idleTimer += Time.deltaTime;

        if (idleTimer > idleDuration)
            movingLeft = !movingLeft;
    }

    private void OnDisable()
    {
        //anim.SetBool("move", false);
    }

    private void Awake()
    {
        initScale = enemy.localScale;
    }
    private void MoveInDirection(int _direction)
    {
        idleTimer = 0;

        //anim.SetBool("move", true);

        enemy.localScale = new Vector3(Mathf.Abs(initScale.x), initScale.y, initScale.z);

        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _direction * speed, enemy.position.y, enemy.position.z);

    }
}

}
