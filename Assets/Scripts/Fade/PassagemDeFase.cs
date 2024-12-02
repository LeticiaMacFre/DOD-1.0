using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PassagemDeFase : MonoBehaviour
{
    public string nextScene;
    public GameObject fadeObj;
    public Animator fadeAnim;

    // Start is called before the first frame update
    void Start()
    {
        fadeObj.SetActive(true);
        fadeAnim = fadeObj.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(FadeOut());
        }
    }

    IEnumerator FadeOut()
    {
        fadeAnim.SetTrigger("FadeOut");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(nextScene);
    }
}
