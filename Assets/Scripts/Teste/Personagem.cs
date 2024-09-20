using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Novo Personagem", menuName = "Dialogo/Personagem")]
public class Personagem : ScriptableObject
{
        public string Nome;
        public AudioClip[] Expressoes;
}
