using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WaveCtrl : MonoBehaviour
{
    private Transform Player;
    private Transform trans;
    private Animator animator;

    public float speed;
    public float Wave_Speed;
    public int Enemy_Wave_Damage;

    private bool Player_State;
    private bool Talk_Value;

    private bool Right;
    private bool Left;

    private bool hourglass;

    void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        trans = GetComponent<Transform>();
        animator = GetComponent<Animator>();

        Right = false;
        Left = false;
    }

    void Start()
    {
        Enemy_Wave_Damage = SystemManager.instance.Enemy_Wave_Damage;
    }

    void OnEnable()
    {
        GameManager.Player_Die += Player_Die;
        GameManager.Player_Alive += Player_Alive;
        GameManager.Talk_In += Talk_In;
        GameManager.Talk_Out += Talk_Out;

        Player_State = true;
        hourglass = false;

        animator.speed = 1;

        trans.position = new Vector3(transform.position.x, trans.position.y, 6);

        speed = SystemManager.instance.Dove_Speed *0.8f; //맵속도에 맞게 내려와야되서
        Wave_Speed = SystemManager.instance.Dove_Speed;

        StartCoroutine(anim_stop());
        Random_Speed();
        StartCoroutine(Item_Check());
        StartCoroutine(Player_Distance());
    }

    void OnDisable()
    {
        GameManager.Player_Die -= Player_Die;
        GameManager.Player_Alive -= Player_Alive;
        GameManager.Talk_In -= Talk_In;
        GameManager.Talk_Out -= Talk_Out;

        StopAllCoroutines();
    }

    IEnumerator Item_Check()
    {
        int a = PlayerPrefs.GetInt("Item_Hourglass");

        if (a == 1)
        {
            hourglass = true;
        }
        else
        {
            hourglass = false;
        }
        yield return new WaitForSeconds(0.2f);
        StartCoroutine(Item_Check());
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
                StartCoroutine(Item_Check());
                StartCoroutine(Player_Distance());
            }
        }
        catch (NullReferenceException ie)
        {
            print(ie.Message);

            GameManager.Player_Alive += Player_Alive;

            if (gameObject.activeSelf == true)
            {
                StartCoroutine(Item_Check());
                StartCoroutine(Player_Distance());
            }
        }
    }

    void Talk_In()
    {
        try
        {
            Talk_Value = true;
        }
        catch (NullReferenceException ie)
        {
            print(ie.Message);

            GameManager.Talk_In += Talk_In;

            Talk_Value = true;
        }
    }
    void Talk_Out()
    {
        try
        {
            Talk_Value = false;
        }
        catch (NullReferenceException ie)
        {
            print(ie.Message);

            GameManager.Talk_Out += Talk_Out;

            Talk_Value = false;
        }
    }


    IEnumerator anim_stop()
    {
        yield return new WaitForSeconds(0.7f);
        animator.speed = 0;

        if (transform.position.x > Player.position.x) //오른쪽
        {
            Right = true;
            Left = false;
            trans.localScale = new Vector3(trans.localScale.x, trans.localScale.y, 1);
        }
        else
        {
            Right = false;
            Left = true;
            trans.localScale = new Vector3(-trans.localScale.x, trans.localScale.y, 1);
        }
    }

    void Random_Speed()
    {
        Wave_Speed = UnityEngine.Random.Range((Wave_Speed * 1.2f), (Wave_Speed * 1.5f));
    }

    IEnumerator Player_Distance()
    {
        while (Player_State)
        {
            float distance = Vector2.Distance(Player.transform.position, transform.position);
            if (distance > 2.5f)
            {
                transform.rotation = Quaternion.identity;
                gameObject.SetActive(false);
            }
            if (transform.position.y < Player.position.y - 2.5f)
            {
                transform.rotation = Quaternion.identity;
                gameObject.SetActive(false);
            }

            yield return new WaitForSeconds(1f);
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player") //부딫히는 것
        {
            GameManager.instance.Hp_Minus_Kind(0);
            GameManager.instance.Hp_Minus(Enemy_Wave_Damage);
        }

        if (GameManager.instance.fever == false)
        {
            if (coll.gameObject.tag == "Duck" && DoveCtrl.instance.Hit_Value == false)
            {
                gameObject.SetActive(false);
                GameManager.instance.Aid_Duck_Shield_Off();
            }
        }
    }

    void Update()
    {
        if (Player_State == true)
        {
            if (Talk_Value == false)
            {
                if (Right == true)
                {
                    if(hourglass == true)
                    {
                        transform.Translate(-Wave_Speed  * 0.7f * Time.deltaTime, -speed * Time.deltaTime, 0);
                    }
                    else
                    {
                        transform.Translate(-Wave_Speed * Time.deltaTime, -speed * Time.deltaTime, 0);
                    }
                }
                else if (Left == true)
                {
                    if (hourglass == true)
                    {
                        transform.Translate(Wave_Speed * 0.7f * Time.deltaTime, -speed * Time.deltaTime, 0);
                    }
                    else
                    {
                        transform.Translate(Wave_Speed * Time.deltaTime, -speed * Time.deltaTime, 0);
                    }
                }
            }
        }
    }
}
