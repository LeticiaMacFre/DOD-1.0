using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Novo Dialogo", menuName = "Dialogo/Conversa")]
public class Dialogo : ScriptableObject
{
    public FalasDaConversa[] Falas;
}

[System.Serializable]
public class FalasDaConversa
{
    public Personagem Personagem;
    public int IdDaExpressao;

    
    public int[] TextoDasFalas;



}

