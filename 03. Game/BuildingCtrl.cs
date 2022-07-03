using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BuildingCtrl : MonoBehaviour
{
    public static BuildingCtrl instance;

    private Transform Player;

    private int Value = 0;

    private Transform trans;
    private CapsuleCollider2D box;
    private SpriteRenderer sprite;
    public SpriteRenderer shadow_sprite;

    public Sprite Big_Building_1;
    public Sprite Big_Building_2;
    public Sprite Big_Building_3;

    public Sprite Small_Building_1;
    public Sprite Small_Building_2;
    public Sprite Small_Building_3;
    public Sprite Small_Building_4;
    public Sprite Small_Building_5;
    public Sprite Small_Building_6;

    public EdgeCollider2D Big_Building_3_box;
    public EdgeCollider2D Building_2_box;
    public EdgeCollider2D Building_6_box;

    public Sprite House;

    public List<Sprite> Building_Sprite = new List<Sprite>();

    private int Enemy_Building_Damage;
    private int Enemy_Building_Score;

    private bool Player_State;
    void Awake()
    {
        instance = this;

        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        trans = GetComponent<Transform>();
        sprite = GetComponent<SpriteRenderer>();
        box = GetComponent<CapsuleCollider2D>();

        Sprite_Setting();
    }

    public void Tutorial_Change()
    {
        Value = 1;
    }

    void Sprite_Setting()
    {
        Building_Sprite.Add(Big_Building_1);
        Building_Sprite.Add(Big_Building_2);
        Building_Sprite.Add(Big_Building_3);

        Building_Sprite.Add(Small_Building_1);
        Building_Sprite.Add(Small_Building_2);
        Building_Sprite.Add(Small_Building_3);
        Building_Sprite.Add(Small_Building_4);
        Building_Sprite.Add(Small_Building_5);
        Building_Sprite.Add(Small_Building_6);

        Building_Sprite.Add(House);
    }

    void OnEnable()
    {
        GameManager.Player_Die += Player_Die;
        GameManager.Player_Alive += Player_Alive;

        Player_State = true;

        Enemy_Building_Damage = SystemManager.instance.Enemy_Building_Damage;
        Enemy_Building_Score = SystemManager.instance.Enemy_Building_Score;

        box.enabled = true;
        Big_Building_3_box.enabled = false;
        Building_2_box.enabled = false;
        Building_6_box.enabled = false;

        if(Value == 0)
        {
            Random_Building();
        }
        else
        {
            Building_Change(2,0);
        }
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

            Player_State = true;

            if (gameObject.activeSelf == true)
            {
                StartCoroutine(Player_Distance());
            }
        }
    }

    void Random_Building()
    {
        int i = UnityEngine.Random.Range(0, 3);
        int j = 0;

        if(i == 0)
        {
            j = UnityEngine.Random.Range(0, 3);
        }
        else if(i == 1)
        {
            j = UnityEngine.Random.Range(0, 6);
        }
        else if(i == 2)
        {
            j = 0;
        }


        Building_Change(i,j);
    }

    void Building_Change(int i,int j)
    {
        shadow_sprite.GetComponent<Transform>().rotation = Quaternion.Euler(-180, 0, -60);

        if (i == 0)
        {
            sprite.GetComponent<Transform>().position = new Vector3(trans.position.x, trans.position.y + 0.2f, trans.position.z);
            box.direction = CapsuleDirection2D.Vertical;
            box.size = new Vector2(2.3f, 5.12f);

            if (j == 0)
            {
                sprite.sprite = Building_Sprite[0];
                shadow_sprite.sprite = Building_Sprite[0];

                shadow_sprite.GetComponent<Transform>().localPosition = new Vector3(0.82f, -2.26f, 1);
                //Debug.Log("Big_Building_1");

            }
            else if (j == 1)
            {
                sprite.sprite = Building_Sprite[1];
                shadow_sprite.sprite = Building_Sprite[1];

                box.size = new Vector2(1.8f, 5.12f);

                shadow_sprite.GetComponent<Transform>().localPosition = new Vector3(1.01f, -2.41f, 1);
                //Debug.Log("Big_Building_2");
            }
            else if (j == 2)
            {
                sprite.sprite = Building_Sprite[2];
                shadow_sprite.sprite = Building_Sprite[2];

                shadow_sprite.GetComponent<Transform>().localPosition = new Vector3(0.95f, -2.56f, 1);

                box.enabled = false;
                Big_Building_3_box.enabled = true;
            }
        }
        else if (i == 1)
        {
            box.direction = CapsuleDirection2D.Vertical;
            box.size = new Vector2(2.4f, 2.56f);

            if (j == 0)
            {
                sprite.sprite = Building_Sprite[3];
                shadow_sprite.sprite = Building_Sprite[3];

                box.size = new Vector2(1.9f, 2.56f);

                shadow_sprite.GetComponent<Transform>().localPosition = new Vector3(0.22f, -0.94f, 1);
                //Debug.Log("Building_1");
            }
            else if (j == 1)
            {
                sprite.sprite = Building_Sprite[4];
                shadow_sprite.sprite = Building_Sprite[4];

                shadow_sprite.GetComponent<Transform>().localPosition = new Vector3(0.15f, -0.94f, 1);

                box.enabled = false;
                Building_2_box.enabled = true;
                //Debug.Log("Building_2");
            }
            else if (j == 2)
            {
                sprite.sprite = Building_Sprite[5];
                shadow_sprite.sprite = Building_Sprite[5];

                box.size = new Vector2(1.6f, 2.56f);

                shadow_sprite.GetComponent<Transform>().localPosition = new Vector3(0.4f, -1.23f, 1);
                //Debug.Log("Building_3");
            }
            else if (j == 3)
            {
                sprite.sprite = Building_Sprite[6];
                shadow_sprite.sprite = Building_Sprite[6];

                box.size = new Vector2(1.8f, 2.56f);

                shadow_sprite.GetComponent<Transform>().localPosition = new Vector3(0.33f, -1.15f, 1);
                //Debug.Log("Building_4");
            }
            else if (j == 4)
            {
                sprite.sprite = Building_Sprite[7];
                shadow_sprite.sprite = Building_Sprite[7];

                box.size = new Vector2(1.6f, 2.56f);

                shadow_sprite.GetComponent<Transform>().localPosition = new Vector3(0.42f, -1.24f, 1);
                //Debug.Log("Building_5");
            }
            else if (j == 2)
            {
                sprite.sprite = Building_Sprite[8];
                shadow_sprite.sprite = Building_Sprite[8];

                shadow_sprite.GetComponent<Transform>().localPosition = new Vector3(0.24f, -1.03f, 1);

                box.enabled = false;
                Building_6_box.enabled = true;
                //Debug.Log("Building_6");
            }
        }
        else if (i == 2)
        {
            sprite.sprite = Building_Sprite[9];
            shadow_sprite.sprite = Building_Sprite[9];

            box.direction = CapsuleDirection2D.Vertical;
            box.size = new Vector2(2.2f, 1.8f);

            sprite.GetComponent<Transform>().position = new Vector3(trans.position.x, trans.position.y - 0.05f, trans.position.z);
            shadow_sprite.GetComponent<Transform>().localPosition = new Vector3(1.02f, -0.29f, 1);

            //Debug.Log("House");
        }

    }

    IEnumerator Player_Distance()
    {
        while (Player_State)
        {
            float distance = Vector2.Distance(Player.transform.position, transform.position);
            if (distance > 2.5f)
            {
                if (transform.position.y < Player.position.y - 2.5f)
                {
                    transform.rotation = Quaternion.identity;
                    gameObject.SetActive(false);
                }
            }

            yield return new WaitForSeconds(1f);
        }
    }
}
