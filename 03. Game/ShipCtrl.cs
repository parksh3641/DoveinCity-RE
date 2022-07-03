using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ShipCtrl : MonoBehaviour
{
    private Transform Player;
    private Transform trans;
    private SpriteRenderer Main_sp;

    public int Enemy_Ship_Damage;

    public Sprite Ship_1;
    public Sprite Ship_2;
    public Sprite Ship_3;

    private bool Player_State;

    private int Enemy_Building_Score;


    void Awake()
    {
        Main_sp = GetComponent<SpriteRenderer>();
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        trans = GetComponent<Transform>();
    }
    void Start()
    {
        Enemy_Building_Score = SystemManager.instance.Enemy_Building_Score;
        Enemy_Ship_Damage = SystemManager.instance.Enemy_Ship_Damage;
    }

    void OnEnable()
    {
        GameManager.Player_Die += Player_Die;
        GameManager.Player_Alive += Player_Alive;

        Player_State = true;

        Random_Sprite();
        StartCoroutine(Player_Distance());
    }

    void OnDisable()
    {
        GameManager.Player_Die -= Player_Die;
        GameManager.Player_Alive -= Player_Alive;

        StopAllCoroutines();
    }

    void Random_Sprite()
    {
        int a = UnityEngine.Random.Range(0, 3);
        switch (a)
        {
            case 0:
                Main_sp.sprite = Ship_1;
                break;
            case 1:
                Main_sp.sprite = Ship_2;
                break;
            case 2:
                Main_sp.sprite = Ship_3;
                break;
        }
    }


    void Player_Die()
    {
        try
        {
            Player_State = false;

            StopAllCoroutines();
        }
        catch (NullReferenceException ie)
        {
            print(ie.Message);

            GameManager.Player_Die += Player_Die;

            Player_State = false;

            StopAllCoroutines();

        }
    }
    void Player_Alive()
    {
        try
        {
            Player_State = true;
            if (gameObject.activeSelf == true)
            {
                StartCoroutine(Player_Distance());
            }
        }
        catch (NullReferenceException ie)
        {
            print(ie.Message);

            GameManager.Player_Alive += Player_Alive;

            Player_State = true;
            if (gameObject.activeSelf == true)
            {
                StartCoroutine(Player_Distance());
            }
        }
    }

    IEnumerator Player_Distance()
    {
        if (transform.position.y < Player.position.y - 2.5f)
        {
            transform.rotation = Quaternion.identity;
            gameObject.SetActive(false);
        }
        yield return new WaitForSeconds(1f);
        StartCoroutine(Player_Distance());
    }


    void OnTriggerEnter2D(Collider2D coll)
    {
        if (GameManager.instance.fever == false)
        {
            if(Player_State == true)
            {
                if (coll.gameObject.tag == "Player")
                {
                    GameManager.instance.Hp_Minus_Kind(0);
                    GameManager.instance.Hp_Minus(Enemy_Ship_Damage);
                }
            }
        }
        else
        {
            if (coll.gameObject.tag == "Player")
            {
                gameObject.SetActive(false);
                GameManager.instance.Score_Plus(Enemy_Building_Score);
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
