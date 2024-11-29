using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSyst : MonoBehaviour
{
    public TurnBattle turnBattle;
    public GameObject enunciador;

    private void Start()
    {
        turnBattle.StartTurn();
        enunciador.SetActive(true);
    }
}
