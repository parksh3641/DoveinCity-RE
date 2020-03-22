using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NestManager : MonoBehaviour
{
    public static NestManager instance;

    public UISprite Main_Background;
    public GameObject Nest_Box_Up;
    public GameObject Nest_Box_Down;

    public int Choice;

    private int BD_Coin;
    private int BD_Diamond;
    private int BD_Dora_Feather;

    public UILabel BD_Coin_txt;
    public UILabel BD_Feather_txt;

    //패널 초기화
    public UIPanel Skin_Panel;
    public UIPanel Skill_Panel;

    private int BD_Black_AliveTime;
    private int BD_White_AliveTime;
    private int BD_Eagle_AliveTime;
    private int BD_Dora_AliveTime;

    private int BD_Black_Lv;
    private int BD_White_Lv;
    private int BD_Eagle_Lv;
    private int BD_Dora_Lv;


    //메인화면 날개짓
    public UISprite Black_sprite;
    public UISprite White_sprite;
    public UISprite Eagle_sprite;
    public UISprite Dora_sprite;

    private string[] Black = { "black_1", "black_2", "black_3", "black_4", "black_5", "black_6" };
    private string[] White = { "White_1", "White_2", "White_3", "White_4", "White_5", "White_6" };
    private string[] Eagle = { "Eagle_1", "Eagle_2", "Eagle_3", "Eagle_4", "Eagle_5", "Eagle_6" };
    private string[] Dora = { "Dora_1", "Dora_2", "Dora_3", "Dora_4", "Dora_5", "Dora_6" };


    private string[] Sunshine = { "sun_1", "sun_2", "sun_3", "sun_4", "sun_5", "sun_6" };
    private string[] Clocking = { "clocking_1", "clocking_2", "clocking_3", "clocking_4", "clocking_5", "clocking_6" };
    private string[] Rainbow = { "wjd_1", "wjd_2", "wjd_3", "wjd_4", "wjd_5", "wjd_6" };

    private float Cooltime;

    //메인화면 - 레벨
    private int[] Lv_Up_AliveTime_Value = new int[99];

    public UILabel Black_Lv;
    public UILabel White_Lv;
    public UILabel Eagle_Lv;
    public UILabel Dora_Lv;

    public UISprite Black_Fillter;
    public UISprite White_Fillter;
    public UISprite Eagle_Fillter;
    public UISprite Dora_Fillter;

    public UILabel Black_Fillter_txt;
    public UILabel White_Fillter_txt;
    public UILabel Eagle_Fillter_txt;
    public UILabel Dora_Fillter_txt;

    //둥지
    public UISprite Main_sprite;
    public UILabel Main_name;

    public UISprite Strong_Weather;
    public UISprite Weak_Weather;


    //비둘기 능력치
    public UILabel HEALTH;
    public UILabel DIFFICULTY;
    public UILabel STRONG_WEATHER;
    public UILabel WEAK_WEATHER;

    //둥지 - 스킨
    public UILabel Title;

    private int BD_White; //비둘기 보유 여부
    private int BD_Eagle;
    private int BD_Dora;

    public GameObject White_Rock;
    public GameObject Eagle_Rock;
    public GameObject Dora_Rock;

    private int BD_Sunshine_Skin; //스킨 보유 여부
    private int BD_Clocking_Skin;
    private int BD_Rainbow_Skin;

    public GameObject Sunshine_Rock;
    public GameObject Clocking_Rock;
    public GameObject Rainbow_Rock;

    private int[] BD_Sunshine_Dress = new int[3]; //스킨 착용 여부
    private int[] BD_Clocking_Dress = new int[3];
    private int[] BD_Rainbow_Dress = new int[3];

    private string[] Dress = new string[] { "_Black", "_White", "_Dora" };

    public UISprite Sunshine_Btn;
    public UISprite Clocking_Btn;
    public UISprite Rainbow_Btn;

    public UILabel Sunshine_label;
    public UILabel Clocking_label;
    public UILabel Rainbow_label;
    public UILabel ComingSoon_label;

    //둥지 - 스킬
    private int AliveTime;
    private int SkillValue;
    private int SkillPoint;
    private int MaxSkill;

    private int BD_Black_Skill_Value; //레벨업해서 얻은 스킬 포인트 획득량
    private int BD_White_Skill_Value;
    private int BD_Eagle_Skill_Value;
    private int BD_Dora_Skill_Value;

    private int Black_Skill_Point_All; //이제까지 획득한 스킬 포인트
    private int White_Skill_Point_All;
    private int Eagle_Skill_Point_All;
    private int Dora_Skill_Point_All;


    private int Black_Skill_Point_Total; //스킬 초기화 대비 저장값(아직 사용 안함)
    private int White_Skill_Point_Total;
    private int Eagle_Skill_Point_Total;
    private int Dora_Skill_Point_Total;


    private string Black_Skill_Point_Save = ""; //스킬 투자한 값 불러오기
    private string White_Skill_Point_Save = "";
    private string Eagle_Skill_Point_Save = "";
    private string Dora_Skill_Point_Save = "";

    private string[] Black_Skill_Point = new string[10]; //스킬 투자한 값 저장하기
    private string[] White_Skill_Point = new string[10];
    private string[] Eagle_Skill_Point = new string[10];
    private string[] Dora_Skill_Point = new string[10];

    public UILabel Main_Lv; //스킬 창 안에 레벨표시
    public UILabel Skill_Point_txt; //스킬 포인트 개수
    public UISprite Skill_Fillter;
    public UILabel Skill_Fillter_txt;
    public UILabel Coin_txt; //레벨 업에 필요한 코인 개수

    private int[] Lv_Up_Coin_Value = new int[99];

    //기본값 / 증가값
    public float Default_Black_Hp = 0;
    public float Default_White_Hp = 0;
    public float Default_Eagle_Hp = 0;
    public float Default_Dora_Hp = 0;

    private float Heart_Default_Value;
    private float Heart_Up_Value;

    private float Fly_Default_Value;
    private float Fly_Up_Value;

    private float Coin_Default_Value;
    private float Coin_Up_Value;

    private float Item_Default_Value;
    private float Item_Up_Value;

    private float Hit_Default_Value;
    private float Hit_Up_Value;

    private float Move_Default_Value;
    private float Move_Up_Value;

    private float Fever_Default_Value;
    private float Fever_Up_Value;

    private float FlyDown_Default_Value;
    private float FlyDown_Up_Value;

    private float Score2_Default_Value;
    private float Score2_Up_Value;

    private float Coin2_Default_Value;
    private float Coin2_Up_Value;

    private float[] Skill_Value = new float[20];

    //스킬 정보
    public UILabel Skill_Title_txt_1;
    public UILabel Skill_Value_1;
    public UILabel Skill_Up_Value_1;
    public UILabel Skill_Lv_1;
    public UISprite Skill_Fillter_1;
    public GameObject Skill_Rocked_1;

    public UILabel Skill_Title_txt_2;
    public UILabel Skill_Value_2;
    public UILabel Skill_Up_Value_2;
    public UILabel Skill_Lv_2;
    public UISprite Skill_Fillter_2;
    public GameObject Skill_Rocked_2;

    public UILabel Skill_Title_txt_3;
    public UILabel Skill_Value_3;
    public UILabel Skill_Up_Value_3;
    public UILabel Skill_Lv_3;
    public UISprite Skill_Fillter_3;
    public GameObject Skill_Rocked_3;

    public UILabel Skill_Title_txt_4;
    public UILabel Skill_Value_4;
    public UILabel Skill_Up_Value_4;
    public UILabel Skill_Lv_4;
    public UISprite Skill_Fillter_4;
    public GameObject Skill_Rocked_4;

    public UILabel Skill_Title_txt_5;
    public UILabel Skill_Value_5;
    public UILabel Skill_Up_Value_5;
    public UILabel Skill_Lv_5;
    public UISprite Skill_Fillter_5;
    public GameObject Skill_Rocked_5;

    public UILabel Skill_Title_txt_6;
    public UILabel Skill_Value_6;
    public UILabel Skill_Up_Value_6;
    public UILabel Skill_Lv_6;
    public UISprite Skill_Fillter_6;
    public GameObject Skill_Rocked_6;

    public UILabel Skill_Title_txt_7;
    public UILabel Skill_Value_7;
    public UILabel Skill_Up_Value_7;
    public UILabel Skill_Lv_7;
    public UISprite Skill_Fillter_7;
    public GameObject Skill_Rocked_7;

    public UILabel Skill_Title_txt_8;
    public UILabel Skill_Value_8;
    public UILabel Skill_Up_Value_8;
    public UILabel Skill_Lv_8;
    public UISprite Skill_Fillter_8;
    public GameObject Skill_Rocked_8;

    public UILabel Skill_Title_txt_9;
    public UILabel Skill_Value_9;
    public UILabel Skill_Up_Value_9;
    public UILabel Skill_Lv_9;
    public UISprite Skill_Fillter_9;
    public GameObject Skill_Rocked_9;

    public UILabel Skill_Title_txt_10;
    public UILabel Skill_Value_10;
    public UILabel Skill_Up_Value_10;
    public UILabel Skill_Lv_10;
    public UISprite Skill_Fillter_10;
    public GameObject Skill_Rocked_10;

    private List<UILabel> Skill_Label = new List<UILabel>();
    private List<UISprite> Skill_Sprite = new List<UISprite>();

    //최대값
    private int Max_Money = 0;
    private int Max_AliveTime = 0;
    private int a, b, c, d = 0;

    //언어
    private List<string> Nest_Language = new List<string>();

    void Awake()
    {
        instance = this;
        Add_Skill_Label();

        int coin = 2000;
        for (int i = 0; i < 99; i++)
        {
            Lv_Up_Coin_Value[i] = coin;
            Max_Money += coin;
            coin += 100;
        }

        int lv_up = 10;
        for (int i = 0; i < 99; i++)
        {
            Lv_Up_AliveTime_Value[i] = 10 + lv_up;
            Max_AliveTime += 10 + lv_up;
            lv_up += 1;
        }
        //Debug.Log("총 필요한 개수: "+Max_AliveTime);
        //Coin_Load Text_Load
    }
    void Start()
    {
        Cooltime = SystemManager.instance.SelectDoveCooltime;

        Heart_Default_Value = SystemManager.instance.Heart_Default_Value;
        Heart_Up_Value = SystemManager.instance.Heart_Up_Value;
        Fly_Default_Value = SystemManager.instance.Fly_Default_Value;
        Fly_Up_Value = SystemManager.instance.Fly_Up_Value;
        Coin_Default_Value = SystemManager.instance.Coin_Default_Value;
        Coin_Up_Value = SystemManager.instance.Coin_Up_Value;
        Item_Default_Value = SystemManager.instance.Item_Default_Value;
        Item_Up_Value = SystemManager.instance.Item_Up_Value;
        Hit_Default_Value = SystemManager.instance.Hit_Default_Value;
        Hit_Up_Value = SystemManager.instance.Hit_Up_Value;

        Move_Default_Value = SystemManager.instance.Move_Default_Value;
        Move_Up_Value = SystemManager.instance.Move_Up_Value;
        Fever_Default_Value = SystemManager.instance.Fever_Default_Value;
        Fever_Up_Value = SystemManager.instance.Fever_Up_Value;
        FlyDown_Default_Value = SystemManager.instance.FlyDown_Default_Value;
        FlyDown_Up_Value = SystemManager.instance.FlyDown_Up_Value;
        Score2_Default_Value = SystemManager.instance.Score2_Default_Value;
        Score2_Up_Value = SystemManager.instance.Score2_Up_Value;
        Coin2_Default_Value = SystemManager.instance.Coin2_Default_Value;
        Coin2_Up_Value = SystemManager.instance.Coin2_Up_Value;

        Default_Black_Hp = SystemManager.instance.Default_Black_Hp;
        Default_White_Hp = SystemManager.instance.Default_White_Hp;
        Default_Eagle_Hp = SystemManager.instance.Default_Eagle_Hp;
        Default_Dora_Hp = SystemManager.instance.Default_Dora_Hp;

        Skill_Value[0] = Heart_Default_Value;
        Skill_Value[1] = Heart_Up_Value;
        Skill_Value[2] = Fly_Default_Value;
        Skill_Value[3] = Fly_Up_Value;
        Skill_Value[4] = Coin_Default_Value;
        Skill_Value[5] = Coin_Up_Value;
        Skill_Value[6] = Item_Default_Value;
        Skill_Value[7] = Item_Up_Value;
        Skill_Value[8] = Hit_Default_Value;
        Skill_Value[9] = Hit_Up_Value;

        Skill_Value[10] = Move_Default_Value;
        Skill_Value[11] = Move_Up_Value;
        Skill_Value[12] = Fever_Default_Value;
        Skill_Value[13] = Fever_Up_Value;
        Skill_Value[14] = FlyDown_Default_Value;
        Skill_Value[15] = FlyDown_Up_Value;
        Skill_Value[16] = Score2_Default_Value;
        Skill_Value[17] = Score2_Up_Value;
        Skill_Value[18] = Coin2_Default_Value;
        Skill_Value[19] = Coin2_Up_Value;
    }

    public void Language_Setting()
    {
        if(Nest_Language.Count > 0)
        {
            Nest_Language.Clear();
        }
        int a = PlayerPrefs.GetInt("Language");
        switch (a)
        {
            case 0:
                for(int i =0;i< LanguageManager.instance.Nest_Info_Korean.Length;i++)
                {
                    string b = LanguageManager.instance.Nest_Info_Korean[i];
                    Nest_Language.Add(b);
                }
                break;
            case 1:
                for (int i = 0; i < LanguageManager.instance.Nest_Info_English.Length; i++)
                {
                    string b = LanguageManager.instance.Nest_Info_English[i];
                    Nest_Language.Add(b);
                }
                break;
            case 2:
                for (int i = 0; i < LanguageManager.instance.Nest_Info_Chinese.Length; i++)
                {
                    string b = LanguageManager.instance.Nest_Info_Chinese[i];
                    Nest_Language.Add(b);
                }
                break;
            case 3:
                for (int i = 0; i < LanguageManager.instance.Nest_Info_Japanese.Length; i++)
                {
                    string b = LanguageManager.instance.Nest_Info_Japanese[i];
                    Nest_Language.Add(b);
                }
                break;
        }

        Title_Change();
    }

    void Title_Change() //비둘기 보유 여부
    {
        BD_White = PlayerPrefs.GetInt("BD_White", 0);
        BD_Eagle = PlayerPrefs.GetInt("BD_Eagle", 0);
        BD_Dora = PlayerPrefs.GetInt("BD_Dora", 0);

        Rock_Off(BD_White, White_Rock);
        Rock_Off(BD_Eagle, Eagle_Rock);
        Rock_Off(BD_Dora, Dora_Rock);

        int a = 1 + BD_White + BD_Eagle + BD_Dora;
        Title.text = Nest_Language[0] + " " + a + "/4";
        ComingSoon_label.text = Nest_Language[6];
    }

    void Add_Skill_Label()
    {
        Skill_Label.Add(Skill_Value_1);
        Skill_Label.Add(Skill_Up_Value_1);
        Skill_Label.Add(Skill_Lv_1);
        Skill_Sprite.Add(Skill_Fillter_1);

        Skill_Label.Add(Skill_Value_2);
        Skill_Label.Add(Skill_Up_Value_2);
        Skill_Label.Add(Skill_Lv_2);
        Skill_Sprite.Add(Skill_Fillter_2);

        Skill_Label.Add(Skill_Value_3);
        Skill_Label.Add(Skill_Up_Value_3);
        Skill_Label.Add(Skill_Lv_3);
        Skill_Sprite.Add(Skill_Fillter_3);

        Skill_Label.Add(Skill_Value_4);
        Skill_Label.Add(Skill_Up_Value_4);
        Skill_Label.Add(Skill_Lv_4);
        Skill_Sprite.Add(Skill_Fillter_4);

        Skill_Label.Add(Skill_Value_5);
        Skill_Label.Add(Skill_Up_Value_5);
        Skill_Label.Add(Skill_Lv_5);
        Skill_Sprite.Add(Skill_Fillter_5);

        Skill_Label.Add(Skill_Value_6);
        Skill_Label.Add(Skill_Up_Value_6);
        Skill_Label.Add(Skill_Lv_6);
        Skill_Sprite.Add(Skill_Fillter_6);

        Skill_Label.Add(Skill_Value_7);
        Skill_Label.Add(Skill_Up_Value_7);
        Skill_Label.Add(Skill_Lv_7);
        Skill_Sprite.Add(Skill_Fillter_7);

        Skill_Label.Add(Skill_Value_8);
        Skill_Label.Add(Skill_Up_Value_8);
        Skill_Label.Add(Skill_Lv_8);
        Skill_Sprite.Add(Skill_Fillter_8);

        Skill_Label.Add(Skill_Value_9);
        Skill_Label.Add(Skill_Up_Value_9);
        Skill_Label.Add(Skill_Lv_9);
        Skill_Sprite.Add(Skill_Fillter_9);

        Skill_Label.Add(Skill_Value_10);
        Skill_Label.Add(Skill_Up_Value_10);
        Skill_Label.Add(Skill_Lv_10);
        Skill_Sprite.Add(Skill_Fillter_10);
    }

    public void Renewal() //갱신 코드
    {
        BD_Black_AliveTime = PlayerPrefs.GetInt("BD_Black_AliveTime");
        BD_White_AliveTime = PlayerPrefs.GetInt("BD_White_AliveTime");
        BD_Eagle_AliveTime = PlayerPrefs.GetInt("BD_Eagle_AliveTime");
        BD_Dora_AliveTime = PlayerPrefs.GetInt("BD_Dora_AliveTime");
        Debug.Log(BD_Black_AliveTime);

        Black_Skill_Point_Total = PlayerPrefs.GetInt("Black_Skill_Point_Total");
        White_Skill_Point_Total = PlayerPrefs.GetInt("White_Skill_Point_Total");
        Eagle_Skill_Point_Total = PlayerPrefs.GetInt("Eagle_Skill_Point_Total");
        Dora_Skill_Point_Total = PlayerPrefs.GetInt("Dora_Skill_Point_Total");

        a = Max_AliveTime;
        b = Max_AliveTime;
        c = Max_AliveTime;
        d = Max_AliveTime;

        for (int i = 0;i< Black_Skill_Point_Total; i++)
        {
            a -= Lv_Up_AliveTime_Value[i];
        }
        for (int i = 0; i < White_Skill_Point_Total; i++)
        {
            b -= Lv_Up_AliveTime_Value[i];
        }
        for (int i = 0; i < Eagle_Skill_Point_Total; i++)
        {
            c -= Lv_Up_AliveTime_Value[i];
        }
        for (int i = 0; i < Dora_Skill_Point_Total; i++)
        {
            d -= Lv_Up_AliveTime_Value[i];
        }


        if (BD_Black_AliveTime >= a)
        {
            BD_Black_AliveTime = a;
        }

        if (BD_White_AliveTime >= b)
        {
            BD_White_AliveTime = b;
        }

        if (BD_Eagle_AliveTime >= c)
        {
            BD_Eagle_AliveTime = c;
        }

        if (BD_Dora_AliveTime >= d)
        {
            BD_Dora_AliveTime = d;
        }

        BD_Black_Skill_Value = PlayerPrefs.GetInt("BD_Black_Skill_Value");
        BD_White_Skill_Value = PlayerPrefs.GetInt("BD_White_Skill_Value");
        BD_Eagle_Skill_Value = PlayerPrefs.GetInt("BD_Eagle_Skill_Value");
        BD_Dora_Skill_Value = PlayerPrefs.GetInt("BD_Dora_Skill_Value");

        BD_Black_Lv = 0;
        BD_White_Lv = 0;
        BD_Eagle_Lv = 0;
        BD_Dora_Lv = 0;


        Lv_Load(BD_Black_Skill_Value,1);
        Lv_Load(BD_White_Skill_Value,2);
        Lv_Load(BD_Eagle_Skill_Value,3);
        Lv_Load(BD_Dora_Skill_Value,4);

        Text_Load(Black_Lv, Black_Fillter_txt, Black_Fillter, BD_Black_AliveTime, BD_Black_Lv, BD_Black_Skill_Value);
        Text_Load(White_Lv, White_Fillter_txt, White_Fillter, BD_White_AliveTime, BD_White_Lv, BD_White_Skill_Value);
        Text_Load(Eagle_Lv, Eagle_Fillter_txt, Eagle_Fillter, BD_Eagle_AliveTime, BD_Eagle_Lv, BD_Eagle_Skill_Value);
        Text_Load(Dora_Lv, Dora_Fillter_txt, Dora_Fillter, BD_Dora_AliveTime, BD_Dora_Lv, BD_Dora_Skill_Value);
    }

    void Renewal_Detail()
    {
        BD_Coin = PlayerPrefs.GetInt("BD_Coin");
        BD_Diamond = PlayerPrefs.GetInt("BD_Diamond");
        BD_Dora_Feather = PlayerPrefs.GetInt("BD_Dora_Feather");
        BD_Coin_txt.text = BD_Coin.ToString();
        BD_Feather_txt.text = BD_Dora_Feather.ToString();

        switch(Choice)
        {
            case 1:
                Skill_Rocked(BD_Black_Lv, 18);
                break;
            case 2:
                Skill_Rocked(BD_White_Lv, 18);
                break;
            case 3:
                Skill_Rocked(BD_Eagle_Lv, 18);
                break;
            case 4:
                Skill_Rocked(BD_Dora_Lv, 18);
                break;
        }

        Black_Skill_Point_All = PlayerPrefs.GetInt("Black_Skill_Point_All", 0);
        White_Skill_Point_All = PlayerPrefs.GetInt("White_Skill_Point_All", 0);
        Eagle_Skill_Point_All = PlayerPrefs.GetInt("Eagle_Skill_Point_All", 0);
        Dora_Skill_Point_All = PlayerPrefs.GetInt("Dora_Skill_Point_All", 0);

        Black_Skill_Point_Save = PlayerPrefs.GetString("Black_Skill_Point_Save");
        White_Skill_Point_Save = PlayerPrefs.GetString("White_Skill_Point_Save");
        Eagle_Skill_Point_Save = PlayerPrefs.GetString("Eagle_Skill_Point_Save");
        Dora_Skill_Point_Save = PlayerPrefs.GetString("Dora_Skill_Point_Save");

        //Debug.Log("구구 : "+Black_Skill_Point_Save);
        //Debug.Log("루루 : "+White_Skill_Point_Save);
        //Debug.Log("수리수리 : "+Eagle_Skill_Point_Save);
        //Debug.Log("도라 : "+Dora_Skill_Point_Save);


        //불러온 후 변환
        for (int i = 0; i < Black_Skill_Point_Save.Length; i++)
        {
            Black_Skill_Point[i] = Black_Skill_Point_Save.Substring(i,1);
        }

        for (int i = 0; i < White_Skill_Point_Save.Length; i++)
        {
            White_Skill_Point[i] = White_Skill_Point_Save.Substring(i, 1);
        }

        for (int i = 0; i < Eagle_Skill_Point_Save.Length; i++)
        {
            Eagle_Skill_Point[i] = Eagle_Skill_Point_Save.Substring(i, 1);
        }

        for (int i = 0; i < Dora_Skill_Point_Save.Length; i++)
        {
            Dora_Skill_Point[i] = Dora_Skill_Point_Save.Substring(i, 1);
        }


        if (Choice == 1)
        {
            Coin_Load(Coin_txt, BD_Black_AliveTime, BD_Black_Lv, BD_Black_Skill_Value);
            Skill_Point_txt.text = Black_Skill_Point_All.ToString();
            int a = int.Parse(Black_Skill_Point[0]);
            HEALTH.text = (Default_Black_Hp + (a * Heart_Up_Value)).ToString();
        }
        else if (Choice == 2)
        {
            Coin_Load(Coin_txt, BD_White_AliveTime, BD_White_Lv, BD_White_Skill_Value);
            Skill_Point_txt.text = White_Skill_Point_All.ToString();
            int a = int.Parse(White_Skill_Point[0]);
            HEALTH.text = (Default_White_Hp + (a * Heart_Up_Value)).ToString();
        }
        else if (Choice == 3)
        {
            Coin_Load(Coin_txt, BD_Eagle_AliveTime, BD_Eagle_Lv, BD_Eagle_Skill_Value);
            Skill_Point_txt.text = Eagle_Skill_Point_All.ToString();
            int a = int.Parse(Eagle_Skill_Point[0]);
            HEALTH.text = (Default_Eagle_Hp + (a * Heart_Up_Value)).ToString();
        }
        else if (Choice == 4)
        {
            Coin_Load(Coin_txt, BD_Dora_AliveTime, BD_Dora_Lv, BD_Dora_Skill_Value);
            Skill_Point_txt.text = Dora_Skill_Point_All.ToString();
            int a = int.Parse(Dora_Skill_Point[0]);
            HEALTH.text = (Default_Dora_Hp + (a * Heart_Up_Value)).ToString();
        }

        Skill_Load(Choice, Black_Skill_Point, White_Skill_Point, Eagle_Skill_Point, Dora_Skill_Point, Skill_Label, Skill_Sprite, Skill_Value);


    }

    void Skill_Rocked(int number,int value)
    {
        if(number > value)
        {
            Skill_Rocked_6.SetActive(false);
            Skill_Rocked_7.SetActive(false);
            Skill_Rocked_8.SetActive(false);
            Skill_Rocked_9.SetActive(false);
            Skill_Rocked_10.SetActive(false);
        }
        else
        {
            Skill_Rocked_6.SetActive(true);
            Skill_Rocked_7.SetActive(true);
            Skill_Rocked_8.SetActive(true);
            Skill_Rocked_9.SetActive(true);
            Skill_Rocked_10.SetActive(true);
        }
    }










    void Skill_Load(int value, string[] number1, string[] number2, string[] number3, string[] number4, List<UILabel> label, List<UISprite> sprite, float[] skill_value)
    {
        if (value == 1)
        {
            Skill_Lv_Setting(number1[0], label[0], label[1], label[2], sprite[0], skill_value[0], skill_value[1],0);
            Skill_Lv_Setting(number1[1], label[3], label[4], label[5], sprite[1], skill_value[2], skill_value[3],0);
            Skill_Lv_Setting(number1[2], label[6], label[7], label[8], sprite[2], skill_value[4], skill_value[5],0);
            Skill_Lv_Setting(number1[3], label[9], label[10], label[11], sprite[3], skill_value[6], skill_value[7],0);
            Skill_Lv_Setting(number1[4], label[12], label[13], label[14], sprite[4], skill_value[8], skill_value[9],0);

            Skill_Lv_Setting(number1[5], label[15], label[16], label[17], sprite[5], skill_value[10], skill_value[11],2);
            Skill_Lv_Setting(number1[6], label[18], label[19], label[20], sprite[6], skill_value[12], skill_value[13],0);
            Skill_Lv_Setting(number1[7], label[21], label[22], label[23], sprite[7], skill_value[14], skill_value[15],1);
            Skill_Lv_Setting(number1[8], label[24], label[25], label[26], sprite[8], skill_value[16], skill_value[17],2);
            Skill_Lv_Setting(number1[9], label[27], label[28], label[29], sprite[9], skill_value[18], skill_value[19],2);
        }
        else if (value == 2)
        {
            Skill_Lv_Setting(number2[0], label[0], label[1], label[2], sprite[0], skill_value[0], skill_value[1],0);
            Skill_Lv_Setting(number2[1], label[3], label[4], label[5], sprite[1], skill_value[2], skill_value[3],0);
            Skill_Lv_Setting(number2[2], label[6], label[7], label[8], sprite[2], skill_value[4], skill_value[5],0);
            Skill_Lv_Setting(number2[3], label[9], label[10], label[11], sprite[3], skill_value[6], skill_value[7],0);
            Skill_Lv_Setting(number2[4], label[12], label[13], label[14], sprite[4], skill_value[8], skill_value[9],0);

            Skill_Lv_Setting(number2[5], label[15], label[16], label[17], sprite[5], skill_value[10], skill_value[11],2);
            Skill_Lv_Setting(number2[6], label[18], label[19], label[20], sprite[6], skill_value[12], skill_value[13],0);
            Skill_Lv_Setting(number2[7], label[21], label[22], label[23], sprite[7], skill_value[14], skill_value[15],1);
            Skill_Lv_Setting(number2[8], label[24], label[25], label[26], sprite[8], skill_value[16], skill_value[17],2);
            Skill_Lv_Setting(number3[9], label[27], label[28], label[29], sprite[9], skill_value[18], skill_value[19],2);
        }
        else if (value == 3)
        {
            Skill_Lv_Setting(number3[0], label[0], label[1], label[2], sprite[0], skill_value[0], skill_value[1],0);
            Skill_Lv_Setting(number3[1], label[3], label[4], label[5], sprite[1], skill_value[2], skill_value[3],0);
            Skill_Lv_Setting(number3[2], label[6], label[7], label[8], sprite[2], skill_value[4], skill_value[5],0);
            Skill_Lv_Setting(number3[3], label[9], label[10], label[11], sprite[3], skill_value[6], skill_value[7],0);
            Skill_Lv_Setting(number3[4], label[12], label[13], label[14], sprite[4], skill_value[8], skill_value[9],0);

            Skill_Lv_Setting(number3[5], label[15], label[16], label[17], sprite[5], skill_value[10], skill_value[11],2);
            Skill_Lv_Setting(number3[6], label[18], label[19], label[20], sprite[6], skill_value[12], skill_value[13],0);
            Skill_Lv_Setting(number3[7], label[21], label[22], label[23], sprite[7], skill_value[14], skill_value[15],1);
            Skill_Lv_Setting(number3[8], label[24], label[25], label[26], sprite[8], skill_value[16], skill_value[17],2);
            Skill_Lv_Setting(number3[9], label[27], label[28], label[29], sprite[9], skill_value[18], skill_value[19],2);
        }
        else if (value == 4)
        {
            Skill_Lv_Setting(number4[0], label[0], label[1], label[2], sprite[0], skill_value[0], skill_value[1],0);
            Skill_Lv_Setting(number4[1], label[3], label[4], label[5], sprite[1], skill_value[2], skill_value[3],0);
            Skill_Lv_Setting(number4[2], label[6], label[7], label[8], sprite[2], skill_value[4], skill_value[5],0);
            Skill_Lv_Setting(number4[3], label[9], label[10], label[11], sprite[3], skill_value[6], skill_value[7],0);
            Skill_Lv_Setting(number4[4], label[12], label[13], label[14], sprite[4], skill_value[8], skill_value[9],0);

            Skill_Lv_Setting(number4[5], label[15], label[16], label[17], sprite[5], skill_value[10], skill_value[11],2);
            Skill_Lv_Setting(number4[6], label[18], label[19], label[20], sprite[6], skill_value[12], skill_value[13],0);
            Skill_Lv_Setting(number4[7], label[21], label[22], label[23], sprite[7], skill_value[14], skill_value[15],1);
            Skill_Lv_Setting(number4[8], label[24], label[25], label[26], sprite[8], skill_value[16], skill_value[17],2);
            Skill_Lv_Setting(number4[9], label[27], label[28], label[29], sprite[9], skill_value[18], skill_value[19],2);
        }
    }

    void Skill_Lv_Setting(string value, UILabel a, UILabel b, UILabel c, UISprite fillter, float aa, float bb, int kind) //대상 /기본값/증가값/레벨/필터//+-%설정
    {
        int Value = int.Parse(value);
        float ValueF = float.Parse(value);

        switch(kind)
        {
            case 0:
                a.text = (aa + (bb * Value)).ToString(); //100
                break;
            case 1:
                a.text = (aa + (bb * Value)).ToString(); //100
                break;
            case 2:
                a.text = (aa + (bb * Value)).ToString() + "%"; //100
                break;
        }
        if(Value >= 9)
        {
            b.text = "";
        }
        else
        {
            switch (kind)
            {
                case 0:
                    b.text = "+" + bb.ToString(); //+5
                    break;
                case 1:
                    b.text = bb.ToString(); //-5
                    break;
                case 2:
                    b.text = "+"+bb.ToString()+"%"; //+5%
                    break;
            }
        }
        c.text = "Lv." + (Value + 1).ToString(); //Lv.10
        fillter.fillAmount = (ValueF + 1) / 10.0f;
    }

    public void Lv_Load(int value, int number)
    {
        for (int i=0;i<99;i++)
        {
            if (value > 0)
            {
                value -= 1;
                if(number == 1)
                {
                    BD_Black_Lv += 1;
                }
                else if(number == 2)
                {
                    BD_White_Lv += 1;
                }
                else if(number == 3)
                {
                    BD_Eagle_Lv += 1;
                }
                else if(number == 4)
                {
                    BD_Dora_Lv += 1;
                }
                else
                {
                }
            }
            else
            {
                break;
            }
        }
    }

    void Text_Load(UILabel lv_txt,UILabel fillter_txt, UISprite fillter_amount, int alive,int lv, int value)
    {
        if(lv < 98)
        {
            float a = alive / (20.0f + (1.0f * value)); //메인화면 비둘기 경험치바 0/60
            lv_txt.text = "Lv " + (lv + 1).ToString(); //메인화면 비둘기 레벨 Lv 1
            fillter_txt.text = alive.ToString() + " / " + (20 + (1 * value)).ToString(); //메인화면 비둘기 경험치바 0/60
            fillter_amount.fillAmount = a;
        }
        else
        {
            lv_txt.text = "Lv " + (lv + 1).ToString();
            fillter_txt.text = "Max";
            fillter_amount.fillAmount = 1;
        }
    }

    void Coin_Load(UILabel label, int alive, int lv, int value)
    {
        if(lv < 98)
        {
            float a = alive / (20.0f + (1.0f * value)); //상세화면 비둘기 경험치바 0/60
            label.text = Lv_Up_Coin_Value[lv].ToString();

            Main_Lv.text = "Lv. " + (lv + 1).ToString(); //상세화면 비둘기 레벨 Lv 1
            Skill_Fillter_txt.text = alive.ToString() + " / " + (20 + (1 * value)).ToString(); //상세화면 비둘기 경험치바 0/60
            Skill_Fillter.fillAmount = a;
        }
        else
        {
            Main_Lv.text = "Lv. " + (lv + 1).ToString(); //상세화면 비둘기 레벨 Lv 1
            Skill_Fillter_txt.text = "Max";
            Skill_Fillter.fillAmount = 1;
            label.text = "Max"; //코인 값
        }
    }














    void OnEnable()
    {
        Renewal();

        StartCoroutine(Flying(Black_sprite, Black));
        StartCoroutine(Flying(White_sprite, White));
        StartCoroutine(Flying(Eagle_sprite, Eagle));
        StartCoroutine(Flying(Dora_sprite, Dora));

        BD_Coin = PlayerPrefs.GetInt("BD_Coin");

        Nest_Box_Up.SetActive(true);
        Nest_Box_Down.SetActive(true);

        int a = PlayerPrefs.GetInt("BD_White_Get");
        int b = PlayerPrefs.GetInt("BD_Eagle_Get");
        int c = PlayerPrefs.GetInt("BD_Dora_Get");

        if (a == 1)
        {
            AlarmManager.instance.Alarm_Minus_Nest();
        }
        if (b == 1)
        {
            AlarmManager.instance.Alarm_Minus_Nest();
        }
        if (c == 1)
        {
            AlarmManager.instance.Alarm_Minus_Nest();
        }
        //비둘기 해제 여부
    }

    void OnDisable()
    {
        StopAllCoroutines();
    }

    public void Open()
    {
        Choice = SelectManager.instance.Choice;
        Dove_Stats(Choice);

        Nest_Box_Up.SetActive(false);
        Nest_Box_Down.SetActive(false);

        Renewal_Detail();

        Skin_Panel.clipOffset = new Vector2(-3, 0);
        Skin_Panel.transform.localPosition = new Vector3(-344, 280, 0);

        //스킨 해제 여부
        BD_Sunshine_Skin = PlayerPrefs.GetInt("BD_Sunshine_Skin");
        BD_Clocking_Skin = PlayerPrefs.GetInt("BD_Clocking_Skin");
        BD_Rainbow_Skin = PlayerPrefs.GetInt("BD_Rainbow_Skin");

        AlarmManager.instance.Alarm_Minus_Nest();
        AlarmManager.instance.Alarm_Minus_Nest();
        AlarmManager.instance.Alarm_Minus_Nest();

        //BD_Sunshine_Skin = 1; //임시
        //BD_Clocking_Skin = 1;
        //BD_Rainbow_Skin = 1;

        Rock_Off(BD_Sunshine_Skin, Sunshine_Rock);
        Rock_Off(BD_Clocking_Skin, Clocking_Rock);
        Rock_Off(BD_Rainbow_Skin, Rainbow_Rock);

        //스킨 누가 어떤것을 사용하고 있는지 여부

        for(int i =0;i<BD_Sunshine_Dress.Length;i++)
        {
            BD_Sunshine_Dress[i] = PlayerPrefs.GetInt("Sunshine" + Dress[i]);
            BD_Clocking_Dress[i] = PlayerPrefs.GetInt("Clocking" + Dress[i]);
            BD_Rainbow_Dress[i] = PlayerPrefs.GetInt("Rainbow" + Dress[i]);
        }

        Skin_Setting(BD_Sunshine_Dress, Sunshine_Btn, Sunshine_label);
        Skin_Setting(BD_Clocking_Dress, Clocking_Btn, Clocking_label);
        Skin_Setting(BD_Rainbow_Dress, Rainbow_Btn, Rainbow_label);

        //날개짓
        Fly_Setting(Choice);
    } //비둘기 상세창 처음 열었을때
    public void Dove_Stats(int number)
    {
        if (number == 1)
        {
            Main_name.text = Nest_Language[1];
            DIFFICULTY.text = Nest_Language[9];
            STRONG_WEATHER.text = Nest_Language[12];
            WEAK_WEATHER.text = Nest_Language[11];

            Strong_Weather.spriteName = "Moon";
            Weak_Weather.spriteName = "Sun";
            Main_Background.color = new Color(1,1,1);
        }
        else if (number == 2)
        {
            Main_name.text = Nest_Language[2];
            DIFFICULTY.text = Nest_Language[9];
            STRONG_WEATHER.text = Nest_Language[11];
            WEAK_WEATHER.text = Nest_Language[12];

            Strong_Weather.spriteName = "Sun";
            Weak_Weather.spriteName = "Moon";
            Main_Background.color = new Color(1, 200 / 255f, 1);
        }
        else if (number == 3)
        {
            Main_name.text = Nest_Language[3];
            DIFFICULTY.text = Nest_Language[10];
            STRONG_WEATHER.text = Nest_Language[13];
            WEAK_WEATHER.text = Nest_Language[11];

            Strong_Weather.spriteName = "Rain";
            Weak_Weather.spriteName = "Sun";
            Main_Background.color = new Color(0, 200 / 255f, 1);
        }
        else if (number == 4)
        {
            Main_name.text = Nest_Language[4];
            DIFFICULTY.text = Nest_Language[8];
            STRONG_WEATHER.text = Nest_Language[11];
            WEAK_WEATHER.text = Nest_Language[12];

            Strong_Weather.spriteName = "Sun";
            Weak_Weather.spriteName = "Moon";
            Main_Background.color = new Color(1, 1, 0);
        }
    }
    void Fly_Setting(int number)
    {
        StopAllCoroutines();
        if (number == 1)
        {
            if (BD_Sunshine_Dress[0] == 1)
            {
                StartCoroutine(Flying(Main_sprite, Sunshine));
            }
            else if (BD_Clocking_Dress[0] == 1)
            {
                StartCoroutine(Flying(Main_sprite, Clocking));
            }
            else if (BD_Rainbow_Dress[0] == 1)
            {
                StartCoroutine(Flying(Main_sprite, Rainbow));
            }
            else
            {
                StartCoroutine(Flying(Main_sprite, Black));
            }
        }
        else if (number == 2)
        {
            if (BD_Sunshine_Dress[1] == 1)
            {
                StartCoroutine(Flying(Main_sprite, Sunshine));
            }
            else if (BD_Clocking_Dress[1] == 1)
            {
                StartCoroutine(Flying(Main_sprite, Clocking));
            }
            else if (BD_Rainbow_Dress[1] == 1)
            {
                StartCoroutine(Flying(Main_sprite, Rainbow));
            }
            else
            {
                StartCoroutine(Flying(Main_sprite, White));
            }
        }
        else if(number == 3)
        {
            StartCoroutine(Flying(Main_sprite, Eagle));
        }
        else if(number == 4)
        {
            if (BD_Sunshine_Dress[2] == 1)
            {
                StartCoroutine(Flying(Main_sprite, Sunshine));
            }
            else if (BD_Clocking_Dress[2] == 1)
            {
                StartCoroutine(Flying(Main_sprite, Clocking));
            }
            else if (BD_Rainbow_Dress[2] == 1)
            {
                StartCoroutine(Flying(Main_sprite, Rainbow));
            }
            else
            {
                StartCoroutine(Flying(Main_sprite, Dora));
            }
        }

        StartCoroutine(Flying(Black_sprite, Black));
        StartCoroutine(Flying(White_sprite, White));
        StartCoroutine(Flying(Eagle_sprite, Eagle));
        StartCoroutine(Flying(Dora_sprite, Dora));
    } //비둘기 스킨 날개짓 설정

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

    } //스킨 획득 여부
    void Skin_Setting(int[] number, UISprite btn, UILabel label)
    {
        if(Choice == 1)
        {
            if (number[0] == 0)
            {
                btn.color = new Color(0, 1, 0, 1);
                Skin_Wearbale(label);
            }
            else
            {
                btn.color = new Color(1, 0, 0, 1);
                Skin_Off(label);
            }
        }
        else if(Choice == 2)
        {
            if (number[1] == 0)
            {
                btn.color = new Color(0, 1, 0, 1);
                Skin_Wearbale(label);
            }
            else
            {
                btn.color = new Color(1, 0, 0, 1);
                Skin_Off(label);
            }
        }
        else if(Choice == 3)
        {
            btn.color = new Color(1, 0, 0, 1);
            Skin_Cannot(label);
        }
        else if(Choice == 4)
        {
            /*
            if (number[2] == 0)
            {
                btn.color = new Color(0, 1, 0, 1);
                Skin_Wearbale(label);
            }
            else
            {
                btn.color = new Color(1, 0, 0, 1);
                Skin_Off(label);
            }
            */
            btn.color = new Color(1, 0, 0, 1);
            Skin_Cannot(label);
        }
    } //스킨 착용 여부

    void Skin_Wearbale(UILabel label)
    {
        label.text = Nest_Language[5];
    }

    void Skin_Cannot(UILabel label)
    {
        label.text = Nest_Language[6];
    }

    void Skin_Off(UILabel label)
    {
        label.text = Nest_Language[7];
    }


    //알림 모음

    public void Rocked()
    {
        LanguageManager.instance.Rocked_Notion();
    }

    public void Skill_Rocked()
    {
        LanguageManager.instance.Rocked_Notion();
    }

    public void In_Coming()
    {
        LanguageManager.instance.Rocked_Notion();
    }

    public void Lv_Up_Notion()
    {
        LanguageManager.instance.Lv_Up_Notion();
    }

    public void Low_SurvivalTime_Notion()
    {
        LanguageManager.instance.Low_SurvivalTime_Notion();
    }

    public void Low_Point_Notion()
    {
        LanguageManager.instance.Low_Point_Notion();
    }

    public void Low_Coin_Notion()
    {
        LanguageManager.instance.Low_Coin_Notion();
    }

    public void Max_Lv_Notion()
    {
        LanguageManager.instance.Max_Lv_Notion();
    }

    public void Now_Hold_Notion()
    {
        LanguageManager.instance.Now_Hold_Notion();
    }

    public void Dove_UnRocked_Notion()
    {
        LanguageManager.instance.Dove_UnRocked_Notion();
    }

    public void Skin_Equip_Notion()
    {
        LanguageManager.instance.Skin_Equip_Notion();
    }

    public void Skin_Cancel_Notion()
    {
        LanguageManager.instance.Skin_Cancel_Notion();
    }

    public void Not_Equip_Skin_Notion()
    {
        LanguageManager.instance.Not_Equip_Skin_Notion();
    }


    //비둘기 구매
    public void Buy_White()
    {
        if(BD_White == 0)
        {
            if(BD_Coin >= 25000)
            {
                //업적 - 코인 사용
                int a = PlayerPrefs.GetInt("Achieve_Coin");
                a += 25000;
                PlayerPrefs.SetInt("Achieve_Coin", a);

                BD_Coin -= 25000;
                PlayerPrefs.SetInt("BD_Coin", BD_Coin);
                Dove_UnRocked_Notion();
                EffectManager.instance.Box_Open_3();

                BD_White = 1;
                PlayerPrefs.SetInt("BD_White", 1);
                Rock_Off(BD_White, White_Rock);
                Title_Change();
            }
            else
            {
                Low_Coin_Notion();
            }
        }
        else
        {
            Now_Hold_Notion();
        }
    }
    public void Buy_Eagle()
    {
        if (BD_Eagle == 0)
        {
            if (BD_Coin >= 50000)
            {
                //업적 - 코인 사용
                int a = PlayerPrefs.GetInt("Achieve_Coin");
                a += 50000;
                PlayerPrefs.SetInt("Achieve_Coin", a);

                BD_Coin -= 50000;
                PlayerPrefs.SetInt("BD_Coin", BD_Coin);
                Dove_UnRocked_Notion();
                EffectManager.instance.Box_Open_3();

                BD_Eagle = 1;
                PlayerPrefs.SetInt("BD_Eagle", 1);
                Rock_Off(BD_Eagle, Eagle_Rock);
                Title_Change();
            }
            else
            {
                Low_Coin_Notion();
            }
        }
        else
        {
            Now_Hold_Notion();
        }
    }
    
    public void Buy_Dora()
    {
        if (BD_Dora == 0)
        {
            if (BD_Coin >= 100000)
            {
                //업적 - 코인 사용
                int a = PlayerPrefs.GetInt("Achieve_Coin");
                a += 100000;
                PlayerPrefs.SetInt("Achieve_Coin", a);

                BD_Coin -= 100000;
                PlayerPrefs.SetInt("BD_Coin", BD_Coin);
                Dove_UnRocked_Notion();
                EffectManager.instance.Box_Open_3();

                BD_Dora = 1;
                PlayerPrefs.SetInt("BD_Dora", 1);
                Rock_Off(BD_Dora, Dora_Rock);
                Title_Change();
            }
            else
            {
                Low_Coin_Notion();
            }
        }
        else
        {
            Now_Hold_Notion();
        }
    }

    //스킨 착용
    public void Sunshine_Skin_Up()
    {
        if (BD_Sunshine_Skin > 0)
        {
            if (Choice == 1)
            {
                if (BD_Sunshine_Dress[0] == 0)
                {
                    BD_Sunshine_Dress[0] = 1;
                    BD_Clocking_Dress[0] = 0;
                    BD_Rainbow_Dress[0] = 0;

                    Skin_Equip_Notion();

                    PlayerPrefs.SetInt("Sunshine_Black", 1);
                    PlayerPrefs.SetInt("Clocking_Black", 0);
                    PlayerPrefs.SetInt("Rainbow_Black", 0);
                }
                else
                {
                    BD_Sunshine_Dress[0] = 0;

                    Skin_Cancel_Notion();

                    PlayerPrefs.SetInt("Sunshine_Black", 0);
                    PlayerPrefs.SetInt("Clocking_Black", 0);
                    PlayerPrefs.SetInt("Rainbow_Black", 0);
                }
            }
            else if (Choice == 2)
            {
                if (BD_Sunshine_Dress[1] == 0)
                {
                    BD_Sunshine_Dress[1] = 1;
                    BD_Clocking_Dress[1] = 0;
                    BD_Rainbow_Dress[1] = 0;
                    Skin_Equip_Notion();

                    PlayerPrefs.SetInt("Sunshine_White", 1);
                    PlayerPrefs.SetInt("Clocking_White", 0);
                    PlayerPrefs.SetInt("Rainbow_White", 0);
                }
                else
                {
                    BD_Sunshine_Dress[1] = 0;
                    Skin_Cancel_Notion();

                    PlayerPrefs.SetInt("Sunshine_White", 0);
                    PlayerPrefs.SetInt("Clocking_White", 0);
                    PlayerPrefs.SetInt("Rainbow_White", 0);
                }
            }
            else if (Choice == 3)
            {
                Not_Equip_Skin_Notion();
            }
            else if (Choice == 4)
            {
                /*
                if (BD_Sunshine_Dress[2] == 0)
                {
                    BD_Sunshine_Dress[2] = 1;
                    BD_Clocking_Dress[2] = 0;
                    BD_Rainbow_Dress[2] = 0;
                    Skin_Equip_Notion();

                    PlayerPrefs.SetInt("Sunshine_Dora", 1);
                    PlayerPrefs.SetInt("Clocking_Dora", 0);
                    PlayerPrefs.SetInt("Rainbow_Dora", 0);
                }
                else
                {
                    BD_Sunshine_Dress[2] = 0;
                    Skin_Cancel_Notion();

                    PlayerPrefs.SetInt("Sunshine_Dora", 0);
                    PlayerPrefs.SetInt("Clocking_Dora", 0);
                    PlayerPrefs.SetInt("Rainbow_Dora", 0);
                }
                */
                Not_Equip_Skin_Notion();

            }

            Fly_Setting(Choice);
            Skin_Setting(BD_Sunshine_Dress, Sunshine_Btn, Sunshine_label);
            Skin_Setting(BD_Clocking_Dress, Clocking_Btn, Clocking_label);
            Skin_Setting(BD_Rainbow_Dress, Rainbow_Btn, Rainbow_label);
        }
        else
        {
            Debug.Log("획득 안해서 착용 불가");
        }

    }
    public void Clocking_Skin_Up()
    {
        if (BD_Clocking_Skin > 0)
        {
            if (Choice == 1)
            {
                if (BD_Clocking_Dress[0] == 0)
                {
                    BD_Sunshine_Dress[0] = 0;
                    BD_Clocking_Dress[0] = 1;
                    BD_Rainbow_Dress[0] = 0;
                    Skin_Equip_Notion();

                    PlayerPrefs.SetInt("Sunshine_Black", 0);
                    PlayerPrefs.SetInt("Clocking_Black", 1);
                    PlayerPrefs.SetInt("Rainbow_Black", 0);
                }
                else
                {
                    BD_Clocking_Dress[0] = 0;
                    Skin_Cancel_Notion();

                    PlayerPrefs.SetInt("Sunshine_Black", 0);
                    PlayerPrefs.SetInt("Clocking_Black", 0);
                    PlayerPrefs.SetInt("Rainbow_Black", 0);
                }

            }
            else if (Choice == 2)
            {
                if (BD_Clocking_Dress[1] == 0)
                {
                    BD_Sunshine_Dress[1] = 0;
                    BD_Clocking_Dress[1] = 1;
                    BD_Rainbow_Dress[1] = 0;
                    Skin_Equip_Notion();

                    PlayerPrefs.SetInt("Sunshine_White", 0);
                    PlayerPrefs.SetInt("Clocking_White", 1);
                    PlayerPrefs.SetInt("Rainbow_White", 0);
                }
                else
                {
                    BD_Clocking_Dress[1] = 0;
                    Skin_Cancel_Notion();

                    PlayerPrefs.SetInt("Sunshine_White", 0);
                    PlayerPrefs.SetInt("Clocking_White", 0);
                    PlayerPrefs.SetInt("Rainbow_White", 0);
                }
            }
            else if (Choice == 3)
            {
                Not_Equip_Skin_Notion();
            }
            else if (Choice == 4)
            {
                /*
                if (BD_Clocking_Dress[2] == 0)
                {
                    BD_Sunshine_Dress[2] = 0;
                    BD_Clocking_Dress[2] = 1;
                    BD_Rainbow_Dress[2] = 0;
                    Skin_Equip_Notion();

                    PlayerPrefs.SetInt("Sunshine_Dora", 0);
                    PlayerPrefs.SetInt("Clocking_Dora", 1);
                    PlayerPrefs.SetInt("Rainbow_Dora", 0);
                }
                else
                {
                    BD_Clocking_Dress[2] = 0;
                    Skin_Cancel_Notion();

                    PlayerPrefs.SetInt("Sunshine_Dora", 0);
                    PlayerPrefs.SetInt("Clocking_Dora", 0);
                    PlayerPrefs.SetInt("Rainbow_Dora", 0);
                }
                */
                Not_Equip_Skin_Notion();
            }

            Fly_Setting(Choice);
            Skin_Setting(BD_Sunshine_Dress, Sunshine_Btn, Sunshine_label);
            Skin_Setting(BD_Clocking_Dress, Clocking_Btn, Clocking_label);
            Skin_Setting(BD_Rainbow_Dress, Rainbow_Btn, Rainbow_label);
        }
        else
        {
            Debug.Log("획득 안해서 착용 불가");
        }
    }
    public void Rainbow_Skin_Up()
    {
        if (BD_Rainbow_Skin > 0)
        {
            if (Choice == 1)
            {
                if (BD_Rainbow_Dress[0] == 0)
                {
                    BD_Sunshine_Dress[0] = 0;
                    BD_Clocking_Dress[0] = 0;
                    BD_Rainbow_Dress[0] = 1;
                    Skin_Equip_Notion();

                    PlayerPrefs.SetInt("Sunshine_Black", 0);
                    PlayerPrefs.SetInt("Clocking_Black", 0);
                    PlayerPrefs.SetInt("Rainbow_Black", 1);
                }
                else
                {
                    BD_Rainbow_Dress[0] = 0;
                    Skin_Cancel_Notion();

                    PlayerPrefs.SetInt("Sunshine_Black", 0);
                    PlayerPrefs.SetInt("Clocking_Black", 0);
                    PlayerPrefs.SetInt("Rainbow_Black", 0);
                }
            }
            else if (Choice == 2)
            {
                if (BD_Rainbow_Dress[1] == 0)
                {
                    BD_Sunshine_Dress[1] = 0;
                    BD_Clocking_Dress[1] = 0;
                    BD_Rainbow_Dress[1] = 1;
                    Skin_Equip_Notion();

                    PlayerPrefs.SetInt("Sunshine_White", 0);
                    PlayerPrefs.SetInt("Clocking_White", 0);
                    PlayerPrefs.SetInt("Rainbow_White", 1);
                }
                else
                {
                    BD_Rainbow_Dress[1] = 0;
                    Skin_Cancel_Notion();

                    PlayerPrefs.SetInt("Sunshine_White", 0);
                    PlayerPrefs.SetInt("Clocking_White", 0);
                    PlayerPrefs.SetInt("Rainbow_White", 0);
                }
            }
            else if (Choice == 3)
            {
                Not_Equip_Skin_Notion();
            }
            else if (Choice == 4)
            {
                /*
                if (BD_Rainbow_Dress[2] == 0)
                {
                    BD_Sunshine_Dress[2] = 0;
                    BD_Clocking_Dress[2] = 0;
                    BD_Rainbow_Dress[2] = 1;
                    Skin_Equip_Notion();

                    PlayerPrefs.SetInt("Sunshine_Dora", 0);
                    PlayerPrefs.SetInt("Clocking_Dora", 0);
                    PlayerPrefs.SetInt("Rainbow_Dora", 1);
                }
                else
                {
                    BD_Rainbow_Dress[2] = 0;
                    Skin_Cancel_Notion();

                    PlayerPrefs.SetInt("Sunshine_Dora", 0);
                    PlayerPrefs.SetInt("Clocking_Dora", 0);
                    PlayerPrefs.SetInt("Rainbow_Dora", 0);
                }
                */
                Not_Equip_Skin_Notion();
            }

            Fly_Setting(Choice);
            Skin_Setting(BD_Sunshine_Dress, Sunshine_Btn, Sunshine_label);
            Skin_Setting(BD_Clocking_Dress, Clocking_Btn, Clocking_label);
            Skin_Setting(BD_Rainbow_Dress, Rainbow_Btn, Rainbow_label);
        }
        else
        {
            Debug.Log("획득 안해서 착용 불가");
        }
    }


    public void Select_Dove()
    {
        PlayerPrefs.SetInt("DoveChoice", Choice);
        SelectDove.instance.Check(Choice);
        //SelectManager.instance.Background_Change();
        SelectManager.instance.Exit();
        SelectManager.instance.Exit();
        EffectManager.instance.Dove_Select();
    } //비둘기 선택(메인화면으로 감)

    public void Close()
    {
        SelectManager.instance.Exit();

        Nest_Box_Up.SetActive(true);
        Nest_Box_Down.SetActive(true);

    } //비둘기 상세창 닫았을 때(한 번 뒤로감)

    IEnumerator Flying(UISprite sprite, string[] a)
    {
        sprite.spriteName = a[0];
        yield return new WaitForSeconds(Cooltime);
        sprite.spriteName = a[1];
        yield return new WaitForSeconds(Cooltime);
        sprite.spriteName = a[2];
        yield return new WaitForSeconds(Cooltime);
        sprite.spriteName = a[3];
        yield return new WaitForSeconds(Cooltime);
        sprite.spriteName = a[4];
        yield return new WaitForSeconds(Cooltime);
        sprite.spriteName = a[5];
        yield return new WaitForSeconds(Cooltime);
        sprite.spriteName = a[4];
        yield return new WaitForSeconds(Cooltime);
        sprite.spriteName = a[3];
        yield return new WaitForSeconds(Cooltime);
        sprite.spriteName = a[2];
        yield return new WaitForSeconds(Cooltime);
        sprite.spriteName = a[1];
        yield return new WaitForSeconds(Cooltime);
        StartCoroutine(Flying(sprite, a));
    }

    //선택한 비둘기 / 구구 스킬 / 루루 스킬 / 수리수리 스킬 / 도라 스킬 /라벨 저장소 /스프라이트 저장소

    public void Coin_Lv_Up_Btn() //상세창에서 코인으로 레벨 업
    {
        //어떤 비둘기인지 구별하기
        if (Choice == 1)
        {
            AliveTime = BD_Black_AliveTime;
            SkillValue = BD_Black_Skill_Value;
        }
        else if(Choice == 2)
        {
            AliveTime = BD_White_AliveTime;
            SkillValue = BD_White_Skill_Value;
        }
        else if(Choice == 3)
        {
            AliveTime = BD_Eagle_AliveTime;
            SkillValue = BD_Eagle_Skill_Value;
        }
        else if(Choice == 4)
        {
            AliveTime = BD_Dora_AliveTime;
            SkillValue = BD_Dora_Skill_Value;
        }

        if (AliveTime >= Lv_Up_AliveTime_Value[SkillValue]) //생존시간은 충분한지
        {
            if (BD_Coin >= Lv_Up_Coin_Value[SkillValue]) //코인은 충분한지
            {
                if (SkillValue < 98) //레벨99 미만인지
                {
                    //업적 - 코인 사용
                    int a = PlayerPrefs.GetInt("Achieve_Coin");
                    a += Lv_Up_Coin_Value[SkillValue];
                    PlayerPrefs.SetInt("Achieve_Coin", a);

                    //업적 - 비둘기 총합 레벨
                    int b = PlayerPrefs.GetInt("Achieve_Dove");
                    b += 1;
                    PlayerPrefs.SetInt("Achieve_Dove", b);


                    AliveTime -= Lv_Up_AliveTime_Value[SkillValue];

                    BD_Coin -= Lv_Up_Coin_Value[SkillValue];
                    PlayerPrefs.SetInt("BD_Coin", BD_Coin);

                    Lv_Up_Notion();
                    EffectManager.instance.Coin_Plus();

                    if (Choice == 1) //레벨업
                    {
                        BD_Black_AliveTime = AliveTime;
                        PlayerPrefs.SetInt("BD_Black_AliveTime", BD_Black_AliveTime);

                        BD_Black_Skill_Value += 1;
                        PlayerPrefs.SetInt("BD_Black_Skill_Value", BD_Black_Skill_Value);

                        Black_Skill_Point_All += 1;
                        PlayerPrefs.SetInt("Black_Skill_Point_All", Black_Skill_Point_All);

                        Black_Skill_Point_Total += 1;
                        PlayerPrefs.SetInt("Black_Skill_Point_Total", Black_Skill_Point_Total); //초기화를 대비한 총합
                    }
                    else if(Choice == 2)
                    {
                        BD_White_AliveTime = AliveTime;
                        PlayerPrefs.SetInt("BD_White_AliveTime", BD_White_AliveTime);

                        BD_White_Skill_Value += 1;
                        PlayerPrefs.SetInt("BD_White_Skill_Value", BD_White_Skill_Value);

                        White_Skill_Point_All += 1;
                        PlayerPrefs.SetInt("White_Skill_Point_All", White_Skill_Point_All);

                        White_Skill_Point_Total += 1;
                        PlayerPrefs.SetInt("White_Skill_Point_Total", White_Skill_Point_Total); //초기화를 대비한 총합
                    }
                    else if(Choice == 3)
                    {
                        BD_Eagle_AliveTime = AliveTime;
                        PlayerPrefs.SetInt("BD_Eagle_AliveTime", BD_Eagle_AliveTime);

                        BD_Eagle_Skill_Value += 1;
                        PlayerPrefs.SetInt("BD_Eagle_Skill_Value", BD_Eagle_Skill_Value);

                        Eagle_Skill_Point_All += 1;
                        PlayerPrefs.SetInt("Eagle_Skill_Point_All", Eagle_Skill_Point_All);

                        Eagle_Skill_Point_Total += 1;
                        PlayerPrefs.SetInt("Eagle_Skill_Point_Total", Eagle_Skill_Point_Total); //초기화를 대비한 총합
                    }
                    else if(Choice == 4)
                    {
                        BD_Dora_AliveTime = AliveTime;
                        PlayerPrefs.SetInt("BD_Dora_AliveTime", BD_Dora_AliveTime);

                        BD_Dora_Skill_Value += 1;
                        PlayerPrefs.SetInt("BD_Dora_Skill_Value", BD_Dora_Skill_Value);

                        Dora_Skill_Point_All += 1;
                        PlayerPrefs.SetInt("Dora_Skill_Point_All", Dora_Skill_Point_All);

                        Dora_Skill_Point_Total += 1;
                        PlayerPrefs.SetInt("Dora_Skill_Point_Total", Dora_Skill_Point_Total); //초기화를 대비한 총합
                    }

                    Renewal();
                    Renewal_Detail();
                }
                else
                {
                    Max_Lv_Notion();
                }
            }
            else
            {
                Low_Coin_Notion();
            }
        }
        else
        {
            Low_SurvivalTime_Notion();
        }
    }


    public void Skill_1_Btn()
    {
        if (Choice == 1)
        {
            Skill_Btn(1, 0);
        }
        else if (Choice == 2)
        {
            Skill_Btn(2, 0);
        }
        else if (Choice == 3)
        {
            Skill_Btn(3, 0);
        }
        else if (Choice == 4)
        {
            Skill_Btn(4, 0);
        }
    }
    public void Skill_2_Btn()
    {
        if (Choice == 1)
        {
            Skill_Btn(1, 1);
        }
        else if (Choice == 2)
        {
            Skill_Btn(2, 1);
        }
        else if (Choice == 3)
        {
            Skill_Btn(3, 1);
        }
        else if (Choice == 4)
        {
            Skill_Btn(4, 1);
        }
    }
    public void Skill_3_Btn()
    {
        if (Choice == 1)
        {
            Skill_Btn(1, 2);
        }
        else if (Choice == 2)
        {
            Skill_Btn(2, 2);
        }
        else if (Choice == 3)
        {
            Skill_Btn(3, 2);
        }
        else if (Choice == 4)
        {
            Skill_Btn(4, 2);
        }
    }
    public void Skill_4_Btn()
    {
        if (Choice == 1)
        {
            Skill_Btn(1, 3);
        }
        else if (Choice == 2)
        {
            Skill_Btn(2, 3);
        }
        else if (Choice == 3)
        {
            Skill_Btn(3, 3);
        }
        else if (Choice == 4)
        {
            Skill_Btn(4, 3);
        }
    }
    public void Skill_5_Btn()
    {
        if (Choice == 1)
        {
            Skill_Btn(1, 4);
        }
        else if (Choice == 2)
        {
            Skill_Btn(2, 4);
        }
        else if (Choice == 3)
        {
            Skill_Btn(3, 4);
        }
        else if (Choice == 4)
        {
            Skill_Btn(4, 4);
        }
    }
    public void Skill_6_Btn()
    {
        if (Choice == 1)
        {
            Skill_Btn(1, 5);
        }
        else if (Choice == 2)
        {
            Skill_Btn(2, 5);
        }
        else if (Choice == 3)
        {
            Skill_Btn(3, 5);
        }
        else if (Choice == 4)
        {
            Skill_Btn(4, 5);
        }
    }
    public void Skill_7_Btn()
    {
        if (Choice == 1)
        {
            Skill_Btn(1, 6);
        }
        else if (Choice == 2)
        {
            Skill_Btn(2, 6);
        }
        else if (Choice == 3)
        {
            Skill_Btn(3, 6);
        }
        else if (Choice == 4)
        {
            Skill_Btn(4, 6);
        }
    }
    public void Skill_8_Btn()
    {
        if (Choice == 1)
        {
            Skill_Btn(1, 7);
        }
        else if (Choice == 2)
        {
            Skill_Btn(2, 7);
        }
        else if (Choice == 3)
        {
            Skill_Btn(3, 7);
        }
        else if (Choice == 4)
        {
            Skill_Btn(4, 7);
        }
    }
    public void Skill_9_Btn()
    {
        if (Choice == 1)
        {
            Skill_Btn(1, 8);
        }
        else if (Choice == 2)
        {
            Skill_Btn(2, 8);
        }
        else if (Choice == 3)
        {
            Skill_Btn(3, 8);
        }
        else if (Choice == 4)
        {
            Skill_Btn(4, 8);
        }
    }
    public void Skill_10_Btn()
    {
        if (Choice == 1)
        {
            Skill_Btn(1, 9);
        }
        else if (Choice == 2)
        {
            Skill_Btn(2, 9);
        }
        else if (Choice == 3)
        {
            Skill_Btn(3, 9);
        }
        else if (Choice == 4)
        {
            Skill_Btn(4, 9);
        }
    }

    void Skill_Btn(int number1, int number2) //스킬 찍기 Black_Skill_Point_All을 사용함
    {
        if (Choice == 1)
        {
            SkillPoint = Black_Skill_Point_All;
            MaxSkill = int.Parse(Black_Skill_Point[number2]);
        }
        else if (Choice == 2)
        {
            SkillPoint = White_Skill_Point_All;
            MaxSkill = int.Parse(White_Skill_Point[number2]);
        }
        else if (Choice == 3)
        {
            SkillPoint = Eagle_Skill_Point_All;
            MaxSkill = int.Parse(Eagle_Skill_Point[number2]);
        }
        else if (Choice == 4)
        {
            SkillPoint = Dora_Skill_Point_All;
            MaxSkill = int.Parse(Dora_Skill_Point[number2]);
        }

        if(MaxSkill < 9)
        {
            if (SkillPoint > 0)
            {
                SkillPoint -= 1;
                Lv_Up_Notion();

                if (Choice == 1)
                {
                    Black_Skill_Point_All = SkillPoint;
                    PlayerPrefs.SetInt("Black_Skill_Point_All", Black_Skill_Point_All);
                }
                else if (Choice == 2)
                {
                    White_Skill_Point_All = SkillPoint;
                    PlayerPrefs.SetInt("White_Skill_Point_All", White_Skill_Point_All);
                }
                else if (Choice == 3)
                {
                    Eagle_Skill_Point_All = SkillPoint;
                    PlayerPrefs.SetInt("Eagle_Skill_Point_All", Eagle_Skill_Point_All);
                }
                else if (Choice == 4)
                {
                    Dora_Skill_Point_All = SkillPoint;
                    PlayerPrefs.SetInt("Dora_Skill_Point_All", Dora_Skill_Point_All);
                }
                Save_Skill_Point(number1, number2);

                EffectManager.instance.Coin_Plus();

                Renewal_Detail();
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


    void Save_Skill_Point(int number, int value) //스킬포인트 갱신 코드 -> (비둘기넘버 , 스킬 번호)
    {
        string a = "";
        int b = 0;
        if (number == 1)
        {
            b = int.Parse(Black_Skill_Point[value]) + 1;
            Black_Skill_Point[value] = b.ToString();

            for (int i = 0; i < Black_Skill_Point_Save.Length; i++)
            {
                a = a.Insert(i, Black_Skill_Point[i]);
            }
            PlayerPrefs.SetString("Black_Skill_Point_Save", a);
        }
        else if(number == 2)
        {
            b = int.Parse(White_Skill_Point[value]) + 1;
            White_Skill_Point[value] = b.ToString();

            for (int i = 0; i < White_Skill_Point_Save.Length; i++)
            {
                a = a.Insert(i, White_Skill_Point[i]);
            }
            PlayerPrefs.SetString("White_Skill_Point_Save", a);
        }
        else if(number == 3)
        {
            b = int.Parse(Eagle_Skill_Point[value]) + 1;
            Eagle_Skill_Point[value] = b.ToString();

            for (int i = 0; i < Eagle_Skill_Point_Save.Length; i++)
            {
                a = a.Insert(i, Eagle_Skill_Point[i]);
            }
            PlayerPrefs.SetString("Eagle_Skill_Point_Save", a);
        }
        else if(number == 4)
        {
            b = int.Parse(Dora_Skill_Point[value]) + 1;
            Dora_Skill_Point[value] = b.ToString();

            for (int i = 0; i < Dora_Skill_Point_Save.Length; i++)
            {
                a = a.Insert(i, Dora_Skill_Point[i]);
            }
            PlayerPrefs.SetString("Dora_Skill_Point_Save", a);
        }
    }


    public void Skill_Reset_Btn()
    {
        int Skill_Point_All = 0;
        int Skill_Point_Total = 0;

        if (Choice == 1)
        {
            Skill_Point_All = Black_Skill_Point_All;
            Skill_Point_Total = Black_Skill_Point_Total;
        }
        else if (Choice == 2)
        {
            Skill_Point_All = White_Skill_Point_All;
            Skill_Point_Total = White_Skill_Point_Total;
        }
        else if (Choice == 3)
        {
            Skill_Point_All = Eagle_Skill_Point_All;
            Skill_Point_Total = Eagle_Skill_Point_Total;
        }
        else if (Choice == 4)
        {
            Skill_Point_All = Dora_Skill_Point_All;
            Skill_Point_Total = Dora_Skill_Point_Total;
        }


        if (Skill_Point_All < Skill_Point_Total)
        {
            if (BD_Dora_Feather >= 2)
            {
                BD_Dora_Feather -= 2;
                PlayerPrefs.SetInt("BD_Dora_Feather", BD_Dora_Feather);

                if (Choice == 1)
                {
                    Black_Skill_Point_Total = PlayerPrefs.GetInt("Black_Skill_Point_Total");

                    Black_Skill_Point_All = Black_Skill_Point_Total;
                    PlayerPrefs.SetInt("Black_Skill_Point_All", Black_Skill_Point_All);

                    PlayerPrefs.SetString("Black_Skill_Point_Save", "0000000000");
                }
                else if (Choice == 2)
                {
                    White_Skill_Point_Total = PlayerPrefs.GetInt("White_Skill_Point_Total");

                    White_Skill_Point_All = White_Skill_Point_Total;
                    PlayerPrefs.SetInt("White_Skill_Point_All", White_Skill_Point_All);

                    PlayerPrefs.SetString("White_Skill_Point_Save", "0000000000");
                }
                else if (Choice == 3)
                {
                    Eagle_Skill_Point_Total = PlayerPrefs.GetInt("Eagle_Skill_Point_Total");

                    Eagle_Skill_Point_All = Eagle_Skill_Point_Total;
                    PlayerPrefs.SetInt("Eagle_Skill_Point_All", Eagle_Skill_Point_All);

                    PlayerPrefs.SetString("Eagle_Skill_Point_Save", "0000000000");
                }
                else if (Choice == 4)
                {
                    Dora_Skill_Point_Total = PlayerPrefs.GetInt("Dora_Skill_Point_Total");

                    Dora_Skill_Point_All = Dora_Skill_Point_Total;

                    PlayerPrefs.SetInt("Dora_Skill_Point_All", Dora_Skill_Point_All);
                    PlayerPrefs.SetString("Dora_Skill_Point_Save", "0000000000");
                }

                LanguageManager.instance.Success_Reset_Notion();
                Renewal_Detail();
            }
            else
            {
                LanguageManager.instance.Low_Feather_Notion();
            }
        }
        else
        {
            LanguageManager.instance.Error_Reset_Notion();
        }
    }
}
