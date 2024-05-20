using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public GameObject sound;

    void Start()
    {
        if (sound == null)
        {
            sound = GameObject.Find("Sound");
        }
    }

    public void TelaPrincipal()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void Configuration()
    {
        SceneManager.LoadScene("Configuration");
    }

    public void Play()
    {
        SceneManager.LoadScene("OneScene");
        Destroy(sound);
    }


    public void Quit()
    {
        Application.Quit();
    }
}
