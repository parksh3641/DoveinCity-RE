using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TalkObjectCtrl : MonoBehaviour
{
    Vector3 Object_Which;
    Vector3 Object_Which_x;
    Vector3 Object_Which_y;

    private Transform Player;
    private Animator animator;

    public int Value; //1은 두더지 2는 산신령

    public GameObject Arrow_Mark;
    public GameObject Exclamation_Mark;

    private bool Player_State;
    private bool Skill_Value;
    private bool Check_Value;
    private bool Delete_Value;
    private bool Start_Value;
    private bool Hidden_Value;


    void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        animator = GetComponent<Animator>();

        Player_State = true;
        Skill_Value = false;
        Check_Value = false;
        Start_Value = false;
        Hidden_Value = false;
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
        SkillManager.Skill_In += Skill_In;
        SkillManager.Skill_Out += Skill_Out;
        GameManager.Talk_Out += Talk_Out;
        GameManager.Under_In += Hidden_In;
        GameManager.Castle_In += Hidden_In;
        GameManager.Under_Out += Hidden_Out;
        GameManager.Castle_Out += Hidden_Out;

        Arrow_Mark.SetActive(true);
        Exclamation_Mark.SetActive(false);

        Check_Value = false;
        Delete_Value = true;

        StartCoroutine(Start_Wait(2));
        StartCoroutine(Delete_Time());
        StartCoroutine(Player_Distance());
    }
    void OnDisable()
    {
        GameManager.Player_Die -= Player_Die;
        GameManager.Player_Alive -= Player_Alive;
        SkillManager.Skill_In -= Skill_In;
        SkillManager.Skill_Out -= Skill_Out;
        GameManager.Talk_Out -= Talk_Out;
        GameManager.Under_In -= Hidden_In;
        GameManager.Castle_In -= Hidden_In;
        GameManager.Under_Out -= Hidden_Out;
        GameManager.Castle_Out -= Hidden_Out;

        Check_Value = false;

        StopAllCoroutines();
    }

    IEnumerator Delete_Time()
    {
        yield return new WaitForSeconds(0.2f);
        Delete_Value = false;
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

    void Talk_Out()
    {
        try
        {
            if (Check_Value == true)
            {
                gameObject.SetActive(false);

                EffectManager.instance.Disappear();

                if (Value == 2)
                {
                    GameManager.instance.DisappearUp(Object_Which);
                }
            }
        }
        catch (NullReferenceException ie)
        {
            print(ie.Message);

            GameManager.Talk_Out += Talk_Out;

            if (Check_Value == true)
            {
                gameObject.SetActive(false);

                EffectManager.instance.Disappear();

                if (Value == 2)
                {
                    GameManager.instance.DisappearUp(Object_Which);
                }
            }

        }
    }

    void Skill_In()
    {
        try
        {
            Skill_Value = true;
        }
        catch (NullReferenceException ie)
        {
            print(ie.Message);

            SkillManager.Skill_In += Skill_In;

            Skill_Value = true;
        }
    }
    void Skill_Out()
    {
        try
        {
            Skill_Value = false;
        }
        catch (NullReferenceException ie)
        {
            print(ie.Message);

            SkillManager.Skill_Out += Skill_Out;

            Skill_Value = false;
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

            GameManager.Under_Out += Hidden_Out;
            GameManager.Castle_Out += Hidden_Out;

            Hidden_Value = false;
        }
    }


    IEnumerator Player_Distance()
    {
        float distance = Vector2.Distance(Player.transform.position, transform.position);

        if (distance < 0.4f)
        {
            if (Player_State == true && Skill_Value == false && Check_Value == false && Hidden_Value == false && GameManager.instance.fever == false)
            {
                if(Start_Value == true)
                {
                    Check_Value = true;
                    Check();
                }
            }
        }

        if (transform.position.y < Player.position.y - 2.5f)
        {
            transform.rotation = Quaternion.identity;
            gameObject.SetActive(false);
        }
        yield return new WaitForSeconds(0.1f);
        StartCoroutine(Player_Distance());
    }

    void Check()
    {
        Arrow_Mark.SetActive(false);

        int i = UnityEngine.Random.Range(0, 100); //일단 확률 100퍼
        if (i <= 80)
        {
            Exclamation_Mark.SetActive(true);
            StartCoroutine(Animation_Coming());
        }
        else
        {
            Exclamation_Mark.SetActive(false);
            //Debug.Log("대화 실패");
        }
    }
    
    IEnumerator Animation_Coming()
    {
        EffectManager.instance.Surprised();
        yield return new WaitForSeconds(0.3f);
        if (Value == 1)
        {
            LanguageManager.instance.Talk_Mole_Notion();
        }
        else if (Value == 2)
        {
            LanguageManager.instance.Talk_God_Notion();
        }
        Exclamation_Mark.SetActive(false);
        animator.SetBool("Coming", true);

        if (Value == 1)
        {
            GameManager.instance.MoleTalk();
        }
        else if (Value == 2)
        {
            GameManager.instance.GodTalk();
        }

        yield return new WaitForSeconds(0.7f);
        animator.speed = 0;

        Vector3 a = Camera.main.WorldToViewportPoint(transform.position);

        if(a.x <= 0.5f)
        {
            Object_Which_x = new Vector3(a.x * -540, 0, 0);
        }
        else
        {
            Object_Which_x = new Vector3((a.x - 0.5f) * 540, 0, 0);
        }

        if(a.y <= 0.5f)
        {
            Object_Which_y = new Vector3(0, a.y * -960, 0);
        }
        else
        {
            Object_Which_y = new Vector3(0, (a.y - 0.5f) * 960, 0);
        }
        Object_Which = Object_Which_x + Object_Which_y;
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Wall" || coll.gameObject.tag == "Building" || coll.gameObject.tag == "Building2" || coll.gameObject.tag == "CastleWall" || coll.gameObject.tag == "OliveTree")
        {
            if (Value == 1 && Delete_Value == true)
            {
                gameObject.SetActive(false);
            }
        }

    }
}
