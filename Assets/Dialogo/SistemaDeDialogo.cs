using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class SistemaDeDialogo : MonoBehaviour
{
    [SerializeField] private GameObject _caixaDeDialogo;

    [SerializeField] private AudioClip _somDaExpressao;
    [SerializeField] private TextMeshProUGUI _nomePersonagem;
    [SerializeField] private TextMeshProUGUI _textoFala;

    private Dialogo _dialogoAtual;
    private int _indiceFalas;
    private Queue<string> _filaFalas;

    public void IniciarDialogo(Dialogo dialogo)
    {
        _caixaDeDialogo.SetActive(true);

        _filaFalas = new Queue<string>();

        _dialogoAtual = dialogo;
        _indiceFalas = 0;

        ProximaFala();

    }

    public void ProximaFala()
    {
        if(_filaFalas.Count == 0)
        {
            if (_indiceFalas < _dialogoAtual.Falas.Length)
            {
                //colocar o som do personagem se expressando
                

                //coloca o nome do personagem na caixa de diálogo e arruma o tamanho
                _nomePersonagem.text = _dialogoAtual.Falas[_indiceFalas].Personagem.Nome;

                //coloca todas as falas da expressão atual em um fila
                foreach (string textoFala in _dialogoAtual.Falas[_indiceFalas].TextoDasFalas)
                {
                    _filaFalas.Enqueue(textoFala);
                }

                _indiceFalas++;
            }

            else
            {
                _caixaDeDialogo.SetActive(false);
                return;
            }

        }


        _textoFala.text = _filaFalas.Dequeue();




    }
}
