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
    [SerializeField] public TMP_Text nomePersonagem;
    [SerializeField] public TMP_Text textoFala;
    [SerializeField] private TMP_Text textoBotao;

    public AudioSource somDialogo;
    private AudioClip openEgg;

    public bool InicioDialogo = false;
    public bool FimDialogo = false;

    public GameObject TriggerDialogo;
    private TriggerDialogo triggerDialogo;
    private robsonAndando robson;

    [SerializeField] private List<string> falas = new List<string>();
    [SerializeField] private List<string> quemFala= new List<string>();

    [SerializeField] private int controleFalas;
    
    private void Start()
    {
        triggerDialogo = GameObject.FindGameObjectWithTag("Dialogar").GetComponent<TriggerDialogo>();
        robson = GameObject.FindGameObjectWithTag("Player").GetComponent<robsonAndando>();

        textoBotao.text = "Next";
        controleFalas = 0;
        nomePersonagem.text = quemFala[controleFalas];
        textoFala.text = falas[controleFalas];
        somDialogo = GetComponent<AudioSource>();
    }

    private void Update()
    {
        InicioDialogo = triggerDialogo.ComecarDialogo();

        if(InicioDialogo)
        {
            IniciarDialogo();
        }
    }

    public void IniciarDialogo()
    {
        caixaDeDialogo.SetActive(true);
        somDialogo.PlayOneShot(openEgg);
    }

    
    public void ProximaFala()
    {
        int totalFalas = falas.Count;

        if (controleFalas < totalFalas)
        {
            controleFalas++;
            nomePersonagem.text = quemFala[controleFalas];
            textoFala.text = falas[controleFalas];

            somDialogo.PlayOneShot(openEgg);

            if(controleFalas == totalFalas - 1)
            {
                textoBotao.text = "Close";
            }
        }

        if(controleFalas == totalFalas)
        {
            FinalizaDialogo();
        }
    }
    public void FinalizaDialogo()
    {
        caixaDeDialogo.SetActive(false);
        robson.FimDialogo();
        TriggerDialogo.SetActive(false);
        FimDialogo = true;
    }

    public bool ComecarBatalha()
    {
        return FimDialogo;
    }

}
