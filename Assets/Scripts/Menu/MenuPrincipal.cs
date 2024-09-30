using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public GameObject sound;
    public GameObject menuInGame;
    public bool isPaused = false;
    public bool cursorStatus = true;

    void Start()
    {
        if (sound == null)
        {
            sound = GameObject.Find("Sound");
        }

        if(SceneManager.GetActiveScene().name == "MenuPrincipal")
        {
            //Cursor.visible = cursorStatus;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MenuInGame();
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
        SceneManager.LoadScene("Casarobson");
        //Cursor.visible = !cursorStatus;
        Destroy(sound);
    }


    public void Quit()
    {
        Application.Quit();
    }

    public void MenuInGame()
    {
        if(isPaused)
        {
            Resume();
            menuInGame.SetActive(false);
        }
        else
        {
            Pause();
            menuInGame.SetActive(true);
        }
    }

    private void Pause()
    {
        Time.timeScale = 0;
       // Cursor.visible = !cursorStatus;
        isPaused = true;
    }

    private void Resume()
    {
        Time.timeScale = 1;
       // Cursor.visible = !cursorStatus;
        isPaused = false;
    }
}
