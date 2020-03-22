using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UFOCtrl : MonoBehaviour
{
    private FollowCtrl follow;
    private Transform Player;
    private Transform trans;

    private float Start_X;
    private float Start_Y;

    private float X = 11f; //비둘기 x좌표
    private float Y = 5f;

    public float End_X;

    public GameObject Beam;
    public EdgeCollider2D edge;

    private float Beam_Scale_x = 0.1f;
    private float Beam_Up = 0.05f;

    public int Enemy_Ufo_Damage;
    private int Enemy_Ufo_Score;

    private bool Dove_Come;
    private bool Beam_Go;

    private bool Player_State;

    public Transform[] Points;

    void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        trans = GetComponent<Transform>();

        Start_X = trans.position.x;
        Start_Y = trans.position.y;

        End_X = Start_X + X;

        Beam.SetActive(false);
        Beam.GetComponent<Transform>().localScale = new Vector3(Beam_Scale_x, 1.0f, 1.0f);
        edge.enabled = false;

        follow = GetComponent<FollowCtrl>();
    }

    void Start()
    {
        Enemy_Ufo_Damage = SystemManager.instance.Enemy_Ufo_Damage;
        Enemy_Ufo_Score = SystemManager.instance.Enemy_Ufo_Score;
    }

    void Random_Points()
    {
        Points[0].position = new Vector3(Start_X, Start_Y, -5);
        for(int i =1;i<Points.Length-1;i++)
        {
            float x = UnityEngine.Random.Range(0.5f, X);
            float y1 = UnityEngine.Random.Range(-Y, Start_Y);
            float y2 = UnityEngine.Random.Range(Start_Y, Start_Y+Y);

            if(i%2 ==0)
            {
                Points[i].position = new Vector3(Start_X + x, y1, -5);
            }
            else
            {
                Points[i].position = new Vector3(Start_X + x, y2, -5);
            }
        }
        Points[Points.Length-1].position = new Vector3(End_X, Start_Y, -5);
    }
    void OnEnable()
    {
        GameManager.Player_Die += Player_Die;
        GameManager.Player_Alive += Player_Alive;

        Player_State = true;

        Dove_Come = false;
        Beam_Go = false;

        Random_Points();
        StartCoroutine(Player_Distance());
    }

    void OnDisable()
    {
        GameManager.Player_Die -= Player_Die;
        GameManager.Player_Alive -= Player_Alive;

        StopAllCoroutines();
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

            if (gameObject.activeSelf == true)
            {
                StartCoroutine(Player_Distance());
            }
        }
    }

    IEnumerator Player_Distance()
    {
        while (Player_State)
        {
            float distance = Vector2.Distance(Player.transform.position, transform.position);
            if (distance < 1.0f)
            {
                if(Dove_Come == false)
                {
                    Dove_Come = true;
                    Beam_Go = true;
                    Beam.SetActive(true);
                    StopAllCoroutines();
                    StartCoroutine(Beaming());
                    EffectManager.instance.Beam();
                }
            }
            yield return new WaitForSeconds(1f);
        }
    }

    IEnumerator Beaming()
    {
        if (Beam_Scale_x <= 1)
        {
            Beam_Scale_x += Beam_Up;
        }
        else
        {
            Beam_Scale_x = 1.0f;
            edge.enabled = true;
            yield return new WaitForSeconds(1.5f);
            Beam_Scale_x = 0.1f;
            edge.enabled = false;
            Beam_Go = false;
            Beam.SetActive(false);
            yield return new WaitForSeconds(3f);
            StopAllCoroutines();
            StartCoroutine(Player_Distance());
            Dove_Come = false;
        }
        yield return new WaitForSeconds(0.02f);
        StartCoroutine(Beaming());
    }
    void Update()
    {
        if (Beam_Go == true)
        {
            Beam.GetComponent<Transform>().localScale = new Vector3(Beam_Scale_x, 1.0f, 1.0f);
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(GameManager.instance.fever == false)
        {
            if (coll.gameObject.tag == "Player")
            {
                GameManager.instance.Hp_Minus_Kind(0);
                GameManager.instance.Hp_Minus(Enemy_Ufo_Damage);
            }
        }
    }
}
