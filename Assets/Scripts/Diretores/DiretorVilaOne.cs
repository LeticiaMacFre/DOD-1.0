using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiretorVilaOne : MonoBehaviour
{
    // Start is called before the first frame update


    public robsonAndando playerRob;
    private TriggerDialogo TriggerDialogo;
    private SistemaDeDialogo sistemaDeDialogo;
   

    private bool inicioDialogo = false;

    public Animator animRob;
    

    void Start()
    {
        sistemaDeDialogo = GameObject.FindGameObjectWithTag("Dialogo").GetComponent<SistemaDeDialogo>();
        TriggerDialogo = GameObject.FindGameObjectWithTag("CenaComerciante").GetComponent<TriggerDialogo>();
        playerRob = GameObject.FindGameObjectWithTag("Player").GetComponent<robsonAndando>();
       

        animRob = playerRob.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
         inicioDialogo = TriggerDialogo.PlayerPrimeiroDialogo();
         
        

        if(inicioDialogo)
        {
            sistemaDeDialogo.IniciarDialogo();
            inicioDialogo = false;
        }

        if(sistemaDeDialogo.FimDialogo())
        {
            playerRob.FimDialogo();
            sistemaDeDialogo.FinalizaDialogo();
        }

    }
}
