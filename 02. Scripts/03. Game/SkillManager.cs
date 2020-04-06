using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SkillManager : MonoBehaviour
{
    public static SkillManager instance;

    private bool Player_State;

    public float Skill_Time;
    public float SkillCoolTime;

    public UISprite Skill_Filter;
    public UILabel Skill_txt;

    public bool SkillValue; //스킬 사용할 수 있는지 체크

    private bool Minipoiton;

    private int SFX_Value;
    private bool Hidden_Value;

    private bool Talk_Value;

    private bool fever;

    public delegate void Skillmanager();
    public static event Skillmanager Skill_In, Skill_Out;

    void Awake()
    {
        instance = this;

        Player_State = true;

        Minipoiton = false;
        Talk_Value = false;
        fever = false;
    }

    void Start()
    {
        Skill_Time = SystemManager.instance.Skill_Time;
        SkillCoolTime = SystemManager.instance.Skill_CoolTime;

        SkillValue = false;

        Skill_Filter.enabled = true;
        Skill_txt.text = " ";

        Skill_Filter.fillAmount = 0;
        StartCoroutine(Skill_CoolTime_ReSet(Skill_Filter));
        StartCoroutine(Skill_CooltTme_Counter(SkillCoolTime, Skill_txt));
    }

    void OnEnable()
    {
        GameManager.Player_Die += Player_Die;
        GameManager.Player_Alive += Player_Alive;
        GameManager.Talk_In += Talk_In;
        GameManager.Talk_Out += Talk_Out;
        GameManager.Under_In += Under_In;
        GameManager.Castle_In += Castle_In;
        GameManager.Under_Out += Hidden_Out;
        GameManager.Castle_Out += Hidden_Out;
    }
    void OnDisable()
    {
        GameManager.Player_Die -= Player_Die;
        GameManager.Player_Alive -= Player_Alive;
        GameManager.Talk_In -= Talk_In;
        GameManager.Talk_Out -= Talk_Out;
        GameManager.Under_In -= Under_In;
        GameManager.Castle_In -= Castle_In;
        GameManager.Under_Out -= Hidden_Out;
        GameManager.Castle_Out -= Hidden_Out;
    }

    void Player_Die()
    {
        try
        {
            Player_State = false;

            StopAllCoroutines();

            SkillValue = true;

            Skill_Filter.enabled = false;
            Skill_Filter.fillAmount = 1;

            Skill_txt.text = " ";

            EffectManager.instance.Boast_Song_Off();
        }
        catch (NullReferenceException ie)
        {
            print(ie.Message);

            GameManager.Player_Die += Player_Die;

            Player_State = false;

            StopAllCoroutines();

            SkillValue = true;

            Skill_Filter.enabled = false;
            Skill_Filter.fillAmount = 1;

            Skill_txt.text = " ";

            EffectManager.instance.Boast_Song_Off();
        }

    }

    void Player_Alive()
    {
        try
        {
            Player_State = true;
        }
        catch (NullReferenceException ie)
        {
            print(ie.Message);

            Player_State = true;
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

    void Under_In()
    {
        try
        {
            Hidden_Value = true;
        }
        catch (NullReferenceException ie)
        {
            print(ie.Message);

            GameManager.Under_In += Under_In;

            Hidden_Value = true;
        }
    }
    void Castle_In()
    {
        try
        {
            Hidden_Value = true;
        }
        catch (NullReferenceException ie)
        {
            print(ie.Message);

            GameManager.Castle_In += Castle_In;

            Hidden_Value = true;
        }
    }

    void Hidden_Out()
    {
        try
        {
            StartCoroutine(Hidden_World_Wait());
        }
        catch (NullReferenceException ie)
        {
            print(ie.Message);

            GameManager.Under_Out += Hidden_Out;

            StartCoroutine(Hidden_World_Wait());
        }
    }

    IEnumerator Hidden_World_Wait()
    {
        yield return new WaitForSeconds(3f);
        Hidden_Value = false;
    }

    public void Minipoiton_In()
    {
        Minipoiton = true;
    }

    public void Minipoiton_Out()
    {
        Minipoiton = false;
    }

    public void Fever_On()
    {
        fever = true;
    }

    public void Fever_Off()
    {
        fever = false;
    }


    public void Skill_Use() //스킬 버튼을 눌렀을시
    {
        if (Player_State == true)
        {
            if (Hidden_Value == false && Minipoiton == false && fever == false)
            {
                if (SkillValue == true)
                {
                    //업적 - 스킬 사용
                    int a = PlayerPrefs.GetInt("Achieve_Skill");
                    a += 1;
                    PlayerPrefs.SetInt("Achieve_Skill", a);

                    Skill_In();
                    GameManager.instance.Skill_In();
                    EffectManager.instance.Boast_Song_On();

                    SkillValue = false;
                    Skill_Filter.enabled = true;
                    Skill_Filter.fillAmount = 1;
                    StartCoroutine(Skill_CoolTime(Skill_Filter));
                }
                else
                {
                    LanguageManager.instance.Yet_Skill_Notion();

                }
            }
            else
            {
                LanguageManager.instance.Not_Skill_Notion();
            }
        }
    }
    IEnumerator Skill_CoolTime(UISprite Filter)
    {
        while (Filter.fillAmount > 0)
        {
            Filter.fillAmount -= 1 * Time.smoothDeltaTime / Skill_Time;
            yield return null;
        }
        Skill_Out(); //스킬 끝 전세계 전파
        GameManager.instance.Skill_Out();
        EffectManager.instance.Boast_Song_Off();

        StartCoroutine(Skill_CoolTime_ReSet(Filter));
        StartCoroutine(Skill_CooltTme_Counter(SkillCoolTime, Skill_txt));
        yield break;
    }

    IEnumerator Skill_CoolTime_ReSet(UISprite Filter)
    {
        while (Filter.fillAmount < 1)
        {
            if(Talk_Value == false && Hidden_Value == false)
            {
                Filter.fillAmount += 1 * Time.smoothDeltaTime / SkillCoolTime;
            }
            else
            {
                Filter.fillAmount += 0 * Time.smoothDeltaTime / SkillCoolTime;
            }

            yield return null;
        }
        LanguageManager.instance.CoolTime_Skill_Notion();
        SkillValue = true;
        Skill_Filter.enabled = false;
    }
    IEnumerator Skill_CooltTme_Counter(float number, UILabel label)
    {
        if (number > 0)
        {
            if(Talk_Value == false && Hidden_Value == false)
            {
                number -= 1;
            }
            label.text = number.ToString();

            yield return new WaitForSeconds(1f);
            StartCoroutine(Skill_CooltTme_Counter(number, label));
        }
        else
        {
            label.text = " ";
            StopCoroutine(Skill_CooltTme_Counter(number, label));
        }
    }
}
