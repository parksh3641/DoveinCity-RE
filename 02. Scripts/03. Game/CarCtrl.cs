using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CarCtrl : MonoBehaviour
{
    private Transform Player;

    private BoxCollider2D box;
    private SpriteRenderer sprite;
    public SpriteRenderer shadow_sprite;

    public int Value;

    public float speed;
    public int Car_Color;

    public Sprite Blue_Front;
    public Sprite Blue_Right;
    public Sprite Blue_Left;
    public Sprite Blue_Back;

    public Sprite Mint_Front;
    public Sprite Mint_Right;
    public Sprite Mint_Left;
    public Sprite Mint_Back;

    public Sprite Red_Front;
    public Sprite Red_Right;
    public Sprite Red_Left;
    public Sprite Red_Back;

    public Sprite Yellow_Front;
    public Sprite Yellow_Right;
    public Sprite Yellow_Left;
    public Sprite Yellow_Back;

    public List<Sprite> Car_Sprite_Blue = new List<Sprite>();
    public List<Sprite> Car_Sprite_Mint = new List<Sprite>();
    public List<Sprite> Car_Sprite_Red = new List<Sprite>();
    public List<Sprite> Car_Sprite_Yellow = new List<Sprite>();

    private bool Front_Move;
    private bool Right_Move;
    private bool Left_Move;
    private bool Back_Move;

    private bool Player_State;
    private bool Talk_Value;
    private bool Hourglass;

    private int Car_Damage;

    void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        sprite = GetComponent<SpriteRenderer>();
        box = GetComponent<BoxCollider2D>();
        Sprite_Setting();

        Car_Color = 0;

        Front_Move = false;
        Right_Move = false;
        Left_Move = false;
        Back_Move = false;

        Player_State = true;
        Talk_Value = false;
        Hourglass = false;
    }

    void Sprite_Setting()
    {
        Car_Sprite_Blue.Add(Blue_Front);
        Car_Sprite_Blue.Add(Blue_Right);
        Car_Sprite_Blue.Add(Blue_Left);
        Car_Sprite_Blue.Add(Blue_Back);

        Car_Sprite_Mint.Add(Mint_Front);
        Car_Sprite_Mint.Add(Mint_Right);
        Car_Sprite_Mint.Add(Mint_Left);
        Car_Sprite_Mint.Add(Mint_Back);

        Car_Sprite_Red.Add(Red_Front);
        Car_Sprite_Red.Add(Red_Right);
        Car_Sprite_Red.Add(Red_Left);
        Car_Sprite_Red.Add(Red_Back);

        Car_Sprite_Yellow.Add(Yellow_Front);
        Car_Sprite_Yellow.Add(Yellow_Right);
        Car_Sprite_Yellow.Add(Yellow_Left);
        Car_Sprite_Yellow.Add(Yellow_Back);
    }


    void OnEnable()
    {
        GameManager.Player_Die += Player_Die;
        GameManager.Player_Alive += Player_Alive;
        GameManager.Talk_In += Talk_In;
        GameManager.Talk_Out += Talk_Out;
        GameManager.Under_In += Hidden_In;
        GameManager.Castle_In += Hidden_In;

        Car_Damage = SystemManager.instance.Car_Damage;
        if(Value != 1)
        {
            speed = UnityEngine.Random.Range(SystemManager.instance.Dove_Speed * 1.0f, SystemManager.instance.Dove_Speed * 1.25f);
        }
        else
        {
            speed = UnityEngine.Random.Range(SystemManager.instance.Dove_Speed * 2.25f, SystemManager.instance.Dove_Speed * 2.5f);
        }

        Random_Car();
        StartCoroutine(Delete_Time());
        StartCoroutine(Item_Check());
        StartCoroutine(Player_Distance());
    }

    void OnDisable()
    {
        GameManager.Player_Die -= Player_Die;
        GameManager.Player_Alive -= Player_Alive;
        GameManager.Talk_In -= Talk_In;
        GameManager.Talk_Out -= Talk_Out;
        GameManager.Under_In -= Hidden_In;
        GameManager.Castle_In -= Hidden_In;

        StopAllCoroutines();
    }

    IEnumerator Delete_Time()
    {
        yield return new WaitForSeconds(20f);
        gameObject.SetActive(false);
    }

    IEnumerator Item_Check()
    {
        int a = PlayerPrefs.GetInt("Item_Hourglass");

        if (a == 1)
        {
            Hourglass = true;
        }
        else
        {
            Hourglass = false;
        }
        yield return new WaitForSeconds(0.5f);
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
                StartCoroutine(Delete_Time());
                StartCoroutine(Item_Check());
                StartCoroutine(Player_Distance());
            }
        }
        catch (NullReferenceException ie)
        {
            print(ie.Message);

            GameManager.Player_Alive += Player_Alive;

            Player_State = true;

            if (transform.gameObject.activeSelf == true)
            {
                StartCoroutine(Delete_Time());
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

            StopAllCoroutines();
        }
        catch (NullReferenceException ie)
        {
            print(ie.Message);

            GameManager.Talk_In += Talk_In;

            Talk_Value = true;

            StopAllCoroutines();
        }
    }
    void Talk_Out()
    {
        try
        {
            Talk_Value = false;

            if (transform.gameObject.activeSelf == true)
            {
                StartCoroutine(Delete_Time());
                StartCoroutine(Item_Check());
                StartCoroutine(Player_Distance());
            }
        }
        catch (NullReferenceException ie)
        {
            print(ie.Message);

            GameManager.Talk_Out += Talk_Out;

            Talk_Value = false;

            if (transform.gameObject.activeSelf == true)
            {
                StartCoroutine(Delete_Time());
                StartCoroutine(Item_Check());
                StartCoroutine(Player_Distance());
            }
        }
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
        if (transform.position.y < Player.position.y - 2f)
        {
            transform.rotation = Quaternion.identity;
            gameObject.SetActive(false);
        }
        yield return new WaitForSeconds(1f);
        StartCoroutine(Player_Distance());
    }

    void Random_Car()
    {
        if (Value == 1)
        {
            Back();
        }
        else if (Value == 2)
        {
            Right();
        }
        else if (Value == 3)
        {
            Left();
        }
        else //안쓸거같은데?
        {
            Front();
        }

        int i = UnityEngine.Random.Range(0, 4);

        Car_Color_Change(i, Value);
    }

    void Car_Color_Change(int number,int number2)
    {
        switch(number)
        {
            case 0:
                switch(number2)
                {
                    case 0:
                        break;
                    case 1:
                        sprite.sprite = Car_Sprite_Blue[3];
                        shadow_sprite.sprite = Car_Sprite_Blue[3];
                        break;
                    case 2:
                        sprite.sprite = Car_Sprite_Blue[1];
                        shadow_sprite.sprite = Car_Sprite_Blue[1];
                        break;
                    case 3:
                        sprite.sprite = Car_Sprite_Blue[2];
                        shadow_sprite.sprite = Car_Sprite_Blue[2];
                        break;
                }
                break;
            case 1:
                switch (number2)
                {
                    case 0:
                        break;
                    case 1:
                        sprite.sprite = Car_Sprite_Mint[3];
                        shadow_sprite.sprite = Car_Sprite_Mint[3];
                        break;
                    case 2:
                        sprite.sprite = Car_Sprite_Mint[1];
                        shadow_sprite.sprite = Car_Sprite_Mint[1];
                        break;
                    case 3:
                        sprite.sprite = Car_Sprite_Mint[2];
                        shadow_sprite.sprite = Car_Sprite_Mint[2];
                        break;
                }
                break;
            case 2:
                switch (number2)
                {
                    case 0:
                        break;
                    case 1:
                        sprite.sprite = Car_Sprite_Red[3];
                        shadow_sprite.sprite = Car_Sprite_Red[3];
                        break;
                    case 2:
                        sprite.sprite = Car_Sprite_Red[1];
                        shadow_sprite.sprite = Car_Sprite_Red[1];
                        break;
                    case 3:
                        sprite.sprite = Car_Sprite_Red[2];
                        shadow_sprite.sprite = Car_Sprite_Red[2];
                        break;
                }
                break;
            case 3:
                switch (number2)
                {
                    case 0:
                        break;
                    case 1:
                        sprite.sprite = Car_Sprite_Yellow[3];
                        shadow_sprite.sprite = Car_Sprite_Yellow[3];
                        break;
                    case 2:
                        sprite.sprite = Car_Sprite_Yellow[1];
                        shadow_sprite.sprite = Car_Sprite_Yellow[1];
                        break;
                    case 3:
                        sprite.sprite = Car_Sprite_Yellow[2];
                        shadow_sprite.sprite = Car_Sprite_Yellow[2];
                        break;
                }
                break;
        }
    }


    void Front()
    {
        Front_Move = true;
        Right_Move = false;
        Left_Move = false;
        Back_Move = false;

        box.size = new Vector2(0.9f, 1.28f);
    }
    void Right()
    {
        Front_Move = false;
        Right_Move = true;
        Left_Move = false;
        Back_Move = false;

        box.size = new Vector2(1.41f, 0.9f);
    }
    void Left()
    {
        Front_Move = false;
        Right_Move = false;
        Left_Move = true;
        Back_Move = false;

        box.size = new Vector2(1.41f, 0.9f);
    }
    void Back()
    {
        Front_Move = false;
        Right_Move = false;
        Left_Move = false;
        Back_Move = true;

        box.size = new Vector2(0.9f, 1.28f);
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            if(Player_State == true)
            {
                GameManager.instance.Hp_Minus_Kind(2);
                GameManager.instance.Hp_Minus(Car_Damage);
            }
        }
    }


    void Update()
    {
        if (Player_State == true && Talk_Value == false)
        {
            if (Front_Move == true)
            {
                if (Hourglass == false)
                {
                    transform.Translate(0, speed * Time.deltaTime, 0);
                }
                else
                {
                    transform.Translate(0, speed * 0.7f * Time.deltaTime, 0);
                }
            }
            else if (Right_Move == true)
            {
                if (Hourglass == false)
                {
                    transform.Translate(speed * Time.deltaTime, 0, 0);
                }
                else
                {
                    transform.Translate(speed * 0.7f * Time.deltaTime, 0, 0);
                }
            }
            else if (Left_Move == true)
            {
                if (Hourglass == false)
                {
                    transform.Translate(-speed * Time.deltaTime, 0, 0);
                }
                else
                {
                    transform.Translate(-speed * 0.7f * Time.deltaTime, 0, 0);
                }
            }
            else if (Back_Move == true)
            {
                if (Hourglass == false)
                {
                    transform.Translate(0, -speed * Time.deltaTime, 0);
                }
                else
                {
                    transform.Translate(0, -speed * 0.7f * Time.deltaTime, 0);
                }
            }
        }
    }
}
