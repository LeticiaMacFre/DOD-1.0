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
    public GameObject sound;
    
    public AudioSource audioSource;
    public AudioClip openEgg;
    public AudioClip caveLoop;
    
    public bool startAnimation = false;
    public float tempoCena = 7.0f;
    private bool cenaFulga;

    private SistemaDeDialogo sysDialogo;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FadeInicial());
        robson = GameObject.FindGameObjectWithTag("Player").GetComponent<robsonAndando>();
        sysDialogo = GameObject.FindGameObjectWithTag("Dialogo").GetComponent<SistemaDeDialogo>();
        robsonAnim = robson.GetComponent<Animator>();
        ovoAnim = ovo.GetComponent<Animator>();
        audioSource = sound.GetComponent<AudioSource>();
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
        audioSource.clip = openEgg;
        audioSource.Play();
        robson.Cinematic();
        robsonAnim.SetLayerWeight(3, 1);
        ovoAnim.SetLayerWeight(1, 1);   
        yield return new WaitForSeconds(tempoCena);
        ovo.SetActive(false);
        dragao.SetActive(true);
        dragao.GetComponent<AureluisAI>().enabled = true;
        robson.Cinematic();
        robsonAnim.SetLayerWeight(3, 0);
        saida.SetActive(true);
        audioSource.clip = caveLoop;
        audioSource.Play();
    }

    IEnumerator FadeInicial()
    {
        yield return new WaitForSeconds(1.0f);
        saida.SetActive(false);
    }
}
