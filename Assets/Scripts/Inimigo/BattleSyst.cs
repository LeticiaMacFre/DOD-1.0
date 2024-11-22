using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSyst : MonoBehaviour
{
    public TurnBattle turnBattle;

    private void Start()
    {
        turnBattle.StartTurn();
    }
}
