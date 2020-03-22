using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public static ShopManager instance;

    public ParticleSystem Egg_System;

    public GameObject EasterEgg_GoldEgg;
    public GameObject EasterEgg_GoldEgg_Incubator;

    public GameObject IncubatorWindow;

    public UILabel Main_Title_txt; // 상점
    public UILabel Egg_Title_txt; // 알
    public UILabel Item_Title_txt; // 아이템
    public UILabel Coin_Title_txt; // 코인
    public UILabel Incubator_txt; // 알 부화기

    //부화기
    private bool EggOpen;
    public GameObject Incubator_OpenWindow;

    public UILabel Dove_Egg_txt;
    public UILabel Owl_Egg_txt;
    public UILabel Eagle_Egg_txt;
    public UILabel Gold_Egg_txt;

    public GameObject Dove_Egg_Rock;
    public GameObject Owl_Egg_Rock;
    public GameObject Eagle_Egg_Rock;
    public GameObject Gold_Egg_Rock;


    public UISprite Main_Sprite;
    public UISprite Shadow_Sprite;

    public UILabel Main_txt;
    public UILabel Rare_txt;
    public UILabel Plus_txt;
    public UILabel Hold_txt;

    //조력자 최대값
    private int[] Lv_Up_Value = { 5, 10, 20, 40, 80, 120, 200, 300, 500, 800, 0 };
    private int Max_Path;
    private int Max_Owl;
    private int Max_Duck;

    //획득 값
    private int Get_Coin;
    private int Get_Diamond;
    private int Get_Feather;
    private int Get_Aid_Kind;
    private int Get_Aid;
    private int Skin_Value;
    private int Char_Value;


    //마일리지
    public GameObject Mileage_Notion;

    public UILabel Mileage_Main_txt; // 알 마일리지
    public UILabel Mileage_Hold_txt; // X99
    public UISprite Mileage_Fillter;

    private int mileage; // 마일리지를 10으로 나눈 수


    private List<string> Incubator_Egg = new List<string>();
    private List<string> Incubator_Rare = new List<string>();


    //보유
    private int BD_Coin;
    private int BD_Diamond;
    private int BD_Dora_Feather;
    private int Mileage;

    private int BD_Dove_Egg;
    private int BD_Owl_Egg;
    private int BD_Eagle_Egg;
    private int BD_Gold_Egg;

    private int BD_Hard_Ticket;

    private int BD_White; //비둘기 보유 여부
    private int BD_Eagle;
    private int BD_Dora;

    private int BD_Sunshine_Skin; //스킨 보유 여부
    private int BD_Clocking_Skin;
    private int BD_Rainbow_Skin;

    private int BD_Owl_Lv;
    private int BD_Duck_Lv;

    private int BD_Owl_Points;
    private int BD_Duck_Points;

    //무료 알
    public UILabel Free_Egg_txt;
    public GameObject Free_Egg_Shadow;

    public Shop shop;

    //광고
    public UILabel RewardAd_txt;
    public GameObject Reward_Shadow;


    void Awake()
    {
        instance = this;

        if (Egg_System != null)
        {
            EggOpen = true;

            Egg_System.Stop();

            IncubatorWindow.SetActive(false);
            Incubator_OpenWindow.SetActive(false);
            Mileage_Notion.SetActive(false);

            EasterEgg_GoldEgg.SetActive(false);
            EasterEgg_GoldEgg_Incubator.SetActive(false);
        }
    }

    public void Language_Setting()
    {
        if (Incubator_Egg.Count > 0)
        {
            Incubator_Egg.Clear();
            Incubator_Rare.Clear();
        }
        int a = PlayerPrefs.GetInt("Language");
        switch (a)
        {
            case 0:
                for (int i = 0; i < LanguageManager.instance.Incubator_Egg_Korean.Length; i++)
                {
                    string b = LanguageManager.instance.Incubator_Egg_Korean[i];
                    Incubator_Egg.Add(b);
                }
                for (int i = 0; i < LanguageManager.instance.Incubator_Rare_Korean.Length; i++)
                {
                    string b = LanguageManager.instance.Incubator_Rare_Korean[i];
                    Incubator_Rare.Add(b);
                }
                break;
            case 1:
                for (int i = 0; i < LanguageManager.instance.Incubator_Egg_English.Length; i++)
                {
                    string b = LanguageManager.instance.Incubator_Egg_English[i];
                    Incubator_Egg.Add(b);
                }
                for (int i = 0; i < LanguageManager.instance.Incubator_Rare_English.Length; i++)
                {
                    string b = LanguageManager.instance.Incubator_Rare_English[i];
                    Incubator_Rare.Add(b);
                }
                break;
            case 2:
                for (int i = 0; i < LanguageManager.instance.Incubator_Egg_Chinese.Length; i++)
                {
                    string b = LanguageManager.instance.Incubator_Egg_Chinese[i];
                    Incubator_Egg.Add(b);
                }
                for (int i = 0; i < LanguageManager.instance.Incubator_Rare_Chinese.Length; i++)
                {
                    string b = LanguageManager.instance.Incubator_Rare_Chinese[i];
                    Incubator_Rare.Add(b);
                }
                break;
            case 3:
                for (int i = 0; i < LanguageManager.instance.Incubator_Egg_Japanese.Length; i++)
                {
                    string b = LanguageManager.instance.Incubator_Egg_Japanese[i];
                    Incubator_Egg.Add(b);
                }
                for (int i = 0; i < LanguageManager.instance.Incubator_Rare_Japanese.Length; i++)
                {
                    string b = LanguageManager.instance.Incubator_Rare_Japanese[i];
                    Incubator_Rare.Add(b);
                }
                break;
        }
    }

    void OnEnable()
    {
        Free_Egg_Check();
        RewardAd_Check();

        if (Egg_System != null)
        {
            int a = PlayerPrefs.GetInt("2016041820161103");
            if (a == 1)
            {
                EasterEgg_GoldEgg.SetActive(true);
                EasterEgg_GoldEgg_Incubator.SetActive(true);
            }
        }
    }

    void OnDisable()
    {
        StopAllCoroutines();
    }

    public void Reset()
    {
        int a = System.DateTime.Today.Year;
        int b = System.DateTime.Today.Month;
        int c = System.DateTime.Today.Day;
        string d = a.ToString() + "/" + b.ToString() + "/" + c.ToString();

        PlayerPrefs.SetInt(d, 0);
        PlayerPrefs.SetInt("Shop", 0);
    }

    void Free_Egg_Check()
    {
        int a = System.DateTime.Today.Year;
        int b = System.DateTime.Today.Month;
        int c = System.DateTime.Today.Day;
        string d = a.ToString() + "/" + b.ToString() + "/" + c.ToString();

        int e = PlayerPrefs.GetInt(d);


        if (e == 0)
        {
            if (Egg_System != null)
            {
                Free_Egg_txt.text = "x3";
                Free_Egg_Shadow.SetActive(false);

                int f = PlayerPrefs.GetInt("Shop");
                if (f == 0)
                {
                    PlayerPrefs.SetInt("Shop", 1);
                    AlarmManager.instance.Alarm_Plus_Shop();
                }
            }
        }
        else
        {
            if (Egg_System != null)
            {
                Free_Egg_Shadow.SetActive(true);

                int f = PlayerPrefs.GetInt("Shop");
                if (f == 1)
                {
                    PlayerPrefs.SetInt("Shop", 0);
                    AlarmManager.instance.Alarm_Minus_Shop();
                }

                StartCoroutine(Free_Egg_Timer());
            }
        }
    }

    public void Free_Egg() //하루에 한 번 무료 알
    {
        int a = System.DateTime.Today.Year;
        int b = System.DateTime.Today.Month;
        int c = System.DateTime.Today.Day;
        string d = a.ToString() + "/" + b.ToString() + "/" + c.ToString();

        int e = PlayerPrefs.GetInt(d);

        if (e == 0)
        {
            if(BD_Owl_Egg +3 < 99)
            {
                BD_Owl_Egg = PlayerPrefs.GetInt("BD_Owl_Egg");
                BD_Owl_Egg += 3;
                PlayerPrefs.SetInt("BD_Owl_Egg", BD_Owl_Egg);
                PlayerPrefs.SetInt(d, 1);

                LanguageManager.instance.Success_Reward_Notion();

                shop.Renewal();

                Free_Egg_Check();
            }
            else
            {
                LanguageManager.instance.Max_limit_Notion();
            }
        }
        else
        {
            LanguageManager.instance.Now_Get_Notion();
        }
    }
    IEnumerator Free_Egg_Timer()
    {
        System.DateTime f = System.DateTime.Now;
        System.DateTime g = System.DateTime.Today.AddDays(1);
        System.TimeSpan h = g - f;

        int i = h.Hours;
        int j = h.Minutes;
        int k = h.Seconds;
        int total = i + j + k;

        string l, m, n;


        if(i > 9)
        {
            l = i.ToString();
        }
        else
        {
            l = "0"+i.ToString();
        }

        if(j > 9)
        {
            m = j.ToString();
        }
        else
        {
            m = "0" + j.ToString();
        }

        if(k > 9)
        {
            n = k.ToString();
        }
        else
        {
            n = "0" + k.ToString();
        }

        if(Free_Egg_txt != null)
        {
            Free_Egg_txt.text = l + ":" + m + ":" + n;
        }

        yield return new WaitForSeconds(1);

        if (total <= 0)
        {
            if (Egg_System != null)
            {
                Free_Egg_txt.text = "x3";
                Free_Egg_Shadow.SetActive(false);
                yield break;
            }
        }

        StartCoroutine(Free_Egg_Timer());
    }


    void RewardAd_Check()
    {
        string lastTime = PlayerPrefs.GetString("SaveLastTime");
        System.DateTime lastDateTime = System.DateTime.Parse(lastTime);
        System.TimeSpan compareTime = lastDateTime - System.DateTime.Now;

        int total = compareTime.Minutes + compareTime.Seconds;

        if(total > 0)
        {
            if (Egg_System != null)
            {
                StartCoroutine(RewardAd_Timer());
                Reward_Shadow.SetActive(true);
            }
        }
        else
        {
            if (Egg_System != null)
            {
                Reward_Shadow.SetActive(false);
            }
        }
    }

    IEnumerator RewardAd_Timer()
    {
        string lastTime = PlayerPrefs.GetString("SaveLastTime");
        System.DateTime lastDateTime = System.DateTime.Parse(lastTime);
        System.TimeSpan compareTime = lastDateTime - System.DateTime.Now;

        int j = compareTime.Minutes;
        int k = compareTime.Seconds;
        int total = j + k;

        string m, n;

        if (j > 9)
        {
            m = j.ToString();
        }
        else
        {
            m = "0" + j.ToString();
        }

        if (k > 9)
        {
            n = k.ToString();
        }
        else
        {
            n = "0" + k.ToString();
        }

        RewardAd_txt.text = m + ":" + n;
        yield return new WaitForSeconds(1);

        if (total <= 0)
        {
            Reward_Shadow.SetActive(false);
            int a = PlayerPrefs.GetInt("Language");
            switch (a)
            {
                case 0:
                    RewardAd_txt.text = "무료";
                    break;
                case 1:
                    RewardAd_txt.text = "Free";
                    break;
                case 2:
                    RewardAd_txt.text = "免费的";
                    break;
                case 3:
                    RewardAd_txt.text = "無料";
                    break;
            }
            yield break;
        }

        StartCoroutine(RewardAd_Timer());
    }
    public void RewardAd_Watch() //광고 버튼 클릭
    {
        string lastTime = PlayerPrefs.GetString("SaveLastTime");
        System.DateTime lastDateTime = System.DateTime.Parse(lastTime);
        System.TimeSpan compareTime = lastDateTime - System.DateTime.Now;

        int total = compareTime.Minutes + compareTime.Seconds;

        if (total <= 0)
        {
            AdmobRewardAd.instance.Show(2);
            //RewardAd_Clear(); //임시
        }
        else
        {
            LanguageManager.instance.RewardAd_Error_Notion();
        }
    }

    public void RewardAd_Clear()
    {
        BD_Diamond = PlayerPrefs.GetInt("BD_Diamond");
        BD_Diamond += Random.Range(30, 41);
        PlayerPrefs.SetInt("BD_Diamond", BD_Diamond);

        Reward_Shadow.SetActive(true);

        LanguageManager.instance.Success_Reward_Notion();

        PlayerPrefs.SetString("SaveLastTime", System.DateTime.Now.AddMinutes(10).ToString());
        StartCoroutine(RewardAd_Timer());
    }


    public void IncubatorWindowOpen() //부화기 오픈
    {
        IncubatorWindow.SetActive(true);
        Incubator_OpenWindow.SetActive(false);
        SelectManager.instance.Arrow_Stop();
        Language_Setting();

        Renewal();
    }

    public void Shop_Effect_Stop()
    {
        EggOpen = true;
        if(IncubatorWindow.activeSelf == true)
        {
            IncubatorWindow.SetActive(false);
            Mileage_Notion.SetActive(false);
            Egg_System.Stop();
        }
    }

    void Renewal()
    {
        BD_Coin = PlayerPrefs.GetInt("BD_Coin");
        BD_Diamond = PlayerPrefs.GetInt("BD_Diamond");
        BD_Dora_Feather = PlayerPrefs.GetInt("BD_Dora_Feather");

        Mileage = PlayerPrefs.GetInt("Mileage");
        mileage = PlayerPrefs.GetInt("mileage");

        Mileage_Fillter.fillAmount = mileage / 10.0f;
        Mileage_Hold_txt.text = "X" + Mileage.ToString();

        BD_Dove_Egg = PlayerPrefs.GetInt("BD_Dove_Egg");
        BD_Owl_Egg = PlayerPrefs.GetInt("BD_Owl_Egg");
        BD_Eagle_Egg = PlayerPrefs.GetInt("BD_Eagle_Egg");
        BD_Gold_Egg = PlayerPrefs.GetInt("BD_Gold_Egg");

        BD_Hard_Ticket = PlayerPrefs.GetInt("BD_Hard_Ticket");

        BD_White = PlayerPrefs.GetInt("BD_White", 0);
        BD_Eagle = PlayerPrefs.GetInt("BD_Eagle", 0);
        BD_Dora = PlayerPrefs.GetInt("BD_Dora", 0);

        BD_Sunshine_Skin = PlayerPrefs.GetInt("BD_Sunshine_Skin");
        BD_Clocking_Skin = PlayerPrefs.GetInt("BD_Clocking_Skin");
        BD_Rainbow_Skin = PlayerPrefs.GetInt("BD_Rainbow_Skin");

        Egg_Rock(BD_Dove_Egg, Dove_Egg_Rock, Dove_Egg_txt);
        Egg_Rock(BD_Owl_Egg, Owl_Egg_Rock, Owl_Egg_txt);
        Egg_Rock(BD_Eagle_Egg, Eagle_Egg_Rock, Eagle_Egg_txt);
        Egg_Rock(BD_Gold_Egg, Gold_Egg_Rock, Gold_Egg_txt);

        Max_Path = 0;

        for (int i = 0; i < Lv_Up_Value.Length; i++)
        {
            Max_Path += Lv_Up_Value[i];
        }

        BD_Owl_Lv = PlayerPrefs.GetInt("BD_Owl_Lv");
        BD_Duck_Lv = PlayerPrefs.GetInt("BD_Duck_Lv");

        Max_Owl = 0;
        Max_Duck = 0;

        Max_Owl = Max_Path;
        Max_Duck = Max_Path;

        for (int i = 0; i < BD_Owl_Lv; i++)
        {
            Max_Owl -= Lv_Up_Value[i];
        }

        for (int i = 0; i < BD_Duck_Lv; i++)
        {
            Max_Duck -= Lv_Up_Value[i];
        }

        BD_Owl_Points = PlayerPrefs.GetInt("BD_Owl_Points");
        BD_Duck_Points = PlayerPrefs.GetInt("BD_Duck_Points");

        if (BD_Owl_Points >= Max_Owl)
        {
            BD_Owl_Points = Max_Owl;
        }

        if (BD_Duck_Points >= Max_Duck)
        {
            BD_Duck_Points = Max_Duck;
        }
    }

    void Egg_Rock(int number,GameObject Rock, UILabel txt)
    {
        if(number > 0 )
        {
            Rock.SetActive(false);
            txt.text = number.ToString();
        }
        else
        {
            Rock.SetActive(true);
            txt.text = "";
        }
    }

    void  Egg_Zero()
    {
        LanguageManager.instance.Low_Egg_Notion();
    }

    public void Dove_Egg_Open()
    {
        if(EggOpen == true)
        {
            if (BD_Dove_Egg >= 1)
            {
                EggOpen = false;
                BD_Dove_Egg -= 1;
                PlayerPrefs.SetInt("BD_Dove_Egg", BD_Dove_Egg);
                Egg_Open(1);
            }
            else
            {
                Egg_Zero();
            }
        }
    }

    public void Owl_Egg_Open()
    {
        if (EggOpen == true)
        {
            if (BD_Owl_Egg >= 1)
            {
                EggOpen = false;
                BD_Owl_Egg -= 1;
                PlayerPrefs.SetInt("BD_Owl_Egg", BD_Owl_Egg);
                Egg_Open(2);
            }
            else
            {
                Egg_Zero();
            }
        }
    }

    public void Eagle_Egg_Open()
    {
        if (EggOpen == true)
        {
            if (BD_Eagle_Egg >= 1)
            {
                EggOpen = false;
                BD_Eagle_Egg -= 1;
                PlayerPrefs.SetInt("BD_Eagle_Egg", BD_Eagle_Egg);
                Egg_Open(3);
            }
            else
            {
                Egg_Zero();
            }
        }
    }

    public void Gold_Egg_Open()
    {
        if (EggOpen == true)
        {
            if (BD_Gold_Egg >= 1)
            {
                EggOpen = false;
                BD_Gold_Egg -= 1;
                PlayerPrefs.SetInt("BD_Gold_Egg", BD_Gold_Egg);
                Egg_Open(4);
            }
            else
            {
                Egg_Zero();
            }
        }
    }

    void Egg_Open(int number)
    {
        //업적 - 알 까기
        int b = PlayerPrefs.GetInt("Achieve_Egg");
        b += 1;
        PlayerPrefs.SetInt("Achieve_Egg", b);

        StopAllCoroutines();

        StartCoroutine(Free_Egg_Timer());
        StartCoroutine(RewardAd_Timer());

        Egg_System.Play();

        Incubator_OpenWindow.SetActive(false);
        Incubator_OpenWindow.SetActive(true);

        Main_Sprite.GetComponent<Coin>().enabled = false;

        if (number == 1)
        {
            Get_Coin = Random.Range(500, 751);
            Get_Diamond = Random.Range(5, 11);
            Get_Feather = Random.Range(1, 2);
            Get_Aid_Kind = 1;
            Get_Aid = Random.Range(10, 21);
            Skin_Value = 1;
            Char_Value = 1;
        }
        else if (number == 2)
        {
            Get_Coin = Random.Range(1000, 1501);
            Get_Diamond = Random.Range(10, 16);
            Get_Feather = Random.Range(2, 3);
            Get_Aid_Kind = 2;
            Get_Aid = Random.Range(20, 41);
            Skin_Value = 2;
            Char_Value = 2;
        }
        else if (number == 3)
        {
            Get_Coin = Random.Range(2000, 3001);
            Get_Diamond = Random.Range(15, 21);
            Get_Feather = Random.Range(3, 4);
            Get_Aid_Kind = 1;
            Get_Aid = Random.Range(30, 61);
            Skin_Value = 3;
            Char_Value = 3;
        }
        else if (number == 4)
        {
            Get_Coin = Random.Range(4000, 6001);
            Get_Diamond = Random.Range(20, 26);
            Get_Feather = Random.Range(4, 5);
            Get_Aid_Kind = 2;
            Get_Aid = Random.Range(40, 81);
            Skin_Value = Random.Range(1, 4);
            Char_Value = Random.Range(1, 4);
        }

        int a = Random.Range(0, 100);

        if (a >= 80)
        {
            //Debug.Log("코인");
            Egg_Mileage_Notion(1);

            Main_Sprite.spriteName = "Coin_1";
            Main_Sprite.GetComponent<Coin>().enabled = true;
            Shadow_Sprite.spriteName = "Coin_1";

            Main_txt.text = Incubator_Egg[0];
            Rare_txt.text = Incubator_Rare[0];

            Plus_txt.text = "+" + Get_Coin.ToString();
            Hold_txt.text = BD_Coin.ToString();

            int coin = BD_Coin;

            BD_Coin += Get_Coin;
            PlayerPrefs.SetInt("BD_Coin", BD_Coin);

            StartCoroutine(Wait(Get_Coin, coin, 0));
            EffectManager.instance.Box_Open_1();

        }
        else if (a >= 30)
        {
            //Debug.Log("조력자");
            Egg_Mileage_Notion(2);

            if (Get_Aid_Kind == 1)
            {
                if (BD_Owl_Points >= Max_Owl || BD_Owl_Lv >= 9)
                {
                    if (BD_Duck_Points >= Max_Duck || BD_Duck_Lv >= 9)
                    {
                        Main_Sprite.spriteName = "Owl_UI";
                        Shadow_Sprite.spriteName = "Owl_UI";

                        Main_txt.text = Incubator_Egg[9];
                        Rare_txt.text = Incubator_Rare[0];

                        Plus_txt.text = "Max";
                        Hold_txt.text = BD_Owl_Points.ToString();

                        int coin = 100 * Get_Aid;

                        StartCoroutine(Reward_Coin(coin));
                    }
                    else
                    {
                        Main_Sprite.spriteName = "Duck_UI";
                        Shadow_Sprite.spriteName = "Duck_UI";

                        Main_txt.text = Incubator_Egg[10];
                        Rare_txt.text = Incubator_Rare[0];

                        Plus_txt.text = "+" + Get_Aid.ToString();
                        Hold_txt.text = BD_Duck_Points.ToString();

                        int duck = BD_Duck_Points;

                        BD_Duck_Points += Get_Aid;
                        PlayerPrefs.SetInt("BD_Duck_Points", BD_Duck_Points);

                        StartCoroutine(Wait(Get_Aid, duck, 0));
                    }
                }
                else
                {
                    Main_Sprite.spriteName = "Owl_UI";
                    Shadow_Sprite.spriteName = "Owl_UI";

                    Main_txt.text = Incubator_Egg[9];
                    Rare_txt.text = Incubator_Rare[0];

                    Plus_txt.text = "+" + Get_Aid.ToString();
                    Hold_txt.text = BD_Owl_Points.ToString();

                    int owl = BD_Owl_Points;

                    BD_Owl_Points += Get_Aid;
                    PlayerPrefs.SetInt("BD_Owl_Points", BD_Owl_Points);

                    StartCoroutine(Wait(Get_Aid, owl, 0));
                }

            }
            else if (Get_Aid_Kind == 2)
            {
                if (BD_Duck_Points >= Max_Duck || BD_Duck_Lv >= 9)
                {
                    if (BD_Owl_Points >= Max_Owl || BD_Owl_Lv >= 9)
                    {
                        Main_Sprite.spriteName = "Duck_UI";
                        Shadow_Sprite.spriteName = "Duck_UI";

                        Main_txt.text = Incubator_Egg[10];
                        Rare_txt.text = Incubator_Rare[0];

                        Plus_txt.text = "Max";
                        Hold_txt.text = BD_Duck_Points.ToString(); ;

                        int coin = 100 * Get_Aid;

                        StartCoroutine(Reward_Coin(coin));
                    }
                    else
                    {
                        Main_Sprite.spriteName = "Owl_UI";
                        Shadow_Sprite.spriteName = "Owl_UI";

                        Main_txt.text = Incubator_Egg[9];
                        Rare_txt.text = Incubator_Rare[0];

                        Plus_txt.text = "+" + Get_Aid.ToString();
                        Hold_txt.text = BD_Owl_Points.ToString();

                        int owl = BD_Owl_Points;

                        BD_Owl_Points += Get_Aid;
                        PlayerPrefs.SetInt("BD_Owl_Points", BD_Owl_Points);

                        StartCoroutine(Wait(Get_Aid, owl, 0));
                    }
                }
                else
                {
                    Main_Sprite.spriteName = "Duck_UI";
                    Shadow_Sprite.spriteName = "Duck_UI";

                    Main_txt.text = Incubator_Egg[10];
                    Rare_txt.text = Incubator_Rare[0];

                    Plus_txt.text = "+" + Get_Aid.ToString();
                    Hold_txt.text = BD_Duck_Points.ToString();

                    int duck = BD_Duck_Points;

                    BD_Duck_Points += Get_Aid;
                    PlayerPrefs.SetInt("BD_Duck_Points", BD_Duck_Points);

                    StartCoroutine(Wait(Get_Aid, duck, 0));
                }
            }

            EffectManager.instance.Box_Open_2();
        }
        else if (a >= 10)
        {
            //Debug.Log("다이아 획득");
            Egg_Mileage_Notion(2);

            Main_Sprite.spriteName = "다이아";
            Shadow_Sprite.spriteName = "다이아";

            Main_txt.text = Incubator_Egg[1];
            Rare_txt.text = Incubator_Rare[0];
            Plus_txt.text = "+" + Get_Diamond.ToString();
            Hold_txt.text = BD_Diamond.ToString();

            int dia = BD_Diamond;

            BD_Diamond += Get_Diamond;
            PlayerPrefs.SetInt("BD_Diamond", BD_Diamond);

            StartCoroutine(Wait(Get_Diamond, dia, 0));

            EffectManager.instance.Box_Open_2();

        }
        else if (a >= 4)
        {
            //Debug.Log("도라의 깃털");
            Egg_Mileage_Notion(3);

            Main_Sprite.spriteName = "도라의 깃털";
            Shadow_Sprite.spriteName = "도라의 깃털";

            Main_txt.text = Incubator_Egg[2];
            Rare_txt.text = Incubator_Rare[1];
            Plus_txt.text = "+" + Get_Feather.ToString();
            Hold_txt.text = BD_Dora_Feather.ToString();

            int feather = BD_Dora_Feather;

            BD_Dora_Feather += Get_Feather;
            PlayerPrefs.SetInt("BD_Dora_Feather", BD_Dora_Feather);

            StartCoroutine(Wait(Get_Feather, feather, 0));

            EffectManager.instance.Box_Open_2();
        }
        else if (a >= 2)
        {
            //Debug.Log("스킨");
            Egg_Mileage_Notion(4);

            Main_txt.text = Incubator_Egg[3];
            Rare_txt.text = Incubator_Rare[2];

            Plus_txt.text = "+" + 1;

            if (Skin_Value == 1)
            {
                if (BD_Sunshine_Skin != 0)
                {
                    Main_Sprite.spriteName = "태양광_UI";
                    Shadow_Sprite.spriteName = "태양광_UI";

                    Plus_txt.text = "보유함";
                    Hold_txt.text = "1/1";

                    StartCoroutine(Reward_Coin(2500));
                }
                else
                {
                    AlarmManager.instance.Alarm_Plus_Nest();

                    Main_Sprite.spriteName = "태양광_UI";
                    Shadow_Sprite.spriteName = "태양광_UI";

                    PlayerPrefs.SetInt("BD_Sunshine_Skin", 1);

                    Hold_txt.text = BD_Sunshine_Skin + "/1";

                    StartCoroutine(Wait(1, 0, 1));
                }
            }
            else if (Skin_Value == 2)
            {
                if (BD_Clocking_Skin != 0)
                {
                    Main_Sprite.spriteName = "클로킹_UI";
                    Shadow_Sprite.spriteName = "클로킹_UI";

                    Plus_txt.text = "보유함";
                    Hold_txt.text = "1/1";

                    StartCoroutine(Reward_Coin(5000));
                }
                else
                {
                    AlarmManager.instance.Alarm_Plus_Nest();

                    Main_Sprite.spriteName = "클로킹_UI";
                    Shadow_Sprite.spriteName = "클로킹_UI";

                    PlayerPrefs.SetInt("BD_Clocking_Skin", 1);

                    Hold_txt.text = BD_Clocking_Skin + "/1";

                    StartCoroutine(Wait(1, 0, 1));
                }
            }
            else if (Skin_Value == 3)
            {
                if (BD_Rainbow_Skin != 0)
                {
                    Main_Sprite.spriteName = "와정대_UI";
                    Shadow_Sprite.spriteName = "와정대_UI";

                    Plus_txt.text = "보유함";
                    Hold_txt.text = "1/1";

                    StartCoroutine(Reward_Coin(10000));

                }
                else
                {
                    AlarmManager.instance.Alarm_Plus_Nest();

                    Main_Sprite.spriteName = "와정대_UI";
                    Shadow_Sprite.spriteName = "와정대_UI";

                    PlayerPrefs.SetInt("BD_Rainbow_Skin", 1);

                    Hold_txt.text = BD_Rainbow_Skin + "/1";

                    StartCoroutine(Wait(1, 0, 1));
                }
            }
            else
            {

            }

            EffectManager.instance.Box_Open_3();

        }
        else if (a >= 0)
        {
            //Debug.Log("캐릭터");
            Egg_Mileage_Notion(5);

            Main_txt.text = Incubator_Egg[6];
            Rare_txt.text = Incubator_Rare[3];

            Plus_txt.text = "+" + 1;

            if (Char_Value == 1)
            {
                if (BD_White != 0)
                {
                    Main_Sprite.spriteName = "White_3";
                    Shadow_Sprite.spriteName = "White_3";

                    Plus_txt.text = "보유함";
                    Hold_txt.text = "1/1";

                    StartCoroutine(Reward_Coin(2500));
                }
                else
                {
                    AlarmManager.instance.Alarm_Plus_Nest();
                    PlayerPrefs.SetInt("BD_White_Get", 1);

                    Main_Sprite.spriteName = "White_3";
                    Shadow_Sprite.spriteName = "White_3";

                    PlayerPrefs.SetInt("BD_White", 1);

                    Hold_txt.text = BD_White + "/1";

                    StartCoroutine(Wait(1, 0, 1));
                }

            }
            else if (Char_Value == 2)
            {
                if (BD_Eagle != 0)
                {
                    Main_Sprite.spriteName = "Eagle_3";
                    Shadow_Sprite.spriteName = "Eagle_3";

                    Plus_txt.text = "보유함";
                    Hold_txt.text = "1/1";

                    StartCoroutine(Reward_Coin(5000));
                }
                else
                {
                    AlarmManager.instance.Alarm_Plus_Nest();
                    PlayerPrefs.SetInt("BD_Eagle_Get", 1);

                    Main_Sprite.spriteName = "Eagle_3";
                    Shadow_Sprite.spriteName = "Eagle_3";

                    PlayerPrefs.SetInt("BD_Eagle", 1);

                    Hold_txt.text = BD_Eagle + "/1";

                    StartCoroutine(Wait(1, 0, 1));
                }
            }
            else if (Char_Value == 3)
            {
                if (BD_Dora != 0)
                {
                    Main_Sprite.spriteName = "Dora_3";
                    Shadow_Sprite.spriteName = "Dora_3";

                    Plus_txt.text = "보유함";
                    Hold_txt.text = "1/1";

                    StartCoroutine(Reward_Coin(10000));
                }
                else
                {
                    AlarmManager.instance.Alarm_Plus_Nest();
                    PlayerPrefs.SetInt("BD_Dora_Get", 1);

                    Main_Sprite.spriteName = "Dora_3";
                    Shadow_Sprite.spriteName = "Dora_3";

                    PlayerPrefs.SetInt("BD_Dora", 1);

                    Hold_txt.text = BD_Dora + "/1";

                    StartCoroutine(Wait(1, 0, 1));
                }
            }
            else
            {

            }

            EffectManager.instance.Box_Open_3();

        }

        Renewal();

    }

    void Egg_Mileage_Notion(int number)
    {
        Mileage_Notion.SetActive(false);
        Mileage_Notion.SetActive(true);
        Mileage_Notion.GetComponent<UILabel>().text = "+" + number.ToString();

        mileage += number;
        PlayerPrefs.SetInt("mileage", mileage);

        if(mileage >= 10)
        {
            mileage -= 10;
            Mileage += 1;
            PlayerPrefs.SetInt("mileage", mileage);
            PlayerPrefs.SetInt("Mileage", Mileage);
        }
    }

    IEnumerator Reward_Coin(int number)
    {
        yield return new WaitForSeconds(1.0f);
        EggOpen = true;

        Main_Sprite.spriteName = "Coin_1";
        Main_Sprite.GetComponent<Coin>().enabled = true;
        Shadow_Sprite.spriteName = "Coin_1";

        Main_txt.text = Incubator_Egg[0];
        Rare_txt.text = Incubator_Rare[0];

        Get_Coin = number;

        int coin = BD_Coin;

        BD_Coin += Get_Coin;
        PlayerPrefs.SetInt("BD_Coin", BD_Coin);

        Plus_txt.text = "+" + Get_Coin.ToString();
        Hold_txt.text = BD_Coin.ToString();

        StartCoroutine(Wait(Get_Coin, BD_Coin, 0));
    }

    IEnumerator Wait(int number, int target, int value)
    {
        yield return new WaitForSeconds(1.0f);
        EggOpen = true;
        StartCoroutine(Plus(number, target, value));
    }
    IEnumerator Plus(int number, int target, int value)
    {
        if (number > 0)
        {
            if(number >= 250)
            {
                number -= 250;
                target += 250;
            }
            else
            {
                if(number >= 100)
                {
                    number -= 100;
                    target += 100;
                }
                else
                {
                    if(number >= 10)
                    {
                        number -= 10;
                        target += 10;
                    }
                    else
                    {
                        number -= 1;
                        target += 1;
                    }
                }
            }

            if(value == 0)
            {
                Hold_txt.text = target.ToString();
            }
            else
            {
                Hold_txt.text = target.ToString()+"/1";
            }
        }
        else
        {
            yield break;
        }
        yield return new WaitForSeconds(0.01f);
        StartCoroutine(Plus(number, target, value));
    }
}
