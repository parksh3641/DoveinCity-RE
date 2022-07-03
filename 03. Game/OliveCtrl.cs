using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OliveCtrl : MonoBehaviour
{
    public int Value; //0은 잎사귀 1는 본체

    private Transform trans;

    private int DoveChoice;
    private int Leaf_Time;

    private float Shake_Amount = 0.015f;
    private float Shake_Time = 0.05f;

    private bool Shaking;

    private int Enemy_Olive_Score;

    void Awake()
    {
        trans = GetComponent<Transform>();
    }

    void Start()
    {
        DoveChoice = SystemManager.instance.DoveChoice;

        Enemy_Olive_Score = SystemManager.instance.Enemy_Olive_Score;
        Leaf_Time = SystemManager.instance.Leaf_Time;
    }

    void OnEnable()
    {
        Shaking = false;
    }
    void OnDisable()
    {
        StopAllCoroutines();
    }

    IEnumerator Shake()
    {
        yield return new WaitForSeconds(0.25f);
        for (int i = 0; i < 2; i++)
        {
            transform.position = new Vector3(trans.position.x + Shake_Amount, trans.position.y, transform.position.z);
            yield return new WaitForSeconds(Shake_Time);
            transform.position = new Vector3(trans.position.x - Shake_Amount, trans.position.y, transform.position.z);
            yield return new WaitForSeconds(Shake_Time);
        }
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (GameManager.instance.fever != false)
        {
            if (coll.gameObject.tag == "Player")
            {
                gameObject.SetActive(false);
                GameManager.instance.Score_Plus(Enemy_Olive_Score);
                EffectManager.instance.Bang();
                Disappear(coll.gameObject.transform.position);
            }
        }
    }
    void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player2")
        {
            if (DoveChoice == 1 || DoveChoice == 2)
            {
                if(Shaking == false)
                {
                    Shaking = true;
                    StartCoroutine(Shake());
                    GameManager.instance.Olive_Start(Leaf_Time);
                }
            }
        }
    }
    void Disappear(Vector3 point)
    {
        Vector3 a = Camera.main.WorldToViewportPoint(point);
        Vector3 x;
        Vector3 y;
        Vector3 z;

        if (a.x <= 0.5f)
        {
            x = new Vector3(a.x * -540, 0, 0);
        }
        else
        {
            x = new Vector3((a.x - 0.5f) * 540, 0, 0);
        }

        if (a.y <= 0.5f)
        {
            y = new Vector3(0, a.y * -960, 0);
        }
        else
        {
            y = new Vector3(0, (a.y - 0.5f) * 960, 0);
        }
        z = x + y;
        GameManager.instance.DisappearUp(z);
    }
}
