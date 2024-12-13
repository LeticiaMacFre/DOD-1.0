using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSyst : MonoBehaviour
{
    private TurnBattle turnBattle;
    private SistemaDeDialogo dialogo;
    public GameObject enunciador;
    public GameObject botoesPlayer;
    public bool startBatalha = true;

    public bool terminouDialogo;
    private void Start()
    {
        turnBattle = GameObject.Find("TurnDiretor").GetComponent<TurnBattle>();
        dialogo = GameObject.Find("Dialogo").GetComponent<SistemaDeDialogo>();
    }

    public void Update()
    {
        if(dialogo.VerificaFimDialogo() && startBatalha)
        {
            IniciaBatalha();
            startBatalha = false;
        }

        if (turnBattle.VerificaFimDaBatalha())
        {

        }
    }

    private void IniciaBatalha()
    {
        turnBattle.StartTurn();
        enunciador.SetActive(true);
        botoesPlayer.SetActive(true);
    }

    private void FimBatalha()
    {
        enunciador.SetActive(false);
        botoesPlayer.SetActive(false);
    }
}
