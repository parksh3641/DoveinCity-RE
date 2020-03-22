using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectDove : MonoBehaviour
{
    private Transform trans;
    public static SelectDove instance;

    private UISprite sprite;

    private float Cooltime;
    private int DoveChoice;

    private string[] Black = { "black_1", "black_2", "black_3", "black_4", "black_5", "black_6" };
    private string[] White = { "White_1", "White_2", "White_3", "White_4", "White_5", "White_6" };
    private string[] Eagle = { "Eagle_1", "Eagle_2", "Eagle_3", "Eagle_4", "Eagle_5", "Eagle_6" };
    private string[] Dora = { "Dora_1", "Dora_2", "Dora_3", "Dora_4", "Dora_5", "Dora_6" };

    void Awake()
    {
        instance = this;

        trans = GetComponent<Transform>();
    }

    void Start()
    {
        sprite = GetComponent<UISprite>();

        Cooltime = SystemManager.instance.SelectDoveCooltime;
        DoveChoice = SystemManager.instance.DoveChoice;

        trans.localScale = new Vector2(1.0f, 1.0f);

        if (DoveChoice == 1)
        {
            StartCoroutine(Flying(Black));
        }
        else if (DoveChoice == 2)
        {
            StartCoroutine(Flying(White));
        }
        else if (DoveChoice == 3)
        {
            StartCoroutine(Flying(Eagle));
            trans.localScale = new Vector2(1.2f, 1.2f);
        }
        else if (DoveChoice == 4)
        {
            StartCoroutine(Flying(Dora));
        }
    }

    public void Check(int number)
    {
        StopAllCoroutines();

        trans.localScale = new Vector2(1.0f, 1.0f);

        if (number == 1)
        {
            StartCoroutine(Flying(Black));
        }
        else if(number == 2)
        {
            StartCoroutine(Flying(White));
        }
        else if (number == 3)
        {
            StartCoroutine(Flying(Eagle));
            trans.localScale = new Vector2(1.2f, 1.2f);
        }
        else if(number == 4)
        {
            StartCoroutine(Flying(Dora));
        }
    }

    IEnumerator Flying(string[] a)
    {
        while (true)
        {
            sprite.spriteName = a[0];
            yield return new WaitForSeconds(Cooltime);
            sprite.spriteName = a[1];
            yield return new WaitForSeconds(Cooltime);
            sprite.spriteName = a[2];
            yield return new WaitForSeconds(Cooltime);
            sprite.spriteName = a[3];
            yield return new WaitForSeconds(Cooltime);
            sprite.spriteName = a[4];
            yield return new WaitForSeconds(Cooltime);
            sprite.spriteName = a[5];
            yield return new WaitForSeconds(Cooltime);
            sprite.spriteName = a[4];
            yield return new WaitForSeconds(Cooltime);
            sprite.spriteName = a[3];
            yield return new WaitForSeconds(Cooltime);
            sprite.spriteName = a[2];
            yield return new WaitForSeconds(Cooltime);
            sprite.spriteName = a[1];
            yield return new WaitForSeconds(Cooltime);
        }
    }
}
