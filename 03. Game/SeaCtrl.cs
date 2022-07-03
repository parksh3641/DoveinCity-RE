using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaCtrl : MonoBehaviour
{
    private SpriteRenderer sp;

    public Sprite Main_sp;
    public Sprite Sub_sp;

    void Awake()
    {
        sp = GetComponent<SpriteRenderer>();
        Main_sp = Resources.Load("4-3", typeof(Sprite)) as Sprite;
        Sub_sp = Resources.Load("4-4", typeof(Sprite)) as Sprite;
    }

    void OnEnable()
    {
        StartCoroutine(Check());
    }

    void OnDisable()
    {
        StopAllCoroutines();
    }

    IEnumerator Check()
    {
        sp.sprite = Main_sp;
        yield return new WaitForSeconds(1f);
        sp.sprite = Sub_sp;
        yield return new WaitForSeconds(1f);
        StartCoroutine(Check());
    }
}
