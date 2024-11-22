using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class TurnBattle : MonoBehaviour
{
    public GameObject[] playerCharacters;
    public GameObject enemyCharacter;

    private BatalhaVilao inimigo;

    private int currentCharacterIndex = 0;

    private float turnTime = 30f;
    private float timer;
    private bool turnActive = false;

    private void Start()
    {
        inimigo = enemyCharacter.GetComponent<BatalhaVilao>();
    }

    public void StartTurn()
    {
        if (currentCharacterIndex < playerCharacters.Length)
        {
            turnActive = true;
            timer = turnTime;
            Debug.Log($"É a vez de {playerCharacters[currentCharacterIndex]}");
        }
        else
        {
            EndPlayerTurn();
        }
    }

    public void EndPlayerTurn()
    {
        currentCharacterIndex++;
        turnActive = false;

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
        if(inimigo.VidaDoVilao() > 0)
        {
            var target = playerCharacters[Random.Range(0, playerCharacters.Length)];
            //inimigo.AtaqueAoPlayer(target);
          
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

    public void OnPlayerActionCompleted()
    {
        EndPlayerTurn();
    }


    



}
