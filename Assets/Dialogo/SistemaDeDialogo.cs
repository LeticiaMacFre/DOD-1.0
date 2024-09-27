using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class SistemaDeDialogo : MonoBehaviour
{
    [SerializeField] public GameObject caixaDeDialogo;

    [SerializeField] public AudioClip somDaExpressao;
    [SerializeField] public TMP_Text nomePersonagem;
    [SerializeField] public TMP_Text textoFala;

    private BasicArray array;

    private void Start()
    {
        array = GameObject.FindGameObjectWithTag("Array").GetComponent<BasicArray>();
    }

   

    public void IniciarDialogo()
    {
        caixaDeDialogo.SetActive(true);
    }



}
