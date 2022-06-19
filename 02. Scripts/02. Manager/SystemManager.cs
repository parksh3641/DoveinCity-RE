using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SystemManager : MonoBehaviour
{
    public static SystemManager instance;
    private Transform MyWitch;

    public int BD_Coin = 0; //게임화폐
    public int BD_Diamond = 0;
    public int BD_Dora_Feather = 0;

    //인게임
    public int BD_Black_AliveTime = 0;
    public int BD_White_AliveTime = 0;
    public int BD_Eagle_AliveTime = 0;
    public int BD_Dora_AliveTime = 0;

    public int BD_Black_Skill_Value;
    public int BD_White_Skill_Value;
    public int BD_Eagle_Skill_Value;
    public int BD_Dora_Skill_Value;

    //날씨
    public int Weather_Cycle_Value;

    //레벨값
    public float Heart_Default_Value = 0;
    public float Heart_Up_Value = 0;
    public float Fly_Default_Value = 0;
    public float Fly_Up_Value = 0;
    public float Coin_Default_Value = 0;
    public float Coin_Up_Value = 0;
    public float Item_Default_Value = 0;
    public float Item_Up_Value = 0;
    public float Hit_Default_Value = 0;
    public float Hit_Up_Value = 0;

    public float Move_Default_Value = 0;
    public float Move_Up_Value = 0;
    public float Fever_Default_Value = 0;
    public float Fever_Up_Value = 0;
    public float FlyDown_Default_Value = 0;
    public float FlyDown_Up_Value = 0;
    public float Score2_Default_Value = 0;
    public float Score2_Up_Value = 0;
    public float Coin2_Default_Value = 0;
    public float Coin2_Up_Value = 0;

    //스킬값
    public int Skill_Default_Value = 0;
    public int Skill_Up_Value = 0;

    public int Advertising_Count = 0;
    public int BD_Diamond_Count = 0;
    public int BD_Diamond_Number = 0;

    public float SelectDoveCooltime = 0f; //선택창 비둘기 날개짓 쿨타임
    public int DoveChoice = 0; //선택창 비둘기 선택한 번호

    public float Dove_Speed = 0; //게임속 비둘기 속도
    public float Up_Speed = 0; //단계 증가시 속도에다가 더해질 될 숫자
    private int NowStage = 0;
    private int Max_Level = 0; //최대 증가 단계

    public int NowScore = 0;
    public int HighScore = 0;
    public int Black_HighScore = 0;
    public int White_HighScore = 0;
    public int Eagle_HighScore = 0;
    public int Dora_HighScore = 0;


    public float ScoreCooltime = 0;

    public int HighStage = 0;
    public int HighTimer = 0;

    public int Music_OnOff = 1;
    public int SFX_OnOff = 1;
    public int Vibration_OnOff = 1;

    public float ShakeAmount = 0; //부딫힐시 화면 진동
    public float ShakeTime = 0;

    public float Dove_Invincibel_Time = 0;

    //기본 값
    public float Default_Hp = 0;
    public float Default_Black_Hp = 0;
    public float Default_White_Hp = 0;
    public float Default_Eagle_Hp = 0;
    public float Default_Dora_Hp = 0;

    public float Dove_Hp_Down_Speed = 0;
    public float Skill_Time; //스킬 발동시간
    public float Skill_CoolTime; //스킬 재사용 대시시간
    public float Item_Time; //아이템 발동시간

    //강화 설정
    public float Upgrade_Hp = 0;
    public float Upgrade_Skill_Time = 0;
    public float Upgrade_Coin = 0;
    public float Upgrade_Item_Time = 0;
    public float Upgrade_Hit_Time = 0;

    public float Upgrade_Move = 0;
    public float Upgrade_Fever = 0;
    public float Upgrade_FlyDown = 0;
    public float Upgrade_Score2 = 0;
    public float Upgrade_Coin2 = 0;

    private string Black_Skill_Point_Save;
    private string White_Skill_Point_Save;
    private string Eagle_Skill_Point_Save;
    private string Dora_Skill_Point_Save;

    private string[] Black_Skill_Point = new string[10];
    private string[] White_Skill_Point = new string[10];
    private string[] Eagle_Skill_Point = new string[10];
    private string[] Dora_Skill_Point = new string[10];


    //스킨
    private int BD_Sunshine_Skin;
    private int BD_Clocking_Skin;
    private int BD_Rainbow_Skin;

    //게임 설정
    public static int LoadingCode;

    //적 설정
    public int Enemy_Dove_Damage = 0;
    public int Enemy_Eagle_Damage = 0;

    public int Enemy_Dove_Score = 0;
    public int Enemy_Eagle_Score = 0;
    public int Enemy_Ufo_Score = 0;
    public int Enemy_Olive_Score = 0;
    public int Enemy_Building_Score = 0;
    public int Enemy_Castle_Score = 0;

    public int Enemy_Ufo_Damage = 0;
    public int Enemy_Ship_Damage = 0;
    public int Enemy_Wave_Damage = 0;
    public int Enemy_Building_Damage = 0;
    public int Enemy_Mole_Damage = 0;

    public float Enemy_Dove_Random_CoolTime = 0; //방향전환
    public float Enemy_Dove_Create_CoolTime = 0;
    public float Enemy_Eagle_Create_CoolTime = 0;
    public float Enemy_Wave_Create_CoolTime = 0;

    //오브젝트 설정
    public int Object_Trash_Hp = 0;
    public int Object_Coin_Value = 0;

    public float Object_Coin_Create_CoolTime = 0;

    public int Leaf_Time = 0;

    public int Mandu_Hp = 0;
    public int Stone_Damage = 0;
    public int Candy_Hp = 0;

    public float People_Speed = 0;
    public float People_Random_Move_CoolTime = 0;

    public int Car_Damage = 0;
    public float Car_Random_CoolTime = 0;

    //숭례문, 지하세계
    public int Under_Time_Value = 0;
    public int Castle_Time_Value = 0;

    //아이템 설정
    public int Item_Heart_Hp = 0;
    public int Item_Diamond_Number = 0;
    public int Item_Dora_Number = 0;

    public float Object_Item_Create_CoolTime;

    //피버모드
    public float Fever_Time;

    float a, b, c, d, e, f, g, h, i, j;

    //조력자 기본값
    public int Owl_Default_Value = 0;
    public int Owl_Up_Value = 0;
    public float Owl_CoolTime = 0;

    public int Duck_Default_Value = 0;
    public int Duck_Up_Value = 0;

    void Awake()     //게임 시작하기전 기본적인 설정
    {
        instance = this;

        DoveChoice = PlayerPrefs.GetInt("DoveChoice");

        if (DoveChoice == 0) //게임을 처음 킬시
        {
            PlayerPrefs.DeleteAll();

            DoveChoice = 1;
            PlayerPrefs.SetInt("DoveChoice", 1);

            PlayerPrefs.SetInt("Music_Onoff",1);
            PlayerPrefs.SetInt("SFX_Onoff",1);
            PlayerPrefs.SetInt("Vibration_Onoff",1);

            PlayerPrefs.SetString("Nickname", "반갑습니다.");

            PlayerPrefs.SetString("Black_Skill_Point_Save","0000000000");
            PlayerPrefs.SetString("White_Skill_Point_Save","0000000000");
            PlayerPrefs.SetString("Eagle_Skill_Point_Save", "0000000000");
            PlayerPrefs.SetString("Dora_Skill_Point_Save", "0000000000");

            string a = PlayerPrefs.GetString("SaveLastTime");
            if (a != null)
            {
                PlayerPrefs.SetString("SaveLastTime", System.DateTime.Now.ToString());
            }

            Debug.Log("처음 킴");
        }

        Stat_Load();

        Black_HighScore = PlayerPrefs.GetInt("Black_HighScore");
        White_HighScore = PlayerPrefs.GetInt("White_HighScore");
        Eagle_HighScore = PlayerPrefs.GetInt("Eagle_HighScore");
        Dora_HighScore = PlayerPrefs.GetInt("Dora_HighScore");

        HighStage = PlayerPrefs.GetInt("HighStage");
        HighTimer = PlayerPrefs.GetInt("HighTimer");

        BD_Coin = PlayerPrefs.GetInt("BD_Coin");
        BD_Diamond = PlayerPrefs.GetInt("BD_Diamond");
        BD_Dora_Feather = PlayerPrefs.GetInt("BD_Dora_Feather");

        BD_Black_AliveTime = PlayerPrefs.GetInt("BD_Black_AliveTime");
        BD_White_AliveTime = PlayerPrefs.GetInt("BD_White_AliveTime");
        BD_Eagle_AliveTime = PlayerPrefs.GetInt("BD_Eagle_AliveTime");
        BD_Dora_AliveTime = PlayerPrefs.GetInt("BD_Dora_AliveTime");

        MyWitch = GetComponent<Transform>();

        //게임 시작전 기본 설정
        Time.timeScale = 1.0f;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
        //Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Application.targetFrameRate = 60;
        Screen.SetResolution(1080, 1920, false);

        Music_OnOff = PlayerPrefs.GetInt("Music_Onoff");
        SFX_OnOff = PlayerPrefs.GetInt("SFX_Onoff");
        Vibration_OnOff = PlayerPrefs.GetInt("Vibration_Onoff");
    }

    void Start()
    {
        if (SFX_OnOff == 0)
        {
            EffectManager.instance.SFX_Off();
        }
        else
        {
            EffectManager.instance.SFX_On();
        }
    }
    void Stat_Load()
    {
        Heart_Default_Value = 0;
        Heart_Up_Value = 2;

        Fly_Default_Value = 5.5f; //높이날기 지속시간
        Fly_Up_Value = 0.2f;

        Coin_Default_Value = 20;
        Coin_Up_Value = 2;

        Item_Default_Value = 20;
        Item_Up_Value = 1;

        Hit_Default_Value = 1.5f;
        Hit_Up_Value = 0.05f;

        Move_Default_Value = 0;
        Move_Up_Value = 1;

        Fever_Default_Value = 10;
        Fever_Up_Value = 0.5f;

        FlyDown_Default_Value = 60;
        FlyDown_Up_Value = -1;

        Score2_Default_Value = 0;
        Score2_Up_Value = 3;

        Coin2_Default_Value = 0;
        Coin2_Up_Value = 2;

        Black_Skill_Point_Save = PlayerPrefs.GetString("Black_Skill_Point_Save");
        White_Skill_Point_Save = PlayerPrefs.GetString("White_Skill_Point_Save");
        Eagle_Skill_Point_Save = PlayerPrefs.GetString("Eagle_Skill_Point_Save");
        Dora_Skill_Point_Save = PlayerPrefs.GetString("Dora_Skill_Point_Save");

        //불러온 후 변환
        if(Black_Skill_Point_Save != null)
        {
            for (int i = 0; i < Black_Skill_Point_Save.Length; i++)
            {
                Black_Skill_Point[i] = Black_Skill_Point_Save.Substring(i, 1);
            }
        }

        if (White_Skill_Point_Save != null)
        {
            for (int i = 0; i < White_Skill_Point_Save.Length; i++)
            {
                White_Skill_Point[i] = White_Skill_Point_Save.Substring(i, 1);
            }
        }

        if (Eagle_Skill_Point_Save != null)
        {
            for (int i = 0; i < Eagle_Skill_Point_Save.Length; i++)
            {
                Eagle_Skill_Point[i] = Eagle_Skill_Point_Save.Substring(i, 1);
            }
        }

        if (Dora_Skill_Point_Save != null)
        {
            for (int i = 0; i < Dora_Skill_Point_Save.Length; i++)
            {
                Dora_Skill_Point[i] = Dora_Skill_Point_Save.Substring(i, 1);
            }
        }

        if (DoveChoice == 1)
        {
            a = float.Parse(Black_Skill_Point[0]);
            b = float.Parse(Black_Skill_Point[1]);
            c = float.Parse(Black_Skill_Point[2]);
            d = float.Parse(Black_Skill_Point[3]);
            e = float.Parse(Black_Skill_Point[4]);
            f = float.Parse(Black_Skill_Point[5]);
            g = float.Parse(Black_Skill_Point[6]);
            h = float.Parse(Black_Skill_Point[7]);
            i = float.Parse(Black_Skill_Point[8]);
            j = float.Parse(Black_Skill_Point[9]);
        }
        else if (DoveChoice == 2)
        {
            a = float.Parse(White_Skill_Point[0]);
            b = float.Parse(White_Skill_Point[1]);
            c = float.Parse(White_Skill_Point[2]);
            d = float.Parse(White_Skill_Point[3]);
            e = float.Parse(White_Skill_Point[4]);
            f = float.Parse(White_Skill_Point[5]);
            g = float.Parse(White_Skill_Point[6]);
            h = float.Parse(White_Skill_Point[7]);
            i = float.Parse(White_Skill_Point[8]);
            j = float.Parse(White_Skill_Point[9]);
        }
        else if (DoveChoice == 3)
        {
            a = float.Parse(Eagle_Skill_Point[0]);
            b = float.Parse(Eagle_Skill_Point[1]);
            c = float.Parse(Eagle_Skill_Point[2]);
            d = float.Parse(Eagle_Skill_Point[3]);
            e = float.Parse(Eagle_Skill_Point[4]);
            f = float.Parse(Eagle_Skill_Point[5]);
            g = float.Parse(Eagle_Skill_Point[6]);
            h = float.Parse(Eagle_Skill_Point[7]);
            i = float.Parse(Eagle_Skill_Point[8]);
            j = float.Parse(Eagle_Skill_Point[9]);
        }
        else if (DoveChoice == 4)
        {
            a = float.Parse(Dora_Skill_Point[0]);
            b = float.Parse(Dora_Skill_Point[1]);
            c = float.Parse(Dora_Skill_Point[2]);
            d = float.Parse(Dora_Skill_Point[3]);
            e = float.Parse(Dora_Skill_Point[4]);
            f = float.Parse(Dora_Skill_Point[5]);
            g = float.Parse(Dora_Skill_Point[6]);
            h = float.Parse(Dora_Skill_Point[7]);
            i = float.Parse(Dora_Skill_Point[8]);
            j = float.Parse(Dora_Skill_Point[9]);
        }
        else
        {
            a = 0;
            b = 0;
            c = 0;
            d = 0;
            e = 0;
            f = 0;
            g = 0;
            h = 0;
            i = 0;
            j = 0;
        }

        Upgrade_Hp += (a * Heart_Up_Value);
        Upgrade_Skill_Time += (b * Fly_Up_Value);
        Upgrade_Coin += (c * Coin_Up_Value);
        Upgrade_Item_Time += (d * Item_Up_Value);
        Upgrade_Hit_Time += (e * Hit_Up_Value);

        Upgrade_Move += (f * Move_Up_Value);
        Upgrade_Fever += (g * Fever_Up_Value);
        Upgrade_FlyDown += (h * FlyDown_Up_Value);
        Upgrade_Score2 += (i * Score2_Up_Value);
        Upgrade_Coin2 += (j * Coin2_Up_Value);

        Default_Black_Hp = 100;
        Default_White_Hp = 100;
        Default_Eagle_Hp = 150;
        Default_Dora_Hp = 80;

        switch(DoveChoice)
        {
            case 1:
                Default_Hp = Default_Black_Hp + Upgrade_Hp;
                break;
            case 2:
                Default_Hp = Default_White_Hp + Upgrade_Hp;
                break;
            case 3:
                Default_Hp = Default_Eagle_Hp + Upgrade_Hp;
                break;
            case 4:
                Default_Hp = Default_Dora_Hp + Upgrade_Hp;
                break;
        }

        Skill_Time = Fly_Default_Value + Upgrade_Skill_Time;
        //코인은 Upgrade_Coin을 직접 불러서 사용함.
        Item_Time = Item_Default_Value + Upgrade_Item_Time;
        Dove_Invincibel_Time = Hit_Default_Value + Upgrade_Hit_Time;

        //이동속도
        Fever_Time = Fever_Default_Value + Upgrade_Fever;
        Skill_CoolTime = FlyDown_Default_Value + Upgrade_FlyDown;
        //점수 2배
        //코인 2배



        //스킨
        BD_Sunshine_Skin = PlayerPrefs.GetInt("BD_Sunshine_Skin");
        BD_Clocking_Skin = PlayerPrefs.GetInt("BD_Clocking_Skin");
        BD_Rainbow_Skin = PlayerPrefs.GetInt("BD_Rainbow_Skin"); //게임매니저 코인 획득에서 직접 적용됩니다.

        if (DoveChoice != 3)
        {
            if(DoveChoice == 1)
            {
                int a = PlayerPrefs.GetInt("Sunshine_Black");
                if(a == 1 && BD_Sunshine_Skin == 1)
                {
                    Default_Hp = Mathf.RoundToInt(Default_Hp + (Default_Hp * 0.15f));
                }

                int b = PlayerPrefs.GetInt("Clocking_Black");
                if (b == 1 && BD_Clocking_Skin == 1)
                {
                    Item_Time = Mathf.RoundToInt(Item_Time + (Item_Time * 0.3f));
                }
            }
            else if(DoveChoice == 2)
            {
                int a = PlayerPrefs.GetInt("Sunshine_White");
                if (a == 1 && BD_Sunshine_Skin == 1)
                {
                    Default_Hp = Mathf.RoundToInt(Default_Hp + (Default_Hp * 0.15f));
                }

                int b = PlayerPrefs.GetInt("Clocking_White");
                if (b == 1 && BD_Clocking_Skin == 1)
                {
                    Item_Time = Mathf.RoundToInt(Item_Time + (Item_Time * 0.3f));
                }
            }
            else if (DoveChoice == 4)
            {
                int a = PlayerPrefs.GetInt("Sunshine_Dora");
                if (a == 1 && BD_Sunshine_Skin == 1)
                {
                    Default_Hp = Mathf.RoundToInt(Default_Hp + (Default_Hp * 0.15f));
                }

                int b = PlayerPrefs.GetInt("Clocking_Dora");
                if (b == 1 && BD_Clocking_Skin == 1)
                {
                    Item_Time = Mathf.RoundToInt(Item_Time + (Item_Time * 0.3f));
                }
            }
        }

        Default_Setting();
    } //스탯 찍은거 로드

    void Default_Setting()
    {
        SelectDoveCooltime = 0.05f;

        Advertising_Count = 1;
        BD_Diamond_Number = 5;
        BD_Diamond_Count = 3;
        //BD_Diamond = 10000; //임시 다이아100
        //BD_Coin = 1000000;

        //레벨값
        PlayerPrefs.SetInt("Lv_Default_Value", 60);
        PlayerPrefs.SetInt("Lv_Up_Value", 30);

        //날씨
        Weather_Cycle_Value = 40;

        //스킬값
        Skill_Default_Value = 1000;
        Skill_Up_Value = 500;

        //맵 이동속도
        Dove_Speed = 1.0f;
        Up_Speed = Dove_Speed * 0.1f;

        int a = PlayerPrefs.GetInt("Level");
        switch(a)
        {
            case 0:
                break;
            case 1:
                Dove_Speed += (Up_Speed * 2);
                break;
            case 2:
                Dove_Speed += (Up_Speed * 5);
                break;
        }
        //Debug.Log(Dove_Speed);


        //스코어 증가속도
        ScoreCooltime = 0.1f;

        //비둘기 기본 값
        Dove_Hp_Down_Speed = 1.0f;

        ShakeAmount = 0.03f; //화면 진동
        ShakeTime = 0.2f;

        Enemy_Dove_Score = 30;
        Enemy_Eagle_Score = 60;
        Enemy_Ufo_Score = 100;
        Enemy_Building_Score = 50;
        Enemy_Castle_Score = 250;
        Enemy_Olive_Score = 50;

        //보통 기준.
        Enemy_Dove_Random_CoolTime = 2.0f;
        Enemy_Dove_Create_CoolTime = 2.0f;
        Enemy_Eagle_Create_CoolTime = 8.0f;
        Enemy_Wave_Create_CoolTime = 5.0f;

        Enemy_Dove_Damage = 10;
        Enemy_Eagle_Damage = 25;

        Enemy_Ufo_Damage = 25;
        Enemy_Building_Damage = 35;
        Enemy_Ship_Damage = 20;
        Enemy_Wave_Damage = 15;
        Enemy_Mole_Damage = 12;
        Stone_Damage = 12;
        Car_Damage = 15;

        //오브젝트
        Object_Trash_Hp = 10;
        Object_Coin_Value = 20;

        Leaf_Time = 10;

        Mandu_Hp = 10;
        Candy_Hp = 10;

        People_Speed = 0.25f; //0.2f
        People_Random_Move_CoolTime = 3f;

        Car_Random_CoolTime = 1.5f;

        Under_Time_Value = 22;
        Castle_Time_Value = 14;

        //아이템
        Item_Heart_Hp = 25;
        Item_Diamond_Number = 1;
        Item_Dora_Number = 1;

        //생성시간
        Object_Coin_Create_CoolTime = 3f;
        Object_Item_Create_CoolTime = 6f;

        //단계
        Max_Level = 10;


        //조력자(부엉이)
        Owl_CoolTime = 20;
        Owl_Default_Value = 5;
        Owl_Up_Value = 1;

        Duck_Default_Value = 120;
        Duck_Up_Value = 6;
    }

    //로딩씬
    public void OneGo()
    {
        LoadingScene(1);
    }
    public void TwoGo()
    {
        LoadingScene(2);
    }
    public void ThreeGo()
    {
        LoadingScene(3);
    }
    public void FourGo()
    {
        LoadingScene(4);
    }
    public void FiveGo()
    {
        LoadingScene(5);
    }
    public void SixGo()
    {
        LoadingScene(6);
    }
    public void LoadingScene(int number)
    {
        LoadingCode = number;
        SceneManager.LoadScene("Load");
    }

    public void Black_Alivetime_Up()
    {
        BD_Black_AliveTime = PlayerPrefs.GetInt("BD_Black_AliveTime");
        BD_Black_AliveTime += 9999;
        PlayerPrefs.SetInt("BD_Black_AliveTime", BD_Black_AliveTime);
    }

    public void White_Alivetime_Up()
    {
        BD_Black_AliveTime = PlayerPrefs.GetInt("BD_White_AliveTime");
        BD_White_AliveTime += 9999;
        PlayerPrefs.SetInt("BD_White_AliveTime", BD_White_AliveTime);
    }

    public void Eagle_Alivetime_Up()
    {
        BD_Black_AliveTime = PlayerPrefs.GetInt("BD_Eagle_AliveTime");
        BD_Eagle_AliveTime += 9999;
        PlayerPrefs.SetInt("BD_Eagle_AliveTime", BD_Eagle_AliveTime);
    }

    public void Dora_Alivetime_Up()
    {
        BD_Black_AliveTime = PlayerPrefs.GetInt("BD_Dora_AliveTime");
        BD_Dora_AliveTime += 9999;
        PlayerPrefs.SetInt("BD_Dora_AliveTime", BD_Dora_AliveTime);
    }

    public void Black_Alivetime_Zero()
    {
        PlayerPrefs.SetInt("BD_Black_AliveTime", 0);
        PlayerPrefs.SetInt("BD_Black_Skill_Value", 0);
        PlayerPrefs.SetInt("Black_Skill_Point_All", 0);
        PlayerPrefs.SetInt("Black_Skill_Point_Total", 0);
        PlayerPrefs.SetString("Black_Skill_Point_Save", "0000000000");
    }

    public void White_Alivetime_Zero()
    {
        PlayerPrefs.SetInt("BD_White_AliveTime", 0);
        PlayerPrefs.SetInt("BD_White_Skill_Value", 0);
        PlayerPrefs.SetInt("White_Skill_Point_All", 0);
        PlayerPrefs.SetInt("White_Skill_Point_Total", 0);
        PlayerPrefs.SetString("White_Skill_Point_Save", "0000000000");
    }

    public void Eagle_Alivetime_Zero()
    {
        PlayerPrefs.SetInt("BD_Eagle_AliveTime", 0);
        PlayerPrefs.SetInt("BD_Eagle_Skill_Value", 0);
        PlayerPrefs.SetInt("Eagle_Skill_Point_All", 0);
        PlayerPrefs.SetInt("Eagle_Skill_Point_Total", 0);
        PlayerPrefs.SetString("Eagle_Skill_Point_Save", "0000000000");
    }

    public void Dora_Alivetime_Zero()
    {
        PlayerPrefs.SetInt("BD_Dora_AliveTime", 0);
        PlayerPrefs.SetInt("BD_Dora_Skill_Value", 0);
        PlayerPrefs.SetInt("Dora_Skill_Point_All", 0);
        PlayerPrefs.SetInt("Dora_Skill_Point_Total", 0);
        PlayerPrefs.SetString("Dora_Skill_Point_Save", "0000000000");
    }

    public void Owl_Points_Up()
    {
        int a = PlayerPrefs.GetInt("BD_Owl_Points");
        a += 1000;
        PlayerPrefs.SetInt("BD_Owl_Points", a);
    }

    public void Duck_Points_Up()
    {
        int a = PlayerPrefs.GetInt("BD_Duck_Points");
        a += 1000;
        PlayerPrefs.SetInt("BD_Duck_Points", a);
    }

    public void Owl_Points_Zero()
    {
        PlayerPrefs.SetInt("BD_Owl_Points", 0);
        PlayerPrefs.SetInt("BD_Owl_Lv", 0);
    }

    public void Duck_Points_Zero()
    {
        PlayerPrefs.SetInt("BD_Duck_Points", 0);
        PlayerPrefs.SetInt("BD_Duck_Lv", 0);
    }

    public void Score_Up()
    {
        int a = PlayerPrefs.GetInt("AllScore");
        a += 1000;
        PlayerPrefs.SetInt("AllScore", a);
    }

    public void Score_Down()
    {
        int a = PlayerPrefs.GetInt("AllScore");
        a -= 500;
        PlayerPrefs.SetInt("AllScore", a);
    }

    public void Score_Retry()
    {
        ProgressManager.instance.Renewal();
    }

    public void Skin_Reset()
    {
        PlayerPrefs.SetInt("BD_Sunshine_Skin", 0);
        PlayerPrefs.SetInt("BD_Clocking_Skin", 0);
        PlayerPrefs.SetInt("BD_Rainbow_Skin", 0);
    }

    public void Skin_Up()
    {
        PlayerPrefs.SetInt("BD_Sunshine_Skin",1);
        PlayerPrefs.SetInt("BD_Clocking_Skin",1);
        PlayerPrefs.SetInt("BD_Rainbow_Skin",1);
    }


    public void Stage_Up()
    {
        NowStage = GameManager.instance.NowStage;
        if (NowStage <= Max_Level)
        {
            Dove_Speed += Up_Speed;
            //Debug.Log(Dove_Speed);

            MapCtrl.instance.Stage_Up();
            FollowCtrl.instance.Stage_Up();
            DoveTouch.instance.Stage_Up();
        }
        else
        {
            //Debug.Log(Max_Level + "단계에 도달하여 더 이상 속도가 증가되지 않습니다.");
        }
    }

    void LateUpdate()
    {
        MyWitch.transform.position = Camera.main.transform.position;
    }
}