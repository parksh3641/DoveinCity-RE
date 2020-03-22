using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class NicknameManager : MonoBehaviour
{

    public static NicknameManager instance;

    private string Nickname;

    public UIInput MainInput;
    public UILabel Input_txt;
    public UILabel Input2_txt;
    public UILabel Diamond_txt;

    private int BD_Coin;
    private int BD_Diamond;
    private int Nickname_Change_Number;

    private int[] Change_Value = { 0, 50, 100, 200, 300, 400, 500, 500 };

    void Awake()
    {
        instance = this;

        //PlayerPrefs.SetInt("Nickname_Change_Number", 0);
    }

    public void Renewal()
    {
        Nickname = PlayerPrefs.GetString("Nickname");
        Nickname_Change_Number = PlayerPrefs.GetInt("Nickname_Change_Number");
        if (Nickname_Change_Number >= 6)
        {
            Nickname_Change_Number = 6;
        }

        if (Nickname_Change_Number == 0)
        {
            Diamond_txt.text = "0";
        }
        else
        {
            Diamond_txt.text = Change_Value[Nickname_Change_Number].ToString();
        }

        MainInput.value = "";
    }

    public void Btn()
    {
        BD_Diamond = PlayerPrefs.GetInt("BD_Diamond");

        string Check = Regex.Replace(Input_txt.text, @"[^a-zA-Z0-9가-힣 ]", "", RegexOptions.Singleline);

        if (Input_txt.text.Equals(Check) == true)
        {
            if (BD_Diamond >= Change_Value[Nickname_Change_Number])
            {
                string a = ((Input_txt.text.Trim()).Replace(" ", ""));
                string b = ((Nickname.Trim()).Replace(" ", ""));
                if (!(a.Equals(b)))
                {
                    if (a.Length > 1)
                    {
                        PlayerPrefs.SetString("Nickname", a);
                        LanguageManager.instance.Success_Nickname_Notion();
                        SelectManager.instance.Exit();

                        BD_Diamond -= Change_Value[Nickname_Change_Number];
                        PlayerPrefs.SetInt("BD_Diamond", BD_Diamond);

                        Nickname_Change_Number += 1;
                        PlayerPrefs.SetInt("Nickname_Change_Number", Nickname_Change_Number);
                    }
                    else
                    {
                        LanguageManager.instance.Low_Letter_Notion();
                    }
                }
                else
                {
                    LanguageManager.instance.Overlap_Nickname_Notion();
                }
            }
            else
            {
                LanguageManager.instance.Low_Diamond_Notion();
            }
        }
        else
        {
            LanguageManager.instance.Special_Text_Notion();
        }
    }

    public void Tutorial_Btn()
    {
        BD_Coin = PlayerPrefs.GetInt("BD_Coin");
        BD_Diamond = PlayerPrefs.GetInt("BD_Diamond");

        string Check = Regex.Replace(Input2_txt.text, @"[^a-zA-Z0-9가-힣 ]", "", RegexOptions.Singleline);

        if (Input2_txt.text.Equals(Check) == true)
        {
            if (BD_Diamond >= Change_Value[Nickname_Change_Number])
            {
                string a = ((Input2_txt.text.Trim()).Replace(" ", ""));
                string b = ((Nickname.Trim()).Replace(" ", ""));
                if (!(a.Equals(b)))
                {
                    if (a.Length > 1)
                    {
                        PlayerPrefs.SetString("Nickname", a);
                        LanguageManager.instance.Success_Nickname_Notion();
                        SelectManager.instance.Exit();

                        int c = PlayerPrefs.GetInt("Tutorial");
                        if (c == 1) //튜토리얼 닉네임 설정
                        {
                            PlayerPrefs.SetInt("Tutorial", 2);
                            BD_Coin += 50000;
                            PlayerPrefs.SetInt("BD_Coin", BD_Coin);
                            BD_Diamond += 250;
                            PlayerPrefs.SetInt("BD_Diamond", BD_Diamond);
                        }
                    }
                    else
                    {
                        LanguageManager.instance.Low_Letter_Notion();
                    }
                }
                else
                {
                    LanguageManager.instance.Overlap_Nickname_Notion();
                }
            }
            else
            {
                LanguageManager.instance.Low_Diamond_Notion();
            }
        }
        else
        {
            LanguageManager.instance.Special_Text_Notion();
        }
    }
}
