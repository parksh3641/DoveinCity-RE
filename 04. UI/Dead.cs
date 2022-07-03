using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead : MonoBehaviour
{
    public int Value;

    public UILabel Main_txt;
    public UILabel Main_Number_txt;

    public GameObject Clear;
    public GameObject New;


    private int Dead_;

    private string[] Dead_Number = { "Hungry", "Crash", "Throw", "Accident", "Miss", "Kidnap","","",""};
    //배고픔, 충돌사고, 쳐맞아 사망, 교통사고, 의문사, 납치

    private List<string> Book_Dead = new List<string>();


    void Awake()
    {
        Clear.SetActive(false);
        New.SetActive(false);

        Main_Number_txt.text = (Value + 1).ToString();
    }

    public void Language_Setting()
    {
        if (Book_Dead.Count > 0)
        {
            Book_Dead.Clear();
        }
        int a = PlayerPrefs.GetInt("Language");
        switch (a)
        {
            case 1:
                for (int i = 0; i < LanguageManager.instance.Book_Dead_Korean.Length; i++)
                {
                    string b = LanguageManager.instance.Book_Dead_Korean[i];
                    Book_Dead.Add(b);
                }
                break;
            case 2:
                for (int i = 0; i < LanguageManager.instance.Book_Dead_English.Length; i++)
                {
                    string b = LanguageManager.instance.Book_Dead_English[i];
                    Book_Dead.Add(b);
                }
                break;
            case 3:
                for (int i = 0; i < LanguageManager.instance.Book_Dead_Chinese.Length; i++)
                {
                    string b = LanguageManager.instance.Book_Dead_Chinese[i];
                    Book_Dead.Add(b);
                }
                break;
            case 4:
                for (int i = 0; i < LanguageManager.instance.Book_Dead_Japanese.Length; i++)
                {
                    string b = LanguageManager.instance.Book_Dead_Japanese[i];
                    Book_Dead.Add(b);
                }
                break;
        }

        Main_txt.text = Book_Dead[Value];
    }

    void OnEnable()
    {
        Dead_ = PlayerPrefs.GetInt("Dead_" + Dead_Number[Value]);

        Clear_Check(Dead_);

        Language_Setting();
    }

    void OnDisable()
    {
        Alarm_Check();
    }

    void Clear_Check(int number)
    {
        if (number == 0)
        {
            Clear.SetActive(false);
        }
        else
        {
            Clear.SetActive(true);
            Alarm_Check();
        }
    }

    void Alarm_Check()
    {
        int a = PlayerPrefs.GetInt("Dead_Save_" + Value);
        if (a == 1)
        {
            New.SetActive(true);
            PlayerPrefs.SetInt("Dead_Save_" + Value, 2);
            AlarmManager.instance.Alarm_Minus_Book();
        }
        else
        {
            New.SetActive(false);
        }
    }

}
