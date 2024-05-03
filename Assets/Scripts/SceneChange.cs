using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    public int index;
    public string Caverna;
    public Image fade;
    public Animator anim;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Fading());
        }
    }

    IEnumerator Fading()
    {
        anim.SetBool("Fade", true);
        yield return new WaitUntil(() => fade.color.a == 1);
        SceneManager.LoadScene("Caverna");
    }

}
