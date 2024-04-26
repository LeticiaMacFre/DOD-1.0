using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public void TelaPrincipal()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }

    public void Play()
    {
        SceneManager.LoadScene("OneScene");
    }


    public void Quit()
    {
        Application.Quit();
    }
}
