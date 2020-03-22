using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private UISprite sprite;

    private float First_Cooltime = 1.5f;
    private float Second_Cooltime = 0.15f;

    void Awake()
    {
        sprite = GetComponent<UISprite>();
    }
    void OnEnable()
    {
        StartCoroutine(anim());
    }
    void OnDisable()
    {
        StopAllCoroutines();
    }

    IEnumerator anim()
    {
        sprite.spriteName = "Coin_1";
        yield return new WaitForSeconds(First_Cooltime);
        sprite.spriteName = "Coin_2";
        yield return new WaitForSeconds(Second_Cooltime);
        sprite.spriteName = "Coin_3";
        yield return new WaitForSeconds(Second_Cooltime);
        sprite.spriteName = "Coin_4";
        yield return new WaitForSeconds(Second_Cooltime);
        StartCoroutine(anim());

    }
}
