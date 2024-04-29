using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cameraDoisSegue : MonoBehaviour
{
   /* public GameObject player;
    private Vector3 inicialDoisPosPlayer;
    private Vector3 inicialDoisPosCamera;
    private Vector3 doisSeguePosPlayer = new Vector3(0, 0, 0);
    private Vector3 limiteDoisPosPlayer = new Vector3(0, 0, 0);
    private bool seguePlayerDois;
    private bool limitePlayerDois;


    private void Start()
    {
        inicialDoisPosPlayer = player.transform.position;
        inicialDoisPosCamera = transform.localPosition;
        
    }

    private void Update()
    {
       if(player.transform.position.x <= doisSeguePosPlayer && !limitePlayerDois)
    }

    */
   
    
    public GameObject player;
    private Vector3 inicialPosPlayer;
    private Vector3 inicialPosCamera;
    private Vector3 seguePosPlayer = new Vector3(0, -4.276536f, 0);
    private Vector3 limitePosPlayer = new Vector3(-1.120974f, 0, 0);
    private bool seguePlayer = false;
    private bool seguePulo = false;
    private bool limitePlayer = false;

    private void Start()
    {
        inicialPosPlayer = player.transform.position;
        inicialPosCamera = transform.localPosition;

    }


    private void Update()
    {
        //transform.position = player.transform.position + new Vector3(0, 0, -10);

        if (player.transform.position.x >= seguePosPlayer.x && !limitePlayer)
        {
            seguePlayer = true;
        }
        else
        {
            seguePlayer = false;
        }

        if (player.transform.position.y >= seguePosPlayer.y)
        {
            seguePulo = true;
        }
        else
        {
            seguePulo = false;
        }

        if (seguePlayer)
        {
            transform.position = new Vector3(player.transform.position.x, inicialPosCamera.y, -10);
        }

       
        if(seguePulo)
        {
            transform.position += new Vector3(player.transform.position.x, player.transform.position.y, -10);
        }
        

        if (player.transform.position.x >= limitePosPlayer.x)
        {
            limitePlayer = true;
        }
        else
        {
            limitePlayer = false;
        }


    }
}




