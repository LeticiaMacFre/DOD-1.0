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

    private TMP_Text fala0;
    private TMP_Text fala1;
    private TMP_Text fala2;
    private TMP_Text fala3;
    private TMP_Text fala4;
    private TMP_Text fala5;
    private TMP_Text fala6;

    private TMP_Text nomeRob;
    private TMP_Text nomeComerciante;

    private TMP_Text[] Fala;

    private void Start()
    {
        Fala = new TMP_Text[] { fala0, fala1, fala2, fala3, fala4, fala5, fala6 };
    }

    private void Awake()
    {
        fala0.text = "Olá William!";
        fala1.text = "Olá jovem Rob! Como vai?";
        fala2.text = "Bem! Estou a caminho da floresta";
        fala3.text = "Há rumores de dragões por lá Rob!";
        fala4.text = "Vou descobrir se é verdade hehe";
        fala5.text = "Então prepare-se para correr! Fugir!";
        fala6.text = "Terei cuidado! Até logo!";

        nomeRob.text = "ROBSON";
        nomeComerciante.text = "WILLIAM";

    }




    public void IniciarDialogo()
    {
        caixaDeDialogo.SetActive(true);
        nomePersonagem.text = nomeRob.text;
        textoFala.text = fala0.text;
    }

    //Ao clicar no botão, a fala troca para a próxima a lista e troca-se o nome



    



}
