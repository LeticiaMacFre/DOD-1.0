using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour
{
    public GameObject canvasgroup;
    private Image image;
    private Animator animator;
    public bool fadein = false;
    public bool fadeout = false;

    public float TimeToFade;

    private void Start()
    {
        image = canvasgroup.GetComponent<Image>();
        animator = canvasgroup.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (fadein == true)
        {
            if (image.color.a <= 0)
            {
                float valor += TimeToFade * Time.deltaTime;
                image.color;
                if (canvasgroup.alpha >= 1)
                {
                    fadein = false;
                }
            }
        }

        if (fadeout == true)
        {
            if (canvasgroup.alpha >= 0)
            {
                canvasgroup.alpha += TimeToFade * Time.deltaTime;
                if (canvasgroup.alpha == 0)
                {
                    fadeout = false;
                }
            }
        }
        */


    }

    public void FadeIn()
    {
        // fadein = true;
        animator.Play("Base Layer.Fade");
    }
    public void FadeOut() 
    {
     fadeout = true;
    }   
}
    

    


