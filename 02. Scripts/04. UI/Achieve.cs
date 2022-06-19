using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Achieve : MonoBehaviour
{
    public static Achieve instance;

    private int BD_Coin;
    private int BD_Diamond;
    private int BD_Dora_Feather;

    public string value = ""; //업적 고유 번호
    private int Value;
    private int Language;

    public UILabel Title;
    public UILabel Content;
    public UILabel False_txt; //보상 글자

    public UISprite Reward_Sprite; //코인 다이아 깃털 뭐든 될 수 있음
    public UISprite Reward_Sprite_Shadow;
    public UILabel Reward_Number_txt; //그거에 대한 보상 개수
    private string[] Reward_sp = { "Coin_1", "다이아", "도라의 깃털", "비둘기 알" };

    public UISprite Fillter;
    public UILabel Fillter_txt;

    public GameObject Bar;
    public GameObject Reward;
    public UILabel Reward_txt;
    public GameObject False; //보상 글자 on off
    public GameObject Clear;

    public GameObject Heart_1;
    public GameObject Heart_2;
    public GameObject Heart_3;
    public GameObject Heart_4;
    public GameObject Heart_5;
    public GameObject Heart_6;
    public GameObject Heart_7;
    public GameObject Heart_8;
    public GameObject Heart_9;
    public GameObject Heart_10;

    private List<GameObject> Heart = new List<GameObject>();


    //업적 종류(순서대로)
    private int Achieve_Advertising;
    private int Achieve_Main_Quest;
    private int Achieve_Sub_Quest;
    private int Achieve_Score;
    private int Achieve_Egg;
    private int Achieve_Item;
    private int Achieve_Skill;
    private int Achieve_UFO;
    private int Achieve_Hidden;
    private int Achieve_Level;
    private int Achieve_NPC;




    //업적 현재 값
    private int Achieve_Number;
    private string[] Achieve_Title = { "Achieve_AD","Achieve_Achieve","Achieve_Score","Achieve_AliveTime","Achieve_Level","Achieve_Item","Achieve_Skill","Achieve_Hp","Achieve_Damage",
        "Achieve_Fever","Achieve_Weather","Achieve_Npc","Achieve_Ufo","Achieve_Hidden","Achieve_Coin","Achieve_Diamond","Achieve_Egg","Achieve_Dove"};


    //업적 보상 종류
    private int Achieve_Reward_Kind_Number;

    //업적 단계 횟수 세이브
    private int Achieve_Goal_Save_Number;

    //업적 단계 횟수에 따른 다음 목표치 변화
    private int Achieve_Goal_Number;

    private int[] Achieve_Goal_1 = { 1, 3, 5, 10, 20, 30, 40, 60, 80, 100 };
    private int[] Achieve_Goal_2 = { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };
    private int[] Achieve_Goal_3 = { 5000, 10000, 20000, 40000, 80000, 150000, 300000, 500000, 750000, 1000000 };
    private int[] Achieve_Goal_4 = { 300, 600, 1200, 2400, 5000, 10000, 12500, 25000, 50000, 100000 };
    private int[] Achieve_Goal_5 = { 5, 10, 20, 30, 40, 50, 75, 100, 150, 200 };
    private int[] Achieve_Goal_6 = { 20, 40, 60, 80, 100, 120, 140, 160, 180, 200 };
    private int[] Achieve_Goal_7 = { 5, 10, 20, 30, 40, 50, 75, 100, 150, 200 };
    private int[] Achieve_Goal_8 = { 300, 600, 1200, 2400, 5000, 10000, 12500, 25000, 50000, 100000 };
    private int[] Achieve_Goal_9 = { 300, 600, 1200, 2400, 5000, 10000, 12500, 25000, 50000, 100000 };
    private int[] Achieve_Goal_10 = { 5, 10, 20, 30, 40, 50, 75, 100, 150, 200 };
    private int[] Achieve_Goal_11 = { 5, 10, 20, 30, 40, 50, 75, 100, 150, 200 };
    private int[] Achieve_Goal_12 = { 5, 10, 20, 30, 40, 50, 75, 100, 150, 200 };
    private int[] Achieve_Goal_13 = { 1, 3, 5, 10, 20, 30, 40, 60, 80, 100 };
    private int[] Achieve_Goal_14 = { 1, 3, 5, 10, 20, 30, 40, 60, 80, 100 };
    private int[] Achieve_Goal_15 = { 50000, 100000, 200000, 400000, 800000, 1500000, 3000000, 5000000, 7500000, 10000000 };
    private int[] Achieve_Goal_16 = { 50, 100, 200, 400, 800, 1500, 3000, 5000, 7500, 10000 };
    private int[] Achieve_Goal_17 = { 20, 40, 60, 80, 100, 120, 140, 160, 180, 200 };
    private int[] Achieve_Goal_18 = { 20, 40, 60, 80, 100, 120, 140, 160, 180, 200 };

    //업적 단계 회수에 따른 보상 변화
    private int Achieve_Reward_Number;

    private int[] Achieve_Reward_1 = { 20, 40, 60, 80, 100, 120, 140, 160, 180, 200 };
    private int[] Achieve_Reward_2 = { 20, 40, 60, 80, 100, 120, 140, 160, 180, 200 };
    private int[] Achieve_Reward_3 = { 1000, 2500, 5000, 10000, 15000, 25000, 40000, 60000, 80000, 100000 };
    private int[] Achieve_Reward_4 = { 1000, 2500, 5000, 10000, 15000, 25000, 40000, 60000, 80000, 100000 };
    private int[] Achieve_Reward_5 = { 1000, 2500, 5000, 10000, 15000, 25000, 40000, 60000, 80000, 100000 };
    private int[] Achieve_Reward_6 = { 1000, 2500, 5000, 10000, 15000, 25000, 40000, 60000, 80000, 100000 };
    private int[] Achieve_Reward_7 = { 1000, 2500, 5000, 10000, 15000, 25000, 40000, 60000, 80000, 100000 };
    private int[] Achieve_Reward_8 = { 1000, 2500, 5000, 10000, 15000, 25000, 40000, 60000, 80000, 100000 };
    private int[] Achieve_Reward_9 = { 1000, 2500, 5000, 10000, 15000, 25000, 40000, 60000, 80000, 100000 };
    private int[] Achieve_Reward_10 = { 1000, 2500, 5000, 10000, 15000, 25000, 40000, 60000, 80000, 100000 };
    private int[] Achieve_Reward_11 = { 5, 10, 20, 30, 40, 50, 75, 100, 150, 200 };
    private int[] Achieve_Reward_12 = { 1000, 2500, 5000, 10000, 15000, 25000, 40000, 60000, 80000, 100000 };
    private int[] Achieve_Reward_13 = { 20, 40, 60, 80, 100, 120, 140, 160, 180, 200 };
    private int[] Achieve_Reward_14 = { 20, 40, 60, 80, 100, 120, 140, 160, 180, 200 };
    private int[] Achieve_Reward_15 = { 20, 40, 60, 80, 100, 120, 140, 160, 180, 200 };
    private int[] Achieve_Reward_16 = { 1000, 2500, 5000, 10000, 15000, 25000, 40000, 60000, 80000, 100000 };
    private int[] Achieve_Reward_17 = { 1000, 2500, 5000, 10000, 15000, 25000, 40000, 60000, 80000, 100000 };
    private int[] Achieve_Reward_18 = { 5, 10, 20, 30, 40, 50, 75, 100, 150, 200 };




    //언어설정

    //1
    private string[] Content_Title_Korean = { "광고 시청","업적 달성","총합 점수","총합 생존시간","총합 단계","아이템 획득","스킬 사용","총합 체력 회복량","총합 받은 데미지","피버 모드 발동",
        "날씨 변경","NPC와 대화하기","UFO 납치","히든 스테이지 진입","총합 코인 사용","총합 다이아 사용","총합 알까기","비둘기 총합 레벨","히든 업적" };
    private string[] Content_False_Korean = { "보상" ,"보상 받기"};

    private string[] Content_Title_English = { "Watch an Ad", "Achievement", "Total Score", "Total Survival Time", "Total Stage",  "Get Item", "Use Skill",
        "Total HP Recovery", "Total Damage", "Active Fever Mode", "Changes Weather", "Talk to NPC","Kidnapped By UFO", "Enter Hidden Stage", "Total Coin Use",
        "Total Diamond Use","Hit Shop Eggs", "Dove Total Level", "Hidden Achievement" };

    private string[] Content_False_English = { "Reward","Get Reward"};

    private string[] Content_Title_Chinese = { "收看广告", "实现业绩", "累积分数", "累计生存时间", "累积步骤", "项目获得", "使用技能", "累积体力恢复量", "累计收货", "活动热度模式",
        "天气变化", "与NPC对话", "UFO绑架", "进入隐藏空间","累计使用硬币", "累计使用钻石", "累计采卵", "鸽子总合标签","隐藏的业绩" };
    private string[] Content_False_Chinese = { "奖励","得到奖励" };

    private string[] Content_Title_Japanese = { "広告を得る", "成果", "点数を得る", "生存時間を得る", "段階を得る", "アイテムを取得", "スキルを使用する", "健康回復を得る", "ダメージを得る",
        "アクティブフィーバーモード","天気を変える", "NPCと話す", "宇宙船拉致","非表示のフェーズに入る","コインを使用を得る", "宝石を使用を得る", "ヒットエッグ", "アプローチ鳩合計","隠された業績"  };
    private string[] Content_False_Japanese = { "褒賞" ,"報酬を得る"};

    void Awake()
    {
        instance = this;

        Clear.SetActive(false);
        Reward.SetActive(false);

        Heart.Add(Heart_1);
        Heart.Add(Heart_2);
        Heart.Add(Heart_3);
        Heart.Add(Heart_4);
        Heart.Add(Heart_5);
        Heart.Add(Heart_6);
        Heart.Add(Heart_7);
        Heart.Add(Heart_8);
        Heart.Add(Heart_9);
        Heart.Add(Heart_10);

        Value = int.Parse(value);
    }

    void OnEnable()
    {
        Achieve_Reward_Kind_Number = PlayerPrefs.GetInt("Achieve_Reward_Kind_" + value); //업적 보상 종류 (매니저에서 관리) 1번 받고 끝

        Renewal();
    }
    public void Renewal()
    {
        BD_Coin = PlayerPrefs.GetInt("BD_Coin");
        BD_Diamond = PlayerPrefs.GetInt("BD_Diamond");
        BD_Dora_Feather = PlayerPrefs.GetInt("BD_Dora_Feather");

        Achieve_Number = PlayerPrefs.GetInt(Achieve_Title[Value - 1]); //업적 현재 값
        Achieve_Goal_Save_Number = PlayerPrefs.GetInt("Achieve_Goal_Save_" + value); //업적 단계 횟수 세이브

        Load_Goal_Reward(); //업적 단계 횟수에 따른 다음 목표치 변화 / 업적 단계 횟수에 따른 보상 변화
        Load_Language(); //언어 설정 불러오기
        Load_Sprite(Achieve_Goal_Save_Number); //업적 레벨에 따라 하트 스프라이트, 보상 값, 필터 변경하기

        Reward_Check();

    }
    void Load_Goal_Reward()
    {
        switch (Value)
        {
            case 1:
                Achieve_Goal_Number = Achieve_Goal_1[Achieve_Goal_Save_Number];
                Achieve_Reward_Number = Achieve_Reward_1[Achieve_Goal_Save_Number];
                break;
            case 2:
                Achieve_Goal_Number = Achieve_Goal_2[Achieve_Goal_Save_Number];
                Achieve_Reward_Number = Achieve_Reward_2[Achieve_Goal_Save_Number];
                break;
            case 3:
                Achieve_Goal_Number = Achieve_Goal_3[Achieve_Goal_Save_Number];
                Achieve_Reward_Number = Achieve_Reward_3[Achieve_Goal_Save_Number];
                break;
            case 4:
                Achieve_Goal_Number = Achieve_Goal_4[Achieve_Goal_Save_Number];
                Achieve_Reward_Number = Achieve_Reward_4[Achieve_Goal_Save_Number];
                break;
            case 5:
                Achieve_Goal_Number = Achieve_Goal_5[Achieve_Goal_Save_Number];
                Achieve_Reward_Number = Achieve_Reward_5[Achieve_Goal_Save_Number];
                break;
            case 6:
                Achieve_Goal_Number = Achieve_Goal_6[Achieve_Goal_Save_Number];
                Achieve_Reward_Number = Achieve_Reward_6[Achieve_Goal_Save_Number];
                break;
            case 7:
                Achieve_Goal_Number = Achieve_Goal_7[Achieve_Goal_Save_Number];
                Achieve_Reward_Number = Achieve_Reward_7[Achieve_Goal_Save_Number];
                break;
            case 8:
                Achieve_Goal_Number = Achieve_Goal_8[Achieve_Goal_Save_Number];
                Achieve_Reward_Number = Achieve_Reward_8[Achieve_Goal_Save_Number];
                break;
            case 9:
                Achieve_Goal_Number = Achieve_Goal_9[Achieve_Goal_Save_Number];
                Achieve_Reward_Number = Achieve_Reward_9[Achieve_Goal_Save_Number];
                break;
            case 10:
                Achieve_Goal_Number = Achieve_Goal_10[Achieve_Goal_Save_Number];
                Achieve_Reward_Number = Achieve_Reward_10[Achieve_Goal_Save_Number];
                break;
            case 11:
                Achieve_Goal_Number = Achieve_Goal_11[Achieve_Goal_Save_Number];
                Achieve_Reward_Number = Achieve_Reward_11[Achieve_Goal_Save_Number];
                break;
            case 12:
                Achieve_Goal_Number = Achieve_Goal_12[Achieve_Goal_Save_Number];
                Achieve_Reward_Number = Achieve_Reward_12[Achieve_Goal_Save_Number];
                break;
            case 13:
                Achieve_Goal_Number = Achieve_Goal_13[Achieve_Goal_Save_Number];
                Achieve_Reward_Number = Achieve_Reward_13[Achieve_Goal_Save_Number];
                break;
            case 14:
                Achieve_Goal_Number = Achieve_Goal_14[Achieve_Goal_Save_Number];
                Achieve_Reward_Number = Achieve_Reward_14[Achieve_Goal_Save_Number];
                break;
            case 15:
                Achieve_Goal_Number = Achieve_Goal_15[Achieve_Goal_Save_Number];
                Achieve_Reward_Number = Achieve_Reward_15[Achieve_Goal_Save_Number];
                break;
            case 16:
                Achieve_Goal_Number = Achieve_Goal_16[Achieve_Goal_Save_Number];
                Achieve_Reward_Number = Achieve_Reward_16[Achieve_Goal_Save_Number];
                break;
            case 17:
                Achieve_Goal_Number = Achieve_Goal_17[Achieve_Goal_Save_Number];
                Achieve_Reward_Number = Achieve_Reward_17[Achieve_Goal_Save_Number];
                break;
            case 18:
                Achieve_Goal_Number = Achieve_Goal_18[Achieve_Goal_Save_Number];
                Achieve_Reward_Number = Achieve_Reward_18[Achieve_Goal_Save_Number];
                break;
        }
    }


    void Load_Language() //0 한국어 ,1 영어, 2 중국어, 3 일본어
    {
        Language = PlayerPrefs.GetInt("Language");

        switch (Language)
        {
            case 1:
                Title.text = Content_Title_Korean[Value - 1];
                False_txt.text = Content_False_Korean[0];
                Reward_txt.text = Content_False_Korean[1];
                break;
            case 2:
                Title.text = Content_Title_English[Value - 1];
                False_txt.text = Content_False_English[0];
                Reward_txt.text = Content_False_English[1];
                break;
            case 3:
                Title.text = Content_Title_Chinese[Value - 1];
                False_txt.text = Content_False_Chinese[0];
                Reward_txt.text = Content_False_Chinese[1];
                break;
            case 4:
                Title.text = Content_Title_Japanese[Value - 1];
                False_txt.text = Content_False_Japanese[0];
                Reward_txt.text = Content_False_Japanese[1];
                break;
        }
    }
    void Load_Sprite(int number)
    {
        Reward_Sprite.spriteName = Reward_sp[Achieve_Reward_Kind_Number];
        Reward_Sprite_Shadow.spriteName = Reward_sp[Achieve_Reward_Kind_Number];
        Reward_Number_txt.text = Achieve_Reward_Number.ToString();

        if(Achieve_Reward_Kind_Number == 0)
        {
            Reward_Sprite.GetComponent<Coin>().enabled = true;
            Reward_Sprite_Shadow.GetComponent<Coin>().enabled = true;
        }
        else
        {
            Reward_Sprite.GetComponent<Coin>().enabled = false;
            Reward_Sprite_Shadow.GetComponent<Coin>().enabled = false;
        }


        float a = Achieve_Number;
        float b = Achieve_Goal_Number;
        Fillter.fillAmount = a / b;
        Fillter_txt.text = Achieve_Number.ToString() + " / " + Achieve_Goal_Number.ToString();


        for(int i =0;i<Heart.Count;i++) //전부 비활성화
        {
            Heart[i].GetComponent<UISprite>().color = new Color(0, 0, 0, 130 / 255f);
        }

        for(int i =0;i<number+1; i++) //개수만큼 활성화
        {
            Heart[i].GetComponent<UISprite>().color = new Color(1, 1, 1, 1);
        }
    }

    void Reward_Check() //목표에 도달했는지 체크
    {
        if(Achieve_Goal_Save_Number < 9)
        {
            if(Achieve_Number >= Achieve_Goal_Number)
            {
                if (PlayerPrefs.GetInt("Achieve_" + value) == 0)
                {
                    AlarmManager.instance.Alarm_Plus_Achieve();
                    PlayerPrefs.SetInt("Achieve_" + value, 1);
                }

                Bar.SetActive(false);
                Reward.SetActive(true);
                StopAllCoroutines();
                StartCoroutine(Reward_Btn_Size());
            }
            else
            {
                Bar.SetActive(true);
                Reward.SetActive(false);
            }
        }
        else
        {
            Bar.SetActive(false);
            Reward.SetActive(false);
            False.SetActive(false);
            Clear.SetActive(true);

        }
    }

    IEnumerator Reward_Btn_Size()
    {

        Reward.GetComponent<Transform>().localScale = new Vector3(1.1f, 1.1f, 0);
        yield return new WaitForSeconds(0.1f);
        Reward.GetComponent<Transform>().localScale = new Vector3(1.0f, 1.0f, 0);
        yield return new WaitForSeconds(1.2f);
        StartCoroutine(Reward_Btn_Size());
    }

    public void Reward_Btn()
    {
        AlarmManager.instance.Alarm_Minus_Achieve();
        PlayerPrefs.SetInt("Achieve_" + value, 0);

        Reward_In(Achieve_Reward_Number);
        LanguageManager.instance.Success_Reward_Notion();

        //업적 - 누적 업적
        int a = PlayerPrefs.GetInt("Achieve_Achieve");
        a += 1;
        PlayerPrefs.SetInt("Achieve_Achieve",a);

        Achieve_Goal_Save_Number += 1;
        PlayerPrefs.SetInt("Achieve_Goal_Save_" +value, Achieve_Goal_Save_Number);

        Achieve_Number -= Achieve_Goal_Number;
        PlayerPrefs.SetInt(Achieve_Title[Value - 1], Achieve_Number);

        AchieveManager.instance.Renewal();
    }

    void Reward_In(int number)
    {
        if(Achieve_Reward_Kind_Number == 0)
        {
            BD_Coin += number;
            PlayerPrefs.SetInt("BD_Coin", BD_Coin);
        }
        else if (Achieve_Reward_Kind_Number == 1)
        {
            BD_Diamond += number;
            PlayerPrefs.SetInt("BD_Diamond", BD_Diamond);
        }
        else if (Achieve_Reward_Kind_Number == 2)
        {
            BD_Dora_Feather += number;
            PlayerPrefs.SetInt("BD_Dora_Feather", BD_Dora_Feather);
        }
        else if (Achieve_Reward_Kind_Number == 3)
        {

        }
    }

    public void Google_Achieve()
    {
        GooglePlayManager.instance.ShowAchievementUI();
    }
}
