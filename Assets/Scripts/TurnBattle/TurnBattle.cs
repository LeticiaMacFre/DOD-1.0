using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TurnBattle : MonoBehaviour
{
    public List<Character> playerCharacters = new List<Character>();
    public Character enemy;

    [SerializeField] public TMP_Text enunciadorText;
    [SerializeField] private float timer;

    private int currentCharacterIndex = 0;
    private float turnTime = 30f;
    private bool turnActive = false;
    public bool fimDaBatalha = false;

    private void Start()
    {
        Character[] resultados = GameObject.FindObjectsOfType<Character>();

        foreach (Character character in resultados) 
        {
            if (!character.EhInimigo())
            {
                playerCharacters.Add(character);
            }
            else
            {
                enemy = character;
            }
        }
    }

    public void StartTurn()
    {
        if(currentCharacterIndex < playerCharacters.Count)
        {
            turnActive = true;
            timer = turnTime;
            enunciadorText.text = ($"Turno de {playerCharacters[currentCharacterIndex].characterName} começou!");
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

        Character[] resultados = GameObject.FindObjectsOfType<Character>();

        foreach (Character character in resultados)
        {
            if (character.VerificaSeEstahVivo())
            {
                Debug.Log(character.characterName + ", está vivo.");
            }
            else if(character.EhInimigo())
            {
                Debug.Log("Você Ganhou!");
            }
            else
            {
                Debug.Log("Você Perdeu!");
            }
        }

        if (currentCharacterIndex >= playerCharacters.Count)
        {
            enunciadorText.text = ("Turno dos jogadores acabou. Turno do inimigo começa.");
            StartEnemyTurn();
        }
        else 
        {
            StartTurn();
        }
    }

    public void StartEnemyTurn()
    {
        enunciadorText.text = ("Turno do inimigo");

        if(enemy.health > 0)
        {
            var target = playerCharacters[Random.Range(0, playerCharacters.Count)];
            int attackType = Random.Range(1, 3);
            enemy.Attack(target, attackType);
        }

        else
        {
            VictoryOfBattle();
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
                enunciadorText.text = ("Tempo acabou! Turno finalizado automaticamente.");
                EndPlayerTurn();
            }
        }
    }

    
    public void PlayerAttack(int attackType)
    {
        if(turnActive)
        {
            playerCharacters[currentCharacterIndex].Attack(enemy, attackType);
            EndPlayerTurn();
        }
    }

    public void VictoryOfBattle()
    {
        enunciadorText.text = ("Parabéns! Você ganhou a batalha");
        fimDaBatalha = true;
    }

    public void LoseOfBattle()
    {
        enunciadorText.text = ("Tente derrotá-lo novamente!");
        fimDaBatalha = true;
    }

    public bool VerificaFimDaBatalha()
    {
        return fimDaBatalha;
    }



    



}
