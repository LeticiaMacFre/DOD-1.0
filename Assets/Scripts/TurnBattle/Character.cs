using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public string characterName;
    public int health = 100;
    protected int minAtaque1 = 5;
    protected int maxAtaque1 = 10;
    protected int minAtaque2 = 12;
    protected int maxAtaque2 = 15;
    [SerializeField] protected bool ehInimigo;

    public void Attack(Character target, int attackType)
    {
        int damage = 0;

        if (attackType == 1)
        {
            damage = Random.Range(minAtaque1, maxAtaque2);
        }
        else if (attackType == 2)
            damage = Random.Range(minAtaque2, maxAtaque2);


        if(target != null)
        {
            target.TakeDamage(damage);
            Debug.Log($"{characterName} usou ataque {attackType} causando {damage} de dano a {target.characterName}.");
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log($"{characterName} recebeu {damage} de dano. Vida restante: {health}");

        if(health <= 0)
        {
            Debug.Log($"{characterName} foi derrotado");
        }
    }

    public bool EhInimigo()
    {
        return ehInimigo;
    }

    protected virtual void DefineInimigo(bool valor)
    {
        ehInimigo = valor; 
    }

    public bool VerificaSeEstahVivo()
    {
        if(health <= 0)
        {
            return false;
        }

        return true;
    }
 
}
