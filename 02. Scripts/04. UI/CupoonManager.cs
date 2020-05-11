using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupoonManager : MonoBehaviour
{
    public static CupoonManager instance;

    public ParticleSystem Box_System;

    public UIInput MainInput;
    public UILabel Input_txt;
    public UILabel Enter_Btn_txt;

    public GameObject InputWindow;
    public GameObject RewardWindow;
    public UISprite Main_Sprite;
    public UISprite Shadow_Sprite;
    public UILabel Main_txt;

    private string Input;

    private string Cupoon1 = "안녕하세요"; //보석 50
    private string Cupoon2 = "hello"; //보석 50
    private string Cupoon3 = "你好"; //보석 50
    private string Cupoon4 = "こんにちは"; //보석 50

    private string Cupoon5  = "95gcmj1cb5xcwftz"; //코인 5000
    private string Cupoon6  = "bpoma5w7xfm7um90"; //코인 5000
    private string Cupoon7  = "m9r8y8hzsub7i6tt"; //코인 10000
    private string Cupoon8  = "xr80jdgrzyfi3cyi"; //코인 10000
    private string Cupoon9  = "hiqhw12mjrq4to9n"; //코인 15000
    private string Cupoon10 = "ajfegx2cug1c7kaz"; //코인 15000
    private string Cupoon11 = "8hmo6699sgqahtfm"; //코인 20000
    private string Cupoon12 = "y4tg3j5exk7waueh"; //코인 20000

    private string Cupoon13 = "28bq5vdxihju14ya"; //보석 50
    private string Cupoon14 = "mzv5htovnot18243"; //보석 50
    private string Cupoon15 = "ekcgxw9y2fjbrlnz"; //보석 100
    private string Cupoon16 = "iicxc2pac2j20uom"; //보석 100
    private string Cupoon17 = "5zhopzt2wxrksgl0"; //보석 150
    private string Cupoon18 = "jyzh55rkc8rh6aft"; //보석 150
    private string Cupoon19 = "gtpr8fhgefalpq45"; //보석 200
    private string Cupoon20 = "ho9slkfbgk2lnt5k"; //보석 200

    private string Cupoon21 = "busboo7p784vbie5"; //깃털 5
    private string Cupoon22 = "s6a68dwhk6adjpkr"; //깃털 5
    private string Cupoon23 = "d9ssea6h60c7sde2"; //깃털 10
    private string Cupoon24 = "bz7vjopxyar5iq3u"; //깃털 10
    private string Cupoon25 = "svr6zret4xnsyohz"; //깃털 15
    private string Cupoon26 = "jtdvrhlh9ttjgfji"; //깃털 15
    private string Cupoon27 = "kdd2mkdb5oncwi5n"; //깃털 20
    private string Cupoon28 = "oq5hf31w2dip5xg1"; //깃털 20

    private string Cupoon29 = "9kgrkollj12935ny"; //생존시간 50
    private string Cupoon30 = "3aaal0qdive68bs9"; //생존시간 50
    private string Cupoon31 = "fj0ffftgbaj0i7vz"; //생존시간 100
    private string Cupoon32 = "sfvp3xxyjewmqqto"; //생존시간 100
    private string Cupoon33 = "46io5mjnh66klsv4"; //생존시간 150
    private string Cupoon34 = "weyf29eequkwnvo9"; //생존시간 150
    private string Cupoon35 = "nxp5zcakz0c1wd1m"; //생존시간 200
    private string Cupoon36 = "nlfli48rz677b0zp"; //생존시간 200

    private string Cupoon37 = "vgbe0ay52e0j3sfy"; //모든 조각 25
    private string Cupoon38 = "n8kd1lydpg2z9fvj"; //모든 조각 25
    private string Cupoon39 = "po953bpz76xo75n4"; //모든 조각 50
    private string Cupoon40 = "nrat8khq2d9alzpu"; //모든 조각 50
    private string Cupoon41 = "wnqyz0nsfceewfk0"; //모든 조각 75
    private string Cupoon42 = "4uc5jiw6hc9f2cwj"; //모든 조각 75
    private string Cupoon43 = "oifoeb0fe7kvuyoi"; //모든 조각 100
    private string Cupoon44 = "tyostbk6xayr9iq6"; //모든 조각 100

    private string Cupoon45 = "2016041820161103"; //개발자 전용
    private string Cupoon46 = "2019080920200303"; //베타 테스터 전용
    private string Cupoon47 = "9000000000000000"; //리셋 코드



    private List<string> Cupoon = new List<string>();
    private int[] Cupoon_Kind = { 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 3, 3, 3, 4, 4, 4, 4, 4, 4, 4, 4, 5, 6, 7 }; //0 코인, 1 다이아, 2 깃털, 3 생존시간, 4 조각, 5 개발자
    private int[] Cupoon_Value = { 50, 50, 50, 50, 5000, 5000, 10000, 10000, 15000, 15000, 20000, 20000, 50, 50, 100, 100, 150, 150, 200, 200, 5, 5, 10, 10, 15, 15, 20, 20, 50, 50, 100, 100, 150, 150, 200, 200, 25, 25, 50, 50, 75, 75, 100, 100, 99999, 99999, 0 };

    private string[] Sprite_Name = { "Coin_1", "다이아", "도라의 깃털", "Dora_3", "Owl_UI","Mole_5", "Mole_5", "Mole_5" };

    private Coin coin;

    private int Cupoon_Number;
    private bool cupoon;

    private int BD_Coin;
    private int BD_Diamond;
    private int BD_Feather;

    private int BD_Black_AliveTime;
    private int BD_White_AliveTime;
    private int BD_Eagle_AliveTime;
    private int BD_Dora_AliveTime;

    private int BD_Owl_Points;
    private int BD_Duck_Points;

    private int BD_Hard_Ticket;

    void Awake()
    {
        instance = this;

        Box_System.Stop();

        coin = Main_Sprite.GetComponent<Coin>();
        coin.enabled = false;

        Renewal();

        Cupoon.Add(Cupoon1);
        Cupoon.Add(Cupoon2);
        Cupoon.Add(Cupoon3);
        Cupoon.Add(Cupoon4);
        Cupoon.Add(Cupoon5);
        Cupoon.Add(Cupoon6);
        Cupoon.Add(Cupoon7);
        Cupoon.Add(Cupoon8);
        Cupoon.Add(Cupoon9);
        Cupoon.Add(Cupoon10);
        Cupoon.Add(Cupoon11);
        Cupoon.Add(Cupoon12);
        Cupoon.Add(Cupoon13);
        Cupoon.Add(Cupoon14);
        Cupoon.Add(Cupoon15);
        Cupoon.Add(Cupoon16);
        Cupoon.Add(Cupoon17);
        Cupoon.Add(Cupoon18);
        Cupoon.Add(Cupoon19);
        Cupoon.Add(Cupoon20);
        Cupoon.Add(Cupoon21);
        Cupoon.Add(Cupoon22);
        Cupoon.Add(Cupoon23);
        Cupoon.Add(Cupoon24);
        Cupoon.Add(Cupoon25);
        Cupoon.Add(Cupoon26);
        Cupoon.Add(Cupoon27);
        Cupoon.Add(Cupoon28);
        Cupoon.Add(Cupoon29);
        Cupoon.Add(Cupoon30);
        Cupoon.Add(Cupoon31);
        Cupoon.Add(Cupoon32);
        Cupoon.Add(Cupoon33);
        Cupoon.Add(Cupoon34);
        Cupoon.Add(Cupoon35);
        Cupoon.Add(Cupoon36);
        Cupoon.Add(Cupoon37);
        Cupoon.Add(Cupoon38);
        Cupoon.Add(Cupoon39);
        Cupoon.Add(Cupoon40);
        Cupoon.Add(Cupoon41);
        Cupoon.Add(Cupoon42);
        Cupoon.Add(Cupoon43);
        Cupoon.Add(Cupoon44);
        Cupoon.Add(Cupoon45);
        Cupoon.Add(Cupoon46);
        Cupoon.Add(Cupoon47);
    }

    void Reset()
    {
        for(int i = 0;i<Cupoon.Count;i++)
        {
            PlayerPrefs.SetInt(Cupoon[i], 0);
        }
    }

    public void Renewal()
    {
        cupoon = false;

        Cupoon_Number = 0;
        InputWindow.SetActive(true);
        RewardWindow.SetActive(false);

        BD_Coin = PlayerPrefs.GetInt("BD_Coin", 0);
        BD_Diamond = PlayerPrefs.GetInt("BD_Diamond", 0);
        BD_Feather = PlayerPrefs.GetInt("BD_Dora_Feather", 0);

        BD_Black_AliveTime = PlayerPrefs.GetInt("BD_Black_AliveTime");
        BD_White_AliveTime = PlayerPrefs.GetInt("BD_White_AliveTime");
        BD_Eagle_AliveTime = PlayerPrefs.GetInt("BD_Eagle_AliveTime");
        BD_Dora_AliveTime = PlayerPrefs.GetInt("BD_Dora_AliveTime");

        BD_Owl_Points = PlayerPrefs.GetInt("BD_Owl_Points");
        BD_Duck_Points = PlayerPrefs.GetInt("BD_Duck_Points");

        BD_Hard_Ticket = PlayerPrefs.GetInt("BD_Hard_Ticket");

        MainInput.value = "";

    }

    public void Enter()
    {
        if (cupoon == false)
        {
            Cupoon_Number = 0;

            for (int i = 0; i < Cupoon.Count; i++)
            {
                if (((Input_txt.text.Trim()).ToLower()).Equals((Cupoon[i].Trim()).ToLower()))
                {
                    Cupoon_Number = i;
                    break;
                }
                else
                {
                    Cupoon_Number = 99;
                }
            }

            Input_txt.text.Remove(0, Input_txt.text.Length);
            Check_Number();
        }
        else //보상 받는 코드
        {
            Box_System.Stop();
            Renewal();
            Success_Reward_Notion();
            SelectManager.instance.Exit();
        }
    }

    public void Effect_Stop()
    {
        Box_System.Stop();
    }

    void Check_Number() //번호 확인 성공
    {
        if (Cupoon_Number != 99)
        {
            if(PlayerPrefs.GetInt(Cupoon[Cupoon_Number]) == 0)
            {
                Main_Sprite.spriteName = Sprite_Name[Cupoon_Kind[Cupoon_Number]];
                Shadow_Sprite.spriteName = Sprite_Name[Cupoon_Kind[Cupoon_Number]];

                if (Cupoon_Kind[Cupoon_Number] == 0)
                {
                    coin.enabled = true;
                }

                Main_txt.text = Cupoon_Value[Cupoon_Number].ToString();

                Box_System.Play();

                cupoon = true;
                InputWindow.SetActive(false);
                RewardWindow.SetActive(true);
                Success_Input_Notion();

                Reward_Check();

                EffectManager.instance.Box_Open_3();
            }
            else
            {
                Already_Received_Notion();
            }
        }
        else
        {
            Wrong_Number_Notion();
        }
    }

    void Success_Input_Notion()
    {
        LanguageManager.instance.Success_Input_Notion();
    }

    void Success_Reward_Notion()
    {
        LanguageManager.instance.Success_Reward_Notion();
    }

    void Wrong_Number_Notion()
    {
        LanguageManager.instance.Wrong_Number_Notion();
    }

    void Already_Received_Notion()
    {
        LanguageManager.instance.Already_Received_Notion();
    }

    void Reward_Check()
    {
        int a = Cupoon_Kind[Cupoon_Number]; //종류
        int b = Cupoon_Value[Cupoon_Number]; //값

        PlayerPrefs.SetInt(Cupoon[Cupoon_Number], 1);

        if (a == 0)
        {
            BD_Coin += b;
            PlayerPrefs.SetInt("BD_Coin", BD_Coin);
        }
        else if (a == 1)
        {
            BD_Diamond += b;
            PlayerPrefs.SetInt("BD_Diamond", BD_Diamond);
        }
        else if (a == 2)
        {
            BD_Feather += b;
            PlayerPrefs.SetInt("BD_Dora_Feather", BD_Feather);
        }
        else if (a == 3)
        {
            BD_Black_AliveTime += b;
            BD_White_AliveTime += b;
            BD_Eagle_AliveTime += b;
            BD_Dora_AliveTime += b;

            PlayerPrefs.SetInt("BD_Black_AliveTime", BD_Black_AliveTime);
            PlayerPrefs.SetInt("BD_White_AliveTime", BD_White_AliveTime);
            PlayerPrefs.SetInt("BD_Eagle_AliveTime", BD_Eagle_AliveTime);
            PlayerPrefs.SetInt("BD_Dora_AliveTime", BD_Dora_AliveTime);
        }
        else if (a == 4)
        {
            BD_Owl_Points += b;
            BD_Duck_Points += b;

            PlayerPrefs.SetInt("BD_Owl_Points", BD_Owl_Points);
            PlayerPrefs.SetInt("BD_Duck_Points", BD_Duck_Points);
        }

        else if (a == 5)
        {
            BD_Coin += 9999999;
            BD_Diamond += 9999;
            BD_Feather += 999;

            BD_Black_AliveTime += 9999;
            BD_White_AliveTime += 9999;
            BD_Eagle_AliveTime += 9999;
            BD_Dora_AliveTime += 9999;

            BD_Owl_Points += 9999;
            BD_Duck_Points += 9999;

            BD_Hard_Ticket += 99;

            PlayerPrefs.SetInt("BD_Coin", BD_Coin);
            PlayerPrefs.SetInt("BD_Diamond", BD_Diamond);
            PlayerPrefs.SetInt("BD_Dora_Feather", BD_Feather);

            PlayerPrefs.SetInt("BD_Black_AliveTime", BD_Black_AliveTime);
            PlayerPrefs.SetInt("BD_White_AliveTime", BD_White_AliveTime);
            PlayerPrefs.SetInt("BD_Eagle_AliveTime", BD_Eagle_AliveTime);
            PlayerPrefs.SetInt("BD_Dora_AliveTime", BD_Dora_AliveTime);

            PlayerPrefs.SetInt("BD_Owl", 1);
            PlayerPrefs.SetInt("BD_Duck", 1);

            PlayerPrefs.SetInt("BD_Owl_Points", BD_Owl_Points);
            PlayerPrefs.SetInt("BD_Duck_Points", BD_Duck_Points);

            PlayerPrefs.SetInt("BD_White", 1);
            PlayerPrefs.SetInt("BD_Eagle", 1);
            PlayerPrefs.SetInt("BD_Dora", 1);

            PlayerPrefs.SetInt("BD_Sunshine_Skin", 1);
            PlayerPrefs.SetInt("BD_Clocking_Skin", 1);
            PlayerPrefs.SetInt("BD_Rainbow_Skin", 1);

            PlayerPrefs.SetInt("BD_Hard_Ticket", BD_Hard_Ticket);

            PlayerPrefs.SetInt("AllScore", 90000);
        }

        else if (a == 6)
        {
            BD_Coin += 100000;
            BD_Diamond += 250;
            BD_Feather += 30;

            BD_Black_AliveTime += 300;
            BD_White_AliveTime += 300;
            BD_Eagle_AliveTime += 300;
            BD_Dora_AliveTime += 300;

            BD_Hard_Ticket += 50;

            PlayerPrefs.SetInt("BD_Coin", BD_Coin);
            PlayerPrefs.SetInt("BD_Diamond", BD_Diamond);
            PlayerPrefs.SetInt("BD_Dora_Feather", BD_Feather);

            PlayerPrefs.SetInt("BD_Black_AliveTime", BD_Black_AliveTime);
            PlayerPrefs.SetInt("BD_White_AliveTime", BD_White_AliveTime);
            PlayerPrefs.SetInt("BD_Eagle_AliveTime", BD_Eagle_AliveTime);
            PlayerPrefs.SetInt("BD_Dora_AliveTime", BD_Dora_AliveTime);

            PlayerPrefs.SetInt("BD_Owl", 1);
            PlayerPrefs.SetInt("BD_Duck", 1);

            PlayerPrefs.SetInt("BD_White", 1);
            PlayerPrefs.SetInt("BD_Eagle", 1);
            PlayerPrefs.SetInt("BD_Dora", 1);

            PlayerPrefs.SetInt("BD_Sunshine_Skin", 1);
            PlayerPrefs.SetInt("BD_Clocking_Skin", 1);
            PlayerPrefs.SetInt("BD_Rainbow_Skin", 1);

            PlayerPrefs.SetInt("BD_Hard_Ticket", BD_Hard_Ticket);

            GooglePlayManager.instance.UnlockAchievement_2();
        }
        else if (a == 7)
        {
            PlayerPrefs.DeleteAll();
            SystemManager.instance.OneGo();
        }
    }

    public void Save_Clear()
    {
        for(int i = 0;i<Cupoon.Count;i++)
        {
            PlayerPrefs.SetInt(Cupoon[i], 0);
        }
    }
}
