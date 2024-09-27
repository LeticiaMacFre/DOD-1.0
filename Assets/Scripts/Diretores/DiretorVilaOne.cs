using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiretorVilaOne : MonoBehaviour
{
    // Start is called before the first frame update


    private robsonAndando playerRob;
    private TriggerDialogo TriggerDialogo;
    private SistemaDeDialogo sistemaDeDialogo;
    private BasicArray arrayDialogo;

    private bool inicioDialogo = false;

    public Animator animRob;
    

    void Start()
    {
        sistemaDeDialogo = GameObject.FindGameObjectWithTag("Dialogo").GetComponent<SistemaDeDialogo>();
        TriggerDialogo = GameObject.FindGameObjectWithTag("CenaComerciante").GetComponent<TriggerDialogo>();
        playerRob = GameObject.FindGameObjectWithTag("Player").GetComponent<robsonAndando>();
        arrayDialogo = GameObject.Find("Array").GetComponent<BasicArray>();

        animRob = playerRob.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
         inicioDialogo = TriggerDialogo.PlayerPrimeiroDialogo();
         
        

        if(inicioDialogo)
        {
            sistemaDeDialogo.IniciarDialogo();
        }
    }
}
