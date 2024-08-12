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
    private Vector3 target;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");
        target = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
        // o c�digo est� indicando passo a passo como encontrar os tr�s valores num�ricos. 
    }


    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
    }

    public void FollowPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
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
        yield return new WaitForSeconds(5);
        Destroy(this.gameObject);
    }

}
