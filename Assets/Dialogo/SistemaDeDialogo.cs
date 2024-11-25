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
    public AudioClip openEgg;
    //public GameObject sound;
    

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
        somDialogo = GetComponent<AudioSource>();
    }



    public void IniciarDialogo()
    {
        caixaDeDialogo.SetActive(true);
        somDialogo.PlayOneShot(openEgg);
    }

    
    public void ProximaFala()
    {
        int totalFalas = falas.Count;

        if(controleFalas <= falas.Count)
        {
            controleFalas++;
            nomePersonagem.text = quemFala[controleFalas];
            textoFala.text = falas[controleFalas];

            somDialogo.PlayOneShot(openEgg);

            if (controleFalas == totalFalas - 1)
            {
                textoBotao.text = "Close";
            }
        }
        

    }

    public void FinalizaDialogo()
    {
        caixaDeDialogo.SetActive(false);
    }

    public bool FimDialogo()
    {
        return fimDialogo;
    }

    


}
