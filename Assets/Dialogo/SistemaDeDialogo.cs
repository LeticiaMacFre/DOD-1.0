using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class SistemaDeDialogo : MonoBehaviour
{
    [SerializeField] public GameObject caixaDeDialogo;

    [SerializeField] public AudioClip somDaExpressao;
    [SerializeField] public TextMeshProUGUI nomePersonagem;
    [SerializeField] public TextMeshProUGUI textoFala;

    private Dialogo dialogoAtual;
    private Queue<string> filaFalas;
    private int indiceFalas;

    public bool fimDialogo = false;

   

    public void IniciarDialogo()
    {
        caixaDeDialogo.SetActive(true);

        filaFalas = new Queue<string>();

        indiceFalas = 0;

        ProximaFala();

    }

    public void ProximaFala()
    {
        if(filaFalas.Count == 0)
        {
            if (indiceFalas < dialogoAtual.Falas.Length)
            {
                //colocar o som do personagem se expressando
                

                //coloca o nome do personagem na caixa de diálogo e arruma o tamanho
                nomePersonagem.text = dialogoAtual.Falas[indiceFalas].Personagem.Nome;

                //coloca todas as falas da expressão atual em um fila
                foreach (string textoFala in dialogoAtual.Falas[indiceFalas].TextoDasFalas)
                {
                    filaFalas.Enqueue(textoFala);
                }

                indiceFalas++;
            }

            else
            {
                caixaDeDialogo.SetActive(false);
                fimDialogo = !fimDialogo;
                return;
            }

        }


        textoFala.text = filaFalas.Dequeue();




    }

    public bool TerminoDialogo()
    {
        return fimDialogo;
    }
}
