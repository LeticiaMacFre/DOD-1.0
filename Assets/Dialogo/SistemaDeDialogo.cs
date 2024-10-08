using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class SistemaDeDialogo : MonoBehaviour
{
    [SerializeField] public GameObject caixaDeDialogo;

    [SerializeField] public AudioClip somDaExpressao;
    [SerializeField] public TMP_Text nomePersonagem;
    [SerializeField] public TMP_Text textoFala;
    [SerializeField] private TMP_Text textoBotao;

    [SerializeField] private List<string> falas = new List<string>();
    [SerializeField] private List<string> quemFala= new List<string>();

    [SerializeField] private int controleFalas;

    private bool fimDialogo = false;

    
    private void Start()
    {
        textoBotao.text = "Next";
        controleFalas = 0;
        nomePersonagem.text = quemFala[controleFalas];
        textoFala.text = falas[controleFalas];
    }

   
    public void IniciarDialogo()
    {
        caixaDeDialogo.SetActive(true);
    }

    
    public void ProximaFala()
    {
        int totalFalas = falas.Count -1;

        if(controleFalas < totalFalas)
        {
            controleFalas++;
            nomePersonagem.text = quemFala[controleFalas];
            textoFala.text = falas[controleFalas];
        }
        else if(controleFalas == totalFalas)
        {
            textoBotao.text = "Close";
            fimDialogo = true;
        }
        

    }

    public bool FimDialogo()
    {
        return fimDialogo;
    }

    public void FinalizaDialogo()
    {
        caixaDeDialogo.SetActive(false);
    }

    


}
