using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.UI;

public class TurnBattle : MonoBehaviour
{
    public Character[] playerCharacters;
    public Character enemy;

    public GameObject enunciador;
    
    private int currentCharacterIndex = 0;
    private float turnTime = 30f;
    private float timer;
    private bool turnActive = false;

    public void StartTurn()
    {
        if (currentCharacterIndex < playerCharacters.Length)
        {
            turnActive = true;
            timer = turnTime;
            Debug.Log($"Turno de {playerCharacters[currentCharacterIndex].characterName} começou!");
        }
        else
        {
            EndPlayerTurn();
        }
    }

    public void EndPlayerTurn()
    {
        turnActive = false;
        currentCharacterIndex++;

        if (currentCharacterIndex >= playerCharacters.Length)
        {
            Debug.Log("Turno dos jogadores acabou. Turno do inimigo começa.");
            StartEnemyTurn();
        }
        else
        {
            StartTurn();
        }

    }

    public void StartEnemyTurn()
    {
        Debug.Log("Turno do inimigo");

        if(enemy.health > 0)
        {
            var target = playerCharacters[Random.Range(0, playerCharacters.Length)];
            int attackType = Random.Range(1, 3);
            enemy.Attack(target, attackType);
        }


        currentCharacterIndex = 0;
        StartTurn();
    }

    private void Update()
    {
        if(turnActive)
        {
            timer -= Time.deltaTime;

            if(timer <= 0)
            {
                Debug.Log("Tempo acabou! Turno finalizado automaticamente.");
                EndPlayerTurn();
            }
        }
    }

    
    public void PlayerAttack(int attackType)
    {
        if(turnActive)
        {
            playerCharacters[currentCharacterIndex].Attack(enemy, attackType);
        }
    }

    public void EndTurnManually()
    {
        if(turnActive)
        {
            Debug.Log($"{playerCharacters[currentCharacterIndex].characterName} terminou o turno. ");
        }
    }



    



}
