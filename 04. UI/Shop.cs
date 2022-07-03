using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public static Shop instance;

    public int value = 0; //고유 번호

    public UILabel Title_txt;
    public UILabel Rare_txt;
    public UILabel Buy_txt;

    private string[] Language_Title = {""};

    //광고전용
    public UILabel Request_txt;

    public UISprite Main_Sprite; //메인 그림

    private string[] Main_Name = { "비둘기 알", "부엉이 알", "독수리 알", "황금 알", "하드 모드 티켓", "보물상자_UI" }; //메인 스프라이트 이름

    //아이템 생동감
    private Coin Main_Coin;

    public UILabel Hold_Number_txt; //보유한 개수

    public UISprite Request_Sprite; //구입 화폐 단위
    public UISprite Sub_Sprite; //메인 그림

    private int Request_Value; //0 = 코인, 1 = 다이아, 2 = 도라의 깃털, 9 = 광고(값 없음)
    private int[] Request_Value_Number = { 0, 0, 2, 1, 0, 0, 1, 1, 1, 1 };
    private string[] Request_Name = { "Coin_1", "다이아", "도라의 깃털" }; //값어치 스프라이트 이름
    private Coin Request_Coin;

    public UILabel Request_Money; //구입 화폐량

    private List<string> Shop_Main = new List<string>();
    private List<string> Shop_Rare = new List<string>();
    private List<string> Shop_Buy = new List<string>();




    //보유
    private int BD_Coin;
    private int BD_Diamond;
    private int BD_Dora_Feather;

    private int BD_Dove_Egg;
    private int BD_Owl_Egg;
    private int BD_Eagle_Egg;
    private int BD_Gold_Egg;

    private int BD_Hard_Ticket;
    private int BD_Treasure_Box;

    //구매
    private int Buy_Value;
    private int[] Buy_Value_Number = { 2000, 4500, 3, 150, 1500, 0, 10, 100, 200, 50 };


    void Awake()
    {
        instance = this;

        Main_Coin = Main_Sprite.GetComponent<Coin>();

        //구입 화폐단위와 값 설정
        Request_Value = Request_Value_Number[value - 1];
        if(Request_Value !=0) //코인이 아닐경우
        {
            Request_Coin = Request_Sprite.GetComponent<Coin>();
            Request_Coin.enabled = false;

            Request_Sprite.GetComponent<Transform>().localScale = new Vector3(0.2f, 0.2f, 1);
            Request_Sprite.width = 262;
            Request_Sprite.height = 262;

            if (Sub_Sprite != null)
            {
                Sub_Sprite.width = 262;
                Sub_Sprite.height = 262;

                Sub_Sprite.transform.localPosition = new Vector3(30, -40, 0);
            }
        }

        Request_Sprite.spriteName = Request_Name[Request_Value];
        if (Sub_Sprite != null)
        {
            Sub_Sprite.spriteName = Request_Name[Request_Value];
        }

        Buy_Value = Buy_Value_Number[value - 1];
        Request_Money.text = Buy_Value.ToString();
    }

    public void Language_Setting()
    {
        if (Shop_Main.Count > 0)
        {
            Shop_Main.Clear();
            Shop_Rare.Clear();
            Shop_Buy.Clear();
        }
        int a = PlayerPrefs.GetInt("Language");
        switch (a)
        {
            case 1:
                for (int i = 0; i < LanguageManager.instance.Shop_Main_Korean.Length; i++)
                {
                    string b = LanguageManager.instance.Shop_Main_Korean[i];
                    Shop_Main.Add(b);
                }
                for (int i = 0; i < LanguageManager.instance.Shop_Rare_Korean.Length; i++)
                {
                    string b = LanguageManager.instance.Shop_Rare_Korean[i];
                    Shop_Rare.Add(b);
                }
                for (int i = 0; i < LanguageManager.instance.Shop_Buy_Korean.Length; i++)
                {
                    string b = LanguageManager.instance.Shop_Buy_Korean[i];
                    Shop_Buy.Add(b);
                }
                break;
            case 2:
                for (int i = 0; i < LanguageManager.instance.Shop_Main_English.Length; i++)
                {
                    string b = LanguageManager.instance.Shop_Main_English[i];
                    Shop_Main.Add(b);
                }
                for (int i = 0; i < LanguageManager.instance.Shop_Rare_English.Length; i++)
                {
                    string b = LanguageManager.instance.Shop_Rare_English[i];
                    Shop_Rare.Add(b);
                }
                for (int i = 0; i < LanguageManager.instance.Shop_Buy_English.Length; i++)
                {
                    string b = LanguageManager.instance.Shop_Buy_English[i];
                    Shop_Buy.Add(b);
                }
                break;
            case 3:
                for (int i = 0; i < LanguageManager.instance.Shop_Main_Chinese.Length; i++)
                {
                    string b = LanguageManager.instance.Shop_Main_Chinese[i];
                    Shop_Main.Add(b);
                }
                for (int i = 0; i < LanguageManager.instance.Shop_Rare_Chinese.Length; i++)
                {
                    string b = LanguageManager.instance.Shop_Rare_Chinese[i];
                    Shop_Rare.Add(b);
                }
                for (int i = 0; i < LanguageManager.instance.Shop_Buy_Chinese.Length; i++)
                {
                    string b = LanguageManager.instance.Shop_Buy_Chinese[i];
                    Shop_Buy.Add(b);
                }
                break;
            case 4:
                for (int i = 0; i < LanguageManager.instance.Shop_Main_Japanese.Length; i++)
                {
                    string b = LanguageManager.instance.Shop_Main_Japanese[i];
                    Shop_Main.Add(b);
                }
                for (int i = 0; i < LanguageManager.instance.Shop_Rare_Japanese.Length; i++)
                {
                    string b = LanguageManager.instance.Shop_Rare_Japanese[i];
                    Shop_Rare.Add(b);
                }
                for (int i = 0; i < LanguageManager.instance.Shop_Buy_Japanese.Length; i++)
                {
                    string b = LanguageManager.instance.Shop_Buy_Japanese[i];
                    Shop_Buy.Add(b);
                }
                break;
        }

        Language_Change();
    }

    void Language_Change()
    {
        Title_txt.text = Shop_Main[value -1];
        Buy_txt.text = Shop_Buy[0];
        switch (value)
        {
            case 1:
                Rare_txt.text = Shop_Rare[0];
                break;
            case 2:
                Rare_txt.text = Shop_Rare[1];
                break;
            case 3:
                Rare_txt.text = Shop_Rare[2];
                break;
            case 4:
                Rare_txt.text = Shop_Rare[3];
                break;
            case 5:
                Rare_txt.text = Shop_Rare[4];
                break;
            case 6:
                Buy_txt.text = Shop_Buy[1];
                break;
            case 10:
                Rare_txt.text = Shop_Rare[1];
                break;

        }
    }

    void OnEnable()
    {
        Renewal();
        Language_Setting();
    }
    void OnDisable()
    {
        StopAllCoroutines();
    }

    public void Renewal()
    {
        BD_Coin = PlayerPrefs.GetInt("BD_Coin");
        BD_Diamond = PlayerPrefs.GetInt("BD_Diamond");
        BD_Dora_Feather = PlayerPrefs.GetInt("BD_Dora_Feather");

        BD_Dove_Egg = PlayerPrefs.GetInt("BD_Dove_Egg");
        BD_Owl_Egg = PlayerPrefs.GetInt("BD_Owl_Egg");
        BD_Eagle_Egg = PlayerPrefs.GetInt("BD_Eagle_Egg");
        BD_Gold_Egg = PlayerPrefs.GetInt("BD_Gold_Egg");

        BD_Hard_Ticket = PlayerPrefs.GetInt("BD_Hard_Ticket");
        BD_Treasure_Box = PlayerPrefs.GetInt("BD_Treasure_Box");

        Check_Value(value);
    }

    void Check_Value(int number)
    {
        switch (number)
        {
            case 1:
                Main_Coin.enabled = false;
                Main_Sprite.spriteName = Main_Name[number - 1];
                Hold_Number_txt.text = BD_Dove_Egg.ToString();
                break;
            case 2:
                Main_Coin.enabled = false;
                Main_Sprite.spriteName = Main_Name[number - 1];
                Hold_Number_txt.text = BD_Owl_Egg.ToString();
                break;
            case 3:
                Main_Coin.enabled = false;
                Main_Sprite.spriteName = Main_Name[number - 1];
                Hold_Number_txt.text = BD_Eagle_Egg.ToString();
                break;
            case 4:
                Main_Coin.enabled = false;
                Main_Sprite.spriteName = Main_Name[number - 1];
                Hold_Number_txt.text = BD_Gold_Egg.ToString();
                break;
            case 5:
                Main_Coin.enabled = false;
                Main_Sprite.spriteName = Main_Name[number - 1];
                Hold_Number_txt.text = BD_Hard_Ticket.ToString();
                break;
            case 6: //광고
                Main_Coin.enabled = false;
                Request_Sprite.enabled = false;
                if (Sub_Sprite != null)
                {
                    Sub_Sprite.enabled = false;
                }
                Request_Money.enabled = false;
                Hold_Number_txt.enabled = false;
                break;
            case 7:
                Hold_Number_txt.enabled = false;
                break;
            case 8:
                Hold_Number_txt.enabled = false;
                break;
            case 9:
                Hold_Number_txt.enabled = false;
                break;
            case 10:
                Main_Coin.enabled = false;
                Main_Sprite.spriteName = Main_Name[5];
                Hold_Number_txt.text = BD_Treasure_Box.ToString();
                break;
        }
    }

    public void Buy_Btn() //구매 버튼
    {
        if(value != 6)
        {
            Renewal();
            Buy(value);
        }
    }

    void Sucess_Buy_Notion()
    {
        LanguageManager.instance.Sucess_Buy_Notion();
        Renewal();
    }

    void Max_limit_Notion()
    {
        LanguageManager.instance.Max_limit_Notion();
    }

    void Buy(int number)
    {
        if(Request_Value == 0)
        {
            if(BD_Coin >= Buy_Value)
            {
                if (number == 1)
                {
                    if (BD_Dove_Egg < 99)
                    {
                        //업적 - 코인 사용
                        int a = PlayerPrefs.GetInt("Achieve_Coin");
                        a += Buy_Value;
                        PlayerPrefs.SetInt("Achieve_Coin", a);

                        BD_Coin -= Buy_Value;
                        PlayerPrefs.SetInt("BD_Coin", BD_Coin);
                        BD_Dove_Egg += 1;
                        PlayerPrefs.SetInt("BD_Dove_Egg", BD_Dove_Egg);
                        Sucess_Buy_Notion();
                    }
                    else
                    {
                        Max_limit_Notion();
                    }
                }
                else if (number == 2)
                {
                    if (BD_Owl_Egg < 99)
                    {
                        //업적 - 코인 사용
                        int a = PlayerPrefs.GetInt("Achieve_Coin");
                        a += Buy_Value;
                        PlayerPrefs.SetInt("Achieve_Coin", a);

                        BD_Coin -= Buy_Value;
                        PlayerPrefs.SetInt("BD_Coin", BD_Coin);
                        BD_Owl_Egg += 1;
                        PlayerPrefs.SetInt("BD_Owl_Egg", BD_Owl_Egg);
                        Sucess_Buy_Notion();
                    }
                    else
                    {
                        Max_limit_Notion();
                    }
                }
                else if (number == 5)
                {
                    if (BD_Hard_Ticket < 99)
                    {
                        //업적 - 코인 사용
                        int a = PlayerPrefs.GetInt("Achieve_Coin");
                        a += Buy_Value;
                        PlayerPrefs.SetInt("Achieve_Coin", a);

                        BD_Coin -= Buy_Value;
                        PlayerPrefs.SetInt("BD_Coin", BD_Coin);
                        BD_Hard_Ticket += 1;
                        PlayerPrefs.SetInt("BD_Hard_Ticket", BD_Hard_Ticket);
                        Sucess_Buy_Notion();
                    }
                    else
                    {
                        Max_limit_Notion();
                    }
                }
            }
            else
            {
                LanguageManager.instance.Low_Coin_Notion();
            }
        }
        else if(Request_Value == 1)
        {
            if(BD_Diamond >= Buy_Value)
            {
                if(number == 4)
                {
                    if (BD_Gold_Egg < 99)
                    {
                        //업적 - 다이아 사용
                        int a = PlayerPrefs.GetInt("Achieve_Diamond");
                        a += Buy_Value;
                        PlayerPrefs.SetInt("Achieve_Diamond", a);

                        BD_Diamond -= Buy_Value;
                        PlayerPrefs.SetInt("BD_Diamond", BD_Diamond);
                        BD_Gold_Egg += 1;
                        PlayerPrefs.SetInt("BD_Gold_Egg", BD_Gold_Egg);
                        Sucess_Buy_Notion();
                    }
                    else
                    {
                        Max_limit_Notion();
                    }
                }
                else if (number == 7 || number == 8 || number == 9)
                {
                    if (BD_Coin + (Buy_Value * 100) < 9999999)
                    {
                        //업적 - 다이아 사용
                        int a = PlayerPrefs.GetInt("Achieve_Diamond");
                        a += Buy_Value;
                        PlayerPrefs.SetInt("Achieve_Diamond", a);

                        BD_Diamond -= Buy_Value;
                        PlayerPrefs.SetInt("BD_Diamond", BD_Diamond);
                        BD_Coin += (Buy_Value * 100);
                        PlayerPrefs.SetInt("BD_Coin", BD_Coin);
                        Sucess_Buy_Notion();
                    }
                    else
                    {
                        Max_limit_Notion();
                    }
                }
                else
                {
                    LanguageManager.instance.Rocked_Notion();
                }
            }
            else
            {
                LanguageManager.instance.Low_Diamond_Notion();
            }
        }
        else if(Request_Value == 2)
        {
            if(BD_Dora_Feather >= Buy_Value)
            {
                if (number == 3)
                {
                    if (BD_Eagle_Egg < 99)
                    {
                        BD_Dora_Feather -= Buy_Value;
                        PlayerPrefs.SetInt("BD_Dora_Feather", BD_Dora_Feather);
                        BD_Eagle_Egg += 1;
                        PlayerPrefs.SetInt("BD_Eagle_Egg", BD_Eagle_Egg);
                        Sucess_Buy_Notion();
                    }
                    else
                    {
                        Max_limit_Notion();
                    }
                }
            }
            else
            {
                LanguageManager.instance.Low_Feather_Notion();
            }
        }
        else if(Request_Value == 3) //마일리지 구매
        {

        }
    }
}
