using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public GameObject Creadtive_Mode;
    public MapCtrl mapctrl;

    private Transform Dove;
    private Vector3 Dove_Which;
    private Transform Dove_Plus_Which;
    private Transform Dove_Hp_Which;

    private int DoveChoice;

    private int BD_Coin;
    private int BD_Diamond;
    private float Plus_Coin;
    private int Plus_Diamond;
    private int BD_Dora_Feather;
    private int Plus_Dora_Feather;

    public int BD_Black_AliveTime;
    public int BD_White_AliveTime;
    public int BD_Eagle_AliveTime;
    public int BD_Dora_AliveTime;

    public GameObject Best_Score;
    public GameObject Best_Stage;
    public GameObject Best_Time;

    private string InGame_Best_txt = "";

    private int NowScore; //스코어
    private int Plus_NowScore;

    private int HighScore;
    private int Black_HighScore;
    private int White_HighScore;
    private int Eagle_HighScore;
    private int Dora_HighScore;

    private int NowHighScore; //하이스코어를 초과했을시 가짜로 증가하는 값
    private float ScoreCooltime;

    //강화 2배 확률
    public float Upgrade_Score2 = 0;
    public float Upgrade_Coin2 = 0;

    public int NowStage; //스테이지
    private int HighStage;

    private int NowTimer; //타이머
    private int NowMinTimer;

    private int HighTimer;
    private int HighMinTimer;

    public UILabel NowScoretxt;
    public Transform Nowscoretxt; //최고 점수 갱신시 효과를 주기위해
    public UILabel HighScoretxt;
    public UILabel Cointxt;
    public UILabel Diamondtxt;
    public UILabel Feathertxt;

    public UILabel Continuetxt;

    private bool GameSet;
    private bool Start_Value;
    private bool Renewal;

    private bool Under_Mole_Value;
    private bool Under_Value;
    private bool Castle_Value;

    private int Hidden_Time_Check;

    public int Under_Time_Value;
    public int Castle_Time_Value;

    //EndGameWindow

    private int Best_score;
    private int Best_stage;
    private int Best_time;

    private string rank = "";
    private int Rank;

    public UILabel AliveTime_txt;

    public GameObject EndGameWindow;

    public UILabel End_Scoretxt;
    public UILabel End_Stagetxt;
    public UILabel End_Timertxt;

    public UILabel PlusScore_Title_txt;
    public UILabel End_PlusScoretxt;

    public UILabel End_HighScoretxt;
    public UILabel End_HighStagetxt;
    public UILabel End_HighTimertxt;

    public UILabel PlusCoin_Title_txt;
    public UILabel End_Cointxt;
    public UILabel End_PlusCointxt;

    public UILabel End_Diamondtxt;
    public UILabel End_PlusDiamondtxt;

    public UILabel End_Feathertxt;

    public UILabel Ad_Coin_Plus_txt;

    //OptionWindow

    public GameObject OptionWindow;

    public UISprite Music_sprite;
    public UISprite SFX_sprite;
    public UISprite Vibration_sprite;

    public UILabel Music_txt;
    public UILabel SFX_txt;
    public UILabel Vibration_txt;

    private string[] InGame_On;

    private int Music_OnOff;
    public int SFX_OnOff;
    private int Vibration_OnOff;
    private bool Vibration;

    //TalkWindow
    public GameObject TalkWindow;
    private bool Talk_Value;

    //게임
    private float Default_Hp;
    private float Default_hp;
    private float Default_Max_Hp;
    private float Dove_Hp_Down_Speed;
    private float Dove_Hp_Down_Control;

    private float Upgrade_Coin;

    private bool Hp_Red; //Hp가 일정 비율 이하일시 발동

    private int Leaf_Time; //나무가지 시간

    public UISprite Hp_Filter;
    public UILabel Hp_txt;

    public Transform Heart;

    private bool Skill_Use; //스킬 사용 여부

    public GameObject GameOverWindow;

    private int BD_Diamond_Count;
    private int BD_Diamond_Number;
    private int Advertising_Count;

    public int GameOver_reason;
    public int GameOver_Kind;
    public UILabel GameOver_Reason_txt; //사망원인
    public UILabel BD_Diamond_txt; //현재 보유한 다이아몬드 개수
    public UILabel Advertisting_Count_txt; //광고 이어하기 횟수
    public UILabel Continue_Count_txt; //다이아 이어하기 횟수
    public UILabel BD_Diamond_Number_txt; //다이아 이어하기에 필요한 다이아 카운트

    private List<string> GameOver_Reason = new List<string>();
    private string InGame_Count = "";

    //인게임
    public GameObject Dove_Black;
    public GameObject Dove_White;
    public GameObject Dove_Eagle;
    public GameObject Wave;
    //public GameObject Dove_Dora; //어디에 사용할지 아직 고민중

    public List<GameObject> Enemy_Black = new List<GameObject>();
    public List<GameObject> Enemy_White = new List<GameObject>();
    public List<GameObject> Enemy_Eagle = new List<GameObject>();
    public List<GameObject> Enemy_Wave = new List<GameObject>();

    public List<GameObject> Enemy_Reset = new List<GameObject>();

    public Transform[] Dove_Point;
    public Transform[] Eagle_Point;

    private float Enemy_Dove_Create_CoolTime;
    private float Enemy_Eagle_Create_CoolTime;
    private float Enemy_Wave_Create_CoolTime;

    private int Black_Index;
    private int White_Index;
    private int Eagle_Index;
    private int Wave_Index;

    private int Heal_Index;
    private int Coin_Index;

    private bool Wave_Value;

    //스킨
    private int BD_Rainbow_Skin;

    //효과, 코인
    public GameObject Plus_Heal;
    public GameObject Coin;

    public List<GameObject> Object_Heal = new List<GameObject>();
    public List<GameObject> Object_Coin = new List<GameObject>();
    public List<GameObject> Castle_Coin = new List<GameObject>();

    private int Object_Coin_Value;
    private float Object_Coin_Create_CoolTime;
    private float Object_Coin_Create_CoolTime_Down;

    //아이템
    public GameObject Item;

    private int Item_Index;
    public List<GameObject> Object_Item = new List<GameObject>();

    public Transform[] Coin_Point;
    public Transform[] Item_Point;

    private float Object_Item_Create_CoolTime;
    private float Object_Item_Create_CoolTime_Down;

    //아이템 사용
    private bool Hacktool;

    //지하세계 두더지
    public GameObject Mole_Stone;
    private int Mole_Index;

    public List<GameObject> Object_Mole_Stone = new List<GameObject>();

    //쉴드
    public GameObject Shield;

    //효과 프리팹
    public GameObject Disappear;

    public GameObject MapCtrl;
    public GameObject Default_Map;
    public GameObject Under_Map;
    public GameObject Castle_Map;

    //스코어 표시
    public GameObject Score_Notion;
    public UILabel Score_Notion_txt;

    public GameObject Dove_Notion;
    public UILabel Dove_Notion_txt;

    public GameObject Coin_Plus_Notion;
    public UILabel Coin_Plus_Notion_txt;

    public GameObject Dia_Plus_Notion;
    public UILabel Dia_Plus_Notion_txt;

    public GameObject Feather_Plus_Notion;
    public UILabel Feather_Plus_Notion_txt;

    private string[] InGame_Notion;

    //나무가지
    private bool Leaf_Value;
    public GameObject Leaf_Notion;
    public UILabel Leaf_Notion_txt;

    //Hp 이하일시
    public GameObject Background_Red;
    public UISprite Background_Red_Alpha;
    private float Alpha;


    //피버모드
    public UISprite Fever_Fillter;    
    public UILabel Fever_txt;
    private int Fever;
    private float Fever_Time;
    public bool fever;

    public GameObject Fever1;
    public GameObject Fever2;
    public GameObject Fever3;
    public GameObject Fever4;

    public ParticleSystem F1, F2, F3, F4;

    public Transform[] Fever_Point;

    //난이도
    private int Level;
    public UILabel Level_txt;
    public UILabel Stage_txt;

    private string[] InGame_Level;
    private string InGame_Stage;

    private float Dove_Control;
    private float Eagle_Control;
    private float Wave_Control;
    private float Score_Control;
    private float Hp_Minus_Control;

    //조력자
    private int Aid;
    public GameObject Aid_UI;
    public UISprite Aid_Main_sp;
    public UISprite Aid_Fillter;

    private int BD_Owl_Lv;
    private int BD_Duck_Lv;

    public float Owl_CoolTime = 0;
    public int Owl_Default_Value = 0;
    public int Owl_Up_Value = 0;
    private int Owl_Hp;

    public float Duck_CoolTime = 0;
    public int Duck_Default_Value = 0;
    public int Duck_Up_Value = 0;

    private bool Owl_Hp_Plus;

    //UFO
    public GameObject UFO;
    public GameObject UFO_Notion;
    public UILabel UFO_txt;
    private UISprite UFO_notion;
    private bool UFO_Value; //한번 켜지면 다시 안 꺼짐
    private bool UFO_Blink;
    private bool UFO_Blink_Up;
    private float UFO_Alpha;


    //메인 음악
    private AudioSource source;
    public AudioClip main_theme;
    public AudioClip main_theme_x1;
    public AudioClip main_theme_x2;
    public AudioClip under;
    public AudioClip castle;

    private bool theme_x1;
    private bool theme_x2;

    //광고 보상
    public bool RewardAd_Watch = false;
    public GameObject RewardAd_Object;
    private bool RewardAd = false;
    private int RewardAd_Coin;
    private int RewardAd_Default;

    //파티클 카메라
    public Camera cam;

    //개발자 옵션
    private bool Immortal_Dove;

    public delegate void Gamemanager();
    public static event Gamemanager Player_Die, Player_Alive, Olive_In, Olive_Out, Talk_In, Talk_Out, Under_In, Under_Out, Castle_In, Castle_Out;


    void Awake() //초기화
    {
        instance = this;

        source = gameObject.GetComponent<AudioSource>();
        Creadtive_Mode.SetActive(false);

        Dove_Point = GameObject.Find("Enemy_Dove_Points").GetComponentsInChildren<Transform>();
        Eagle_Point = GameObject.Find("Enemy_Eagle_Points").GetComponentsInChildren<Transform>();
        Fever_Point = GameObject.Find("Fever_Point").GetComponentsInChildren<Transform>();

        //오브젝트 위치
        Dove = GameObject.Find("Dove").GetComponent<Transform>();
        Dove_Plus_Which = GameObject.Find("Dove_Plus_Which").GetComponent<Transform>();
        Dove_Hp_Which = GameObject.Find("Dove_Hp_Which").GetComponent<Transform>();

        Background_Red.SetActive(false);
        Continuetxt.enabled = false;

        Skill_Use = false;
        Talk_Value = false;
        Wave_Value = false;

        Hacktool = false;
        Immortal_Dove = false;
        RewardAd_Watch = false;

        Aid = PlayerPrefs.GetInt("Aid");
        Aid_UI.SetActive(false);
        Owl_Hp_Plus = false;

        cam.depth = 3;

        Disappear.GetComponent<ParticleSystem>().Stop();

        UFO.SetActive(false);
        UFO_Notion.SetActive(false);
        UFO_notion = UFO_Notion.GetComponent<UISprite>();
        UFO_Value = false;
        UFO_Blink = false;
        UFO_Blink_Up = false;

        fever = false;
        Fever = 0;
        Fever1.SetActive(false);
        Fever2.SetActive(false);
        Fever3.SetActive(false);
        Fever4.SetActive(false);

        theme_x1 = false;
        theme_x2 = false;

        Shield.SetActive(false);

        RewardAd = false;
        RewardAd_Object.SetActive(true);

        Language_Setting();
    }

    void OnApplicationPause(bool pause) //앱이 꺼질때
    {
        if (pause)
        {
            if (RewardAd_Watch == false && OptionWindow.activeSelf == false)
            {
                Option2();
            }
        }
        else
        {

        }
    }

    void Start()
    {
        NowScore = 0;
        Plus_Coin = 0;
        Renewal = false;
        Hidden_Time_Check = 0;
        GameOver_Kind = 0;
        GameOver_reason = 0;

        DoveChoice = SystemManager.instance.DoveChoice;

        BD_Coin = SystemManager.instance.BD_Coin;
        BD_Diamond = SystemManager.instance.BD_Diamond;
        BD_Dora_Feather = SystemManager.instance.BD_Dora_Feather;

        BD_Black_AliveTime = PlayerPrefs.GetInt("BD_Black_AliveTime");
        BD_White_AliveTime = PlayerPrefs.GetInt("BD_White_AliveTime");
        BD_Eagle_AliveTime = PlayerPrefs.GetInt("BD_Eagle_AliveTime");
        BD_Dora_AliveTime = PlayerPrefs.GetInt("BD_Dora_AliveTime");

        Advertising_Count = SystemManager.instance.Advertising_Count;
        BD_Diamond_Count = SystemManager.instance.BD_Diamond_Count;
        BD_Diamond_Number = SystemManager.instance.BD_Diamond_Number;

        ScoreCooltime = SystemManager.instance.ScoreCooltime;
        Score_Control = ScoreCooltime * 0.25f;

        Upgrade_Score2 = SystemManager.instance.Upgrade_Score2;
        Upgrade_Coin2 = SystemManager.instance.Upgrade_Coin2;

        Dove_Hp_Down_Speed = SystemManager.instance.Dove_Hp_Down_Speed;
        Dove_Hp_Down_Control = Dove_Hp_Down_Speed * 0.05f;

        //Debug.Log(ScoreCooltime);

        if (DoveChoice == 1)
        {
            HighScore = SystemManager.instance.Black_HighScore;
        }
        else if (DoveChoice == 2)
        {
            HighScore = SystemManager.instance.White_HighScore;
        }
        else if (DoveChoice == 3)
        {
            HighScore = SystemManager.instance.Eagle_HighScore;
        }
        else if (DoveChoice == 4)
        {
            HighScore = SystemManager.instance.Dora_HighScore;
        }


        Rank = PlayerPrefs.GetInt("Rank");

        HighStage = PlayerPrefs.GetInt("HighStage");
        HighTimer = PlayerPrefs.GetInt("HighTimer");

        Default_Hp = SystemManager.instance.Default_Hp;
        Default_Max_Hp = Default_Hp;
        Default_hp = 1 / Default_Hp;

        Upgrade_Coin = SystemManager.instance.Upgrade_Coin;

        Music_OnOff = SystemManager.instance.Music_OnOff;
        SFX_OnOff = SystemManager.instance.SFX_OnOff;
        Vibration_OnOff = SystemManager.instance.Vibration_OnOff;

        EndGameWindow.SetActive(false);
        OptionWindow.SetActive(false);
        GameOverWindow.SetActive(false);
        TalkWindow.SetActive(false);

        Score_Notion.SetActive(false);
        Dove_Notion.SetActive(false);
        Coin_Plus_Notion.SetActive(false);
        Dia_Plus_Notion.SetActive(false);
        Feather_Plus_Notion.SetActive(false);
        Leaf_Notion.SetActive(false);

        Leaf_Value = false;
        Under_Value = false;
        Under_Mole_Value = false;
        Castle_Value = false;

        Under_Time_Value = SystemManager.instance.Under_Time_Value;
        Castle_Time_Value = SystemManager.instance.Castle_Time_Value;

        Enemy_Dove_Create_CoolTime = SystemManager.instance.Enemy_Dove_Create_CoolTime;
        Dove_Control = Enemy_Dove_Create_CoolTime * 0.025f;

        Enemy_Eagle_Create_CoolTime = SystemManager.instance.Enemy_Eagle_Create_CoolTime;
        Eagle_Control = Enemy_Eagle_Create_CoolTime * 0.025f;

        Enemy_Wave_Create_CoolTime = SystemManager.instance.Enemy_Wave_Create_CoolTime;
        Wave_Control = Enemy_Wave_Create_CoolTime * 0.025f;

        Object_Coin_Create_CoolTime = SystemManager.instance.Object_Coin_Create_CoolTime;
        Object_Item_Create_CoolTime = SystemManager.instance.Object_Item_Create_CoolTime;

        Object_Coin_Create_CoolTime_Down = Object_Coin_Create_CoolTime * 0.05f;
        Object_Item_Create_CoolTime_Down = Object_Item_Create_CoolTime * 0.05f;

        Leaf_Time = SystemManager.instance.Leaf_Time;
        Fever_Time = SystemManager.instance.Fever_Time;
        Owl_CoolTime = SystemManager.instance.Owl_CoolTime;

        Owl_Default_Value = SystemManager.instance.Owl_Default_Value;
        Owl_Up_Value = SystemManager.instance.Owl_Up_Value;

        Duck_Default_Value = SystemManager.instance.Duck_Default_Value;
        Duck_Up_Value = SystemManager.instance.Duck_Up_Value;

        BD_Owl_Lv = PlayerPrefs.GetInt("BD_Owl_Lv");
        BD_Duck_Lv = PlayerPrefs.GetInt("BD_Duck_Lv");

        GameSet = false;

        DefaultOption();
        Enemy_Create();

        Black_Index = 0;
        White_Index = 0;
        Eagle_Index = 0;
        Wave_Index = 0;

        Coin_Index = 0;
        Heal_Index = 0;
        Item_Index = 0;
        Mole_Index = 0;

        Restart_Coroutione();
        Create_Check();

        HighScoretxt.text = HighScore.ToString();
        Cointxt.text = "0";
        Diamondtxt.text = "0";
        Feathertxt.text = "0";

        MapCtrl.SetActive(true);
        Coin_Point = GameObject.Find("Coin_Point").GetComponentsInChildren<Transform>();
        Item_Point = GameObject.Find("Item_Point").GetComponentsInChildren<Transform>();

        for (int i = 0; i < Castle_Coin.Count; i++)
        {
            Castle_Coin[i].SetActive(false);
        }


        //난이도 설정
        NowStage = 1;

        Level = PlayerPrefs.GetInt("Level");
        if (Level == 0)
        {
            Level_txt.text = InGame_Level[0];
            Level_txt.color = new Color(0, 1, 0, 1);

            ScoreCooltime += Score_Control;
        }
        else if (Level == 1)
        {
            Level_txt.text = InGame_Level[1];
            Level_txt.color = new Color(0, 1, 1, 1);

            Enemy_Dove_Create_CoolTime = Enemy_Dove_Create_CoolTime - (Enemy_Dove_Create_CoolTime * 0.125f);

            Dove_Hp_Down_Speed = Dove_Hp_Down_Speed - (Dove_Hp_Down_Speed * 0.15f);
        }
        else if (Level == 2)
        {
            Level_txt.text = InGame_Level[2];
            Level_txt.color = new Color(1, 0, 0, 1);

            Enemy_Dove_Create_CoolTime = Enemy_Dove_Create_CoolTime - (Enemy_Dove_Create_CoolTime * 0.25f);
            ScoreCooltime -= Score_Control;
            Dove_Hp_Down_Speed = Dove_Hp_Down_Speed - (Dove_Hp_Down_Speed * 0.3f);

            StartCoroutine(Wait_Ufo());
        }

        Stage_txt.text = InGame_Stage + " " + NowStage.ToString();

        //스킨
        BD_Rainbow_Skin = PlayerPrefs.GetInt("BD_Rainbow_Skin"); //게임매니저 코인 획득에서 직접 적용됩니다.

        if (DoveChoice != 3)
        {
            if (DoveChoice == 1)
            {
                int a = PlayerPrefs.GetInt("Rainbow_Black");
                if (a == 1 && BD_Rainbow_Skin == 1)
                {
                    BD_Rainbow_Skin = 1;
                }
                else
                {
                    BD_Rainbow_Skin = 0;
                }

            }
            else if (DoveChoice == 2)
            {
                int a = PlayerPrefs.GetInt("Rainbow_White");
                if (a == 1 && BD_Rainbow_Skin == 1)
                {
                    BD_Rainbow_Skin = 1;
                }
                else
                {
                    BD_Rainbow_Skin = 0;
                }
            }
            else if (DoveChoice == 4)
            {
                int a = PlayerPrefs.GetInt("Rainbow_Dora");
                if (a == 1 && BD_Rainbow_Skin == 1)
                {
                    BD_Rainbow_Skin = 1;
                }
                else
                {
                    BD_Rainbow_Skin = 0;
                }
            }
        }
        else
        {
            BD_Rainbow_Skin = 0;
        }

        StartCoroutine(Start_Wait(2.0f));

    }

    IEnumerator Start_Wait(float number)
    {
        Start_Value = false;
        yield return new WaitForSeconds(number);
        Start_Value = true;
    }

    void Language_Setting()
    {
        int a = PlayerPrefs.GetInt("Language");
        switch (a)
        {
            case 1:
                for (int i = 0; i < LanguageManager.instance.Book_Dead_Korean.Length; i++)
                {
                    string b = LanguageManager.instance.Book_Dead_Korean[i];
                    GameOver_Reason.Add(b);
                }
                InGame_Best_txt = LanguageManager.instance.InGame_Best_Korean;
                InGame_Level = LanguageManager.instance.InGame_Level_Korean;
                InGame_Stage = LanguageManager.instance.InGame_Stage_Korean;
                InGame_Notion = LanguageManager.instance.InGame_Notion_Korean;
                InGame_On = LanguageManager.instance.InGame_Korean_On;
                InGame_Count = LanguageManager.instance.InGame_Count_Korean;
                UFO_txt.text = LanguageManager.instance.InGame_UFO_Korean;
                break;
            case 2:
                for (int i = 0; i < LanguageManager.instance.Book_Dead_English.Length; i++)
                {
                    string b = LanguageManager.instance.Book_Dead_English[i];
                    GameOver_Reason.Add(b);
                }
                InGame_Best_txt = LanguageManager.instance.InGame_Best_English;
                InGame_Level = LanguageManager.instance.InGame_Level_English;
                InGame_Stage = LanguageManager.instance.InGame_Stage_English;
                InGame_Notion = LanguageManager.instance.InGame_Notion_English;
                InGame_On = LanguageManager.instance.InGame_English_On;
                InGame_Count = LanguageManager.instance.InGame_Count_English;
                UFO_txt.text = LanguageManager.instance.InGame_UFO_English;
                break;
            case 3:
                for (int i = 0; i < LanguageManager.instance.Book_Dead_Chinese.Length; i++)
                {
                    string b = LanguageManager.instance.Book_Dead_Chinese[i];
                    GameOver_Reason.Add(b);
                }
                InGame_Best_txt = LanguageManager.instance.InGame_Best_Chinese;
                InGame_Level = LanguageManager.instance.InGame_Level_Chinese;
                InGame_Stage = LanguageManager.instance.InGame_Stage_Chinese;
                InGame_Notion = LanguageManager.instance.InGame_Notion_Chinese;
                InGame_On = LanguageManager.instance.InGame_Chinese_On;
                InGame_Count = LanguageManager.instance.InGame_Count_Chinese;
                UFO_txt.text = LanguageManager.instance.InGame_UFO_Chinese;
                break;
            case 4:
                for (int i = 0; i < LanguageManager.instance.Book_Dead_Japanese.Length; i++)
                {
                    string b = LanguageManager.instance.Book_Dead_Japanese[i];
                    GameOver_Reason.Add(b);
                }
                InGame_Best_txt = LanguageManager.instance.InGame_Best_Japanese;
                InGame_Level = LanguageManager.instance.InGame_Level_Japanese;
                InGame_Stage = LanguageManager.instance.InGame_Stage_Japanese;
                InGame_Notion = LanguageManager.instance.InGame_Notion_Japanese;
                InGame_On = LanguageManager.instance.InGame_Japanese_On;
                InGame_Count = LanguageManager.instance.InGame_Count_Japanese;
                UFO_txt.text = LanguageManager.instance.InGame_UFO_Japanese;
                break;
        }


        Best_Score.GetComponent<UILabel>().text = InGame_Best_txt;
        Best_Stage.GetComponent<UILabel>().text = InGame_Best_txt;
        Best_Time.GetComponent<UILabel>().text = InGame_Best_txt;

        Best_Score.SetActive(false);
        Best_Stage.SetActive(false);
        Best_Time.SetActive(false);
    }

    void Restart_Coroutione()
    {
        StartCoroutine(TimeCheck());
        StartCoroutine(GameScore());
        StartCoroutine(Hp_Down(1));
        StartCoroutine(Fever_Up());
        StartCoroutine(Renewal_Notion());

        if (Under_Value == true)
        {
            StartCoroutine(Object_Create_Mole_Stone());
        }
    }

    IEnumerator Wait_Ufo()
    {
        yield return new WaitForSeconds(2f);
        Ufo_Coming();
    }

    public void Ufo_Coming()
    {
        if(UFO_Value == false)
        {
            UFO_Value = true;
            UFO.SetActive(true);
            UFO_Blink = true;
            UFO_Notion.SetActive(true);
            EffectManager.instance.Warning_On();
            StartCoroutine(Notion_Cooltime(5.4f));

            UFO_Alpha = 0;
            UFO_notion.color = new Color(1, 1, 1, 0);
            UFO_Blink_Up = true;
            StartCoroutine(Notion_Blink());
        }
    }

    IEnumerator Notion_Blink()
    {
        if(UFO_Blink == true)
        {
            if (UFO_Blink_Up == true)
            {
                if (UFO_Alpha >= 0)
                {
                    UFO_Alpha -= (255 / 50);
                }
                else
                {
                    UFO_Blink_Up = false;
                }
            }
            else
            {
                if (UFO_Alpha <= 255)
                {
                    UFO_Alpha += (255 / 50);
                }
                else
                {
                    UFO_Blink_Up = true;
                }
            }

            UFO_notion.color = new Color(1, 1, 1, UFO_Alpha / 255f);
        }
        else
        {
            yield break;
        }
        yield return new WaitForSeconds(0.01f);
        StartCoroutine(Notion_Blink());
    }

    IEnumerator Notion_Cooltime(float number)
    {
        yield return new WaitForSeconds(number);
        UFO_Blink = false;
        UFO_Notion.SetActive(false);
        EffectManager.instance.Warning_Off();
    }


    //적 생성

    void Enemy_Create() //프리팹 미리생성
    {
        if (DoveChoice == 1)
        {
            for (int i = 0; i < 20; i++)
            {
                GameObject a = Instantiate(Dove_White);
                a.name = "Enemy_White_" + i.ToString();
                a.SetActive(false);
                Enemy_White.Add(a);
            }
        }
        else if (DoveChoice == 2)
        {
            for (int i = 0; i < 20; i++)
            {
                GameObject a = Instantiate(Dove_Black);
                a.name = "Enemy_Black_" + i.ToString();
                a.SetActive(false);
                Enemy_Black.Add(a);
            }
        }
        else if (DoveChoice == 3 || DoveChoice == 4)
        {
            for (int i = 0; i < 20; i++)
            {
                GameObject a = Instantiate(Dove_Black);
                a.name = "Enemy_Black_" + i.ToString();
                a.SetActive(false);
                Enemy_Black.Add(a);

                GameObject b = Instantiate(Dove_White);
                b.name = "Enemy_White_" + i.ToString();
                b.SetActive(false);
                Enemy_Black.Add(b);
            }
        }

        if (DoveChoice != 3)
        {
            for (int i = 0; i < 5; i++)
            {
                GameObject a = Instantiate(Dove_Eagle);
                a.name = "Enemy_Eagle_" + i.ToString();
                a.SetActive(false);
                Enemy_Eagle.Add(a);
            }
        }

        for(int i =0; i< 6; i++) //힐
        {
            GameObject a = Instantiate(Plus_Heal) as GameObject;
            a.name = "Heal_" + i.ToString();
            a.transform.parent = GameObject.Find("UI Root").transform;
            a.SetActive(false);
            Object_Heal.Add(a);
        }

        for (int i = 0; i < 300; i++) //코인
        {
            GameObject a = Instantiate(Coin);
            a.name = "Coin_" + i.ToString();
            a.SetActive(false);
            Object_Coin.Add(a);
        }

        for (int i = 0; i < 10; i++) //아이템
        {
            GameObject a = Instantiate(Item);
            a.name = "Item_" + i.ToString();
            a.SetActive(false);
            Object_Item.Add(a);
        }

        for (int i = 0; i < 10; i++) //파도
        {
            GameObject a = Instantiate(Wave);
            a.name = "Wave_" + i.ToString();
            a.SetActive(false);
            Enemy_Wave.Add(a);
        }

        for (int i = 0; i < 10; i++) //지하세계 두더지
        {
            GameObject a = Instantiate(Mole_Stone);
            a.name = "Mole_Stone_" + i.ToString();
            a.SetActive(false);
            Object_Mole_Stone.Add(a);
        }

    }
    void Create_Check()
    {
        if(DoveChoice == 1)
        {
            StartCoroutine(Enemy_Create_White());
            StartCoroutine(Enemy_Create_Eagle());
        }
        else if(DoveChoice == 2)
        {
            StartCoroutine(Enemy_Create_Black());
            StartCoroutine(Enemy_Create_Eagle());
        }
        else if(DoveChoice == 3)
        {
            StartCoroutine(Enemy_Create_Black());
        }
        else if(DoveChoice == 4)
        {
            StartCoroutine(Enemy_Create_Black());
            StartCoroutine(Enemy_Create_Eagle());
        }

        StartCoroutine(Object_Create_Coin());
        StartCoroutine(Object_Create_Item());
    }
    IEnumerator Enemy_Create_Black()
    {
        yield return new WaitForSeconds(Enemy_Dove_Create_CoolTime);
        if (GameSet == false)
        {
            if (Talk_Value == false && Under_Value == false && Castle_Value == false)
            {
                if (Black_Index > Enemy_Black.Count - 1)
                {
                    Black_Index = 0;
                }
                GameObject monster = Enemy_Black[Black_Index];
                if (!monster.activeSelf)
                {
                    int idx = UnityEngine.Random.Range(1, Dove_Point.Length);

                    monster.transform.position = Dove_Point[idx].position;
                    monster.SetActive(true);

                    Black_Index += 1;
                    Enemy_Reset.Add(monster);
                }
            }
        }
        else
        {
            yield break;
        }
        StartCoroutine(Enemy_Create_Black());
    }
    IEnumerator Enemy_Create_White()
    {
        yield return new WaitForSeconds(Enemy_Dove_Create_CoolTime);
        if (GameSet == false)
        {
            if (Talk_Value == false && Under_Value == false && Castle_Value == false)
            {
                if (White_Index > Enemy_White.Count - 1)
                {
                    White_Index = 0;
                }
                GameObject monster = Enemy_White[White_Index];
                if (!monster.activeSelf)
                {
                    int idx = UnityEngine.Random.Range(1, Dove_Point.Length);

                    monster.transform.position = Dove_Point[idx].position;
                    monster.SetActive(true);

                    White_Index += 1;
                    Enemy_Reset.Add(monster);
                }
            }
        }
        else
        {
            yield break;
        }
        StartCoroutine(Enemy_Create_White());
    }
    IEnumerator Enemy_Create_Eagle()
    {
        yield return new WaitForSeconds(Enemy_Eagle_Create_CoolTime);
        if (GameSet == false)
        {
            if (Talk_Value == false && Under_Value == false && Castle_Value == false)
            {
                if (Eagle_Index > Enemy_Eagle.Count - 1)
                {
                    Eagle_Index = 0;
                }
                GameObject monster = Enemy_Eagle[Eagle_Index];
                if (!monster.activeSelf)
                {
                    int idx = UnityEngine.Random.Range(1, Eagle_Point.Length);

                    monster.transform.position = Eagle_Point[idx].position;
                    monster.SetActive(true);

                    Eagle_Index += 1;
                    Enemy_Reset.Add(monster);
                }
            }
        }
        else
        {
            yield break;
        }
        StartCoroutine(Enemy_Create_Eagle());
    }

    IEnumerator Enemy_Create_Wave()
    {
        if (Wave_Value == true)
        {
            if (Talk_Value == false && Under_Value == false && Castle_Value == false)
            {
                if (Wave_Index > Enemy_Wave.Count - 1)
                {
                    Wave_Index = 0;
                }
                GameObject monster = Enemy_Wave[Wave_Index];
                if (!monster.activeSelf)
                {
                    int idx = UnityEngine.Random.Range(1, Dove_Point.Length);

                    monster.transform.position = Dove_Point[idx].position;
                    monster.SetActive(true);

                    Wave_Index += 1;
                }
            }
        }
        else
        {
            yield break;
        }
        yield return new WaitForSeconds(Enemy_Wave_Create_CoolTime);
        StartCoroutine(Enemy_Create_Wave());
    }

    public void Wave_Start()
    {
        Wave_Value = true;
        StartCoroutine(instance.Enemy_Create_Wave());
    }
    public void Wave_End()
    {
        Wave_Value = false;
    }
    IEnumerator Object_Create_Coin()
    {
        yield return new WaitForSeconds(Object_Coin_Create_CoolTime);
        if (GameSet == false)
        {
            if (Talk_Value == false && Under_Value == false && Castle_Value == false)
            {
                GameObject monster = Object_Coin[Coin_Index];
                Coin_Index += 1;
                if (Coin_Index > Object_Coin.Count - 1)
                {
                    Coin_Index = 0;
                }

                GameObject monster2 = Object_Coin[Coin_Index];
                Coin_Index += 1;
                if (Coin_Index > Object_Coin.Count - 1)
                {
                    Coin_Index = 0;
                }

                if (!monster.activeSelf)
                {
                    int idx = UnityEngine.Random.Range(1, Coin_Point.Length / 2 + 1);
                    float x = UnityEngine.Random.Range(0, 0.2f);
                    float y = UnityEngine.Random.Range(0, 0.2f);
                    Vector3 a = new Vector2(x, y);

                    monster.transform.parent = Default_Map.transform;
                    monster.transform.position = Coin_Point[idx].position + a + new Vector3(0, 0, 4);
                    monster.SetActive(true);
                }
                if (!monster2.activeSelf)
                {
                    int idx = UnityEngine.Random.Range(Coin_Point.Length / 2, Coin_Point.Length);
                    float x = UnityEngine.Random.Range(0, 0.2f);
                    float y = UnityEngine.Random.Range(0, 0.2f);
                    Vector3 a = new Vector2(x, y);

                    monster2.transform.parent = Default_Map.transform;
                    monster2.transform.position = Coin_Point[idx].position + a + new Vector3(0, 0, 4);
                    monster2.SetActive(true);
                }
            }
        }
        else
        {
            yield break;
        }
        StartCoroutine(Object_Create_Coin());
    }

    public void Object_Create_Coin2() //빌딩에 생성됬을 경우 다시 생성합니다.
    {
        GameObject monster = Object_Coin[Coin_Index];
        Coin_Index += 1;
        if (Coin_Index > Object_Coin.Count - 1)
        {
            Coin_Index = 0;
        }

        if (!monster.activeSelf)
        {
            int idx = UnityEngine.Random.Range(1, Coin_Point.Length);
            float x = UnityEngine.Random.Range(0, 0.2f);
            float y = UnityEngine.Random.Range(0, 0.2f);
            Vector3 a = new Vector2(x, y);

            monster.transform.parent = Default_Map.transform;
            monster.transform.position = Coin_Point[idx].position + a + new Vector3(0, 0, 4);
            monster.SetActive(true);
        }
    }
    IEnumerator Object_Create_Item()
    {
        yield return new WaitForSeconds(Object_Item_Create_CoolTime);
        if (GameSet == false)
        {
            if (Talk_Value == false && Under_Value == false && Castle_Value == false)
            {
                GameObject monster = Object_Item[Item_Index];
                Item_Index += 1;
                if (Item_Index > Object_Item.Count - 1)
                {
                    Item_Index = 0;
                }

                GameObject monster2 = Object_Item[Item_Index];
                Item_Index += 1;
                if (Item_Index > Object_Item.Count - 1)
                {
                    Item_Index = 0;
                }

                if (!monster.activeSelf)
                {
                    int idx = UnityEngine.Random.Range(1, Item_Point.Length / 2 + 1);
                    float x = UnityEngine.Random.Range(0, 0.2f);
                    float y = UnityEngine.Random.Range(0, 0.2f);
                    Vector3 a = new Vector2(x, y);

                    monster.transform.parent = Default_Map.transform;
                    monster.transform.position = Item_Point[idx].position + a + new Vector3(0, 0, 4);
                    monster.SetActive(true);
                }
                if (!monster2.activeSelf)
                {
                    int idx = UnityEngine.Random.Range(Item_Point.Length / 2, Item_Point.Length);
                    float x = UnityEngine.Random.Range(0, 0.2f);
                    float y = UnityEngine.Random.Range(0, 0.2f);
                    Vector3 a = new Vector2(x, y);

                    monster2.transform.parent = Default_Map.transform;
                    monster2.transform.position = Item_Point[idx].position + a + new Vector3(0, 0, 4);
                    monster2.SetActive(true);
                }
            }
        }
        else
        {
            yield break;
        }
        StartCoroutine(Object_Create_Item());
    }

    public void Object_Create_Item2()
    {
        GameObject monster = Object_Item[Item_Index];
        Item_Index += 1;
        if (Item_Index > Object_Item.Count - 1)
        {
            Item_Index = 0;
        }
        if (!monster.activeSelf)
        {
            int idx = UnityEngine.Random.Range(1, Item_Point.Length);
            float x = UnityEngine.Random.Range(0, 0.2f);
            float y = UnityEngine.Random.Range(0, 0.2f);
            Vector3 a = new Vector2(x, y);

            monster.transform.parent = Default_Map.transform;
            monster.transform.position = Item_Point[idx].position + a + new Vector3(0, 0, 4);
            monster.SetActive(true);
        }
    }

    IEnumerator Object_Create_Mole_Stone()
    {
        yield return new WaitForSeconds(Enemy_Dove_Create_CoolTime);
        if (Under_Value == true && Under_Mole_Value == true)
        {
            if (Mole_Index > Object_Mole_Stone.Count - 1)
            {
                Mole_Index = 0;
            }
            GameObject monster = Object_Mole_Stone[Mole_Index];

            if (!monster.activeSelf)
            {
                int idx = UnityEngine.Random.Range(1, Dove_Point.Length);
                Vector3 a = new Vector3(0, 0, 4);

                monster.transform.position = Dove_Point[idx].position + a;
                monster.SetActive(true);
                Enemy_Reset.Add(monster);

                Mole_Index += 1;
            }
        }
        else
        {
            yield break;
        }
        StartCoroutine(Object_Create_Mole_Stone());
    }

    IEnumerator Object_Create_Heal()
    {
        Heal_Index = 0;
        foreach (GameObject heal in Object_Heal)
        {
            if (!heal.activeSelf)
            {
                float randomX;
                float randomY;

                float c = DoveCtrl.instance.transform.localScale.x * 7.7f;

                if (Heal_Index == 0)
                {
                    Heal_Index = 1;
                    randomX = UnityEngine.Random.Range(Dove_Plus_Which.localPosition.x, Dove_Plus_Which.localPosition.x - (70f * c));
                }
                else
                {
                    Heal_Index = 0;
                    randomX = UnityEngine.Random.Range(Dove_Plus_Which.localPosition.x, Dove_Plus_Which.localPosition.x + (70f * c));
                }

                Vector3 a = Dove_Plus_Which.localPosition + new Vector3(0, 20 * c, 0);
                Vector3 b = Dove_Plus_Which.localPosition + new Vector3(0, -20 * c, 0);

                randomY = UnityEngine.Random.Range(a.y, b.y);

                Notion d = heal.GetComponent<Notion>();
                d.plus_scale = c;

                heal.transform.localPosition = new Vector3(randomX, randomY, 0);
                heal.SetActive(true);
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
    public void Object_Create_Hidden_Coin(Vector3 Point,int number)
    {
        if (Coin_Index > Object_Coin.Count - 1)
        {
            Coin_Index = 0;
        }
        GameObject monster = Object_Coin[Coin_Index];

        if (!monster.activeSelf)
        {
            if(number == 1)
            {
                monster.transform.parent = Under_Map.transform;
                monster.transform.localPosition = Point;
                monster.SetActive(true);
            }
            else
            {
                monster.transform.parent = Castle_Map.transform;
                monster.transform.localPosition = Point;
                monster.SetActive(true);
                Castle_Coin.Add(monster);
            }
        }

        Coin_Index += 1;
    }

    IEnumerator Fever_Create_Coin()
    {
        yield return new WaitForSeconds(1f);
        if (GameSet == false && fever == true)
        {
            if (Talk_Value == false && Under_Value == false && Castle_Value == false)
            {
                Coin_Plus(20);
            }
        }
        else
        {
            yield break;
        }
        StartCoroutine(Fever_Create_Coin());
    }

    //스킬
    public void Skill_In()
    {
        Skill_Use = true;
    }
    public void Skill_Out()
    {
        Skill_Use = false;
    }

    //아이템
    
    public void Hacktool_In() //해킹툴
    {
        Hacktool = true;
    }
    public void Hacktool_Out()
    {
        Hacktool = false;
    }



    //옵션
    public void GameOver() //게임 나가기
    {
        SystemManager.instance.ThreeGo();
        Time.timeScale = 1.0f;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
    }

    //개발자 옵션

    public void Creadtive_Mode_On()
    {
        if(Creadtive_Mode.activeSelf == false)
        {
            Creadtive_Mode.SetActive(true);
        }
        else
        {
            Creadtive_Mode.SetActive(false);
        }
    }
    public void Immortal() //비둘기 무적
    {
        if(Immortal_Dove == false)
        {
            DoveCtrl.instance.box.enabled = false;
            Immortal_Dove = true;
        }
        else
        {
            DoveCtrl.instance.box.enabled = true;
            Immortal_Dove = false;
        }
    }

    public void Clear()
    {
        PlayerPrefs.SetInt("HighScore", 0);
        PlayerPrefs.SetInt("HighStage", 0);
        PlayerPrefs.SetInt("HighTimer", 0);
    }
    public void Hp0()
    {
        Dove_Die();
    }
    public void Hp30()
    {
        Default_Hp = 30;
    }
    public void Damage_Dove()
    {
        Hp_Minus_Kind(0);
        Hp_Minus(10);
    } 
    public void Damage_Eagle()
    {
        Hp_Minus_Kind(0);
        Hp_Minus(25);
    }
    public void Heal()
    {
        Hp_Plus(10);
    }
    public void PointUp()
    {
        Score_Plus(10);
    }
    public void CoinUp()
    {
        Coin_Plus(20);
    }
    public void DiaUp()
    {
        Diamond_Plus(1);
    }
    public void FeatherUp()
    {
        Dora_Feather_Plus(1);
    }
    public void AliveUp()
    {
        NowTimer += 10;
    }

    //나무가지
    public void LeafUp()
    {
        Olive_Start(Leaf_Time);
    }

    //피버모드
    public void FeverUp()
    {
        Fever = 200;
    }

    //히든 맵

    public void UnderUp()
    {
        try
        {
            Talk_End();

            //업적 - 히든 스테이지 입장
            int a = PlayerPrefs.GetInt("Achieve_Hidden");
            a += 1;
            PlayerPrefs.SetInt("Achieve_Hidden", a);

            for (int i = 0; i < Enemy_Reset.Count; i++)
            {
                Enemy_Reset[i].SetActive(false);
            }
            Enemy_Reset.Clear();

            Under_Value = true;
            Under_Mole_Value = true;
            Hidden_Time_Check = 0;

            Fade.instance.Under_In();
            EffectManager.instance.Hidden_In();
            GameManager2.instance.Hidden_In(1);

            UFO.SetActive(false);

            StartCoroutine(Under_Time());

            Under_In();
        }
        catch (NullReferenceException ie)
        {
            print(ie.Message);

            Talk_End();
            //업적 - 히든 스테이지 입장
            int a = PlayerPrefs.GetInt("Achieve_Hidden");
            a += 1;
            PlayerPrefs.SetInt("Achieve_Hidden", a);

            for (int i = 0; i < Enemy_Reset.Count; i++)
            {
                Enemy_Reset[i].SetActive(false);
            }
            Enemy_Reset.Clear();

            Under_Value = true;
            Under_Mole_Value = true;
            Hidden_Time_Check = 0;

            Fade.instance.Under_In();
            EffectManager.instance.Hidden_In();
            GameManager2.instance.Hidden_In(1);

            UFO.SetActive(false);

            StartCoroutine(Under_Time());

            Under_In();
        }
    }
    public void CastleUp()
    {
        try
        {
            //업적 - 히든 스테이지 입장
            int a = PlayerPrefs.GetInt("Achieve_Hidden");
            a += 1;
            PlayerPrefs.SetInt("Achieve_Hidden", a);

            for (int i = 0; i < Enemy_Reset.Count; i++)
            {
                Enemy_Reset[i].SetActive(false);
            }
            Enemy_Reset.Clear();

            Castle_Value = true;
            Hidden_Time_Check = 0;

            Fade.instance.Castle_In();
            EffectManager.instance.Hidden_In();
            GameManager2.instance.Hidden_In(2);

            Talk_End();
            UFO.SetActive(false);

            StartCoroutine(Castle_Time());

            Castle_In();
        }
        catch (NullReferenceException ie)
        {
            print(ie.Message);

            //업적 - 히든 스테이지 입장
            int a = PlayerPrefs.GetInt("Achieve_Hidden");
            a += 1;
            PlayerPrefs.SetInt("Achieve_Hidden", a);

            for (int i = 0; i < Enemy_Reset.Count; i++)
            {
                Enemy_Reset[i].SetActive(false);
            }
            Enemy_Reset.Clear();

            Castle_Value = true;
            Hidden_Time_Check = 0;

            Fade.instance.Castle_In();
            EffectManager.instance.Hidden_In();
            GameManager2.instance.Hidden_In(2);

            Talk_End();
            UFO.SetActive(false);

            StartCoroutine(Castle_Time());

            Castle_In();
        }
    }

    IEnumerator Under_Time()
    {
        if (Hidden_Time_Check > Under_Time_Value)
        {
            Under_End();
            EffectManager.instance.Hidden_Out();
            yield break;
        }
        else if(Hidden_Time_Check == 3)
        {
            source.Stop();
            source.clip = under;
            source.Play();
            yield return new WaitForSeconds(1f);
            Hidden_Time_Check += 1;
            //Debug.Log(Hidden_Time_Check);
            StartCoroutine(Under_Time());
            LanguageManager.instance.Under_In_Notion();
            StartCoroutine(Object_Create_Mole_Stone());
        }
        else
        {
            yield return new WaitForSeconds(1f);
            Hidden_Time_Check += 1;
            //Debug.Log(Hidden_Time_Check);
            StartCoroutine(Under_Time());
        }
    }
    IEnumerator Castle_Time()
    {
        if(Hidden_Time_Check > Castle_Time_Value)
        {
            Castle_End();
            EffectManager.instance.Hidden_Out();
            yield break;
        }
        else if (Hidden_Time_Check == 3)
        {
            source.Stop();
            source.clip = castle;
            source.Play();
            yield return new WaitForSeconds(1f);
            Hidden_Time_Check += 1;
            //Debug.Log(Hidden_Time_Check);
            LanguageManager.instance.Castle_In_Notion();
            StartCoroutine(Castle_Time());
        }
        else
        {
            yield return new WaitForSeconds(1f);
            Hidden_Time_Check += 1;
            //Debug.Log(Hidden_Time_Check);
            StartCoroutine(Castle_Time());
        }
    }

    public void Under_End()
    {
        try
        {
            Under_Mole_Value = false;
            for (int i = 0; i < Enemy_Reset.Count; i++)
            {
                Enemy_Reset[i].SetActive(false);
            }
            Enemy_Reset.Clear();

            Fade.instance.Under_Out();
            GameManager2.instance.Hidden_Out();

            StartCoroutine(Hidden_World_Wait());

            Under_Out();
        }
        catch (NullReferenceException ie)
        {
            print(ie.Message);

            Under_Mole_Value = false;
            for (int i = 0; i < Enemy_Reset.Count; i++)
            {
                Enemy_Reset[i].SetActive(false);
            }
            Enemy_Reset.Clear();

            Fade.instance.Under_Out();
            GameManager2.instance.Hidden_Out();

            StartCoroutine(Hidden_World_Wait());

            Under_Out();
        }
    }
    public void Castle_End()
    {
        try
        {
            Fade.instance.Castle_Out();
            GameManager2.instance.Hidden_Out();

            for (int i = 0; i < Castle_Coin.Count; i++)
            {
                Castle_Coin[i].SetActive(false);
            }

            StartCoroutine(Hidden_World_Wait());

            Castle_Out();
        }
        catch (NullReferenceException ie)
        {
            print(ie.Message);

            Fade.instance.Castle_Out();
            GameManager2.instance.Hidden_Out();

            for (int i = 0; i < Castle_Coin.Count; i++)
            {
                Castle_Coin[i].SetActive(false);
            }

            StartCoroutine(Hidden_World_Wait());

            Castle_Out();
        }
    }

    IEnumerator Hidden_World_Wait()
    {
        yield return new WaitForSeconds(3f);

        source.Stop();
        if (theme_x2 == true)
        {
            source.clip = main_theme_x2;
        }
        else if(theme_x1 == true)
        {
            source.clip = main_theme_x1;
        }
        else
        {
            source.clip = main_theme;
        }
        source.Play();
        Under_Value = false;
        Castle_Value = false;

        if (UFO_Value == true)
        {
            UFO.SetActive(true);
        }
    }



    public void DisappearUp(Vector3 Point)
    {
        Disappear.transform.localPosition = Point;
        Disappear.GetComponent<ParticleSystem>().Play();
    }

    public void Option() //옵션
    {
        if(DoveCtrl.instance.box.enabled == true)
        {
            OptionWindow.SetActive(true);
            Time.timeScale = 0.0f;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
            EffectManager.instance.Option();
        }
    }
    public void Option2()
    {
        OptionWindow.SetActive(true);
        Time.timeScale = 0.0f;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
        EffectManager.instance.Option();
    }
    public void Continue() //옵션창에서 계속하기
    {
        Time.timeScale = 1.0f;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
        EffectManager.instance.Continue();

        if(Time.timeScale == 1)
        {
            OptionWindow.SetActive(false);
        }
    }
    public void DefaultOption()
    {
        if (Music_OnOff == 0)
        {
            Music_OnOff = 0;
            Music_sprite.color = new Color(1f, 0f, 0f, 1f);
            Music_txt.text = InGame_On[1];
            source.enabled = false;
        }
        else
        {
            Music_OnOff = 1;
            Music_sprite.color = new Color(0f, 1f, 0f, 1f);
            Music_txt.text = InGame_On[0];
            source.enabled = true;
        }

        if (SFX_OnOff == 0)
        {
            SFX_OnOff = 0;
            SFX_sprite.color = new Color(1f, 0f, 0f, 1f);
            SFX_txt.text = InGame_On[1];

        }
        else
        {
            SFX_OnOff = 1;
            SFX_sprite.color = new Color(0f, 1f, 0f, 1f);
            SFX_txt.text = InGame_On[0];
        }

        if (Vibration_OnOff == 0)
        {
            Vibration_OnOff = 0;
            Vibration_sprite.color = new Color(1f, 0f, 0f, 1f);
            Vibration_txt.text = InGame_On[1];
            Vibration = false;
        }
        else
        {
            Vibration_OnOff = 1;
            Vibration_sprite.color = new Color(0f, 1f, 0f, 1f);
            Vibration_txt.text = InGame_On[0];
            Vibration = true;
        }

    } //시작시 저장된 값으로 초기화

    public void MusicOnOff() //음악
    {
        if (Music_OnOff == 0)
        {
            Music_OnOff = 1;
            Music_sprite.color = new Color(0f, 1f, 0f, 1f);
            Music_txt.text = InGame_On[0];
            source.enabled = true;
        }
        else
        {
            Music_OnOff = 0;
            Music_sprite.color = new Color(1f, 0f, 0f, 1f);
            Music_txt.text = InGame_On[1];
            source.enabled = false;
        }
        PlayerPrefs.SetInt("Music_Onoff", Music_OnOff);
    }
    public void SFXOnOff() //효과음
    {
        if (SFX_OnOff == 0)
        {
            SFX_OnOff = 1;
            SFX_sprite.color = new Color(0f, 1f, 0f, 1f);
            SFX_txt.text = InGame_On[0];
            EffectManager.instance.SFX_On();
        }
        else
        {
            SFX_OnOff = 0;
            SFX_sprite.color = new Color(1f, 0f, 0f, 1f);
            SFX_txt.text = InGame_On[1];
            EffectManager.instance.SFX_Off();
        }
        PlayerPrefs.SetInt("SFX_Onoff", SFX_OnOff);
    }
    public void VibrationOnOff() //진동
    {
        if (Vibration_OnOff == 0)
        {
            Vibration_OnOff = 1;
            Vibration_sprite.color = new Color(0f, 1f, 0f, 1f);
            Vibration_txt.text = InGame_On[0];
            Vibration = true;
        }
        else
        {
            Vibration_OnOff = 0;
            Vibration_sprite.color = new Color(1f, 0f, 0f, 1f);
            Vibration_txt.text = InGame_On[1];
            Vibration = false;
        }
        PlayerPrefs.SetInt("Vibration_Onoff", Vibration_OnOff);
    }




    //얻는 것
    public void Hp_Plus(int number)
    {
        if (GameSet == false && Start_Value == true)
        {
            //업적 - 체력 회복
            int a = PlayerPrefs.GetInt("Achieve_Hp");
            a += Mathf.RoundToInt(number);
            PlayerPrefs.SetInt("Achieve_Hp", a);

            if (Default_Hp + Mathf.RoundToInt(number) >= Default_Max_Hp)
            {
                Default_Hp = Default_Max_Hp;
                Hp_txt.text = (Mathf.RoundToInt(Default_Hp).ToString()) + "/" + Default_Max_Hp.ToString();
                Hp_Filter.fillAmount = Default_Hp * Default_hp;
            }
            else
            {
                Default_Hp += Mathf.RoundToInt(number);
                Hp_txt.text = (Mathf.RoundToInt(Default_Hp).ToString()) + "/" + Default_Max_Hp.ToString();
                Hp_Filter.fillAmount = Default_Hp * Default_hp;
                Hp_Check();
            }

            if (Under_Value == false)
            {
                Fever += 2;
                Fever_Fillter.fillAmount = Fever / 200.0f;
                Fever_txt.text = Fever.ToString() + "%";
            }

            StartCoroutine(Object_Create_Heal());

            Dove_Notion.SetActive(false);

            Dove_Notion_txt.text = InGame_Notion[0] +" + "+ Mathf.RoundToInt(number).ToString();
            Dove_Notion_txt.color = new Color(1, 0, 0, 1);

            Dove_Notion.transform.localPosition = Dove_Hp_Which.localPosition;
            Dove_Notion.SetActive(true);

            EffectManager.instance.Hp_Plus();
        }
    }

    //조력자

    public void Aid_Owl_Hp_Plus_On()
    {
        if (Owl_Hp_Plus == false)
        {
            Owl_Hp_Plus = true;
            Owl_Hp = Owl_Default_Value + (BD_Owl_Lv * Owl_Up_Value);

            Aid_UI.SetActive(true);
            Aid_Main_sp.spriteName = "Owl_UI";

            Aid_Fillter.fillAmount = 0;
            StartCoroutine(Aid_CoolTime(Aid_Fillter));
        }
    }

    public void Aid_Owl_Hp_Plus_Off()
    {
        Owl_Hp_Plus = false;
        Aid_UI.SetActive(false);
    }

    public void Aid_Duck_Shield_On()
    {
        DoveCtrl.instance.Aid_Duck_Shield_On();
        Aid_UI.SetActive(false);
    }
    public void Aid_Duck_Shield_Off()
    {
        DoveCtrl.instance.Aid_Duck_Shield_Off();

        Duck_CoolTime = Duck_Default_Value - (BD_Duck_Lv * Duck_Up_Value);

        Aid_UI.SetActive(true);
        Aid_Main_sp.spriteName = "Duck_UI";
        Aid_Fillter.fillAmount = 0;
        StartCoroutine(Aid_CoolTime(Aid_Fillter));

#if UNITY_ANDROID || UNITY_IPHONE
        Shield.transform.localPosition = new Vector3(Dove_Which.x * 1, Dove_Which.y, Dove_Plus_Which.localPosition.z) + new Vector3(0f, -400f, 0); //쉴드
#endif

#if UNITY_EDITOR
        Shield.transform.localPosition = new Vector3(Dove_Which.x * 2.13f, Dove_Which.y, Dove_Plus_Which.localPosition.z) + new Vector3(0f, -400f, 0); //쉴드
#endif
        Shield.SetActive(true);
        EffectManager.instance.Shield();
    }


    IEnumerator Aid_CoolTime(UISprite Filter)
    {
        while (Filter.fillAmount < 1)
        {
            if (Aid == 1)
            {
                if(Owl_Hp_Plus == true)
                {
                    if(GameManager2.instance.Weather_Value == 1 &&Talk_Value == false)
                    {
                        Filter.fillAmount += 1 * Time.smoothDeltaTime / Owl_CoolTime;
                    }
                    else
                    {
                        Filter.fillAmount += 0 * Time.smoothDeltaTime / Owl_CoolTime;
                    }
                }
                else
                {
                    yield break;
                }
            }
            else if (Aid == 2)
            {
                if (Talk_Value == false)
                {
                    Filter.fillAmount += 1 * Time.smoothDeltaTime / Duck_CoolTime;
                }
                else
                {
                    Filter.fillAmount += 0 * Time.smoothDeltaTime / Duck_CoolTime;
                }
            }
            yield return null;
        }

        if (Aid == 1)
        {
            if(Owl_Hp_Plus == true)
            {
                Filter.fillAmount = 0;
                Hp_Plus(Owl_Hp);
                StartCoroutine(Aid_CoolTime(Aid_Fillter));
            }
        }
        else if (Aid == 2)
        {
            Aid_Duck_Shield_On();
        }
    }

    public void Hp_Minus_Kind(int number)
    {
        GameOver_Kind = number;
    }

    public void Hp_Minus(float number)
    {
        if(Level == 0)
        {
            //Hp_Minus_Control = number * 0.25f;
            //number -= Hp_Minus_Control;
        }
        else if(Level == 1)
        {

        }
        else if(Level == 2)
        {
            Hp_Minus_Control = number * 0.25f;

            number += Hp_Minus_Control;
        }

        if (GameSet == false && fever == false && Start_Value == true)
        {
            //업적 - 받은 데미지
            int a = PlayerPrefs.GetInt("Achieve_Damage");
            a += Mathf.RoundToInt(number);
            PlayerPrefs.SetInt("Achieve_Damage", a);

            if (Default_Hp - Mathf.RoundToInt(number) < 0)
            {
                if(number >= 20)
                {
                    FollowCam.instance.Hp_Minus(3);
                    EffectManager.instance.Hp_Minus(3);
                }
                else
                {
                    FollowCam.instance.Hp_Minus(1);
                    EffectManager.instance.Hp_Minus(1);
                }
                Default_Hp = 0;
                Hp_txt.text = (Mathf.RoundToInt(Default_Hp).ToString()) + "/" + Default_Max_Hp.ToString();
                Hp_Filter.fillAmount = 0 * Default_hp;

                if(GameOver_Kind == 0) //나머지
                {
                    GameOver_reason = 1;
                }
                else if(GameOver_Kind == 1) //돌멩이
                {
                    GameOver_reason = 2;
                }
                else if (GameOver_Kind == 2) //차
                {
                    GameOver_reason = 3;
                }
                Dove_Die();
            }
            else

            {
                if (Vibration == true)
                {
                    Handheld.Vibrate();
                }
                Default_Hp -= Mathf.RoundToInt(number);
                Hp_txt.text = (Mathf.RoundToInt(Default_Hp).ToString()) + "/" + Default_Max_Hp.ToString();
                Hp_Filter.fillAmount = Default_Hp * Default_hp;

                Fever += 2;
                Fever_Fillter.fillAmount = Fever / 200.0f;
                Fever_txt.text = Fever.ToString() + "%";

                if (number >= 20)
                {
                    FollowCam.instance.Hp_Minus(2);
                    EffectManager.instance.Hp_Minus(2);
                }
                else
                {
                    FollowCam.instance.Hp_Minus(1);
                    EffectManager.instance.Hp_Minus(1);
                }
                DoveCtrl.instance.Hit();
                Hp_Check();

                Dove_Notion.SetActive(false);

                Dove_Notion_txt.color = new Color(1, 0, 0, 1);
                Dove_Notion_txt.text = InGame_Notion[0] +" -"+ Mathf.RoundToInt(number).ToString();

                Dove_Notion.transform.localPosition = Dove_Hp_Which.localPosition;
                Dove_Notion.SetActive(true);
            }
        }

    }
    public void Score_Plus(int number)
    {
        Score_Notion.SetActive(false);
        Score_Notion.SetActive(true);

        int a = 0;
        int b = 0;

        if (Upgrade_Score2 > 0)
        {
            a = UnityEngine.Random.Range(0, 100);
            if(Upgrade_Score2 >= a)
            {
                b = 1;
                Debug.Log("점수 2배 확률");

            }
            else
            {
                b = 0;
            }
        }

        if (Hacktool == false)
        {
            if(b == 0)
            {
                ScoreUp(number);
                Score_Notion_txt.text = "+" + number.ToString();
            }
            else
            {
                ScoreUp(number * 2);
                Score_Notion_txt.text = "+" + (number * 2).ToString();
            }

            Fever += 2;
            Fever_Fillter.fillAmount = Fever / 200.0f;
            Fever_txt.text = Fever.ToString() + "%";
        }
        else
        {
            if (b == 0)
            {
                ScoreUp(number * 2);
                Score_Notion_txt.text = "+" + (number * 2).ToString();
            }
            else
            {
                ScoreUp(number * 4);
                Score_Notion_txt.text = "+" + (number * 4).ToString();
            }

            Fever += 4;
            Fever_Fillter.fillAmount = Fever / 200.0f;
            Fever_txt.text = Fever.ToString() + "%";
        }

        if (fever == true)
        {
            Dove_Notion.SetActive(false);

            Dove_Notion_txt.text = InGame_Notion[4] + " + " + Mathf.RoundToInt(number).ToString();
            Dove_Notion_txt.color = new Color(1, 0, 0, 1);

            Dove_Notion.transform.localPosition = Dove_Hp_Which.localPosition;
            Dove_Notion.SetActive(true);
        }
    }
    public void Coin_Plus(int number)
    {
        EffectManager.instance.Coin_Plus();

        Dove_Notion.SetActive(false);
        Coin_Plus_Notion.SetActive(false);
        Coin_Plus_Notion.SetActive(true);

        number += (int)Upgrade_Coin;

        float number2 = Mathf.Round(number + (number * 0.1f));

        int a = 0;
        int b = 0;
        if(Upgrade_Coin2 > 0)
        {
            a = UnityEngine.Random.Range(0, 100);
            if(Upgrade_Coin2 >= a)
            {
                b = 1;
                Debug.Log("코인 2배 적용");
            }
            else
            {
                b = 0;
            }
        }

        if (Hacktool == false)
        {
            if(BD_Rainbow_Skin == 0)
            {
                if(b == 0)
                {
                    Plus_Coin += number;
                    Coin_Plus_Notion_txt.text = "+" + number.ToString();
                    Dove_Notion_txt.text = InGame_Notion[1] + " + " + number.ToString();
                }
                else
                {
                    Plus_Coin += number * 2;
                    Coin_Plus_Notion_txt.text = "+" + (number * 2).ToString();
                    Dove_Notion_txt.text = InGame_Notion[1] + " + " + (number * 2).ToString();
                }
            }
            else
            {
                if (b == 0)
                {
                    Plus_Coin += number2;
                    Coin_Plus_Notion_txt.text = "+" + number2.ToString();
                    Dove_Notion_txt.text = InGame_Notion[1] + " + " + number2.ToString();
                }
                else
                {
                    Plus_Coin += number2 * 2;
                    Coin_Plus_Notion_txt.text = "+" + (number2 * 2).ToString();
                    Dove_Notion_txt.text = InGame_Notion[1] + " + " + (number2 * 2).ToString();
                }
            }
        }
        else
        {
            if(BD_Rainbow_Skin == 0)
            {
                if (b == 0)
                {
                    Plus_Coin += number * 2;
                    Coin_Plus_Notion_txt.text = "+" + (number * 2).ToString();
                    Dove_Notion_txt.text = InGame_Notion[1] + " + " + (number * 2).ToString();
                }
                else
                {
                    Plus_Coin += number * 4;
                    Coin_Plus_Notion_txt.text = "+" + (number * 4).ToString();
                    Dove_Notion_txt.text = InGame_Notion[1] + " + " + (number * 4).ToString();
                }
            }
            else
            {
                if (b == 0)
                {
                    Plus_Coin += number2 * 2;
                    Coin_Plus_Notion_txt.text = "+" + (number2 * 2).ToString();
                    Dove_Notion_txt.text = InGame_Notion[1] + " + " + (number2 * 2).ToString();
                }
                else
                {
                    Plus_Coin += number2 * 4;
                    Coin_Plus_Notion_txt.text = "+" + (number2 * 4).ToString();
                    Dove_Notion_txt.text = InGame_Notion[1] + " + " + (number2 * 4).ToString();
                }
            }
        }
        Cointxt.text = Plus_Coin.ToString();

        Dove_Notion_txt.color = new Color(1, 1, 0, 1);

        Dove_Notion.SetActive(false);
        Dove_Notion.transform.localPosition = Dove_Hp_Which.localPosition;
        Dove_Notion.SetActive(true);
    }
    public void Diamond_Plus(int number)
    {
        EffectManager.instance.Coin_Plus();

        Dia_Plus_Notion.SetActive(false);
        Dia_Plus_Notion.SetActive(true);

        if (Hacktool == false)
        {
            Plus_Diamond += number;
            Dia_Plus_Notion_txt.text = "+" + number.ToString();
        }
        else
        {
            Plus_Diamond += (number * 2);
            Dia_Plus_Notion_txt.text = "+" + (number * 2).ToString();
        }
        Diamondtxt.text = Plus_Diamond.ToString();

        Dove_Notion.SetActive(false);
        Dove_Notion.SetActive(true);
        Dove_Notion_txt.text = InGame_Notion[2] + " + " + Mathf.RoundToInt(number).ToString();
        Dove_Notion_txt.color = new Color(0, 1, 1, 1);

        Dove_Notion.transform.localPosition = Dove_Hp_Which.localPosition;
    }
    public void Dora_Feather_Plus(int number)
    {
        EffectManager.instance.Coin_Plus();

        Feather_Plus_Notion.SetActive(false);
        Feather_Plus_Notion.SetActive(true);

        if (Hacktool == false)
        {
            Plus_Dora_Feather += number;
            Feather_Plus_Notion_txt.text = "+" + number.ToString();
        }
        else
        {
            Plus_Dora_Feather += (number * 2);
            Feather_Plus_Notion_txt.text = "+" + (number * 2).ToString();

        }
        Feathertxt.text = Plus_Dora_Feather.ToString();

        Dove_Notion.SetActive(false);
        Dove_Notion.SetActive(true);
        Dove_Notion_txt.text = InGame_Notion[3] + " + " + Mathf.RoundToInt(number).ToString();
        Dove_Notion_txt.color = new Color(1, 1, 0, 1);

        Dove_Notion.transform.localPosition = Dove_Hp_Which.localPosition;
    }

    public void Olive_Start(int number)
    {
        if(Leaf_Value == false)
        {
            Leaf_Value = true;
            EffectManager.instance.Olive_In();
            Olive_In();
            StartCoroutine(Olive_Wait(number));
        }
    }
    public void Olive_End()
    {
        Olive_Out();
    }

    IEnumerator Olive_Wait(int number)
    {
        yield return new WaitForSeconds(1f);
        StartCoroutine(Olive_Count(number));
    }
    IEnumerator Olive_Count(int number)
    {
        for (int i = number; i >= 0; i--)
        {
            if(Talk_Value == false)
            {
                Leaf_Notion.transform.localPosition = new Vector3(Dove_Which.x * 2.13f, Dove_Which.y, Dove_Plus_Which.localPosition.z) + new Vector3(0f, -320f, 0); //나무가지
                Leaf_Notion.SetActive(false);
                Leaf_Notion_txt.text = i.ToString();
                Leaf_Notion.SetActive(true);
                yield return new WaitForSeconds(1f);
                if (Under_Value == true || Castle_Value == true)
                {
                    Leaf_Value = false;
                    Leaf_Notion.SetActive(false);
                    Olive_End();
                    yield break;
                }
            }
            else
            {
                i++;
                yield return new WaitForSeconds(1f);
            }
        }
        Leaf_Value = false;
        Leaf_Notion.SetActive(false);
        Olive_End();
    }


    //Hp
    IEnumerator Hp_Down(int number) //Hp 지속적으로 깎이고 Hp가 0으로 떨어졌는지 체크도함.
    {
        while (!GameSet)
        {
            if (Talk_Value == false && Under_Value == false && Castle_Value == false)
            {
                if (Default_Hp >= 1)
                {
                    if (Skill_Use == false && Immortal_Dove == false)
                    {
                        if(fever == false)
                        {
                            Default_Hp -= number;
                        }
                        else
                        {
                            if (Default_Hp < Default_Max_Hp)
                            {
                                Default_Hp += number * 1;
                            }
                        }

                    }
                    Hp_txt.text = (Mathf.RoundToInt(Default_Hp).ToString()) + "/" + Default_Max_Hp.ToString();
                    Hp_Filter.fillAmount = Default_Hp * Default_hp;
                    Hp_Check();
                }
                else
                {
                    Hp_txt.text = (Mathf.RoundToInt(Default_Hp).ToString()) + "/" + Default_Max_Hp.ToString();
                    Hp_Filter.fillAmount = Default_Hp * Default_hp;
                    GameOver_reason = 0;
                    Dove_Die();
                    yield break;
                }
            }
            else
            {
                if(Default_Hp <= 0)
                {
                    Hp_txt.text = (Mathf.RoundToInt(Default_Hp).ToString()) + "/" + Default_Max_Hp.ToString();
                    Hp_Filter.fillAmount = Default_Hp * Default_hp;
                    GameOver_reason = 0;
                    Dove_Die();
                    yield break;
                }
                else
                {
                    Hp_Check();
                }
            }
            yield return new WaitForSeconds(Dove_Hp_Down_Speed);
        }
    }
    public void Hp_Check()
    {
        if (Default_Hp <= Default_Max_Hp * 0.3f)
        {
            if (Hp_Red == false)
            {
                Hp_Red = true;
                Hp_Red_In();
            }
        }
        else
        {
            if (Hp_Red == true)
            {
                Hp_Red = false;
                Hp_Red_Out();
            }
        }
    } //Hp 체크

    public void Hp_Red_In()
    {
        Background_Red.SetActive(true);
        StartCoroutine(Hp_Red_Twinkling_In());
        StartCoroutine(Heart_Size());
        EffectManager.instance.Hp_Red_In();
    } //Hp 일정 이하일시
    public void Hp_Red_Out()
    {
        Alpha = 0;
        Background_Red_Alpha.color = new Color(Background_Red_Alpha.color.r, Background_Red_Alpha.color.g, Background_Red_Alpha.color.b, Alpha);
        Background_Red.SetActive(false);
        EffectManager.instance.Hp_Red_Out();
    } //Hp 일정 이상일시

    IEnumerator Hp_Red_Twinkling_In()
    {
        while(!GameSet)
        {
            if(Hp_Red == true)
            {
                if (Alpha > 20f / 255f)
                {
                    Alpha -= 1 / 255f;
                }
                else
                {
                    StartCoroutine(Hp_Red_Twinkling_Out());
                    yield break;
                }
                yield return new WaitForSeconds(0.01f);
            }
            else
            {
                yield break;
            }
        }
    }
    IEnumerator Hp_Red_Twinkling_Out()
    {
        while (!GameSet)
        {
            if (Hp_Red == true)
            {
                if (Alpha < 60f / 255f)
                {
                    Alpha += 1 / 255f;
                }
                else
                {
                    StartCoroutine(Hp_Red_Twinkling_In());
                    yield break;
                }
                yield return new WaitForSeconds(0.01f);
            }
            else
            {
                yield break;
            }
        }
    }
    IEnumerator Heart_Size()
    {
        if (Hp_Red == true)
        {
            Heart.localScale = new Vector3(1.3f, 1.3f, 0);
            yield return new WaitForSeconds(0.1f);
            Heart.localScale = new Vector3(1.0f, 1.0f, 0);
            yield return new WaitForSeconds(1.2f);
            StartCoroutine(Heart_Size());
        }
        else
        {
            Heart.localScale = new Vector3(1.0f, 1.0f, 0);
            yield break;
        }
    }

    //Fever

    public void Fever_Plus()
    {
        Fever += (200 / 5);
        Fever_Fillter.fillAmount = Fever / 200.0f;
    }
    IEnumerator Fever_Up()
    {
        if(Fever < 200)
        {
            if (GameSet == false && Talk_Value == false && Under_Value == false && Castle_Value == false && Skill_Use == false)
            {
                Fever += 1;
                Fever_Fillter.fillAmount = Fever / 200.0f;
                Fever_txt.text = Fever.ToString() + "%";
            }
        }
        else
        {
            Fever = 200;
            Fever_Fillter.fillAmount = 1;
            Fever_On();
            yield break;
        }
        yield return new WaitForSeconds(1f);
        StartCoroutine(Fever_Up());
    }

    void Fever_On()
    {
        //업적 - 피버 모드 발동
        int b = PlayerPrefs.GetInt("Achieve_Fever");
        b += 1;
        PlayerPrefs.SetInt("Achieve_Fever", b);

        LanguageManager.instance.Fever_Mode_Notion();
        DoveCtrl.instance.Fever_On();
        SkillManager.instance.Fever_On();
        GameManager2.instance.Fever_On();

        Dove_Hp_Down_Speed = Dove_Hp_Down_Speed * 0.2f;

        source.Pause();
        EffectManager.instance.Disco_Song_On();

        fever = true;

        float a = (Fever_Time / 200);

        F1.Play();
        F2.Play();
        F3.Play();
        F4.Play();

        Fever1.SetActive(true);
        Fever2.SetActive(true);
        Fever3.SetActive(true);
        Fever4.SetActive(true);

        //StartCoroutine(Fever_Create_Coin());

        StartCoroutine(Fevering(a));
    }

    void Fever_Off()
    {
        if(GameSet == false)
        {
            source.UnPause();
        }

        DoveCtrl.instance.Fever_Off();
        SkillManager.instance.Fever_Off();
        GameManager2.instance.Fever_Off();

        Dove_Hp_Down_Speed = SystemManager.instance.Dove_Hp_Down_Speed;

        EffectManager.instance.Disco_Song_Off();

        F1.Play();
        F2.Play();
        F3.Play();
        F4.Play();

        Fever1.SetActive(false);
        Fever2.SetActive(false);
        Fever3.SetActive(false);
        Fever4.SetActive(false);

        fever = false;

        Fever = 0;
        Fever_Fillter.fillAmount = Fever / 200.0f;
        Fever_txt.text = Fever.ToString() + "%";
    }

    IEnumerator Fevering(float time)
    {
        if(Fever > 0)
        {
            if (Talk_Value == false && Under_Value == false && Castle_Value == false)
            {
                Fever -= 1;
                Fever_Fillter.fillAmount = Fever / 200.0f;
                Fever_txt.text = Fever.ToString() + "%";
            }

        }
        else
        {
            source.UnPause();

            Fever_Off();

            yield return new WaitForSeconds(1f);

            StartCoroutine(Fever_Up());
            yield break;
        }
        yield return new WaitForSeconds(time); //이 값을 변경시켜야됨
        StartCoroutine(Fevering(time));
    }

    public void Stage_Up() //스테이지 증가
    {
        LanguageManager.instance.Stage_Up_Notion();
        NowStage += 1;
        Stage_txt.text = InGame_Stage + " " +NowStage.ToString();
        SystemManager.instance.Stage_Up();

        if(Level == 0)
        {
            if(NowStage >= 5)
            {
                Ufo_Coming();
            }
        }
        else if(Level == 1)
        {
            if (NowStage >= 3)
            {
                Ufo_Coming();
            }
        }

        if(NowStage < 11)
        {
            Enemy_Dove_Create_CoolTime -= Dove_Control;
            Enemy_Eagle_Create_CoolTime -= Eagle_Control;
            Enemy_Wave_Create_CoolTime -= Wave_Control;

            Object_Coin_Create_CoolTime -= Object_Coin_Create_CoolTime_Down;
            Object_Item_Create_CoolTime -= Object_Item_Create_CoolTime_Down;

            Dove_Hp_Down_Speed -= Dove_Hp_Down_Control;
        }

        if (NowStage >= 8)
        {
            if(theme_x2 == false)
            {
                theme_x2 = true;
                source.clip = main_theme_x2;
                source.Play();
            }
        }
        else if(NowStage >= 4)
        {
            if(theme_x1 == false)
            {
                theme_x1 = true;
                source.clip = main_theme_x1;
                source.Play();
            }
        }
    }

    //대화
    public void GodTalk()
    {
        try
        {
            Talk_In();
            TalkWindow.SetActive(true);
            TalkManager.instance.Renewal(0);

            Talk_Value = true;
            source.volume = 0.7f;

        }
        catch (NullReferenceException ie)
        {
            print(ie.Message);

            Talk_In();
            TalkWindow.SetActive(true);
            TalkManager.instance.Renewal(0);

            Talk_Value = true;
            source.volume = 0.7f;
        }
    }
    public void MoleTalk()
    {
        try
        {
            Talk_In();
            TalkWindow.SetActive(true);
            TalkManager.instance.Renewal(1);

            Talk_Value = true;
            source.volume = 0.7f;

        }
        catch (NullReferenceException ie)
        {
            print(ie.Message);

            Talk_In();
            TalkWindow.SetActive(true);
            TalkManager.instance.Renewal(1);

            Talk_Value = true;
            source.volume = 0.7f;
        }
    }
    public void Talk_End() //대화종료
    {
        try
        {
            Talk_Value = false;
            source.volume = 1.0f;

            if (Castle_Value == true || Under_Value == true)
            {

            }
            else
            {
                Talk_Out();
            }

            TalkWindow.SetActive(false);
        }
        catch (NullReferenceException ie)
        {
            print(ie.Message);

            Talk_Value = false;
            source.volume = 1.0f;

            if (Castle_Value == true || Under_Value == true)
            {

            }
            else
            {
                Talk_Out();
            }

            TalkWindow.SetActive(false);
        }
    }


    public void EndGame() //점수화면
    {
        GameSet = true;
        EndGameWindow.SetActive(true);

        Record_Check(); //업적도 같이 처리

        Save_AliveTime(NowTimer);

        TimeExChange();

        //추가 점수

        switch (Rank)
        {
            case 0:
                rank = "Rank D";
                PlusScore_Title_txt.color = new Color(1, 0.5f, 0);
                PlusCoin_Title_txt.color = new Color(1, 0.5f, 0);
                Plus_NowScore = 0;
                break;
            case 1:
                rank = "Rank C";
                PlusScore_Title_txt.color = new Color(1, 1, 0);
                PlusCoin_Title_txt.color = new Color(1, 1, 0);
                Plus_NowScore = 2;
                break;
            case 2:
                rank = "Rank B";
                PlusScore_Title_txt.color = new Color(0, 1, 0);
                PlusCoin_Title_txt.color = new Color(0, 1, 0);
                Plus_NowScore = 5;
                break;
            case 3:
                rank = "Rank A";
                PlusScore_Title_txt.color = new Color(1, 0, 0);
                PlusCoin_Title_txt.color = new Color(1, 0, 0);
                Plus_NowScore = 10;
                break;
            case 4:
                rank = "Rank S";
                PlusScore_Title_txt.color = new Color(1, 0, 1);
                PlusCoin_Title_txt.color = new Color(1, 0, 1);
                Plus_NowScore = 20;
                break;
        }


        if (Plus_NowScore > 0)
        {
            if(Rank != 0)
            {
                PlusScore_Title_txt.text = rank + " + " + Plus_NowScore.ToString() + "%";
            }
            float a = (float)NowScore;
            float b = Mathf.Ceil((a * (Plus_NowScore * 0.01f)));
            float c = a + b;
            NowScore = Mathf.RoundToInt(c);
            End_PlusScoretxt.text = "+" + b.ToString();
        }
        else
        {
            PlusScore_Title_txt.text = " ";
            End_PlusScoretxt.text = " ";
        }

        End_Scoretxt.text = NowScore.ToString();
        End_Stagetxt.text = NowStage.ToString();
        End_Timertxt.text = NowMinTimer.ToString() + ":" + NowTimer.ToString();

        int d = PlayerPrefs.GetInt("AllScore");
        d += NowScore;
        PlayerPrefs.SetInt("AllScore", d);


        HighChange(NowScore, HighScore, End_HighScoretxt, 0);
        HighChange(NowStage, HighStage, End_HighStagetxt, 1);
        HighChange(((NowMinTimer* 60)+NowTimer), ((HighMinTimer*60)+HighTimer), End_HighTimertxt, 2);

        StartCoroutine(Best_Notion(Best_score, Best_stage, Best_time));

        AliveTime_txt.text = " ";
        AliveTime_txt.text = "+"+((NowMinTimer * 60) + NowTimer).ToString();



        //보상

        float Gold = 0;
        float Plus_Gold = 0;

        if (Level == 0)
        {
            Gold = Mathf.RoundToInt(NowScore * 0.3f); //점수의 30% 획득
        }
        else if (Level == 1)
        {
            Gold = Mathf.RoundToInt(NowScore * 0.4f); //점수의 40% 획득
        }
        else if (Level == 2)
        {
            Gold = Mathf.RoundToInt(NowScore * 0.5f); //점수의 50% 획득
        }

        PlusCoin_Title_txt.text = "";
        End_PlusCointxt.text = "0";

        if (Plus_NowScore > 0)
        {
            if (Rank != 0)
            {
                PlusCoin_Title_txt.text = rank + " + " + Plus_NowScore.ToString() + "%";
            }
            float a = (float)(Gold + Plus_Coin);
            float b = Mathf.Ceil((a * (Plus_NowScore * 0.01f)));
            Plus_Gold = Mathf.RoundToInt(b);
            End_PlusCointxt.text = "+" + b.ToString();
        }

        End_Cointxt.text = Mathf.RoundToInt(Gold + Plus_Coin).ToString();
        RewardAd_Default = Mathf.RoundToInt(Gold + Plus_Coin);

        BD_Coin += Mathf.RoundToInt(Gold + Plus_Coin + Plus_Gold);
        PlayerPrefs.SetInt("BD_Coin", BD_Coin);

        //광고 코인 100%
        Ad_Coin_Plus_txt.text = "+"+Mathf.RoundToInt((Gold + Plus_Coin + Plus_Gold) * 1).ToString();
        RewardAd_Coin = Mathf.RoundToInt((Gold + Plus_Coin + Plus_Gold) * 1);


        int Diamond = 0;
        if(Level == 0)
        {
            if(NowMinTimer >= 2)
            {
                Diamond = UnityEngine.Random.Range(5, 11);
            }
        }
        else if(Level == 1)
        {
            if (NowMinTimer >= 2)
            {
                Diamond = UnityEngine.Random.Range(10, 16);
            }
        }
        else if(Level == 2)
        {
            if (NowMinTimer >= 2)
            {
                Diamond = UnityEngine.Random.Range(20, 31);
            }
        }


        BD_Diamond += Diamond + Plus_Diamond;
        End_Diamondtxt.text = (Diamond+Plus_Diamond).ToString();

        PlayerPrefs.SetInt("BD_Diamond", BD_Diamond);



        End_Feathertxt.text = "0";

        BD_Dora_Feather += Plus_Dora_Feather;
        End_Feathertxt.text = Plus_Dora_Feather.ToString();

        PlayerPrefs.SetInt("BD_Dora_Feather", BD_Dora_Feather);

    }

    void Record_Check()
    {
        //업적 - 누적 점수
        int a = PlayerPrefs.GetInt("Achieve_Score");
        a += NowScore;
        PlayerPrefs.SetInt("Achieve_Score", a);

        //업적 - 누적 생존 시간
        int b = PlayerPrefs.GetInt("Achieve_AliveTime");
        b += NowTimer;
        PlayerPrefs.SetInt("Achieve_AliveTime", b);

        //업적 - 누적 단계
        int c = PlayerPrefs.GetInt("Achieve_Level");
        c += NowStage;
        PlayerPrefs.SetInt("Achieve_Score", c);

        Record_Change(4, 5);
        Record_Change(3, 4);
        Record_Change(2, 3);
        Record_Change(1, 2);
        Recording(1);
    }

    void Record_Change(int number, int number2) //값 위치 교환 1에 정보를 2로 옮김
    {
        int a = PlayerPrefs.GetInt("Dove_" + number.ToString());
        int b = PlayerPrefs.GetInt("Level_" + number.ToString());
        int c = PlayerPrefs.GetInt("Stage_" + number.ToString());
        int d = PlayerPrefs.GetInt("Score_" + number.ToString());
        int e = PlayerPrefs.GetInt("AliveTime_" + number.ToString());
        int f = PlayerPrefs.GetInt("Dead_" + number.ToString());

        PlayerPrefs.SetInt("Dove_" + number2.ToString(), a);
        PlayerPrefs.SetInt("Level_" + number2.ToString(), b);
        PlayerPrefs.SetInt("Stage_" + number2.ToString(), c);
        PlayerPrefs.SetInt("Score_" + number2.ToString(), d);
        PlayerPrefs.SetInt("AliveTime_" + number2.ToString(), e);
        PlayerPrefs.SetInt("Dead_" + number2.ToString(), f);
    }

    void Recording(int number) //기록 저장
    {
        PlayerPrefs.SetInt("Dove_" + number.ToString(), DoveChoice);
        PlayerPrefs.SetInt("Level_" + number.ToString(), Level);
        PlayerPrefs.SetInt("Stage_" + number.ToString(), NowStage);
        PlayerPrefs.SetInt("Score_" + number.ToString(), NowScore);
        PlayerPrefs.SetInt("AliveTime_" + number.ToString(), NowTimer);
        PlayerPrefs.SetInt("Dead_" + number.ToString(), GameOver_reason);
    }

    public void HighChange(int a, int b, UILabel btxt, int value) //결과창에서 현재스코어가 최고스코어보다 높으면 갱신해주기
    {
        switch(value)
        {
            case 0: //점수
                if (a > b)
                {
                    Best_score = 1;
                    btxt.text = a.ToString();
                    Save_HighScore(a);
                }
                else
                {
                    btxt.text = b.ToString();
                }
                break;
            case 1: //스테이지
                if (a > b)
                {
                    Best_stage = 1;
                    btxt.text = a.ToString();
                    PlayerPrefs.SetInt("HighStage", a);
                }
                else
                {
                    btxt.text = b.ToString();
                }
                break;
            case 2: //생존시간
                if (a > b)
                {
                    btxt.text = NowMinTimer.ToString() + ":" + NowTimer.ToString();
                    PlayerPrefs.SetInt("HighTimer", a);
                    Best_time = 1;
                }
                else
                {
                    btxt.text = HighMinTimer.ToString() + ":" + HighTimer.ToString();
                }
                break;
        }
    }

    void Save_HighScore(int number)
    {
        if(DoveChoice == 1)
        {
            PlayerPrefs.SetInt("Black_HighScore", number);
            //Debug.Log("구구 최고 점수 : " + number);
        }
        else if(DoveChoice == 2)
        {
            PlayerPrefs.SetInt("White_HighScore", number);
            //Debug.Log("루루 최고 점수 : " + number);
        }
        else if (DoveChoice == 3)
        {
            PlayerPrefs.SetInt("Eagle_HighScore", number);
            //Debug.Log("수리수리 최고 점수 : " + number);
        }
        else if (DoveChoice == 4)
        {
            PlayerPrefs.SetInt("Dora_HighScore", number);
            //Debug.Log("도라 최고 점수 : " + number);
        }

        Black_HighScore = PlayerPrefs.GetInt("Black_HighScore");
        White_HighScore = PlayerPrefs.GetInt("White_HighScore");
        Eagle_HighScore = PlayerPrefs.GetInt("Eagle_HighScore");
        Dora_HighScore = PlayerPrefs.GetInt("Dora_HighScore");

        HighScore = Black_HighScore + White_HighScore + Eagle_HighScore + Dora_HighScore;
        PlayerPrefs.SetInt("HighScore", HighScore);
    }

    IEnumerator Best_Notion(int number, int number2, int number3)
    {
        yield return new WaitForSeconds(0.5f);

        if (number == 1)
        {
            Best_Score.SetActive(true);
            EffectManager.instance.Hp_Minus(1);
        }
        yield return new WaitForSeconds(0.5f);

        if (number2 == 1)
        {
            Best_Stage.SetActive(true);
            EffectManager.instance.Hp_Minus(1);
        }
        yield return new WaitForSeconds(0.5f);

        if (number3 == 1)
        {
            Best_Time.SetActive(true);
            EffectManager.instance.Hp_Minus(1);
        }

    }

    IEnumerator TimeCheck() //시간 재는 함수(비둘기 생존시간 레벨업에 사용됨)
    {
        while (!GameSet)
        {
            if (Talk_Value == false && Under_Value == false && Castle_Value == false)
            {
                NowTimer += 1;
            }
            yield return new WaitForSeconds(1f);
        }
    }
    public void TimeExChange()
    {
        while (NowTimer >= 60)
        {
            NowTimer -= 60;
            NowMinTimer += 1;
        }

        while (HighTimer >= 60)
        {
            HighTimer -= 60;
            HighMinTimer += 1;
        }
    } //분을 초로 바꿔주는 함수




    public void Dove_Die()
    {
        Talk_End();
        Player_Die();

        Leaf_Value = false;
        Leaf_Notion.SetActive(false);
        Olive_End();

        LanguageManager.instance.Dead_Notion();
        EffectManager.instance.GameOver();

        GameSet = true;
        Skill_Use = false;
        Immortal_Dove = false;

        Hp_Red = true;
        Hp_Red_Out();


        if (Music_OnOff == 1)
        {
            source.Pause();
        }

        //피버모드 초기화
        if(fever == true)
        {
            Fever_Off();
        }

        if (UFO_Blink == true)
        {
            UFO_Blink = false;
            UFO_Notion.SetActive(false);
            EffectManager.instance.Warning_Off();
        }

        GameOver_Reason_txt.text = GameOver_Reason[GameOver_reason];

        switch(GameOver_reason)
        {
            case 0:
                PlayerPrefs.SetInt("Dead_Hungry", 1);
                break;
            case 1:
                PlayerPrefs.SetInt("Dead_Crash", 1);
                break;
            case 2:
                PlayerPrefs.SetInt("Dead_Throw", 1);
                break;
            case 3:
                PlayerPrefs.SetInt("Dead_Accidnet", 1);
                break;
            case 4:
                PlayerPrefs.SetInt("Dead_Miss", 1);
                break;
            case 5:
                PlayerPrefs.SetInt("Dead_Kidnap", 1);
                break;
        }
        BD_Diamond_txt.text = BD_Diamond.ToString();
        Advertisting_Count_txt.text = InGame_Count + Advertising_Count.ToString();
        Continue_Count_txt.text = InGame_Count + BD_Diamond_Count.ToString();
        BD_Diamond_Number_txt.text = "-" + BD_Diamond_Number.ToString();

        StopAllCoroutines();

        if (GameOver_reason != 3)
        {
            StartCoroutine(EndGame_Wait());
        }
        else
        {
            GameOverWindow.SetActive(true);
        }

    } //비둘기 죽음

    IEnumerator EndGame_Wait()
    {
        yield return new WaitForSeconds(1.5f);
        GameOverWindow.SetActive(true);
    }

    //죽음 종류
    public void Mole_Die() //두더지 의문사
    {
        GameOver_reason = 4;
        Dove_Die();
    }

    public void Ufo_Die() //UFO 납치
    {
        //업적 - UFO 납치
        int a = PlayerPrefs.GetInt("Achieve_Ufo");
        a += 1;
        PlayerPrefs.SetInt("Achieve_Ufo", a);

        StartCoroutine(Ufo_Die_anim());
        EffectManager.instance.Ufo();
    }

    IEnumerator Ufo_Die_anim()
    {
        Talk_End();
        Player_Die();
        LanguageManager.instance.Dead_Ufo_Notion();

        Leaf_Value = false;
        Leaf_Notion.SetActive(false);
        Olive_End();

        GameSet = true;
        Skill_Use = false;
        Immortal_Dove = false;

        Hp_Red = true;
        Hp_Red_Out();

        if (Music_OnOff == 1)
        {
            source.Pause();
        }

        if (fever == true)
        {
            Fever_Off();
        }

        GameOver_reason = 5;
        yield return new WaitForSeconds(2.0f);
        EndGame();
    }

    public void Dove_Alive()
    {
        GameOverWindow.SetActive(false);
        StartCoroutine(Continue_Count());

    } // 비둘기 부활


    public void Dove_Alive_Advertising() //이어하기 광고
    {
        if (Advertising_Count > 0)
        {
            RewardAd_Watch = true;

            AdmobRewardAd.instance.Show(0);
        }
        else
        {
            LanguageManager.instance.Not_Count_Notion();
        }
    }

    public void RewardAd_Alive() //이어하기 광고로 부활
    {
        RewardAd_Watch = false;

        Advertising_Count -= 1;
        GameOverWindow.SetActive(false);
        StartCoroutine(Continue_Count());

    }

    public void RewardAd_Coin_Watch() //광고 코인 100퍼
    {
        if(RewardAd ==false)
        {
            RewardAd_Watch = true;

            AdmobRewardAd.instance.Show(1);
        }
    }

    public void RewardAd_Coin_Watch_Clear() //광고 코인 100퍼 시청 완료
    {
        RewardAd_Watch = false;

        RewardAd = true;
        RewardAd_Object.SetActive(false);
        LanguageManager.instance.Success_Reward_Notion();

        End_Cointxt.text = (RewardAd_Default + RewardAd_Coin).ToString();

        BD_Coin = PlayerPrefs.GetInt("BD_Coin");
        BD_Coin += RewardAd_Coin;
        PlayerPrefs.SetInt("BD_Coin", BD_Coin);

    }

    public void Dove_Alive_Diamond()
    {
        if (BD_Diamond >= BD_Diamond_Number)
        {
            if(BD_Diamond_Count > 0)
            {
                //업적 - 다이아 사용
                int a = PlayerPrefs.GetInt("Achieve_Diamond");
                a += BD_Diamond_Number;
                PlayerPrefs.SetInt("Achieve_Diamond", a);

                BD_Diamond -= BD_Diamond_Number;
                BD_Diamond_Count -= 1;
                BD_Diamond_Number += 10;
                //다이아 세이브
                Dove_Alive();
            }
            else
            {
                LanguageManager.instance.Not_Count_Notion();
            }
        }
        else
        {
            LanguageManager.instance.Low_Diamond_Notion();
        }
    }
    public void Dove_Alive_EndGame()
    {
        GameOverWindow.SetActive(false);
        EndGame();
    }

    IEnumerator Continue_Count()
    {
        Continuetxt.enabled = true;
        Continuetxt.color = new Color(0, 0, 1, 1);
        Continuetxt.text = "3";
        yield return new WaitForSeconds(1f);
        Continuetxt.color = new Color(0, 1, 0, 1);
        Continuetxt.text = "2";
        yield return new WaitForSeconds(1f);
        Continuetxt.color = new Color(1, 1, 0, 1);
        Continuetxt.text = "1";
        yield return new WaitForSeconds(1f);
        Continuetxt.color = new Color(1, 0, 0, 1);
        Continuetxt.text = "Go!";
        yield return new WaitForSeconds(1f);
        Continuetxt.enabled = false;

        Player_Alive();

        GameSet = false;

        Hp_Red = false;
        Hp_Red_Out();

        if (Music_OnOff == 1)
        {
            source.Play();
        }

        Default_Hp = Default_Max_Hp;
        Hp_txt.text = (Mathf.RoundToInt(Default_Hp).ToString()) + "/" + Default_Max_Hp.ToString();
        Hp_Filter.fillAmount = Default_Hp * Default_hp;

        if (Aid_UI.activeSelf == true)
        {
            StartCoroutine(Aid_CoolTime(Aid_Fillter));
        }

        Restart_Coroutione();
        Create_Check();

        if(Under_Value == true)
        {
            StartCoroutine(Under_Time());
        }
        else if(Castle_Value == true)
        {
            StartCoroutine(Castle_Time());
        }

        yield break;
    }

    IEnumerator GameScore() //점수 증가
    {
        while (!GameSet)
        {
            if (Talk_Value == false && Under_Value == false && Castle_Value == false)
            {
                if (Renewal == false)
                {
                    ScoreCheck(NowScore, HighScore);
                }

                if(Hacktool == false)
                {
                    ScoreUp(1);
                }
                else
                {
                    ScoreUp(2);
                }
            }
            yield return new WaitForSeconds(ScoreCooltime);
        }
    }
    public void ScoreUp(int number)
    {
        NowScore += number;
        NowScoretxt.text = NowScore.ToString();
        if (Renewal == true)
        {
            NowHighScore+= number;
            HighScoretxt.text = NowHighScore.ToString();
        }
    }

    public void ScoreCheck(int NowScore, int HighScore) //최고점수 갱신했는지 검사
    {
        if (NowScore >= HighScore)
        {
            Renewal = true;
            NowHighScore = NowScore;
            NowScoretxt.color = new Color(255, 0, 0);
            //Nowscoretxt.transform.localPosition = new Vector3(-40, 299, 0);
            Nowscoretxt.localScale = new Vector3(1.5f, 1.5f, 1);

            //Debug.Log("최고 기록 갱신!");
        }
    }

    public void Save_AliveTime(int number)
    {
        if(DoveChoice == 1)
        {
            BD_Black_AliveTime += number;
            PlayerPrefs.SetInt("BD_Black_AliveTime", BD_Black_AliveTime);
            Debug.Log("구구의 생존시간이 " + number.ToString() + " 만큼 증가했습니다.");
        }
        else if(DoveChoice == 2)
        {
            BD_White_AliveTime += number;
            PlayerPrefs.SetInt("BD_White_AliveTime", BD_White_AliveTime);
            Debug.Log("루루의 생존시간이 " + number.ToString() + " 만큼 증가했습니다.");
        }
        else if (DoveChoice == 3)
        {
            BD_Eagle_AliveTime += number;
            PlayerPrefs.SetInt("BD_Eagle_AliveTime", BD_Eagle_AliveTime);
            Debug.Log("수리수리의 생존시간이 " + number.ToString() + " 만큼 증가했습니다.");
        }
        else if (DoveChoice == 4)
        {
            BD_Dora_AliveTime += number;
            PlayerPrefs.SetInt("BD_Dora_AliveTime", BD_Dora_AliveTime);
            Debug.Log("도라의 생존시간이 " + number.ToString() + " 만큼 증가했습니다.");
        }
        else
        {
            Debug.Log("에러");
        }
    }

    IEnumerator Renewal_Notion()
    {
#if UNITY_ANDROID || UNITY_IPHONE
        Dove_Which = Camera.main.WorldToScreenPoint(Dove.transform.localPosition) + new Vector3(-534.0f, -576.0f, 0);
        Dove_Hp_Which.localPosition = new Vector3(Dove_Which.x * 1, Dove_Which.y, Dove_Plus_Which.localPosition.z) + new Vector3(0f, -340f, 0); //체력 회복, 코인 ,다이아 ,깃털 표시
        Dove_Plus_Which.localPosition = new Vector3(Dove_Which.x * 1, Dove_Which.y, Dove_Plus_Which.localPosition.z) + new Vector3(0f, -420f, 0); //힐 하는 곳
#endif

#if UNITY_EDITOR
        Dove_Which = Camera.main.WorldToScreenPoint(Dove.transform.localPosition) + new Vector3(-248f, -273.3f, 0);
        Dove_Hp_Which.localPosition = new Vector3(Dove_Which.x * 2.13f, Dove_Which.y, Dove_Plus_Which.localPosition.z) + new Vector3(0f, -340f, 0); //체력 회복, 코인 ,다이아 ,깃털 표시
        Dove_Plus_Which.localPosition = new Vector3(Dove_Which.x * 2.13f, Dove_Which.y, Dove_Plus_Which.localPosition.z) + new Vector3(0f, -420f, 0); //힐 하는 곳
#endif
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(Renewal_Notion());
    }

    void Update()
    {
        if (Hp_Red == true)
        {
            Background_Red_Alpha.color = new Color(Background_Red_Alpha.color.r, Background_Red_Alpha.color.g, Background_Red_Alpha.color.b, Alpha);
        }
    }
}
