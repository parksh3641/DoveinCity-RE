using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressItem : MonoBehaviour
{
    public static ProgressItem instance;

    public string Box_Number = ""; // 박스 고유 번호

    public int Kind = 0; // 내용물 종류
    public int Value = 0; // 내용물 값
    public int rank = 0; //랭크 1부터 C

    public UISprite Main_sp;
    public UISprite Shadow_sp;

    public UILabel Rank;
    public GameObject Rock;

    public UILabel Number_txt;
    public UILabel Rank_txt;

    private int Item_State;
    private int Possible;

    private string[] Kind_Number = { "Coin_1", "다이아", "도라의 깃털", "비둘기 알", "부엉이 알", "독수리 알", "황금 알","하드 모드 티켓", "Owl_UI", "Duck_UI" };
    private string[] Rank_Number = { "C", "B", "A", "S" };

    //보유
    private int BD_Coin;
    private int BD_Diamond;
    private int BD_Feather;

    private int BD_Dove_Egg;
    private int BD_Owl_Egg;
    private int BD_Eagle_Egg;
    private int BD_Gold_Egg;

    private int BD_Hard_Ticket;

    private int BD_Owl;
    private int BD_Duck;

    void Awake()
    {
        instance = this;

        Box_Number = gameObject.name;
        if (rank == 0)
        {
            Main_sp.spriteName = Kind_Number[Kind];
            Shadow_sp.spriteName = Kind_Number[Kind];
            Number_txt.text = Value.ToString();

            Rank.text = "";
            Rank_txt.text = "";

            if(Value == 1)
            {
                Number_txt.text = "Unlock";
                Number_txt.color = new Color(1, 1, 0);
            }
        }
        else
        {
            Rank_Color();
            Rank.text = Rank_Number[rank-1];
            Rank_txt.text = "Rank";
            Main_sp.enabled = false;
            Shadow_sp.enabled = false;

            Number_txt.text = "";
        }

        Item_State = 0;

        Renewal();
    }

    void Rank_Color()
    {
        switch (rank)
        {
            case 1:
                Rank.color = new Color(1, 1, 0);
                break;
            case 2:
                Rank.color = new Color(0, 1, 0);
                break;
            case 3:
                Rank.color = new Color(1, 0, 0);
                break;
            case 4:
                Rank.color = new Color(1, 0, 1);
                break;

        }
    }
    
    public void Item_Open()
    {
        Item_State = 1;
        if (Possible == 0 && Item_State == 1)
        {
            Rock.SetActive(false);
        }
        else
        {
            Rock.SetActive(true);
        }
    }

    public void Item_Close()
    {
        Item_State = 0;
        Rock.SetActive(true);
    }

    void Renewal()
    {
        BD_Coin = PlayerPrefs.GetInt("BD_Coin", 0);
        BD_Diamond = PlayerPrefs.GetInt("BD_Diamond", 0);
        BD_Feather = PlayerPrefs.GetInt("BD_Dora_Feather", 0);

        BD_Dove_Egg = PlayerPrefs.GetInt("BD_Dove_Egg");
        BD_Owl_Egg = PlayerPrefs.GetInt("BD_Owl_Egg");
        BD_Eagle_Egg = PlayerPrefs.GetInt("BD_Eagle_Egg");
        BD_Gold_Egg = PlayerPrefs.GetInt("BD_Gold_Egg");

        BD_Hard_Ticket = PlayerPrefs.GetInt("BD_Hard_Ticket");

        BD_Owl = PlayerPrefs.GetInt("BD_Owl");
        BD_Duck = PlayerPrefs.GetInt("BD_Duck");

        Possible = PlayerPrefs.GetInt("Box_Number_" + Box_Number);
    }

    public void Btn()
    {
        if (Possible == 0 && Item_State == 1)
        {
            if (rank == 0)
            {
                Renewal();

                switch (Kind)
                {
                    case 0:
                        if(BD_Coin + Value > 9999999)
                        {
                            LanguageManager.instance.Max_Point_Notion();
                        }
                        else
                        {
                            BD_Coin += Value;
                            PlayerPrefs.SetInt("BD_Coin", BD_Coin);

                            Reward_Success();
                        }
                        break;
                    case 1:
                        if (BD_Diamond + Value > 9999)
                        {
                            LanguageManager.instance.Max_Point_Notion();
                        }
                        else
                        {
                            BD_Diamond += Value;
                            PlayerPrefs.SetInt("BD_Diamond", BD_Diamond);

                            Reward_Success();
                        }
                        break;
                    case 2:
                        if (BD_Feather + Value > 999)
                        {
                            LanguageManager.instance.Max_Point_Notion();
                        }
                        else
                        {
                            BD_Feather += Value;
                            PlayerPrefs.SetInt("BD_Dora_Feather", BD_Feather);

                            Reward_Success();
                        }
                        break;
                    case 3:
                        if (BD_Dove_Egg + Value > 99)
                        {
                            LanguageManager.instance.Max_Point_Notion();
                        }
                        else
                        {
                            BD_Dove_Egg += Value;
                            PlayerPrefs.SetInt("BD_Dove_Egg", BD_Dove_Egg);

                            Reward_Success();
                        }
                        break;
                    case 4:
                        if (BD_Owl_Egg + Value > 99)
                        {
                            LanguageManager.instance.Max_Point_Notion();
                        }
                        else
                        {
                            BD_Owl_Egg += Value;
                            PlayerPrefs.SetInt("BD_Owl_Egg", BD_Owl_Egg);

                            Reward_Success();
                        }
                        break;
                    case 5:
                        if (BD_Eagle_Egg + Value > 99)
                        {
                            LanguageManager.instance.Max_Point_Notion();
                        }
                        else
                        {
                            BD_Eagle_Egg += Value;
                            PlayerPrefs.SetInt("BD_Eagle_Egg", BD_Eagle_Egg);

                            Reward_Success();
                        }
                        break;
                    case 6:
                        if (BD_Gold_Egg + Value > 99)
                        {
                            LanguageManager.instance.Max_Point_Notion();
                        }
                        else
                        {
                            BD_Gold_Egg += Value;
                            PlayerPrefs.SetInt("BD_Gold_Egg", BD_Gold_Egg);

                            Reward_Success();
                        }
                        break;
                    case 7:
                        if (BD_Hard_Ticket + Value > 99)
                        {
                            LanguageManager.instance.Max_Point_Notion();
                        }
                        else
                        {
                            BD_Hard_Ticket += Value;
                            PlayerPrefs.SetInt("BD_Hard_Ticket", BD_Hard_Ticket);

                            Reward_Success();
                        }
                        break;
                    case 8:
                        BD_Owl += Value;
                        PlayerPrefs.SetInt("BD_Owl", BD_Owl);

                        Reward_Success();
                        break;
                    case 9:
                        BD_Duck += Value;
                        PlayerPrefs.SetInt("BD_Duck", BD_Duck);

                        Reward_Success();
                        break;
                }
            }
            else
            {
                int a = PlayerPrefs.GetInt("Rank");
                if(a < rank)
                {
                    PlayerPrefs.SetInt("Rank", rank);
                }

                Reward_Success();
            }
        }
    }
    void Reward_Success()
    {
        LanguageManager.instance.Success_Reward_Notion();

        PlayerPrefs.SetInt("Box_Number_" + Box_Number, 1);
        Rock.SetActive(true);

        Renewal();
    }
}
