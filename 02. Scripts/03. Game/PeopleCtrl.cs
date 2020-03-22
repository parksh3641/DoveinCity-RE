using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PeopleCtrl : MonoBehaviour
{
    private Transform Player;

    private SpriteRenderer sprite;

    private int People_Check;
    private float People_Speed;
    private float Map_Speed;
    private int Dove_Choice;

    private int Candy_Hp;
    private int index; //중복 방지

    private float People_Random_Move_CoolTime;

    private Animator animator_main;
    public Animator Shadow_animator_main;

    public RuntimeAnimatorController animator_child;
    public RuntimeAnimatorController Shadow_animator_child;

    public RuntimeAnimatorController animator_adult;
    public RuntimeAnimatorController Shadow_animator_adult;

    private bool Player_State;
    private bool Olive_State;
    private bool Candy_State;
    private bool Talk_Value;
    private bool Delete_Value;

    private bool Front_Move;
    private bool Right_Move;
    private bool Left_Move;
    private bool Back_Move;

    //대각선
    private bool Front_Right_Move;
    private bool Front_Left_Move;
    private bool Back_Right_Move;
    private bool Back_Left_Move;

    private bool Draw_State;

    private Vector3 Front_Draw_Point;
    private Vector3 Right_Draw_Point;
    private Vector3 Left_Draw_Point;
    private Vector3 Back_Draw_Point;

    private int Wall_Count;
    private bool Hidden_Value;
    private bool Start_Value;

    void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        animator_main = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();

        Front_Draw_Point = new Vector3(-0.04f, 0.04f, 0);
        Right_Draw_Point = new Vector3(0.07f, 0.02f, 0);
        Left_Draw_Point = new Vector3(-0.07f, 0.02f, 0);
        Back_Draw_Point = new Vector3(0.04f, 0.04f, 0);

        Talk_Value = false;
        Hidden_Value = false;
    }

    void Start()
    {
        Dove_Choice = SystemManager.instance.DoveChoice;
        Candy_Hp = SystemManager.instance.Candy_Hp;
        People_Speed = SystemManager.instance.People_Speed;
        People_Random_Move_CoolTime = SystemManager.instance.People_Random_Move_CoolTime;
    }

    IEnumerator Start_Wait(float number)
    {
        Start_Value = false;
        yield return new WaitForSeconds(number);
        Start_Value = true;
    }

    void OnEnable()
    {
        GameManager.Player_Die += Player_Die;
        GameManager.Player_Alive += Player_Alive;
        GameManager.Olive_In += Olive_In;
        GameManager.Olive_Out += Olive_Out;
        GameManager.Talk_In += Talk_In;
        GameManager.Talk_Out += Talk_Out;
        GameManager.Under_In += Hidden_In;
        GameManager.Castle_In += Hidden_In;
        GameManager.Under_Out += Hidden_Out;
        GameManager.Castle_Out += Hidden_Out;

        Map_Speed = SystemManager.instance.Dove_Speed;

        Wall_Count = 0;

        //float a = (Map_Speed * 0.6f) /2;
        Vector3 b = new Vector2(0, -0.04f);
        Front_Draw_Point += b;
        Right_Draw_Point += b;
        Left_Draw_Point += b;
        Back_Draw_Point += b;

        Player_State = true;
        Start_Value = false;
        Olive_State = false;
        Hidden_Value = false;

        Candy_State = true;
        Draw_State = false;

        Delete_Value = true;

        index = 0;

        animator_main.speed = 1;
        Shadow_animator_main.speed = 1;

        StartCoroutine(Start_Wait(2.0f));
        StartCoroutine(Delete_Time());
        People_check();
        StartCoroutine(Count_Reset());
        StartCoroutine(Random_Move());
        StartCoroutine(Player_Distance());
    }

    void OnDisable()
    {
        GameManager.Player_Die -= Player_Die;
        GameManager.Player_Alive -= Player_Alive;
        GameManager.Olive_In -= Olive_In;
        GameManager.Olive_Out -= Olive_Out;
        GameManager.Talk_In -= Talk_In;
        GameManager.Talk_Out -= Talk_Out;
        GameManager.Under_In -= Hidden_In;
        GameManager.Castle_In -= Hidden_In;
        GameManager.Under_Out -= Hidden_Out;
        GameManager.Castle_Out -= Hidden_Out;

        animator_main.SetBool("Front", false);
        animator_main.SetBool("Right", false);
        animator_main.SetBool("Left", false);
        animator_main.SetBool("Back", false);

        Shadow_animator_main.SetBool("Front", false);
        Shadow_animator_main.SetBool("Right", false);
        Shadow_animator_main.SetBool("Left", false);
        Shadow_animator_main.SetBool("Back", false);

        animator_main.SetBool("Front_Draw", false);
        animator_main.SetBool("Right_Draw", false);
        animator_main.SetBool("Left_Draw", false);
        animator_main.SetBool("Back_Draw", false);

        Shadow_animator_main.SetBool("Front_Draw", false);
        Shadow_animator_main.SetBool("Right_Draw", false);
        Shadow_animator_main.SetBool("Left_Draw", false);
        Shadow_animator_main.SetBool("Back_Draw", false);

        Olive_State = false;

        Front_Move = false;
        Right_Move = false;
        Left_Move = false;
        Back_Move = false;

        Front_Right_Move = false;
        Front_Left_Move = false;
        Back_Right_Move = false;
        Back_Left_Move = false;

        StopAllCoroutines();
    }

    void People_check()
    {
        int a = UnityEngine.Random.Range(0, 2);
        if(a == 0) //어린이
        {
            People_Check = 0;
            Sprite_Change(0);
        }
        else // 어른
        {
            People_Check = 1;
            Sprite_Change(1);
        }
    }

    void Sprite_Change(int value)
    {
        if(value == 0)
        {
            animator_main.runtimeAnimatorController = animator_child;
            Shadow_animator_main.runtimeAnimatorController = Shadow_animator_child;
        }
        else
        {
            animator_main.runtimeAnimatorController = animator_adult;
            Shadow_animator_main.runtimeAnimatorController = Shadow_animator_adult;
        }
    }


    void Player_Die()
    {
        try
        {
            Player_State = false;

            Olive_State = false;
            Hidden_Value = false;

            animator_main.speed = 0;
            Shadow_animator_main.speed = 0;

            StopAllCoroutines();
        }
        catch (NullReferenceException ie)
        {
            print(ie.Message);

            GameManager.Player_Die += Player_Die;

            Player_State = false;

            Olive_State = false;
            Hidden_Value = false;

            animator_main.speed = 0;
            Shadow_animator_main.speed = 0;

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
                animator_main.speed = 1;
                Shadow_animator_main.speed = 1;

                StartCoroutine(Count_Reset());
                StartCoroutine(Random_Move());
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
                animator_main.speed = 1;
                Shadow_animator_main.speed = 1;

                StartCoroutine(Count_Reset());
                StartCoroutine(Random_Move());
                StartCoroutine(Player_Distance());
            }
        }
    }
    void Olive_In()
    {
        try
        {
            Olive_State = true;
        }
        catch (NullReferenceException ie)
        {
            print(ie.Message);

            GameManager.Olive_In += Olive_In;

            Olive_State = true;

        }
    }
    void Olive_Out()
    {
        try
        {
            Olive_State = false;
        }
        catch (NullReferenceException ie)
        {
            print(ie.Message);

            GameManager.Olive_Out += Olive_Out;

            Olive_State = false;

        }
    }

    void Talk_In()
    {

        try
        {
            Talk_Value = true;

            animator_main.enabled = false;
            Shadow_animator_main.enabled = false;
        }
        catch (NullReferenceException ie)
        {
            print(ie.Message);

            GameManager.Talk_In += Talk_In;

            Talk_Value = true;

            animator_main.enabled = false;
            Shadow_animator_main.enabled = false;
        }
    }
    void Talk_Out()
    {
        try
        {
            Talk_Value = false;

            if(gameObject.activeSelf == true)
            {
                animator_main.enabled = true;
                Shadow_animator_main.enabled = true;

                if (People_Check == 0)
                {
                    animator_main.SetBool("Candy", false);
                    Shadow_animator_main.SetBool("Candy", false);
                }

                if (Draw_State == true)
                {
                    animator_main.SetBool("Front_Draw", false);
                    animator_main.SetBool("Right_Draw", false);
                    animator_main.SetBool("Left_Draw", false);
                    animator_main.SetBool("Back_Draw", false);

                    Shadow_animator_main.SetBool("Front_Draw", false);
                    Shadow_animator_main.SetBool("Right_Draw", false);
                    Shadow_animator_main.SetBool("Left_Draw", false);
                    Shadow_animator_main.SetBool("Back_Draw", false);

                    animator_main.SetBool("Draw_End", true);
                    Shadow_animator_main.SetBool("Draw_End", true);
                }
            }

        }
        catch (NullReferenceException ie)
        {
            print(ie.Message);

            GameManager.Talk_Out += Talk_Out;

            Talk_Value = false;

            if (gameObject.activeSelf == true)
            {
                animator_main.enabled = true;
                Shadow_animator_main.enabled = true;

                if (People_Check == 0)
                {
                    animator_main.SetBool("Candy", false);
                    Shadow_animator_main.SetBool("Candy", false);
                }

                if (Draw_State == true)
                {
                    animator_main.SetBool("Front_Draw", false);
                    animator_main.SetBool("Right_Draw", false);
                    animator_main.SetBool("Left_Draw", false);
                    animator_main.SetBool("Back_Draw", false);

                    Shadow_animator_main.SetBool("Front_Draw", false);
                    Shadow_animator_main.SetBool("Right_Draw", false);
                    Shadow_animator_main.SetBool("Left_Draw", false);
                    Shadow_animator_main.SetBool("Back_Draw", false);

                    animator_main.SetBool("Draw_End", true);
                    Shadow_animator_main.SetBool("Draw_End", true);
                }
            }
        }
    }

    void Hidden_In()
    {
        try
        {
            Hidden_Value = true;
        }
        catch (NullReferenceException ie)
        {
            print(ie.Message);

            GameManager.Under_In -= Hidden_In;
            GameManager.Castle_In -= Hidden_In;

            Hidden_Value = true;
        }
    }
    void Hidden_Out()
    {
        try
        {
            Hidden_Value = false;
        }
        catch (NullReferenceException ie)
        {
            print(ie.Message);

            GameManager.Under_Out -= Hidden_Out;
            GameManager.Castle_Out -= Hidden_Out;

            Hidden_Value = false;
        }
    }

    IEnumerator Count_Reset()
    {
        yield return new WaitForSeconds(3f);
        Wall_Count = 0;
        StartCoroutine(Count_Reset());
    }

    IEnumerator Player_Distance()
    {
        if(Player_State == true)
        {
            float distance = Vector2.Distance(Player.transform.position, transform.position);

            if (distance < 0.55f)
            {
                Draw_Check();
            }

            if (transform.position.y < Player.position.y - 2.5f)
            {
                transform.rotation = Quaternion.identity;
                gameObject.SetActive(false);
            }

            yield return new WaitForSeconds(0.5f);
            StartCoroutine(Player_Distance());
        }
        else
        {
            yield break;
        }
    }
    IEnumerator Random_Move()
    {
        if (Player_State == true)
        {
            if (People_Check == 0)
            {
                animator_main.SetBool("Candy", false);
                Shadow_animator_main.SetBool("Candy", false);
            }

            animator_main.SetBool("Draw_End", false);
            Shadow_animator_main.SetBool("Draw_End", false);

            int i = UnityEngine.Random.Range(0, 4);
            int j = UnityEngine.Random.Range(0, 3);
            if (i == 0)
            {
                if (index == 1)
                {
                    StartCoroutine(Random_Move());
                    yield break;
                }
                else
                {
                    Front();
                    index = 1;
                }
            }
            else if (i == 1)
            {
                if (j == 0)
                {
                    if (index == 2)
                    {
                        StartCoroutine(Random_Move());
                        yield break;
                    }
                    else
                    {
                        Front_Right();
                        Right();
                        index = 2;
                    }
                }
                else if (j == 1)
                {
                    if (index == 3)
                    {
                        StartCoroutine(Random_Move());
                        yield break;
                    }
                    else
                    {
                        Front_Left();
                        Right();
                        index = 3;
                    }
                }
                else
                {
                    if (index == 4)
                    {
                        StartCoroutine(Random_Move());
                        yield break;
                    }
                    else
                    {
                        Clear();
                        Right();
                        index = 4;
                    }
                }
            }
            else if (i == 2)
            {
                if (j == 0)
                {
                    if (index == 5)
                    {
                        StartCoroutine(Random_Move());
                        yield break;
                    }
                    else
                    {
                        Back_Right();
                        Left();
                        index = 5;
                    }
                }
                else if (j == 1)
                {
                    if (index == 6)
                    {
                        StartCoroutine(Random_Move());
                        yield break;
                    }
                    else
                    {
                        Back_Left();
                        Left();
                        index = 6;
                    }
                }
                else
                {
                    if (index == 7)
                    {
                        StartCoroutine(Random_Move());
                        yield break;
                    }
                    else
                    {
                        Clear();
                        Left();
                        index = 7;
                    }
                }
            }
            else
            {
                if (index == 8)
                {
                    StartCoroutine(Random_Move());
                    yield break;
                }
                else
                {
                    Back();
                    index = 8;
                }
            }

            yield return new WaitForSeconds(UnityEngine.Random.Range(People_Random_Move_CoolTime * 0.8f, People_Random_Move_CoolTime * 1.2f));

            StartCoroutine(Random_Move());
        }
        else
        {
            yield break;
        }
    }

    void Draw_Check()
    {
        if (Draw_State == false && Hidden_Value == false && Start_Value == true)
        {
            if (Olive_State == true)
            {
                if (Dove_Choice == 1 || Dove_Choice == 2)
                {
                    Olive_State = false;
                    Draw_State = true;
                    Draw();
                }
            }
            else
            {
                if (Dove_Choice == 3)
                {
                    Draw_State = true;
                    Draw();
                }
                else if (Dove_Choice == 4)
                {
                    if (DoveCtrl.instance.Weather_Value == 0)
                    {
                        Draw_State = true;
                        Draw();
                    }
                }
            }
        }
    }
    void Draw() //던지기
    {
        Front_Move = false;
        Right_Move = false;
        Left_Move = false;
        Back_Move = false;

        if (Player.position.x < transform.position.x)
        {
            if (Player.position.y < transform.position.y)
            {
                animator_main.SetBool("Front_Draw", true);
                Shadow_animator_main.SetBool("Front_Draw", true);

                //Debug.Log("↙ 감지됨");
                StartCoroutine(Drawing(transform.position + Front_Draw_Point));
            }
            else
            {
                animator_main.SetBool("Left_Draw", true);
                Shadow_animator_main.SetBool("Left_Draw", true);

                //Debug.Log("↖ 감지됨");
                StartCoroutine(Drawing(transform.position + Left_Draw_Point));

            }
        }
        else
        {
            if (Player.position.y < transform.position.y)
            {
                animator_main.SetBool("Right_Draw", true);
                Shadow_animator_main.SetBool("Right_Draw", true);

                //Debug.Log("↘ 감지됨");
                StartCoroutine(Drawing(transform.position + Right_Draw_Point));
            }
            else
            {
                animator_main.SetBool("Back_Draw", true);
                Shadow_animator_main.SetBool("Back_Draw", true);

                //Debug.Log("↗ 감지됨");
                StartCoroutine(Drawing(transform.position + Back_Draw_Point));
            }
        }
    }

    IEnumerator Drawing(Vector3 Point)
    {
        People_Speed = 0;
        yield return new WaitForSeconds(0.3f);

        if (Dove_Choice == 1 || Dove_Choice == 3)
        {
            GameManager2.instance.Object_Create_Stone(Point);
        }
        else
        {
            GameManager2.instance.Object_Create_Mandu(Point);
        }

        yield return new WaitForSeconds(1.5f);

        animator_main.SetBool("Front_Draw", false);
        animator_main.SetBool("Right_Draw", false);
        animator_main.SetBool("Left_Draw", false);
        animator_main.SetBool("Back_Draw", false);

        Shadow_animator_main.SetBool("Front_Draw", false);
        Shadow_animator_main.SetBool("Right_Draw", false);
        Shadow_animator_main.SetBool("Left_Draw", false);
        Shadow_animator_main.SetBool("Back_Draw", false);

        if (People_Check == 0)
        {
            animator_main.SetBool("Candy", false);
            Shadow_animator_main.SetBool("Candy", false);
        }

        animator_main.SetBool("Draw_End", true);
        Shadow_animator_main.SetBool("Draw_End", true);

        yield return new WaitForSeconds(1.0f);

        People_Speed = SystemManager.instance.People_Speed;
    }

    void Front()
    {
        animator_main.SetBool("Front", true);
        animator_main.SetBool("Right", false);
        animator_main.SetBool("Left", false);
        animator_main.SetBool("Back", false);
        Front_Move = true;
        Right_Move = false;
        Left_Move = false;
        Back_Move = false;

        Shadow_animator_main.SetBool("Front", true);
        Shadow_animator_main.SetBool("Right", false);
        Shadow_animator_main.SetBool("Left", false);
        Shadow_animator_main.SetBool("Back", false);
    }
    void Right()
    {
        animator_main.SetBool("Front", false);
        animator_main.SetBool("Right", true);
        animator_main.SetBool("Left", false);
        animator_main.SetBool("Back", false);
        Front_Move = false;
        Right_Move = true;
        Left_Move = false;
        Back_Move = false;

        Shadow_animator_main.SetBool("Front", false);
        Shadow_animator_main.SetBool("Right", true);
        Shadow_animator_main.SetBool("Left", false);
        Shadow_animator_main.SetBool("Back", false);
    }
    void Left()
    {
        animator_main.SetBool("Front", false);
        animator_main.SetBool("Right", false);
        animator_main.SetBool("Left", true);
        animator_main.SetBool("Back", false);
        Front_Move = false;
        Right_Move = false;
        Left_Move = true;
        Back_Move = false;

        Shadow_animator_main.SetBool("Front", false);
        Shadow_animator_main.SetBool("Right", false);
        Shadow_animator_main.SetBool("Left", true);
        Shadow_animator_main.SetBool("Back", false);
    }
    void Back()
    {
        animator_main.SetBool("Front", false);
        animator_main.SetBool("Right", false);
        animator_main.SetBool("Left", false);
        animator_main.SetBool("Back", true);
        Front_Move = false;
        Right_Move = false;
        Left_Move = false;
        Back_Move = true;

        Shadow_animator_main.SetBool("Front", false);
        Shadow_animator_main.SetBool("Right", false);
        Shadow_animator_main.SetBool("Left", false);
        Shadow_animator_main.SetBool("Back", true);
    }

    void Clear()
    {
        Front_Right_Move = false;
        Front_Left_Move = false;
        Back_Right_Move = false;
        Back_Left_Move = false;
    }
    void Front_Right()
    {
        Front_Right_Move = true;
        Front_Left_Move = false;
        Back_Right_Move = false;
        Back_Left_Move = false;
    }
    void Front_Left()
    {
        Front_Right_Move = false;
        Front_Left_Move = true;
        Back_Right_Move = false;
        Back_Left_Move = false;
    }
    void Back_Right()
    {
        Front_Right_Move = false;
        Front_Left_Move = false;
        Back_Right_Move = true;
        Back_Left_Move = false;
    }
    void Back_Left()
    {
        Front_Right_Move = false;
        Front_Left_Move = false;
        Back_Right_Move = false;
        Back_Left_Move = true;
    }

    IEnumerator Candy()
    {
        People_Speed = 0;

        animator_main.SetBool("Candy", true);
        Shadow_animator_main.SetBool("Candy", true);

        yield return new WaitForSeconds(1.5f);

        animator_main.SetBool("Candy", false);
        Shadow_animator_main.SetBool("Candy", false);

        animator_main.SetBool("Draw_End", true);
        Shadow_animator_main.SetBool("Draw_End", true);

        yield return new WaitForSeconds(1.0f);

        People_Speed = SystemManager.instance.People_Speed;
    }

    IEnumerator Delete_Time()
    {
        yield return new WaitForSeconds(0.2f);
        Delete_Value = false;
    }
    void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Wall" || coll.gameObject.tag == "Building" || coll.gameObject.tag == "Building2" || coll.gameObject.tag == "CastleWall" || coll.gameObject.tag == "OliveTree"
            || coll.gameObject.tag == "Ship")
        {
            Wall_Count += 1;
            if (Wall_Count >= 10)
            {
                gameObject.SetActive(false);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {

        }
        else if (coll.gameObject.tag == "Player2") //사탕 냠냠
        {
            if (Player_State == true)
            {
                if (Dove_Choice == 1 && People_Check == 0 && Candy_State == true)
                {
                    Candy_State = false;
                    StartCoroutine(Candy());
                    GameManager.instance.Hp_Plus(Candy_Hp);
                }
            }
        }

        if (coll.gameObject.tag == "Wall" || coll.gameObject.tag == "Building" || coll.gameObject.tag == "Building2" || coll.gameObject.tag == "CastleWall" || coll.gameObject.tag == "OliveTree"
            || coll.gameObject.tag == "Ship")
        {
            if (Delete_Value == true)
            {
                gameObject.SetActive(false);
            }
            else
            {
                Wall_Count += 1;
                if (Wall_Count >= 10)
                {
                    gameObject.SetActive(false);
                }

                if (Front_Move == true)
                {
                    Back();
                }
                else if (Right_Move == true)
                {
                    if (Front_Right_Move == true)
                    {
                        Back_Left();
                    }
                    else if (Front_Left_Move == true)
                    {
                        Back_Right();
                    }
                    Left();
                }
                else if (Left_Move == true)
                {
                    if (Back_Right_Move == true)
                    {
                        Front_Left();
                    }
                    else if (Back_Left_Move == true)
                    {
                        Front_Right();
                    }
                    Right();
                }
                else
                {
                    Front();
                }
            }
        }
    }

    void Update()
    {
        if (Player_State == true && Talk_Value == false)
        {
            if (Front_Move == true)
            {
                transform.Translate(0, -People_Speed * Time.deltaTime, 0);
                //Debug.Log("↓ 이동중");
            }
            else if (Right_Move == true)
            {
                if (Front_Right_Move == true) //↗
                {
                    transform.Translate(People_Speed * Time.deltaTime, People_Speed * Time.deltaTime, 0);
                    //Debug.Log("↗ 이동중");
                }
                else if (Front_Left_Move == true)//↘
                {
                    transform.Translate(People_Speed * Time.deltaTime, -People_Speed * Time.deltaTime, 0);
                    //Debug.Log("↘ 이동중");
                }
                else
                {
                    transform.Translate(People_Speed * Time.deltaTime, 0, 0);
                    //Debug.Log("→ 이동중");
                }
            }
            else if (Left_Move == true)
            {
                if (Back_Right_Move == true) //↖
                {
                    transform.Translate(-People_Speed * Time.deltaTime, People_Speed * Time.deltaTime, 0);
                    //Debug.Log("↖ 이동중");
                }
                else if (Back_Left_Move == true) //↙
                {
                    transform.Translate(-People_Speed * Time.deltaTime, -People_Speed * Time.deltaTime, 0);
                    //Debug.Log("↙ 이동중");
                }
                else
                {
                    transform.Translate(-People_Speed * Time.deltaTime, 0, 0);
                    //Debug.Log("← 이동중");
                }
            }
            else if (Back_Move == true)
            {
                transform.Translate(0, People_Speed * Time.deltaTime, 0);
                //Debug.Log("↑ 이동중");
            }
        }
    }
}
