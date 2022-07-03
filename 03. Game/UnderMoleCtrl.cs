using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderMoleCtrl : MonoBehaviour
{
    private Transform trans;
    private Animator animator;

    private int Enemy_Mole_Damage;

    void Awake()
    {
        trans = GetComponent<Transform>();
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        Enemy_Mole_Damage = SystemManager.instance.Enemy_Mole_Damage;
    }
    void OnEnable()
    {
        Random_Size();
    }

    void Random_Size()
    {
        float a = Random.Range(1f, 1.5f);
        float b = Random.Range(0.1f, 0.5f);
        animator.speed = a;
        trans.localScale = new Vector3(b, b, trans.localScale.z);
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (GameManager.instance.fever == false)
        {
            if (coll.gameObject.tag == "Player")
            {
                GameManager.instance.Hp_Minus_Kind(0);
                GameManager.instance.Hp_Minus(Enemy_Mole_Damage);
            }
        }
        else
        {
            if (coll.gameObject.tag == "Player")
            {
                gameObject.SetActive(false);
                GameManager.instance.Score_Plus(Enemy_Mole_Damage);
                EffectManager.instance.Bang();
                Disappear(coll.gameObject.transform.position);
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
