using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEditor;
using UnityEngine;

public class BasicArray : MonoBehaviour
{
    private TMP_Text[] nome;
    private TMP_Text[] fala;

    private TMP_Text fala0;
    private TMP_Text fala1;
    private TMP_Text fala2;
    private TMP_Text fala3;
    private TMP_Text fala4;
    private TMP_Text fala5;
    private TMP_Text fala6;


 private void Awake()
 {
        fala0.text = "Ol� William!";
        fala1.text = "Ol� jovem Rob! Como vai?";
        fala2.text = "Bem! Estou a caminho da floresta";
        fala3.text = "H� rumores de drag�es por l� Rob!";
        fala4.text = "Vou descobrir se � verdade hehe";
        fala5.text = "Ent�o prepare-se para correr! Fugir!";
        fala6.text = "Terei cuidado! At� logo!";

 }

    private void Start()
    {
        fala = new TMP_Text[] { fala0, fala1, fala2, fala3, fala4, fala5, fala6, null };
    }

}









