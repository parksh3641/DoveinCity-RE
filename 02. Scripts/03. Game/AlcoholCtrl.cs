using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlcoholCtrl : MonoBehaviour
{
    private UISprite Main_sp;
    private string[] Alcohol = { "Alcohol_1", "Alcohol_2", "Alcohol_3" };

    public float CoolTime = 0.1f;


    void Awake()
    {
        Main_sp = GetComponent<UISprite>();
    }

    void OnEnable()
    {
        StartCoroutine(Alcohol_Move());
    }

    void OnDisable()
    {
        StopAllCoroutines();
    }

    IEnumerator Alcohol_Move()
    {
        Main_sp.spriteName = Alcohol[0];
        yield return new WaitForSeconds(CoolTime);
        Main_sp.spriteName = Alcohol[1];
        yield return new WaitForSeconds(CoolTime);
        Main_sp.spriteName = Alcohol[2];
        yield return new WaitForSeconds(CoolTime);
        Main_sp.spriteName = Alcohol[1];
        yield return new WaitForSeconds(CoolTime);
        StartCoroutine(Alcohol_Move());
    }
}
