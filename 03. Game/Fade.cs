using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    public static Fade instance;

    public GameObject Background_Black; //블랙
    private UISprite Black_Fade;

    public float B_fDuration = 3.0f;

    void Awake()
    {
        instance = this;

        Black_Fade = Background_Black.GetComponent<UISprite>();
        Background_Black.SetActive(true);
    }

    void Start()
    {
        StartCoroutine(FadeIn());
    }

    public void Under_In()
    {
        StartCoroutine(FadeOut());
    }
    public void Under_Out()
    {
        StartCoroutine(FadeOut());
    }
    public void Castle_In()
    {
        StartCoroutine(FadeOut());
    }
    public void Castle_Out()
    {
        StartCoroutine(FadeOut());
    }


    IEnumerator FadeIn()
    {
        yield return new WaitForSeconds(0.05f);
        TweenAlpha.Begin(Black_Fade.gameObject, B_fDuration-1.5f, 0.0f);
        yield return new WaitForSeconds(B_fDuration);
    }
    IEnumerator FadeOut()
    {
        TweenAlpha.Begin(Black_Fade.gameObject, B_fDuration, 1.0f);
        yield return new WaitForSeconds(B_fDuration);
        B_fDuration = 3.0f;
        StartCoroutine(FadeIn());
    }
}
