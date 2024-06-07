using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiretorCavernaOvo : MonoBehaviour
{
    public GameObject ovo;
    private Animator ovoAnim;
    public GameObject dragao;
    public robsonAndando robson;
    public Animator robsonAnim;
    public GameObject saida;
    public bool startAnimation = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FadeInicial());
        robson = GameObject.FindGameObjectWithTag("Player").GetComponent<robsonAndando>();
        robsonAnim = robson.GetComponent<Animator>();
        ovoAnim = ovo.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(robson.GetTrigger() == "ovo" && !startAnimation)
        {
            StartCoroutine(StartAnimation());
            startAnimation = true;
        }
    }

    IEnumerator StartAnimation()
    {
        robson.Cinematic();
        robsonAnim.SetLayerWeight(3, 1);
        ovoAnim.SetLayerWeight(1, 1);   
        yield return new WaitForSeconds(5.0f);
        ovo.SetActive(false);
        dragao.SetActive(true);
        dragao.GetComponent<AureliusMove>().enabled = true;
        robson.Cinematic();
        robsonAnim.SetLayerWeight(3, 0);
        saida.SetActive(true);
    }

    IEnumerator FadeInicial()
    {
        yield return new WaitForSeconds(1.0f);
        saida.SetActive(false);
    }
}
