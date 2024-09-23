using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiretorVilaOne : MonoBehaviour
{
    // Start is called before the first frame update


    private robsonAndando playerRob;
    private TriggerDialogo TriggerDialogo;
    private SistemaDeDialogo sistemaDeDialogo;

    private bool inicioDialogo = false;
    private bool fimDoDialogo = false;

    void Start()
    {
        sistemaDeDialogo = GameObject.FindGameObjectWithTag("Dialogo").GetComponent<SistemaDeDialogo>();
        TriggerDialogo = GameObject.FindGameObjectWithTag("CenaComerciante").GetComponent<TriggerDialogo>();
        playerRob = GameObject.FindGameObjectWithTag("Player").GetComponent<robsonAndando>();
    }

    // Update is called once per frame
    void Update()
    {
         inicioDialogo = TriggerDialogo.PlayerPrimeiroDialogo();
         fimDoDialogo = sistemaDeDialogo.TerminoDialogo();
        

        if(inicioDialogo)
        {
            sistemaDeDialogo.IniciarDialogo();
            playerRob.Cinematic();

            if(fimDoDialogo)
            {
                playerRob.Cinematic();
            }
        }
    }
}
