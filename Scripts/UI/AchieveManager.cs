using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchieveManager : MonoBehaviour
{
    public static AchieveManager instance;

    private string Achieve_Reward_Kind = "Achieve_Reward_Kind_";
    private int[] Achieve_Kind_Value = { 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 1, 1, 1, 0, 0, 2 };//0 코인 ,1 다이아, 2 깃털

    public int Achieve_AD;
    public int Achieve_Achieve;
    public int Achieve_Score;
    public int Achieve_AliveTime;
    public int Achieve_Level;
    public int Achieve_Item;
    public int Achieve_Skill;
    public int Achieve_Hp;
    public int Achieve_Damage;
    public int Achieve_Fever;
    public int Achieve_Weather;
    public int Achieve_Npc;
    public int Achieve_Ufo;
    public int Achieve_Hidden;
    public int Achieve_Coin;
    public int Achieve_Diamond;
    public int Achieve_Egg;
    public int Achieve_Dove;

    private string[] Achieve_Title = { "Achieve_AD","Achieve_Achieve","Achieve_Score","Achieve_AliveTime","Achieve_Level","Achieve_Item","Achieve_Skill","Achieve_Hp","Achieve_Damage",
        "Achieve_Fever","Achieve_Weather","Achieve_Npc","Achieve_Ufo","Achieve_Hidden","Achieve_Coin","Achieve_Diamond","Achieve_Egg","Achieve_Dove"};

    public List<Achieve> Achieve_All = new List<Achieve>();


    //지속적인 갱신이 필요한 업적
    public List<Achieve> Achieve_Renewal = new List<Achieve>();

    void Awake()
    {
        instance = this;

        for (int i = 0;i< Achieve_Kind_Value.Length; i++) //업적에 대한 각각의, 보상 설정
        {
            PlayerPrefs.SetInt(Achieve_Reward_Kind+(i+1).ToString(), Achieve_Kind_Value[i]);
        }
    }

    void Start()
    {
        if (Achieve_Renewal.Count != 0)
        {
            StartCoroutine(Renewal_Achieve());
        }
    }

    public void Renewal()
    {
        for (int i = 0; i < Achieve_Kind_Value.Length; i++) //업적 재설정
        {
            Achieve_All[i].Renewal();
        }
    }

    public void Reset()
    {

        for (int i = 0; i < Achieve_Title.Length; i++)
        {
            PlayerPrefs.SetInt(Achieve_Title[i], 0);
            PlayerPrefs.SetInt("Achieve_Goal_Save_" + i, 0);
            PlayerPrefs.SetInt("Achieve_" + i, 0);
        }
    }

    public void Achieve_AD_Up()
    {
        int a = PlayerPrefs.GetInt("Achieve_AD");
        a += 1;
        PlayerPrefs.SetInt("Achieve_AD",a);
    }

    IEnumerator Renewal_Achieve()
    {
        for(int i =0;i < Achieve_Renewal.Count;i++)
        {
            Achieve_Renewal[i].Renewal();
        }
        yield return new WaitForSeconds(3);
        StartCoroutine(Renewal_Achieve());
    }
}
