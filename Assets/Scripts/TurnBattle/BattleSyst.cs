using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSyst : MonoBehaviour
{
    private TurnBattle turnBattle;
    private SistemaDeDialogo dialogo;
    public GameObject enunciador;
    public GameObject botoesPlayer;

    public bool terminouDialogo;
    private void Start()
    {
        turnBattle = GameObject.Find("TurnDiretor").GetComponent<TurnBattle>();
        dialogo = GameObject.Find("Dialogo").GetComponent<SistemaDeDialogo>();
    }

    public void Update()
    {
        terminouDialogo = dialogo.ComecarBatalha();

        if (terminouDialogo)
        {
            turnBattle.StartTurn();
            enunciador.SetActive(true);
            botoesPlayer.SetActive(true);
        }
    }
}
