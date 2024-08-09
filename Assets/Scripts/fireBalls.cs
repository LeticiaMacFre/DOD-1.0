using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
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
        target = 
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(1 * speed * Time.deltaTime, 0, 0);
    }

    public void FollowPlayer()
    {

}
