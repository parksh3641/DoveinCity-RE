using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CoinCtrl : MonoBehaviour
{
    private Transform trans;
    private Transform Player;
    private int Object_Coin_Value;

    private float speed;
    private bool magnet;

    private bool Delete_Value;
    void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        trans = GetComponent<Transform>();
        magnet = false;
    }

    void Start()
    {
        Object_Coin_Value = SystemManager.instance.Object_Coin_Value;
    }

    void OnEnable()
    {
        GameManager.Under_In += Hidden_In;
        GameManager.Castle_In += Hidden_In;

        speed = SystemManager.instance.Dove_Speed;

        magnet = false;
        Delete_Value = true;

        StartCoroutine(Delete_Time());
        StartCoroutine(Item_Check());
        StartCoroutine(Player_Distance());
    }
    void OnDisable()
    {
        GameManager.Under_In -= Hidden_In;
        GameManager.Castle_In -= Hidden_In;

        StopAllCoroutines();
    }

    IEnumerator Item_Check()
    {
        float distance = Vector2.Distance(Player.transform.position, transform.position);
        int a = PlayerPrefs.GetInt("Item_Magnet");

        if (distance < 0.5f)
        {
            if (a == 1)
            {
                magnet = true;
            }
            else
            {
                magnet = false;
            }
        }

        yield return new WaitForSeconds(0.5f);
        StartCoroutine(Item_Check());
    }

    void Hidden_In()
    {
        try
        {
            gameObject.SetActive(false);
        }
        catch (NullReferenceException ie)
        {
            print(ie.Message);

            GameManager.Under_In += Hidden_In;
            GameManager.Castle_In += Hidden_In;

            gameObject.SetActive(false);
        }
    }

    IEnumerator Delete_Time()
    {
        yield return new WaitForSeconds(0.2f);
        Delete_Value = false;
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
        if (coll.gameObject.tag == "Player2")
        {
            gameObject.SetActive(false);
            GameManager.instance.Coin_Plus(Object_Coin_Value);
        }


        if (magnet == true && DoveCtrl.instance.Skill_Use == true)
        {
            if (coll.gameObject.tag == "Player3")
            {
                magnet = false;
                gameObject.SetActive(false);
                GameManager.instance.Coin_Plus(Object_Coin_Value);
            }
        }


        if (coll.gameObject.tag == "Building" || coll.gameObject.tag == "Building2" || coll.gameObject.tag == "CastleWall" || coll.gameObject.tag == "OliveTree")
        {
            if(Delete_Value == true)
            {
                GameManager.instance.Object_Create_Coin2();
                gameObject.SetActive(false);
            }
        }
    }

    void Update()
    {
        if (magnet == true)
        {
            Vector2 relativePos = Player.transform.position - transform.position;
            float angle = Mathf.Atan2(relativePos.y, relativePos.x) * Mathf.Rad2Deg;
            transform.localRotation = Quaternion.Euler(0, 0, angle - 90);
            transform.Translate(transform.up * speed * 3f * Time.deltaTime, Space.World);
        }
    }
}
