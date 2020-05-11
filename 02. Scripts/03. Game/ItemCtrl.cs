using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ItemCtrl : MonoBehaviour
{
    public int Value = 0; //0 하트, 1 다이아, 2 도라의 깃털, 3 자석, 4 미니포션, 5 기압계, 6 해킹툴, 7 시간의 모래시계,8 피버모드,9 디스코 뮤직박스
    public int Under = 0;

    private Transform Player;
    private float x; //비둘기 x최대치 좌표

    private Transform trans;
    public Transform Shadow_Trans;
    private SpriteRenderer sprite;
    public SpriteRenderer Shadow_sprite;
    private CapsuleCollider2D coll;

    private int Item_Heart_Hp = 0;
    private int Item_Diamond_Number = 0;
    private int Item_Dora_Number = 0;

    public Sprite Heart;
    public Sprite Diamond;
    public Sprite Feather;
    public Sprite Magnet;
    public Sprite Minipoiton;
    public Sprite Barometer;
    public Sprite Hacktool;
    public Sprite Hourglass;
    public Sprite Fevermode;
    public Sprite Discomusicbox;

    public List<Sprite> List_Item = new List<Sprite>();

    void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        sprite = GetComponent<SpriteRenderer>();
        trans = GetComponent<Transform>();
        coll = GetComponent<CapsuleCollider2D>();

        List_Item.Add(Heart);
        List_Item.Add(Diamond);
        List_Item.Add(Feather);
        List_Item.Add(Magnet);
        List_Item.Add(Minipoiton);
        List_Item.Add(Barometer);
        List_Item.Add(Hacktool);
        List_Item.Add(Hourglass);
        List_Item.Add(Fevermode);
        List_Item.Add(Discomusicbox);
    }

    void Start()
    {
        Item_Heart_Hp = SystemManager.instance.Item_Heart_Hp;
        Item_Diamond_Number = SystemManager.instance.Item_Diamond_Number;
        Item_Dora_Number = SystemManager.instance.Item_Dora_Number;
    }

    public void Tutorial_Change()
    {
        Under = 2;
    }
    void OnEnable()
    {
        GameManager.Under_In += Hidden_In;
        GameManager.Castle_In += Hidden_In;

        if (Under == 0)
        {
            Random_Item(25, 10, 5, 10, 10, 10, 10, 10, 10, 0);
            x = DoveCtrl.instance.x;
            StartCoroutine(Player_Distance());
        }
        else if(Under == 1)
        {
            Random_Item(25, 50, 25, 0, 0, 0, 0, 0, 0, 0);
        }
        else if (Under == 2)
        {
            Random_Item(100, 0, 0, 0, 0, 0, 0, 0, 0, 0);
        }
    }
    void OnDisable()
    {
        GameManager.Under_In -= Hidden_In;
        GameManager.Castle_In -= Hidden_In;

        StopAllCoroutines();
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

    IEnumerator Player_Distance()
    {
        if(transform.position.x < x && transform.position.x > -x)
        {
            if (transform.position.y < Player.position.y - 2.5f)
            {
                transform.rotation = Quaternion.identity;
                gameObject.SetActive(false);
            }
        }
        else
        {
            gameObject.SetActive(false);
        }
        yield return new WaitForSeconds(1f);
        StartCoroutine(Player_Distance());
    }

    void Random_Item(int number,int number2,int number3, int number4,int number5, int number6, int number7, int number8, int number9, int number10)
    {
        int i = UnityEngine.Random.Range(0, 100);
        if(i > 100 - number)
        {
            Value = 0;
        }
        else if(i >= 100 - number - number2)
        {
            Value = 1;
        }
        else if(i >= 100 - number - number2 - number3)
        {
            Value = 2;
        }
        else if(i >= 100 - number - number2 - number3 - number4)
        {
            Value = 3;
        }
        else if (i >= 100 - number - number2 - number3 - number4 - number5)
        {
            Value = 4;
        }
        else if (i >= 100 - number - number2 - number3 - number4 - number5 - number6)
        {
            Value = 5;
        }
        else if (i >= 100 - number - number2 - number3 - number4 - number5 - number6 - number7)
        {
            Value = 6;
        }
        else if (i >= 100 - number - number2 - number3 - number4 - number5 - number6 - number7 - number8)
        {
            Value = 7;
        }
        else if (i >= 100 - number - number2 - number3 - number4 - number5 - number6 - number7 - number8 - number9)
        {
            Value = 8;
        }
        else
        {
            Value = 0;
            return;
        }

        sprite.sprite = List_Item[Value];
        Shadow_sprite.sprite = List_Item[Value];
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (Under != 2)
        {
            if (coll.gameObject.tag == "Player2")
            {
                if (Value == 0)
                {
                    if (Under == 0)
                    {
                        GameManager.instance.Hp_Plus(Item_Heart_Hp);
                    }
                    else
                    {
                        GameManager.instance.Hp_Plus(Item_Heart_Hp * 3);
                    }
                }
                else if (Value == 1)
                {
                    if (Under == 0)
                    {
                        GameManager.instance.Diamond_Plus(Item_Diamond_Number);
                    }
                    else
                    {
                        GameManager.instance.Diamond_Plus(Item_Diamond_Number * 20);
                    }
                }
                else if (Value == 2)
                {
                    if (Under == 0)
                    {
                        GameManager.instance.Dora_Feather_Plus(Item_Dora_Number);
                    }
                    else
                    {
                        GameManager.instance.Dora_Feather_Plus(Item_Dora_Number * 5);
                    }

                }
                else
                {
                    GameManager2.instance.Item_Use(Value); //분담
                }

                EffectManager.instance.Coin_Plus();
                gameObject.SetActive(false);
            }

            if (coll.gameObject.tag == "Building")
            {
                gameObject.SetActive(false);
            }
        }
        else
        {
            if (coll.gameObject.tag == "Player2")
            {
                gameObject.SetActive(false);
                TutorialManager.instance.InGame_Hp_Plus(Item_Heart_Hp);
            }
        }

        if (coll.gameObject.tag == "Building" || coll.gameObject.tag == "Building2" || coll.gameObject.tag == "CastleWall" || coll.gameObject.tag == "OliveTree")
        {
            GameManager.instance.Object_Create_Item2();
            gameObject.SetActive(false);
        }
    }
}
