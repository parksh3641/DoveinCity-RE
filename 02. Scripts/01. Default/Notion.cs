using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notion : MonoBehaviour
{
    public static Notion instance;

    public float first_speed = 0.5f;
    public float first_cooltime = 0.05f;
    public float second_speed = 0.06f;
    public float second_cooltime = 1.6f;
    private float second_speed_down;
    public float plus_alpha = 0.014f;
    public float plus_scale = 0.9f;
    private float alpha;
    private float scale;

    private Transform trans;
    private Vector3 which;
    private UILabel label;
    private UISprite sprite;

    private int value = 0;

    void Awake()
    {
        instance = this;

        trans = GetComponent<Transform>();
        label = GetComponent<UILabel>();

        if(label == null)
        {
            sprite = GetComponent<UISprite>();
        }
    }

    void OnEnable()
    {
        second_speed_down = second_speed;
        which = trans.localPosition;
        alpha = 1.0f;
        scale = plus_scale;
        value = 0;
        StartCoroutine(First_Wait());
    }
    void OnDisable()
    {
        StopAllCoroutines();
        second_speed = second_speed_down;
        trans.localPosition = which;
        transform.localScale = new Vector3(plus_scale, plus_scale, 0);
    }

    void Update()
    {
        if(label != null)
        {
            label.color = new Color(label.color.r, label.color.g, label.color.b, alpha);
        }
        else
        {
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, alpha);
        }
        transform.localScale = new Vector3(scale, scale, 0);

        if (value == 0)
        {
            transform.Translate(0, first_speed * Time.deltaTime, 0);
        }
        else if(value == 1)
        {
            transform.Translate(0, second_speed * Time.deltaTime, 0);
        }
    }

    IEnumerator First_Wait()
    {
        StartCoroutine(First_Up());
        yield return new WaitForSeconds(first_cooltime);
        value = 1;
        StartCoroutine(Second_Wait());
    }
    IEnumerator First_Up()
    {
        if (scale < 1)
        {
            scale += 0.02f;
            yield return new WaitForSeconds(0.01f);
            StartCoroutine(First_Up());
        }
        else
        {
            StopCoroutine(First_Up());
        }
    }
    IEnumerator Second_Wait()
    {
        StartCoroutine(Second_Down());
        yield return new WaitForSeconds(second_cooltime);
        value = 2;
        StartCoroutine(Second());
    }

    IEnumerator Second()
    {
        if (alpha > 0)
        {
            alpha -= plus_alpha;
            yield return new WaitForSeconds(0.01f);
            StartCoroutine(Second());
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
    IEnumerator Second_Down()
    {
        if(second_speed > 0)
        {
            second_speed -= second_speed * 0.015f;
            yield return new WaitForSeconds(0.01f);
            StartCoroutine(Second_Down());
        }
    }
}
