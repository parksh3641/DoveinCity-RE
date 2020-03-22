using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DoveCtrl : MonoBehaviour
{
    public static DoveCtrl instance;

    public GameObject Branch;

    public float x;

    private int DoveChoice;

    private bool Player_State;

    private float Dove_Invincibel_Time;
    public bool Skill_Use;
    private float Skill_Time;

    private float Dove_Size;
    private float Shadow_Size;

    public bool Hit_Value;
    private float Alpha;
    private float Shadow_Alpha;

    private Animator anim;
    public Animator Shadow_anim;

    private SpriteRenderer sprite;
    public SpriteRenderer Shadow_sprite;

    private Transform Dove_transform;
    public Transform Shadow_transform;

    public CapsuleCollider2D box;
    public CapsuleCollider2D Shadow_box;

    private string[] anim_name = { "Black", "White", "Eagle", "Dora", "SunSkin", "ClockSkin", "WowSkin" };

    public Sprite Black_Skill;
    public Sprite White_Skill;
    public Sprite Eagle_Skill;
    public Sprite Dora_Skill;

    public Sprite Sunshine_Skill;
    public Sprite Clocking_Skill;
    public Sprite Rainbow_Skill;

    private List<Sprite> Sprite_Skill_Number = new List<Sprite>();

    private Sprite Sprite_Skill; //기본 값

    public Sprite Black_die;
    public Sprite White_die;
    public Sprite Eagle_die;
    public Sprite Dora_die;

    //히든 맵

    Vector3 Save_Which;
    private bool Under_Value;
    private bool Castle; //캐슬 한번만 입장시키기.
    private bool Castle_Value;
    private bool Hidden_Value;

    //아이템
    public bool Minipoiton;

    //날씨
    public int Weather_Value = 0; //0 = 낮,1 = 밤,2 = 비

    //조력자
    public GameObject Aid_Object;
    public GameObject Aid_Main;
    public SpriteRenderer Aid_Main_sp;
    public SpriteRenderer Aid_Shadow_sp;

    public Sprite Owl_sp;
    public Sprite Duck_sp;

    private int Aid;

    //피버모드
    private bool fever;
    //UFO
    private bool Ufo;

    private bool Talk_Value;

    private int Enemy_Building_Damage;
    private int Enemy_Building_Score;
    private int Enemy_Castle_Score;

    void Awake()
    {
        instance = this;

        box = GetComponent<CapsuleCollider2D>();

        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        Dove_transform = GetComponent<Transform>();

        Player_State = true;
        Talk_Value = false;

        Alpha = 1;
        Shadow_Alpha = 0.5f;
        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, Alpha);
        Shadow_sprite.color = new Color(Shadow_sprite.color.r, Shadow_sprite.color.g, Shadow_sprite.color.b, Shadow_Alpha);

        Dove_Size = 0.13f;
        Shadow_Size = 0.7f;
        x = 4.71f;

        Branch.SetActive(false);

        Hit_Value = false;
        box.enabled = true;
        Shadow_box.enabled = true;

        Under_Value = false;
        Castle = false;
        Castle_Value = false;
        Hidden_Value = false;

        Minipoiton = false;

        Sprite_Skill_Number.Add(Black_Skill);
        Sprite_Skill_Number.Add(White_Skill);
        Sprite_Skill_Number.Add(Eagle_Skill);
        Sprite_Skill_Number.Add(Dora_Skill);
        Sprite_Skill_Number.Add(Sunshine_Skill);
        Sprite_Skill_Number.Add(Clocking_Skill);
        Sprite_Skill_Number.Add(Rainbow_Skill);

        Aid_Object.SetActive(false);
        Aid = PlayerPrefs.GetInt("Aid");
        if(Aid == 1)
        {
            Aid_Main_sp.sprite = Owl_sp;
            Aid_Shadow_sp.sprite = Owl_sp;
        }
        else if(Aid == 2)
        {
            Aid_Object.SetActive(true);
            Aid_Main_sp.sprite = Duck_sp;
            Aid_Shadow_sp.sprite = Duck_sp;
            Aid_Main_sp.gameObject.tag = "Duck";
        }

        fever = false;
        Ufo = false;
    }
    void Start()
    {
        DoveChoice = SystemManager.instance.DoveChoice; //비둘기 선택값 가져오기
        DoveChange(DoveChoice);

        Dove_Invincibel_Time = SystemManager.instance.Dove_Invincibel_Time;
        Skill_Time = SystemManager.instance.Skill_Time;

        Enemy_Building_Damage = SystemManager.instance.Enemy_Building_Damage;
        Enemy_Building_Score = SystemManager.instance.Enemy_Building_Score;
        Enemy_Castle_Score = SystemManager.instance.Enemy_Castle_Score;

        if(box == null)
        {
            box = GetComponent<CapsuleCollider2D>();
        }

        StartCoroutine(Start_Wait(2f));
    }

    public void DoveChange(int number) //선택값에 따라 비둘기 변경
    {
        int a, b, c = 0;

        anim.CrossFade(anim_name[number - 1], 0.1f);
        Shadow_anim.CrossFade(anim_name[number - 1], 0.1f);

        Sprite_Skill = Sprite_Skill_Number[number - 1];

        if (number == 1)
        {
            a = PlayerPrefs.GetInt("Sunshine_Black");
            b = PlayerPrefs.GetInt("Clocking_Black");
            c = PlayerPrefs.GetInt("Rainbow_Black");
            if (a == 1)
            {
                anim.CrossFade(anim_name[4], 0.1f);
                Shadow_anim.CrossFade(anim_name[4], 0.1f);
                Sprite_Skill = Sprite_Skill_Number[4];
                //Debug.Log("태양광 스킨착용");
            }
            else if (b == 1)
            {
                anim.CrossFade(anim_name[5], 0.1f);
                Shadow_anim.CrossFade(anim_name[5], 0.1f);
                Sprite_Skill = Sprite_Skill_Number[5];
                //Debug.Log("클로킹 스킨 착용");
            }
            else if (c == 1)
            {
                anim.CrossFade(anim_name[6], 0.1f);
                Shadow_anim.CrossFade(anim_name[6], 0.1f);
                Sprite_Skill = Sprite_Skill_Number[6];
                //Debug.Log("무지개 스킨 착용");
            }
            else
            {
                //Debug.Log("스킨 미착용");
            }
        }
        else if (number == 2)
        {
            a = PlayerPrefs.GetInt("Sunshine_White");
            b = PlayerPrefs.GetInt("Clocking_White");
            c = PlayerPrefs.GetInt("Rainbow_White");
            if (a == 1)
            {
                anim.CrossFade(anim_name[4], 0.1f);
                Shadow_anim.CrossFade(anim_name[4], 0.1f);
                Sprite_Skill = Sprite_Skill_Number[4];
                //Debug.Log("태양광 스킨착용");
            }
            else if (b == 1)
            {
                anim.CrossFade(anim_name[5], 0.1f);
                Shadow_anim.CrossFade(anim_name[5], 0.1f);
                Sprite_Skill = Sprite_Skill_Number[5];
                //Debug.Log("클로킹 스킨 착용");
            }
            else if (c == 1)
            {
                anim.CrossFade(anim_name[6], 0.1f);
                Shadow_anim.CrossFade(anim_name[6], 0.1f);
                Sprite_Skill = Sprite_Skill_Number[6];
                //Debug.Log("무지개 스킨 착용");
            }
            else
            {
                //Debug.Log("스킨 미착용");
            }
        }
        else if (number == 3) //수리수리일경우 box 크기 증가
        {
            box.size = new Vector2(1.4f, 1.4f);
            Shadow_box.size = new Vector3(1.4f, 1.4f);
        }
        else if (number == 4)
        {
            a = PlayerPrefs.GetInt("Sunshine_Dora");
            b = PlayerPrefs.GetInt("Clocking_Dora");
            c = PlayerPrefs.GetInt("Rainbow_Dora");
            if (a == 1)
            {
                anim.CrossFade(anim_name[4], 0.1f);
                Shadow_anim.CrossFade(anim_name[4], 0.1f);
                Sprite_Skill = Sprite_Skill_Number[4];
                //Debug.Log("태양광 스킨착용");
            }
            else if (b == 1)
            {
                anim.CrossFade(anim_name[5], 0.1f);
                Shadow_anim.CrossFade(anim_name[5], 0.1f);
                Sprite_Skill = Sprite_Skill_Number[5];
                //Debug.Log("클로킹 스킨 착용");
            }
            else if (c == 1)
            {
                anim.CrossFade(anim_name[6], 0.1f);
                Shadow_anim.CrossFade(anim_name[6], 0.1f);
                Sprite_Skill = Sprite_Skill_Number[6];
                //Debug.Log("무지개 스킨 착용");
            }
            else
            {
                //Debug.Log("스킨 미착용");
            }
        }
    }


    IEnumerator Start_Wait(float number)
    {
        Hit_Value = false;
        box.enabled = false;
        Shadow_box.enabled = false;

        yield return new WaitForSeconds(number);

        box.enabled = true;
        Shadow_box.enabled = true;
    }
    void OnEnable()
    {
        GameManager.Player_Die += Player_Die;
        GameManager.Player_Alive += Player_Alive;
        SkillManager.Skill_In += Skill_In;
        SkillManager.Skill_Out += Skill_Out;
        GameManager.Olive_In += Olive_In;
        GameManager.Olive_Out += Olive_Out;
        GameManager.Talk_In += Talk_In;
        GameManager.Talk_Out += Talk_Out;
        GameManager.Under_In += Under_In;
        GameManager.Under_Out += Under_Out;
        GameManager.Castle_In += Castle_In;
        GameManager.Castle_Out += Castle_Out;
    }
    void OnDisable()
    {
        GameManager.Player_Die -= Player_Die;
        GameManager.Player_Alive -= Player_Alive;
        SkillManager.Skill_In -= Skill_In;
        SkillManager.Skill_Out -= Skill_Out;
        GameManager.Olive_In -= Olive_In;
        GameManager.Olive_Out -= Olive_Out;
        GameManager.Talk_In -= Talk_In;
        GameManager.Talk_Out -= Talk_Out;
        GameManager.Under_In -= Under_In;
        GameManager.Under_Out -= Under_Out;
        GameManager.Castle_In -= Castle_In;
        GameManager.Castle_Out -= Castle_Out;
    }

    //플레이어 죽을시
    void Player_Die()
    {
        try
        {
            Player_State = false;
            Talk_Value = false;

            Hit_Value = false;
            box.enabled = false;
            Shadow_box.enabled = false;

            anim.enabled = false;
            Shadow_anim.enabled = false;

            if (Aid == 2)
            {
                Aid_Main_sp.gameObject.tag = "Finish";
            }

            Dove_transform.position = new Vector3(Dove_transform.position.x, Dove_transform.position.y, 0);

            if (DoveChoice == 1)
            {
                sprite.sprite = Black_die;
                Shadow_sprite.sprite = Black_die;
            }
            else if (DoveChoice == 2)
            {
                sprite.sprite = White_die;
                Shadow_sprite.sprite = White_die;
            }
            else if (DoveChoice == 3)
            {
                sprite.sprite = Eagle_die;
                Shadow_sprite.sprite = Eagle_die;
            }
            else if (DoveChoice == 4)
            {
                sprite.sprite = Dora_die;
                Shadow_sprite.sprite = Dora_die;
            }

            Alpha = 1;
            Shadow_Alpha = 0.5f;

            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, Alpha);
            Shadow_sprite.color = new Color(Shadow_sprite.color.r, Shadow_sprite.color.g, Shadow_sprite.color.b, Shadow_Alpha);

            Skill_Use = false;

            Dove_Size = 0.13f;
            Shadow_Size = 0.7f;
            x = 4.71f;

            Dove_transform.localScale = new Vector3(Dove_Size, Dove_Size, 1);
            Shadow_transform.localScale = new Vector3(Shadow_Size, Shadow_Size, 1);

            Shadow_transform.localPosition = new Vector3(0.1f, -0.2f, 1);
            Dove_transform.localScale = new Vector3(0.095f, 0.095f, 1);

            Branch.SetActive(false);

            StopAllCoroutines();
        }
        catch (NullReferenceException ie)
        {
            print(ie.Message);

            GameManager.Player_Die += Player_Die;

            Player_State = false;
            Talk_Value = false;

            Hit_Value = false;
            box.enabled = false;
            Shadow_box.enabled = false;

            anim.enabled = false;
            Shadow_anim.enabled = false;

            if (Aid == 2)
            {
                Aid_Main_sp.gameObject.tag = "Finish";
            }

            Dove_transform.position = new Vector3(Dove_transform.position.x, Dove_transform.position.y, 0);

            if (DoveChoice == 1)
            {
                sprite.sprite = Black_die;
                Shadow_sprite.sprite = Black_die;
            }
            else if (DoveChoice == 2)
            {
                sprite.sprite = White_die;
                Shadow_sprite.sprite = White_die;
            }
            else if (DoveChoice == 3)
            {
                sprite.sprite = Eagle_die;
                Shadow_sprite.sprite = Eagle_die;
            }
            else if (DoveChoice == 4)
            {
                sprite.sprite = Dora_die;
                Shadow_sprite.sprite = Dora_die;
            }

            Alpha = 1;
            Shadow_Alpha = 0.5f;

            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, Alpha);
            Shadow_sprite.color = new Color(Shadow_sprite.color.r, Shadow_sprite.color.g, Shadow_sprite.color.b, Shadow_Alpha);

            Skill_Use = false;

            Dove_Size = 0.13f;
            Shadow_Size = 0.7f;
            x = 4.71f;

            Dove_transform.localScale = new Vector3(Dove_Size, Dove_Size, 1);
            Shadow_transform.localScale = new Vector3(Shadow_Size, Shadow_Size, 1);

            Shadow_transform.localPosition = new Vector3(0.1f, -0.2f, 1);
            Dove_transform.localScale = new Vector3(0.095f, 0.095f, 1);

            Branch.SetActive(false);

            StopAllCoroutines();
        }

    }
    void Player_Alive()
    {
        try
        {
            Player_State = true;

            if (Aid == 2)
            {
                Aid_Main_sp.gameObject.tag = "Duck";
            }

            Hit_Value = false;
            Hit();
            Shadow_box.enabled = true;

            anim.enabled = true;
            Shadow_anim.enabled = true;

            Shadow_transform.localPosition = new Vector3(0.3f, -0.4f, 1);
            Dove_transform.localScale = new Vector3(0.13f, 0.13f, 1);
        }
        catch (NullReferenceException ie)
        {
            print(ie.Message);

            GameManager.Player_Alive += Player_Alive;

            Player_State = true;

            if (Aid == 2)
            {
                Aid_Main_sp.gameObject.tag = "Duck";
            }

            Hit_Value = false;
            Hit();
            Shadow_box.enabled = true;

            anim.enabled = true;
            Shadow_anim.enabled = true;

            Shadow_transform.localPosition = new Vector3(0.3f, -0.4f, 1);
            Dove_transform.localScale = new Vector3(0.13f, 0.13f, 1);
        }
    }

    //스킬 사용시
    void Skill_In()
    {
        try
        {
            Dove_transform.position = new Vector3(Dove_transform.position.x, Dove_transform.position.y, -4);

            if (Aid == 2)
            {
                Aid_Main_sp.gameObject.tag = "Finish";
            }

            Hit_Value = false;
            box.enabled = false;
            Shadow_box.enabled = false;

            anim.enabled = false;
            Shadow_anim.enabled = false;

            sprite.sprite = Sprite_Skill;
            Shadow_sprite.sprite = Sprite_Skill;

            Skill_Use = true;
            StartCoroutine(Dove_Size_Up());
            StartCoroutine(Dove_Size_Wait());
        }
        catch (NullReferenceException ie)
        {
            print(ie.Message);

            SkillManager.Skill_In += Skill_In;

            Dove_transform.position = new Vector3(Dove_transform.position.x, Dove_transform.position.y, -4);

            if (Aid == 2)
            {
                Aid_Main_sp.gameObject.tag = "Finish";
            }

            Hit_Value = false;
            box.enabled = false;
            Shadow_box.enabled = false;

            anim.enabled = false;
            Shadow_anim.enabled = false;

            sprite.sprite = Sprite_Skill;
            Shadow_sprite.sprite = Sprite_Skill;

            Skill_Use = true;
            StartCoroutine(Dove_Size_Up());
            StartCoroutine(Dove_Size_Wait());
        }
    }
    void Skill_Out()
    {
        try
        {
            Dove_transform.position = new Vector3(Dove_transform.position.x, Dove_transform.position.y, 0);

            if (Aid == 2)
            {
                Aid_Main_sp.gameObject.tag = "Duck";
            }

            anim.enabled = true;
            Shadow_anim.enabled = true;

            Hit_Value = false;
            box.enabled = true;
            Shadow_box.enabled = true;
        }
        catch (NullReferenceException ie)
        {
            print(ie.Message);

            SkillManager.Skill_Out += Skill_Out;
            box = GetComponent<CapsuleCollider2D>();

            Dove_transform.position = new Vector3(Dove_transform.position.x, Dove_transform.position.y, 0);

            if (Aid == 2)
            {
                Aid_Main_sp.gameObject.tag = "Duck";
            }

            anim.enabled = true;
            Shadow_anim.enabled = true;

            Hit_Value = false;
            box.enabled = true;
            Shadow_box.enabled = true;
        }
    }

    //올리브
    void Olive_In()
    {
        try
        {
            Branch.SetActive(true);
        }
        catch (NullReferenceException ie)
        {
            print(ie.Message);

            GameManager.Olive_In += Olive_In;

            Branch.SetActive(true);
        }
    }
    void Olive_Out()
    {
        try
        {
            Branch.SetActive(false);
        }
        catch (NullReferenceException ie)
        {
            print(ie.Message);

            GameManager.Olive_Out += Olive_Out;

            Branch.SetActive(false);
        }
    }

    void Talk_In()
    {
        try
        {
            Talk_Value = true;

            Hit_Value = false;
            box.enabled = false;
        }
        catch (NullReferenceException ie)
        {
            print(ie.Message);

            GameManager.Talk_In += Talk_In;
            box = GetComponent<CapsuleCollider2D>();

            Talk_Value = true;

            Hit_Value = false;
            box.enabled = false;
        }
    }
    void Talk_Out()
    {
        try
        {
            Talk_Value = false;

            if(Hidden_Value == false)
            {
                Hit_Value = false;
                box.enabled = true;
                Shadow_box.enabled = true;
            }
        }
        catch (NullReferenceException ie)
        {
            print(ie.Message);

            GameManager.Talk_Out += Talk_Out;

            Talk_Value = false;

            if (Hidden_Value == false)
            {
                Hit_Value = false;
                box.enabled = true;
                Shadow_box.enabled = true;
            }
        }
    }

    void Under_In()
    {
        try
        {
            Save_Which = transform.position;

            Under_Value = true;
            Hidden_Value = true;

            StartCoroutine(Hidden_World_Wait());
            StartCoroutine(Start_Wait(5));
        }
        catch (NullReferenceException ie)
        {
            print(ie.Message);

            GameManager.Under_In += Under_In;

            StopAllCoroutines();

            Save_Which = transform.position;

            Under_Value = true;
            Hidden_Value = true;

            StartCoroutine(Hidden_World_Wait());
            StartCoroutine(Start_Wait(5));
        }
    }
    void Under_Out()
    {
        try
        {
            Under_Value = false;
            Hidden_Value = true;

            StartCoroutine(Hidden_Out());
            StartCoroutine(Start_Wait(5));
        }
        catch (NullReferenceException ie)
        {
            print(ie.Message);

            StopAllCoroutines();

            GameManager.Under_Out += Under_Out;

            Under_Value = false;
            Hidden_Value = true;

            StartCoroutine(Hidden_Out());
            StartCoroutine(Start_Wait(5));
        }
    }
    void Castle_In()
    {
        try
        {
            Save_Which = transform.position;

            Castle_Value = true;
            Hidden_Value = true;

            StartCoroutine(Hidden_World_Wait());
            StartCoroutine(Start_Wait(5));
        }
        catch (NullReferenceException ie)
        {
            print(ie.Message);

            GameManager.Castle_In += Castle_In;

            StopAllCoroutines();

            Save_Which = transform.position;

            Castle_Value = true;
            Hidden_Value = true;

            StartCoroutine(Hidden_World_Wait());
            StartCoroutine(Start_Wait(5));
        }
    }
    void Castle_Out()
    {
        try
        {
            Castle_Value = false;
            Hidden_Value = true;

            Hit_Value = false;
            box.enabled = false;
            Shadow_box.enabled = false;

            StartCoroutine(Hidden_Out());
            StartCoroutine(Start_Wait(5));
        }
        catch (NullReferenceException ie)
        {
            print(ie.Message);

            GameManager.Castle_Out += Castle_Out;

            StopAllCoroutines();

            Castle_Value = false;
            Hidden_Value = true;

            Hit_Value = false;
            box.enabled = false;
            Shadow_box.enabled = false;

            StartCoroutine(Hidden_Out());
            StartCoroutine(Start_Wait(5));
        }
    }

    //조력자
    public void Aid_Duck_Shield_On()
    {
        Aid_Main.SetActive(true);
    }
    public void Aid_Duck_Shield_Off()
    {
        Aid_Main.SetActive(false);
    }

    //피버모드
    public void Fever_On()
    {
        fever = true;

        Hit_Value = false;
        box.enabled = true;
        Shadow_box.enabled = true;

        StartCoroutine(Fever_Size_Up());
    }
    public void Fever_Off()
    {
        fever = false;
        StartCoroutine(Fever_Size_Down());

        Hit_Value = false;
        Hit();
    }

    IEnumerator Fever_Size_Up()
    {
        if (Player_State == true)
        {
            if (fever == true)
            {
                if (Dove_Size <= 0.52f)
                {
                    Dove_Size += 0.0039f;
                    if(Shadow_Size > 0.35f)
                    {
                        Shadow_Size -= 0.0035f;
                    }
                }
                else
                {
                    Dove_Size = 0.52f;
                    Shadow_Size = 0.35f;
                    Dove_transform.localScale = new Vector3(Dove_Size, Dove_Size, 1);
                    Shadow_transform.localScale = new Vector3(Shadow_Size, Shadow_Size, 1);
                    yield break;
                }

            }
            else
            {
                StartCoroutine(Fever_Size_Down());
                yield break;
            }
        }
        else
        {
            StartCoroutine(Fever_Size_Down());
            yield break;
        }
        Dove_transform.localScale = new Vector3(Dove_Size, Dove_Size, 1);
        Shadow_transform.localScale = new Vector3(Shadow_Size, Shadow_Size, 1);
        yield return new WaitForSeconds(0.01f);
        StartCoroutine(Fever_Size_Up());
    }
    IEnumerator Fever_Size_Down()
    {
        if (Player_State == true)
        {
            if (Dove_Size >= 0.13f)
            {
                Dove_Size -= 0.0039f;
                Shadow_Size += 0.0035f;
            }
            else
            {
                Dove_Size = 0.13f;
                Shadow_Size = 0.7f;
                Dove_transform.localScale = new Vector3(Dove_Size, Dove_Size, 1);
                Shadow_transform.localScale = new Vector3(Shadow_Size, Shadow_Size, 1);
                yield break;
            }
        }
        else
        {
            Dove_Size = 0.13f;
            Shadow_Size = 0.7f;
            Dove_transform.localScale = new Vector3(Dove_Size, Dove_Size, 1);
            Shadow_transform.localScale = new Vector3(Shadow_Size, Shadow_Size, 1);
            yield break;
        }
        Dove_transform.localScale = new Vector3(Dove_Size, Dove_Size, 1);
        Shadow_transform.localScale = new Vector3(Shadow_Size, Shadow_Size, 1);
        yield return new WaitForSeconds(0.01f);
        StartCoroutine(Fever_Size_Down());
    }

    public void Weather_Sun()
    {
        Weather_Value = 0;
        if (Aid == 1)
        {
            Aid_Object.SetActive(false);
            GameManager.instance.Aid_Owl_Hp_Plus_Off();
        }
    }
    public void Weather_Dark()
    {
        Weather_Value = 1;
        if(Aid == 1)
        {
            Aid_Object.SetActive(true);
            GameManager.instance.Aid_Owl_Hp_Plus_On();
        }
    }
    public void Weather_Rain()
    {
        Weather_Value = 2;
        if (Aid == 1)
        {
            Aid_Object.SetActive(false);
            GameManager.instance.Aid_Owl_Hp_Plus_Off();
        }
    }

    public void Minipoiton_In()
    {
        Minipoiton = true;
        StartCoroutine(Minipoiton_Size_Down());
    }
    public void Minipoiton_Out()
    {
        Minipoiton = false;
        if(fever == false)
        {
            StartCoroutine(Minipoiton_Size_Up());
        }
    }

    IEnumerator Minipoiton_Size_Up()
    {
        while (Player_State)
        {
            if (Minipoiton == false)
            {
                if (Dove_Size <= 0.13f)
                {
                    Dove_Size += 0.00325f;
                    Shadow_Size += 0.0175f;
                }
                else
                {
                    Dove_Size = 0.13f;
                    Shadow_Size = 0.7f;
                    Dove_transform.localScale = new Vector3(Dove_Size, Dove_Size, 1);
                    Shadow_transform.localScale = new Vector3(Shadow_Size, Shadow_Size, 1);
                    yield break;
                }
            }
            Dove_transform.localScale = new Vector3(Dove_Size, Dove_Size, 1);
            Shadow_transform.localScale = new Vector3(Shadow_Size, Shadow_Size, 1);
            yield return new WaitForSeconds(0.01f);
        }
    }
    IEnumerator Minipoiton_Size_Down()
    {
        while (Player_State)
        {
            if (Minipoiton == true)
            {
                if (Dove_Size >= 0.065f)
                {
                    Dove_Size -= 0.00325f;
                    Shadow_Size -= 0.0175f;
                }
                else
                {
                    Dove_Size = 0.065f;
                    Shadow_Size = 0.35f;
                    Dove_transform.localScale = new Vector3(Dove_Size, Dove_Size, 1);
                    Shadow_transform.localScale = new Vector3(Shadow_Size, Shadow_Size, 1);
                    yield break;
                }
            }
            Dove_transform.localScale = new Vector3(Dove_Size, Dove_Size, 1);
            Shadow_transform.localScale = new Vector3(Shadow_Size, Shadow_Size, 1);
            yield return new WaitForSeconds(0.01f);
        }
    }

    IEnumerator Hidden_World_Wait()
    {
        yield return new WaitForSeconds(3f);

        if (Under_Value == true)
        {
            x = 2.91f;
            transform.position = new Vector3(0, transform.position.y, transform.position.z);
        }
        else if (Castle_Value == true)
        {
            x = 1.17f;
            transform.position = new Vector3(0, transform.position.y, transform.position.z);
        }
    }

    IEnumerator Hidden_Out()
    {
        yield return new WaitForSeconds(3f);

        x = 4.71f;
        transform.position = new Vector3(Save_Which.x, Save_Which.y, transform.position.z);

        Hit_Value = false;
        Hit();

        if (Hidden_Value == true)
        {
            Hidden_Value = false;
            Castle = false;
        }
    }


    IEnumerator Dove_Size_Wait()
    {
        yield return new WaitForSeconds(Skill_Time/2);
        Skill_Use = false;
    }
    IEnumerator Dove_Size_Up()
    {
        if (Player_State == true)
        {
            if (Skill_Use == true)
            {
                if (Dove_Size <= 0.26f)
                {
                    Dove_Size += 0.00039f;
                    Shadow_Size -= 0.00105f;
                }
            }
            else
            {
                StartCoroutine(Dove_Size_Down());
                yield break;
            }
        }
        else
        {
            StartCoroutine(Dove_Size_Down());
            yield break;
        }
        Dove_transform.localScale = new Vector3(Dove_Size, Dove_Size, 1);
        Shadow_transform.localScale = new Vector3(Shadow_Size, Shadow_Size, 1);
        yield return new WaitForSeconds(0.01f);
        StartCoroutine(Dove_Size_Up());
    }
    IEnumerator Dove_Size_Down()
    {
        if (Player_State == true)
        {
            if (Dove_Size >= 0.13f)
            {
                Dove_Size -= 0.00039f;
                Shadow_Size += 0.00105f;
            }
            else
            {
                Dove_Size = 0.13f;
                Dove_transform.localScale = new Vector3(Dove_Size, Dove_Size, 1);
                yield break;
            }
        }
        else
        {
            Dove_Size = 0.13f;
            Shadow_Size = 0.7f;
            Dove_transform.localScale = new Vector3(Dove_Size, Dove_Size, 1);
            Shadow_transform.localScale = new Vector3(Shadow_Size, Shadow_Size, 1);
            yield break;
        }
        Dove_transform.localScale = new Vector3(Dove_Size, Dove_Size, 1);
        Shadow_transform.localScale = new Vector3(Shadow_Size, Shadow_Size, 1);
        yield return new WaitForSeconds(0.01f);
        StartCoroutine(Dove_Size_Down());
    }


    //적과 부딫혔을시
    public void Hit()
    {
        if (Hit_Value == false)
        {
            Hit_Value = true;
            StartCoroutine(Invincibel_Time());
        }

    }
    IEnumerator Invincibel_Time() //비둘기 깜빡이는 시간
    {
        box.enabled = false;
        Alpha = 1;
        Shadow_Alpha = 0.5f;
        StartCoroutine(Invincibel_Wait());
        yield return new WaitForSeconds(Dove_Invincibel_Time);

        if(Talk_Value == false && Skill_Use == false)
        {
            Hit_Value = false;
            box.enabled = true;
            Shadow_box.enabled = true;
        }
    }
    IEnumerator Invincibel_Wait() //비둘기 깜빡이는 코루틴
    {
        while (Hit_Value)
        {
            Alpha = 0.5f;
            Shadow_Alpha = 0.25f;
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, Alpha);
            Shadow_sprite.color = new Color(Shadow_sprite.color.r, Shadow_sprite.color.g, Shadow_sprite.color.b, Shadow_Alpha);
            yield return new WaitForSeconds(0.15f);
            Alpha = 1f;
            Shadow_Alpha = 0.5f;
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, Alpha);
            Shadow_sprite.color = new Color(Shadow_sprite.color.r, Shadow_sprite.color.g, Shadow_sprite.color.b, Shadow_Alpha);
            yield return new WaitForSeconds(0.15f);
        }
        yield break;
    }

    public void Ufo_Die()
    {
        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0);
        Shadow_sprite.color = new Color(Shadow_sprite.color.r, Shadow_sprite.color.g, Shadow_sprite.color.b, 0);
        box.enabled = false;
        Shadow_box.enabled = false;
    }

    void Update()
    {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -x, x), transform.position.y, transform.position.z);
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (fever == false)
        {
            if (coll.gameObject.tag == "Castle")
            {
                if(Castle == false)
                {
                    Castle = true;
                    GameManager.instance.CastleUp();
                }
            }
            else if (coll.gameObject.tag == "CastleWall")
            {
                GameManager.instance.Hp_Minus_Kind(0);
                GameManager.instance.Hp_Minus(25);
            }

            if (coll.gameObject.tag == "Beam")
            {
                if(Ufo == false)
                {
                    Ufo = true;
                    GameManager.instance.Ufo_Die();
                    Ufo_Die();
                }
            }
            if (coll.gameObject.tag == "Building" || coll.gameObject.tag == "Building2")
            {
                GameManager.instance.Hp_Minus_Kind(0);
                GameManager.instance.Hp_Minus(Enemy_Building_Damage);
            }
        }
        else
        {
            if (coll.gameObject.tag == "CastleWall")
            {
                coll.gameObject.transform.parent.gameObject.SetActive(false);
                GameManager.instance.Score_Plus(Enemy_Castle_Score);
                EffectManager.instance.Bang();
                Disappear(coll.gameObject.transform.position);
            }

            if (coll.gameObject.tag == "Building")
            {
                coll.gameObject.SetActive(false);
                GameManager.instance.Score_Plus(Enemy_Building_Score);
                EffectManager.instance.Bang();
                Disappear(coll.gameObject.transform.position);
            }
            if (coll.gameObject.tag == "Building2")
            {
                coll.transform.parent.gameObject.SetActive(false);
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
