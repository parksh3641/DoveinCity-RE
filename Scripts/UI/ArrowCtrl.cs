using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowCtrl : MonoBehaviour
{
    private Transform trans;
    public float x = 0.08f; // 적용됨
    public float CoolTime = 0.6f;

    public float X;
    public float Y;

    private bool Straight;

    void Awake()
    {
        trans = GetComponent<Transform>();
        X = trans.localPosition.x;
        Y = trans.localPosition.y;
    }

    void OnEnable()
    {
        StartCoroutine(Home_Which());
    }

    void OnDisable()
    {
        StopAllCoroutines();
    }
    IEnumerator Home_Which()
    {
        yield return new WaitForSeconds(0.02f);
        trans.localPosition = new Vector3(X, Y, trans.localPosition.z);
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        Straight = true;
        yield return new WaitForSeconds(CoolTime);
        Straight = false;
        yield return new WaitForSeconds(CoolTime);
        StartCoroutine(Wait());
    }

    void Update()
    {
        if (Straight == true)
        {
            trans.Translate(x * Time.deltaTime, 0, 0);
        }
        else
        {
            trans.Translate(-x * Time.deltaTime, 0, 0);
        }
    }
}
