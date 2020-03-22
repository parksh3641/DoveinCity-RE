using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyCtrl : MonoBehaviour
{
    public static EnemyCtrl instance;

    public int EnemyCheck = 0;
    public int Value = 0; //1이면 튜토리얼용 독수리로 변함.

    private float Default_Speed = 0;
    public float Enemy_Dove_Speed = 0;
    public float Enemy_Eagle_Speed = 0;

    public int Enemy_Dove_Score;
    public int Enemy_Eagle_Score;

    private CapsuleCollider2D boxCollider;
    private Transform trans;
    public Transform Shadow_Transform;
    private Animator anim;
    public Animator Shadow_anim;

    private Transform Player;

    public int Enemy_Black;
    public int Enemy_White;
    public int Enemy_Eagle;
    public int Enemy_Dora;

    public int DoveChoice;
    private float Enemy_Dove_Random_CoolTime;

    private int Gradiant;

    private bool Player_State;
    private bool Talk_Value;
    private bool Hourglass;

    public bool Vector; //참은 오른쪽, 거짓은 왼쪽

    public int Enemy_Dove_Damage;
    public int Enemy_Eagle_Damage;

    private string[] anim_name = { "Black", "White", "Eagle", "Dora"};

    private int Weather;
    private bool Minipoiton;

    void Awake()
    {
        instance = this;

        trans = GetComponent<Transform>();
        boxCollider = GetComponent<CapsuleCollider2D>();
        anim = GetComponent<Animator>();
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        Talk_Value = false;
        Hourglass = false;

        Value = 0;
    }

    void Start()
    {
        DoveChoice = SystemManager.instance.DoveChoice;

        Enemy_Dove_Damage = SystemManager.instance.Enemy_Dove_Damage;
        Enemy_Eagle_Damage = SystemManager.instance.Enemy_Eagle_Damage;

        Enemy_Dove_Score = SystemManager.instance.Enemy_Dove_Score;
        Enemy_Eagle_Score = SystemManager.instance.Enemy_Eagle_Score;

        Enemy_Dove_Random_CoolTime = SystemManager.instance.Enemy_Dove_Random_CoolTime;
    }

    public void Tutorial_Change()
    {
        Value = 1;
    }

    void OnEnable()
    {
        GameManager.Player_Die += Player_Die;
        GameManager.Player_Alive += Player_Alive;
        GameManager.Talk_In += Talk_In;
        GameManager.Talk_Out += Talk_Out;
        GameManager.Under_In += Under_In;
        GameManager.Castle_In += Castle_In;

        Player_State = true;
        Talk_Value = false;
        Hourglass = false;

        anim.enabled = true;
        Shadow_anim.enabled = true;

        anim.speed = 1f;
        Shadow_anim.speed = 1f;

        if (Value == 0)
        {
            Enemy_Dove_Speed = SystemManager.instance.Dove_Speed * 0.85f;
            Enemy_Eagle_Speed = SystemManager.instance.Dove_Speed * 1.75f;
        }
        else
        {
            Enemy_Dove_Speed = SystemManager.instance.Dove_Speed * 1.5f;
            Enemy_Eagle_Speed = SystemManager.instance.Dove_Speed * 1.75f;
        }


        Enemy_Check();
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
        GameManager.Under_In -= Under_In;
        GameManager.Castle_In -= Castle_In;

        StopAllCoroutines();
    }

    IEnumerator Item_Check()
    {
        int a = PlayerPrefs.GetInt("Item_Hourglass");

        if (a == 1)
        {
            if(Hourglass == false)
            {
                Hourglass = true;
                anim.speed = 0.5f;
                Shadow_anim.speed = 0.5f;
                if (Enemy_Black == 1 || Enemy_White == 1)
                {
                    Default_Speed = Enemy_Dove_Speed;
                    Enemy_Dove_Speed = Enemy_Dove_Speed * 0.7f;
                }
                else
                {
                    Default_Speed = Enemy_Eagle_Speed;
                    Enemy_Eagle_Speed = Enemy_Eagle_Speed * 0.7f;
                }
            }
        }
        else
        {
            if (Hourglass == true)
            {
                Hourglass = false;
                anim.speed = 1f;
                Shadow_anim.speed = 1f;
                if (Enemy_Black == 1 || Enemy_White == 1)
                {
                    Enemy_Dove_Speed = Default_Speed;
                }
                else
                {
                    Enemy_Eagle_Speed = Default_Speed;
                }
            }
        }
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(Item_Check());
    }

    void Player_Die()
    {
        try
        {
            Player_State = false;

            anim.enabled = false;
            Shadow_anim.enabled = false;


            StopAllCoroutines();
        }
        catch (NullReferenceException ie)
        {
            print(ie.Message);

            GameManager.Player_Die += Player_Die;

            Player_State = false;

            anim.enabled = false;
            Shadow_anim.enabled = false;


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
                anim.enabled = true;
                Shadow_anim.enabled = true;
                anim.speed = 1;
                Shadow_anim.speed = 1;

                Hourglass = false;

                if (Value == 0)
                {
                    Enemy_Dove_Speed = SystemManager.instance.Dove_Speed * 0.85f;
                    Enemy_Eagle_Speed = SystemManager.instance.Dove_Speed * 1.75f;
                }
                else
                {
                    Enemy_Dove_Speed = SystemManager.instance.Dove_Speed * 1.5f;
                    Enemy_Eagle_Speed = SystemManager.instance.Dove_Speed * 1.75f;
                }

                Enemy_Check();
                Random_Speed();
                StartCoroutine(Item_Check());
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
                anim.enabled = true;
                Shadow_anim.enabled = true;

                anim.speed = 1;
                Shadow_anim.speed = 1;

                Hourglass = false;

                if (Value == 0)
                {
                    Enemy_Dove_Speed = SystemManager.instance.Dove_Speed * 0.85f;
                    Enemy_Eagle_Speed = SystemManager.instance.Dove_Speed * 1.75f;
                }
                else
                {
                    Enemy_Dove_Speed = SystemManager.instance.Dove_Speed * 1.5f;
                    Enemy_Eagle_Speed = SystemManager.instance.Dove_Speed * 1.75f;
                }

                Enemy_Check();
                Random_Speed();
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

            anim.enabled = false;
            Shadow_anim.enabled = false;
        }
        catch (NullReferenceException ie)
        {
            print(ie.Message);

            GameManager.Talk_In += Talk_In;

            Talk_Value = true;

            anim.enabled = false;
            Shadow_anim.enabled = false;
        }
    }
    void Talk_Out()
    {
        try
        {
            Talk_Value = false;

            anim.enabled = true;
            Shadow_anim.enabled = true;
        }
        catch (NullReferenceException ie)
        {
            print(ie.Message);

            GameManager.Talk_Out += Talk_Out;

            Talk_Value = false;

            anim.enabled = true;
            Shadow_anim.enabled = true;
        }
    }

    void Under_In()
    {
        gameObject.SetActive(false);
    }
    void Castle_In()
    {
        gameObject.SetActive(false);
    }

    void Random_Speed()
    {
        if(EnemyCheck != 3)
        {
            Enemy_Dove_Speed = UnityEngine.Random.Range((Enemy_Dove_Speed * 1.0f), (Enemy_Dove_Speed * 1.25f));
        }
        else
        {
            Enemy_Eagle_Speed = UnityEngine.Random.Range((Enemy_Eagle_Speed * 1.0f), (Enemy_Eagle_Speed * 1.25f));
        }
    }
    void Dove_Check()
    {
        Gradiant = UnityEngine.Random.Range(50, 150);
        if (transform.position.x >= Player.position.x) //플레이어보다 오른쪽에 있을 경우
        {
            Vector = true;
            Shadow_Transform.localPosition = new Vector3(-0.3f, -0.4f, Shadow_Transform.localPosition.z);
            transform.Rotate(new Vector3(0, 0, Gradiant));
        }
        else
        {
            Vector = false;
            Shadow_Transform.localPosition = new Vector3(0.3f, 0.4f, Shadow_Transform.localPosition.z);
            transform.Rotate(new Vector3(0, 0, Gradiant));

        }
    }

    void Enemy_Check()
    {
        if(EnemyCheck == 1)
        {
            Enemy_Black = 1;
            anim.CrossFade(anim_name[0], 0.1f);
            Shadow_anim.CrossFade(anim_name[0], 0.1f);

            Dove_Check();
            StartCoroutine(Random_Move());
            trans.position = new Vector3(transform.position.x, trans.position.y, 3);
        }
        else if(EnemyCheck == 2)
        {
            Enemy_White = 1;
            anim.CrossFade(anim_name[1], 0.1f);
            Shadow_anim.CrossFade(anim_name[1], 0.1f);

            if(Value == 0)
            {
                Dove_Check();
                StartCoroutine(Random_Move());
                trans.position = new Vector3(transform.position.x, trans.position.y, 3);
            }
            else
            {
                trans.rotation = Quaternion.Euler(0, 0, 180);
                Shadow_Transform.transform.localPosition = new Vector3(-0.3f, 0.4f, Shadow_Transform.localPosition.z);
            }
        }
        else if (EnemyCheck == 3)
        {
            Enemy_Eagle = 1;
            anim.CrossFade(anim_name[2], 0.1f);
            Shadow_anim.CrossFade(anim_name[2], 0.1f);

            boxCollider.size = new Vector2(1.8f, 0.5f);
            trans.rotation = Quaternion.Euler(0, 0, 180);

            trans.position = new Vector3(transform.position.x, trans.position.y, -2);
            Shadow_Transform.transform.localPosition = new Vector3(-0.3f, 0.4f, Shadow_Transform.localPosition.z);

        }
        else if (EnemyCheck == 4)
        {
            Enemy_Dora = 1;
            anim.CrossFade(anim_name[3], 0.1f);
            Shadow_anim.CrossFade(anim_name[3], 0.1f);

            Dove_Check();
            StartCoroutine(Random_Move());
            trans.position = new Vector3(transform.position.x, trans.position.y, 3);
        }
    }

    IEnumerator Random_Move()
    {
        while (Player_State)
        {
            if (Talk_Value == false)
            {
                transform.rotation = Quaternion.identity;
                Gradiant = UnityEngine.Random.Range(50, 150);
                if (Vector == true)
                {
                    transform.Rotate(new Vector3(0, 0, Gradiant));

                }
                else
                {
                    transform.Rotate(new Vector3(0, 0, -Gradiant));

                }
            }
            yield return new WaitForSeconds(Enemy_Dove_Random_CoolTime);
        }
    }
    IEnumerator Player_Distance()
    {
        while (Player_State)
        {
            float distance = Vector2.Distance(Player.transform.position, transform.position);

            if (Enemy_Black == 1 || Enemy_White == 1)
            {
                if (distance > 2.0f)
                {
                    transform.rotation = Quaternion.identity;
                    gameObject.SetActive(false);
                }
            }

            if (transform.position.y < Player.position.y - 1.5f)
            {
                transform.rotation = Quaternion.identity;
                gameObject.SetActive(false);
            }

            yield return new WaitForSeconds(1f);
        }
    }

    void Update()
    {
        if (Player_State == true && Talk_Value == false)
        {
            if (Enemy_Black == 1 || Enemy_White == 1)
            {
                transform.Translate(0, Enemy_Dove_Speed * Time.deltaTime, 0);
            }
            else
            {
                transform.Translate(0, Enemy_Eagle_Speed * Time.deltaTime, 0);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (Value == 0)
        {
            Weather = DoveCtrl.instance.Weather_Value;
            Minipoiton = DoveCtrl.instance.Minipoiton;

            if (GameManager.instance.fever == false)
            {
                if (coll.gameObject.tag == "Player") //부딫히는 것
                {
                    if (DoveChoice == 1) //구구일때
                    {
                        if (Enemy_White == 1) //루루면 데미지입음
                        {
                            if (Weather != 1) //밤이 아닐 경우
                            {
                                GameManager.instance.Hp_Minus_Kind(0);
                                GameManager.instance.Hp_Minus(Enemy_Dove_Damage);
                            }
                        }
                        else if (Enemy_Eagle == 1) //독수리면 데미지입음
                        {
                            GameManager.instance.Hp_Minus_Kind(0);
                            GameManager.instance.Hp_Minus(Enemy_Eagle_Damage);
                        }
                    }
                    else if (DoveChoice == 2) //루루일때
                    {
                        if (Enemy_Black == 1)
                        {
                            if (Minipoiton == true || Weather != 0) //미니포션 먹었거나 낮이 아닐경우 구구 못 잡아먹음
                            {
                                GameManager.instance.Hp_Minus_Kind(0);
                                GameManager.instance.Hp_Minus(Enemy_Dove_Damage);
                            }

                        }
                        if (Enemy_Eagle == 1) //독수리면 데미지입음
                        {
                            GameManager.instance.Hp_Minus_Kind(0);
                            GameManager.instance.Hp_Minus(Enemy_Eagle_Damage);
                        }
                    }
                    else if (DoveChoice == 3)
                    {
                        if (Minipoiton == true) //미니포션 먹어서 아무도 못 잡아먹음
                        {
                            GameManager.instance.Hp_Minus_Kind(0);
                            GameManager.instance.Hp_Minus(Enemy_Dove_Damage);
                        }
                        else
                        {
                            //아무일도 일어나지 않음. 먹지 않음
                        }
                    }
                    else if (DoveChoice == 4)
                    {
                        if (Enemy_Eagle == 1) // 독수리면 데미지 입음
                        {
                            GameManager.instance.Hp_Minus_Kind(0);
                            GameManager.instance.Hp_Minus(Enemy_Eagle_Damage);
                        }
                    }
                }
                else if (coll.gameObject.tag == "Player2") //부딫혔지만 먹을 수 있는 것
                {
                    if (DoveChoice == 1) //구구일때
                    {
                        if (Enemy_White == 1)
                        {
                            if (Weather == 1) //밤에 잡아먹음
                            {
                                gameObject.SetActive(false);
                                GameManager.instance.Hp_Plus(Enemy_Dove_Damage);
                                GameManager.instance.Score_Plus(Enemy_Dove_Score);
                            }
                        }
                    }
                    if (DoveChoice == 2) //루루일때
                    {
                        if (Enemy_Black == 1) //구구랑 부딫히는데 미니포션 안 먹었을때 먹을 수 있음
                        {
                            if (Minipoiton == false)
                            {
                                if (Weather == 0) //낮일 경우
                                {
                                    gameObject.SetActive(false);
                                    GameManager.instance.Hp_Plus(Enemy_Dove_Damage);
                                    GameManager.instance.Score_Plus(Enemy_Dove_Score);
                                }
                            }
                        }
                    }
                    else if (DoveChoice == 3) //수리수리일때
                    {
                        if (Minipoiton == false) //미니포션 안 먹었고 언제든 먹을 수 있음
                        {
                            gameObject.SetActive(false);
                            if (Weather == 2) //비 오는 날에 체력 2배 회복
                            {
                                GameManager.instance.Hp_Plus((Enemy_Dove_Damage / 2) * 2);
                                GameManager.instance.Score_Plus(Enemy_Dove_Score);
                            }
                            else
                            {
                                GameManager.instance.Hp_Plus(Enemy_Dove_Damage / 2);
                                GameManager.instance.Score_Plus(Enemy_Dove_Score / 2);
                            }
                        }
                    }
                    else if (DoveChoice == 4) //도라일때
                    {
                        if (Enemy_Black == 1 || Enemy_White == 1) //체력 나누어줌 개꿀
                        {
                            GameManager.instance.Hp_Plus(Enemy_Dove_Damage / 3);
                            GameManager.instance.Score_Plus(Enemy_Dove_Score / 3);
                        }
                    }
                }
                else if (coll.gameObject.tag == "Duck" && DoveCtrl.instance.Hit_Value == false)
                {
                    if (DoveChoice == 1 && Weather != 1)
                    {
                        gameObject.SetActive(false);
                        GameManager.instance.Aid_Duck_Shield_Off();
                    }
                    else if(DoveChoice == 2 && Weather != 0)
                    {
                        gameObject.SetActive(false);
                        GameManager.instance.Aid_Duck_Shield_Off();
                    }
                }
            }
            else
            {
                if (coll.gameObject.tag == "Player")
                {
                    if (EnemyCheck == 3)
                    {
                        gameObject.SetActive(false);
                        GameManager.instance.Score_Plus(Enemy_Eagle_Score);
                        EffectManager.instance.Bang();
                        Disappear(coll.gameObject.transform.position);
                    }
                }
            }

            if (coll.gameObject.tag == "Beam")
            {
                gameObject.SetActive(false);
            }
        }
        else
        {
            if (coll.gameObject.tag == "Player")
            {
                TutorialManager.instance.InGame_Hp_Minus(Enemy_Eagle_Damage);
            }
            else if (coll.gameObject.tag == "Sun")
            {
                TutorialManager.instance.InGame_Hp_Minus(Enemy_Dove_Damage);
            }
            else if (coll.gameObject.tag == "Moon")
            {
                gameObject.SetActive(false);
                TutorialManager.instance.InGame_Hp_Plus(Enemy_Dove_Damage);
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
