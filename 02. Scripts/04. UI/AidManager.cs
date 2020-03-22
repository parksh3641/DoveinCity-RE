using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AidManager : MonoBehaviour
{
    public static AidManager instance;

    private int Aid;

    private int BD_Owl;
    private int BD_Duck;

    private int BD_Owl_Lv;
    private int BD_Duck_Lv;

    private int BD_Owl_Points;
    private int BD_Duck_Points;

    public GameObject Defalut_Arrow;


    //부엉이
    public GameObject Owl_Rock;
    public GameObject Owl_Select_Arrow; // 선택 화살 표

    public UILabel Owl_Lv_txt;
    public UILabel Owl_Points_txt;
    public UISprite Owl_Fillter;

    public UILabel Owl_Lv_Up_txt; // 레벨 업
    public UILabel Owl_Info_txt; // 설명 창

    public UILabel Owl_Hp_txt;// + 2

    public int Owl_Default_Value = 0;
    public int Owl_Up_Value = 0;


    //오리
    public GameObject Duck_Rock;
    public GameObject Duck_Select_Arrow; // 선택 화살 표

    public UILabel Duck_Lv_txt;
    public UILabel Duck_Points_txt;
    public UISprite Duck_Fillter;

    public UILabel Duck_Lv_Up_txt; // 레벨 업
    public UILabel Duck_Info_txt; // 설명 창

    public UILabel Duck_Time_txt;// -120
    public UILabel Duck_Shield_txt;// 1

    public int Duck_Default_Value = 0;
    public int Duck_Up_Value = 0;

    private int[] Lv_Up_Value = { 5, 10, 20, 40, 80, 120, 200, 300, 500, 800, 0 }; //최대 장까지 보유가능.

    private int Max_Path;
    private int a, b = 0;


    void Awake()
    {
        instance = this;

        for(int i = 0;i<Lv_Up_Value.Length;i++)
        {
            Max_Path += Lv_Up_Value[i];
        }
        //Debug.Log(Max_Path);

        Default_Check();
    }

    void Renewal()
    {
        Aid = PlayerPrefs.GetInt("Aid");

        Owl_Default_Value = SystemManager.instance.Owl_Default_Value;
        Owl_Up_Value = SystemManager.instance.Owl_Up_Value;

        Duck_Default_Value = SystemManager.instance.Duck_Default_Value;
        Duck_Up_Value = SystemManager.instance.Duck_Up_Value;

        BD_Owl = PlayerPrefs.GetInt("BD_Owl");
        BD_Duck = PlayerPrefs.GetInt("BD_Duck");

        BD_Owl_Lv = PlayerPrefs.GetInt("BD_Owl_Lv");
        BD_Duck_Lv = PlayerPrefs.GetInt("BD_Duck_Lv");

        BD_Owl_Points = PlayerPrefs.GetInt("BD_Owl_Points");
        BD_Duck_Points = PlayerPrefs.GetInt("BD_Duck_Points");

        a = Max_Path;
        b = Max_Path;

        for(int i = 0;i<BD_Owl_Lv;i++)
        {
            a -= Lv_Up_Value[i];
        }

        for (int i = 0; i < BD_Duck_Lv; i++)
        {
            b -= Lv_Up_Value[i];
        }

        if(BD_Owl_Points >= a)
        {
            BD_Owl_Points = a;
            PlayerPrefs.SetInt("BD_Owl_Points", BD_Owl_Points);
        }

        if (BD_Duck_Points >= b)
        {
            BD_Duck_Points = b;
            PlayerPrefs.SetInt("BD_Duck_Points", BD_Duck_Points);
        }

        Lv_Check(BD_Owl_Lv,BD_Owl_Points, Owl_Lv_txt, Owl_Points_txt, Owl_Fillter);
        Lv_Check(BD_Duck_Lv,BD_Duck_Points, Duck_Lv_txt, Duck_Points_txt, Duck_Fillter);

        Owl_Hp_txt.text = "+"+(Owl_Default_Value + (BD_Owl_Lv * Owl_Up_Value)).ToString();

        Duck_Time_txt.text = (Duck_Default_Value - (BD_Duck_Lv * Duck_Up_Value)).ToString();
        Duck_Shield_txt.text = 1.ToString();
    }

    void Default_Check()
    {
        Aid = PlayerPrefs.GetInt("Aid");

        if (Aid == 1)
        {
            Owl_Select_Arrow.SetActive(true);
            Duck_Select_Arrow.SetActive(false);
            Defalut_Arrow.SetActive(false);
        }
        else if (Aid == 2)
        {
            Owl_Select_Arrow.SetActive(false);
            Duck_Select_Arrow.SetActive(true);
            Defalut_Arrow.SetActive(false);
        }
        else
        {
            Owl_Select_Arrow.SetActive(false);
            Duck_Select_Arrow.SetActive(false);
            Defalut_Arrow.SetActive(true);
        }
    }

    void OnEnable()
    {
        Renewal();

        //BD_Owl = 1;
        //BD_Duck = 1;

        Rock_Off(BD_Owl, Owl_Rock);
        Rock_Off(BD_Duck, Duck_Rock);

    }

    void OnDisable()
    {

    }

    void Lv_Check(int number,int number2, UILabel lv_txt, UILabel txt,UISprite fillter)
    {
        if(number < 10)
        {
            lv_txt.text = "Lv " + (number + 1).ToString();
            txt.text = number2.ToString() + "/" + Lv_Up_Value[number];
            fillter.fillAmount = (float)number2 / Lv_Up_Value[number];
        }
        else
        {
            lv_txt.text = "Lv Max";
            txt.text = "Max";
            fillter.fillAmount = 1;
        }

    }

    void Rock_Off(int number, GameObject rock)
    {
        if (number == 0)
        {
            rock.SetActive(true);
        }
        else
        {
            rock.SetActive(false);
        }

    }

    public void Owl_Lv_Up_Btn()
    {
        Lv_Up(BD_Owl_Lv,BD_Owl_Points,1);
    }

    public void Duck_Lv_Up_Btn()
    {
        Lv_Up(BD_Duck_Lv, BD_Duck_Points, 2);
    }

    void Max_Lv_Notion()
    {
        LanguageManager.instance.Max_Lv_Notion();
    }

    void Lv_Up_Notion()
    {
        LanguageManager.instance.Lv_Up_Notion();
    }

    void Low_Point_Notion()
    {
        LanguageManager.instance.Low_Point_Notion();
    }

    void Lv_Up(int lv,int points, int value)
    {
        if (lv < 10)
        {
            if (points >= Lv_Up_Value[lv])
            {
                points -= Lv_Up_Value[lv];

                Lv_Up_Notion();

                if (value == 1)
                {
                    BD_Owl_Points = points;
                    PlayerPrefs.SetInt("BD_Owl_Points", BD_Owl_Points);
                    BD_Owl_Lv += 1;
                    PlayerPrefs.SetInt("BD_Owl_Lv", BD_Owl_Lv);
                }
                else if (value == 2)
                {
                    BD_Duck_Points = points;
                    PlayerPrefs.SetInt("BD_Duck_Points", BD_Duck_Points);
                    BD_Duck_Lv += 1;
                    PlayerPrefs.SetInt("BD_Duck_Lv", BD_Duck_Lv);
                }

                EffectManager.instance.Coin_Plus();

                Renewal();
            }
            else
            {
                Low_Point_Notion();
            }
        }
        else
        {
            Max_Lv_Notion();
        }
    }


    public void Owl_Select()
    {
        if(BD_Owl > 0)
        {
            PlayerPrefs.SetInt("Aid", 1);
            Default_Check();
        }
        else
        {
            Debug.Log("획득 안해서 착용 불가");
        }
    }

    public void Duck_Select()
    {
        if (BD_Duck > 0)
        {
            PlayerPrefs.SetInt("Aid", 2);
            Default_Check();
        }
        else
        {
            Debug.Log("획득 안해서 착용 불가");
        }
    }

    public void Default_Select()
    {
        PlayerPrefs.SetInt("Aid", 0);
        Default_Check();
    }
}
